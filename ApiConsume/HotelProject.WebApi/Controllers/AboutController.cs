using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;
        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _AboutService.GetAll();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _AboutService.Insert(about);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _AboutService.GetByID(id);
            _AboutService.Delete(value);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _AboutService.Update(about);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
           var value = _AboutService.GetByID(id);
            return Ok(value);
        }
    }
}
