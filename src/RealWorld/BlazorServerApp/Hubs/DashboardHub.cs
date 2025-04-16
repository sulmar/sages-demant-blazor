using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp.Hubs;

public class DashboardHub : Hub
{
    private readonly ILogger<DashboardHub> _logger;

    public DashboardHub(ILogger<DashboardHub> logger)
    {
        _logger = logger;
    }

    override public Task OnConnectedAsync()
    {
        // zła praktyka!
        // Console.WriteLine(Context.ConnectionId);

        // zła praktyka!
        // _logger.LogInformation($"Client connected: {Context.ConnectionId}");

        // dobra praktyka!
        _logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);

        return base.OnConnectedAsync();
    }

    override public Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }
}
