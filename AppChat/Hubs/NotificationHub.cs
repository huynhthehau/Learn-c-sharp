using Microsoft.AspNetCore.SignalR;

namespace DemoAuth.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string user, string notification)
            => await Clients.All.SendAsync("ReceiveMessage", user, notification);
    }
}
