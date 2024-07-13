using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        [Route("ErrorPage/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return View("Error401");
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error500");
                default:
                    return View("Error");
            }
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult Error403()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }
}
