using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
