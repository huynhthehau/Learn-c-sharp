using DemoApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace DemoApi.Hubs
{
    public class SignalHub : Hub
    {
        public async Task BroadcastEmployee(Employee employee)
        {
            await Clients.All.SendAsync("ReceiveEmployee", employee);
        }
        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
