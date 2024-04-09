using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication9.Services.HealthCheck
{
    public class MySecondHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            var healthCheckResult = new HealthCheckResult(
                HealthStatus.Healthy,
                "The second health check is running smoothly.",
                null,
                null);

            return Task.FromResult(healthCheckResult);
        }
    }
}
