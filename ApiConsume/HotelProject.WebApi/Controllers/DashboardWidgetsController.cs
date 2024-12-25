using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;  
        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IRoomService roomService,IGuestService guestService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _roomService = roomService;
            _guestService = guestService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }

        [HttpGet("GuestCount")]
        public IActionResult GuestCount()
        {
            var value = _guestService.GetCount();
            return Ok(value);
        }
    }
}
