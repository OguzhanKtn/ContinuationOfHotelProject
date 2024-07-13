using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesServices;

        public ServicesController(IServicesService servicesServices)
        {
            _servicesServices = servicesServices;
        }

        [HttpGet]
        public IActionResult ServicesList()
        {
            var values = _servicesServices.GetAll();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddServices(Services services)
        {
            _servicesServices.Insert(services);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteServices(int id)
        {
            var value = _servicesServices.GetByID(id);
            _servicesServices.Delete(value);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public IActionResult UpdateServices(Services services)
        {
            _servicesServices.Update(services);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetServices(int id)
        {
            var value = _servicesServices.GetByID(id);
            return Ok(value);
        }
    }
}
