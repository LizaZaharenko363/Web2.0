using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication9.Services.HealthCheck
{
    public class HealthCheckResponseWriter : IHealthCheckResponseWriter
    {
        public async Task WriteResponseAsync(HttpContext httpContext, HealthReport result)
        {
            var status = result.Status;

            httpContext.Response.StatusCode = status switch
            {
                HealthStatus.Healthy => StatusCodes.Status200OK,
                HealthStatus.Degraded => StatusCodes.Status503ServiceUnavailable,
                HealthStatus.Unhealthy => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status200OK,
            };

            await httpContext.Response.WriteAsJsonAsync(result);
        }
    }
}
