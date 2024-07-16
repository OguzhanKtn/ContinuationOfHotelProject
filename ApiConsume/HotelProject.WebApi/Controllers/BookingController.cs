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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.GetByID(id);
            _bookingService.Delete(value);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.Update(booking);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
           var value = _bookingService.GetByID(id);
            return Ok(value);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }
    }
}
