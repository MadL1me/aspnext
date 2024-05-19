using Microsoft.OpenApi.Models;

namespace AspnextTemplate.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspnextTemplate", Version = "v1" });

#if (AddZitadelAuth)
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "Access Token (PAN or JWT)"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
#endif
        });

        services.AddEndpointsApiExplorer();

        return services;
    }
}
