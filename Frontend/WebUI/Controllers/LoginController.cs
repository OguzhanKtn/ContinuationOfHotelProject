using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using WebUI.Dtos.LoginDto;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto dto)
        {
            if (ModelState.IsValid)
            {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(dto);
                    StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
                    var response = await client.PostAsync("http://localhost:10881/api/Token",stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var token = await response.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("AuthToken", token);
                        var token2 = HttpContext.Session.GetString("AuthToken");
                        return RedirectToAction("Index", "Staff");
                    }
                else
                {
                    ModelState.AddModelError(string.Empty, "Giriş başarısız. Lütfen tekrar deneyin.");
                }
            }
            return View();
        }
      }
    }
