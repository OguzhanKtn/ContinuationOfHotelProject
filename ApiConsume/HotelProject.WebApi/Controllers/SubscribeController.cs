using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _SubscribeService.Insert(subscribe);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteSubscribe()
        {
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public IActionResult UpdateSubscribe()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribe()
        {
            return Ok();
        }
    }
}
