
using BlazorServerApp.Domain;
using BlazorServerApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp.BackgroundServices;

public class DashboardBackgroundService : BackgroundService
{
    private ILogger<DashboardBackgroundService> _logger;
    private readonly IHubContext<DashboardHub> hubContext;

    public DashboardBackgroundService(ILogger<DashboardBackgroundService> logger, IHubContext<DashboardHub> hubContext)
    {
        _logger = logger;
        this.hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var info = new Info(
                Random.Shared.Next(1, 100),
                Random.Shared.Next(10, 50),
                Random.Shared.Next(100, 300),
                Random.Shared.Next(0, 2) == 1);

            _logger.LogInformation("{UtcNow} {info}", DateTime.UtcNow, info.ToString());

            await hubContext.Clients.All.SendAsync("UpdateInfo", info);

            await Task.Delay(Random.Shared.Next(500, 2000));
        }

    }
}
