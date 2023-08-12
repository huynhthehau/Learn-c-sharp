using DemoAuth.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DemoAuth.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChatController : BaseController
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public ChatController(IHubContext<NotificationHub> notificationHub)
        {
            _hubContext = notificationHub;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
            return Ok();
        }
    }
}
