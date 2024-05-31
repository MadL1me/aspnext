using System.Diagnostics;
using System.Diagnostics.Metrics;
using AspnextTemplate.Domain.Observability;

namespace AspnextTemplate.Infrastructure.Observability;

public class MetricsProvider : IMetricsProvider
{
    private readonly Counter<long> _testMetricCounter;

    public MetricsProvider(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MetricsConstants.AppMeterName);
        _testMetricCounter = meter.CreateCounter<long>("AspnextTemplate_test_counter");
    }

    public void IncTestMetric(long metricLabel)
    {
        _testMetricCounter.Add(1, new TagList
        {
            new("test_label", metricLabel),
        });
    }
}
