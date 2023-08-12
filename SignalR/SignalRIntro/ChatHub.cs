using Microsoft.AspNetCore.SignalR;

namespace SignalRIntro
{
    public sealed class ChatHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joned");
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
        }
    }
}
