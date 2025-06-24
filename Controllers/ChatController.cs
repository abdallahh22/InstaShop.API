using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.IChatService;
using Store.Services.Services.IChatService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController : ControllerBase
    {
        private readonly IChatService _service;

        public ChatController(IChatService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllChat")]
        public async Task<IActionResult> GetAllChat()
             => Ok(await _service.GetAllChatAsync());

        [Cache(5)]
        [HttpGet("GetChatById")]
        public async Task<IActionResult> GetChatByIdAsync(int Id)
             => Ok(await _service.GetChatByIdAsync(Id));

        [HttpPost("CreateChat")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreateChatAsync(ChatDto dto)
            => Ok(await _service.CreateChatAsync(dto));

        [HttpPut("UpdateChat")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateChatAsync(int ChatId, ChatDto dto)
            => Ok(await _service.UpdateChatAsync(ChatId, dto));

        [HttpDelete("DeleteChat")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteChatAsync(int? id)
            => Ok(await _service.DeleteChatAsync(id));
    }
}
