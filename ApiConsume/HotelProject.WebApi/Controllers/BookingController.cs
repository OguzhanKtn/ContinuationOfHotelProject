using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
       
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {    
            _bookingService.Insert(booking);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.GetByID(id);
            _bookingService.Delete(value);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.Update(booking);
            return Ok();
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
           var value = _bookingService.GetByID(id);
            return Ok(value);
        }
    }
}
