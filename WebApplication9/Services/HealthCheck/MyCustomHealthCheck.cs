using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication9.Services.HealthCheck
{
    public class MyCustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true; 
            if (isHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("The first check is running smoothly."));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("The first check is not healthy."));
            }
        }
    }
}
