using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.NotificationUserService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationUserController : ControllerBase
    {
        private readonly INotificationUserService _service;

        public NotificationUserController(INotificationUserService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllNotificationUsers")]
        public async Task<IActionResult> GetAllNotificationUsers()
            => Ok(await _service.GetAllNotificationUserAsync());

        [Cache(5)]
        [HttpGet("GetNotificationUserById")]
        public async Task<IActionResult> GetNotificationUserByIdAsync(int Id)
            => Ok(await _service.GetNotificationUserByIdAsync(Id));

        [HttpPost("CreateNotificationUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateNotificationUserAsync(NotificationUserDto dto)
            => Ok(await _service.CreateNotificationUserAsync(dto));

        [HttpPut("UpdateNotificationUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateNotificationUserAsync(int NotificationUserId, NotificationUserDto dto)
            => Ok(await _service.UpdateNotificationUserAsync(NotificationUserId, dto));

        [HttpDelete("DeleteNotificationUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteNotificationUserAsync(int? id)
            => Ok(await _service.DeleteNotificationUserAsync(id));
    }
}
