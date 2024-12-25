using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.RegisterDto;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto newUserDto)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = newUserDto.Name,
                Surname = newUserDto.Surname,
                Email = newUserDto.Mail,
                UserName = newUserDto.Username,
                City = newUserDto.City,
            };
            var result = await _userManager.CreateAsync(appUser,newUserDto.Password);
            if(result.Succeeded) 
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
