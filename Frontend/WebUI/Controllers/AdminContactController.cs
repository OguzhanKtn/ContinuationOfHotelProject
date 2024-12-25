using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebUI.Dtos.ContactDto;
using WebUI.Dtos.MessageDetailDto;
using WebUI.Dtos.SendMessageDto;

namespace WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        public async Task<IActionResult> Inbox()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:10881/InboxList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var contactCount = await GetContactCount();
                ViewBag.ContactCount = contactCount;
                ViewBag.SendMessageCount = await GetSendMessageCount();
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InboxByCategory(int id)
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"http://localhost:10881/InboxListByCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View("Inbox", values);
            }
            return View("Inbox");
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto sendMessageDto) 
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            sendMessageDto.SenderName = "admin";
            sendMessageDto.SenderEmail = "admin@mail.com";
            sendMessageDto.Date = DateTime.Parse(DateTime.Now.ToString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(sendMessageDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("http://localhost:10881/api/SendMessage", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View(); 
        }

        public async Task<IActionResult> SendBox()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:10881/api/SendMessage");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                var sendMessageCount = await GetSendMessageCount();
                ViewBag.SendMessageCount = sendMessageCount;
                var contactCount = await GetContactCount();
                ViewBag.ContactCount = contactCount;
                return View(values);
            }
            return View();
        }
       
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> InboxMessageDetails(int id)
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"http://localhost:10881/api/Contact/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<InboxMessageDetailDto>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> SendboxMessageDetails(int id)
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"http://localhost:10881/api/SendMessage/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SendboxMessageDetailDto>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<string> GetContactCount()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"http://localhost:10881/api/Contact/GetContactCount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<string>(jsonData);
                return value.ToString();
            }
            return null;
        }

        public async Task<string> GetSendMessageCount()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"http://localhost:10881/api/SendMessage/GetSendMessageCount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<string>(jsonData);
                return value.ToString();
            }
            return null;
        }
    }
}
