using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
