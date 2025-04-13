using Microsoft.AspNetCore.Builder;

namespace OM.Assessment.API.Extensions;

public static class HealthCheckExtension
{
    public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
        });

        return app;
    }
}