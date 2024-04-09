using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication9.Services.HealthCheck
{
    public interface IHealthCheckResponseWriter
    {
        Task WriteResponseAsync(HttpContext httpContext, HealthReport result);
    }
}
