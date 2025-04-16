
namespace BlazorServerApp.BackgroundServices;

public class DashboardBackgroundService : BackgroundService
{
    private ILogger<DashboardBackgroundService> _logger;

    public DashboardBackgroundService(ILogger<DashboardBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Simulate some work
            Thread.Sleep(1000);

            _logger.LogInformation("Background service is running... {UtcNow}", DateTime.UtcNow);
        }
        return Task.CompletedTask;
    }
}
