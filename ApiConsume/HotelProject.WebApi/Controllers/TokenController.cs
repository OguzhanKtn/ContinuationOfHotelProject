using BusinessLayer.Abstract;
using DtoLayer.Dtos.LoginRequestDto;
using EntityLayer.Concrete;
using HotelProject.WebApi.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;

        public TokenController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Token(LoginRequestDto request)
        {
           var login = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (login.Succeeded)
            {
                return Ok(new CreateToken().TokenCreate());
            }        
            return Unauthorized();
        }
    }
}
