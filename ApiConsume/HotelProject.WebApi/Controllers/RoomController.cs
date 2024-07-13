using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.RoomDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.GetAll();
            return Ok(values);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddRoom(AddRoomDto roomDto) 
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomDto);
            _roomService.Insert(values);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var value = _roomService.GetByID(id);
            _roomService.Delete(value);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto roomDto) 
        { 
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomDto);
            _roomService.Update(values);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id) 
        {
            var value = _roomService.GetByID(id);
            return Ok(value);
        }
    }
}
