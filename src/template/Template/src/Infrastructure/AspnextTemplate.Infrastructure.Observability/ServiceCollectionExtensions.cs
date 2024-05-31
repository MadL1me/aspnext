using System.Reflection;
using AspnextTemplate.Domain.Observability;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace AspnextTemplate.Infrastructure.Observability;

public static class MetricsConstants
{
    public const string AppMeterName = "AspnextTemplate.Meter";
}

public record ObservabilityOptions(
    string Environment,
    string ServiceNamespace,
    string ServiceName,
    string OtlpEndpoint = "http://localhost:4317");

public static class ServiceCollectionExtensions
{
    public static OpenTelemetryBuilder AddObservability(this IServiceCollection services, ObservabilityOptions options)
    {
        var serviceVersion = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

        services.AddSingleton<IMetricsProvider, MetricsProvider>();
        services.AddSingleton(TracerProvider.Default.GetTracer(options.ServiceName));

        return services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(
                serviceName: options.ServiceName,
                serviceNamespace: options.ServiceNamespace,
                serviceVersion: serviceVersion,
                serviceInstanceId: Environment.MachineName
            ).AddAttributes(new Dictionary<string, object>
            {
                { "deployment.environment", options.Environment }
            }))
            .WithTracing(tracing => tracing
                .AddSource(options.ServiceName)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: options.ServiceName, serviceVersion: serviceVersion))
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opts =>
                {
                    opts.Endpoint = new Uri(options.OtlpEndpoint);
                }))
            .WithMetrics(metrics => metrics.AddAspNetCoreInstrumentation()
                .AddRuntimeInstrumentation()
                .AddMeter(MetricsConstants.AppMeterName)
                .AddPrometheusExporter()
            );
    }
}
