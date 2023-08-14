using Microsoft.AspNetCore.Mvc;

namespace WebChatApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
