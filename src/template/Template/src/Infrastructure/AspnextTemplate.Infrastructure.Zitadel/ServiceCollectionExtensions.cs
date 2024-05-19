using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zitadel.Extensions;

namespace AspnextTemplate.Infrastructure.Zitadel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddZitadelAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var authConfig = configuration.GetSection(nameof(ZitadelConfiguration)).Get<ZitadelConfiguration>();

        if (authConfig is null)
        {
            throw new ApplicationException("Auth configuration cannot be null: " +
                                           "Setup ZitadelConfiguration section with required data");
        }

        services.AddSingleton<IAuthorizationHandler, ZitadelRoleHandler>();

        services
            .AddAuthorization(options =>
            {
                options.AddPolicy("ZitadelRolePolicy", policy =>
                    policy.Requirements.Add(new HasZitadelRoleRequirement("test")));
            })
            .AddAuthentication(o => { })
            .AddZitadelIntrospection(
                AuthConstants.Schema,
                o =>
                {
                    o.Authority = authConfig.ZitadelHostUrl;
                    o.ClientId = authConfig.ClientId;
                    o.ClientSecret = authConfig.ClientSecret;
                    o.EnableCaching = false;
                    o.Validate();
                });

        return services;
    }
}
