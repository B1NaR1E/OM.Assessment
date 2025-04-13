using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OM.Assessment.API.Configs;

namespace OM.Assessment.API.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        var swaggerSettings = configuration.GetSection(nameof(SwaggerSettings))
            .Get<SwaggerSettings>();
		
        if (swaggerSettings is null)
            return services;

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo
            {
                Version = swaggerSettings.Version,
                Title = swaggerSettings.Title,
                Description = swaggerSettings.Description,
                Contact = new OpenApiContact { Name = "Sidney Roth", Email = "sidneyroth.sr@gmail.com" }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app,
        IConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        var swaggerSettings = configuration.GetSection(nameof(SwaggerSettings))
            .Get<SwaggerSettings>();
        
        if (swaggerSettings is null)
            return app;

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/{swaggerSettings.Version}/swagger.json", swaggerSettings.Title);
        });

        return app;
    }
}