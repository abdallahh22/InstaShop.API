using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.NotificationService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllNotifications")]
        public async Task<IActionResult> GetAllNotifications()
             => Ok(await _service.GetAllNotificationAsync());

        [Cache(5)]
        [HttpGet("GetNotificationById")]
        public async Task<IActionResult> GetNotificationByIdAsync(int Id)
             => Ok(await _service.GetNotificationByIdAsync(Id));

        [HttpPost("CreateNotification")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateNotificationAsync(NotificationDto dto)
            => Ok(await _service.CreateNotificationAsync(dto));

        [HttpPut("UpdateNotification")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateNotificationAsync(int NotificationId, NotificationDto dto)
            => Ok(await _service.UpdateNotificationAsync(NotificationId, dto));

        [HttpDelete("DeleteNotification")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteNotificationAsync(int? id)
            => Ok(await _service.DeleteNotificationAsync(id));
    }
}
