﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendService;

        public SendMessageController(ISendMessageService sendService)
        {
            _sendService = sendService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendService.GetAll();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _sendService.GetByID(id);
            return Ok(value);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendService.Insert(sendMessage);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var value = _sendService.GetByID(id);
            _sendService.Delete(value);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendService.Update(sendMessage);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendService.GetSendMessageCount());
        }
    }
}
