using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Authorize]
        [HttpGet]
        [Route("/InboxList")]
        public IActionResult InboxListContact()
        {
            try
            {
                var values = _contactService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpGet]
        [Route("/InboxListByCategory/{id}")]
        public IActionResult InboxListByCategory(int id)
        {
            try
            {
                var values = _contactService.messageListByCategory(id);
                return Ok(values);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult MessageDetail(int id)
        {
            var value = _contactService.GetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact) 
        { 
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.Insert(contact);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return Ok(_contactService.GetContactCount());
        }
    }
}
