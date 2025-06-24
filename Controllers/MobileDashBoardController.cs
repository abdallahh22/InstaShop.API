using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Services.Mapping.Dto_s.MobileDto_s;
using Store.Services.Services.DashBoradService;
using Store.Services.Services.InstaShopDashboard;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MobileDashBoardController : ControllerBase
    {
        private readonly IInstaDashboardService _service;
        private readonly UserManager<AppUser> _userManager;
        

        public MobileDashBoardController(IInstaDashboardService service, 
            UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
           
        }

        [HttpGet("GetInstaDashboardDataAsync")]
        public async Task<IActionResult> GetInstaDashboardDataAsync()
            => Ok(await _service.GetInstaDashboardDataAsync());

        [HttpGet("GetInstaShopStores")]
        public async Task<IActionResult> GetInstaShopStores()
            => Ok(await _service.GetInstaShopStores());


        [HttpGet("GetDriversandStoresUsersInfoAsync")]
        public async Task<IActionResult> GetUsersInfoDtoDataAsync()
        {
            var (driverUsers, storeUsers) = await _service.GetUsersInfoDtoDataAsync();

            return Ok(new
            {
                DriverUsers = driverUsers,
                StoreUsers = storeUsers
            });
        }

        [HttpGet("GetCategoriesByStoreIdAsync")]
        public async Task<IActionResult> GetCategoriesByStoreIdAsync(int storeId)
          => Ok(await _service.GetCategoriesByStoreIdAsync(storeId));

        [HttpGet("OrdersStatus")]
        public async Task<IActionResult> GetUserOrdersAsync(string userId)
          => Ok(await _service.GetUserOrdersAsync(userId));

        [HttpPost("add-message")]
        public async Task<IActionResult> AddContactMessage([FromBody] ContactMessageDto contactMessageDto)
        {
            if (string.IsNullOrEmpty(contactMessageDto.Message))
            {
                return BadRequest("The message field is required.");
            }

            await _service.AddContactMessageAsync(contactMessageDto);
            return Ok(new { Message = " Sent message successfully." });
        }

        [HttpGet("GetUserInfoByUserIdAsync")]
        public async Task<IActionResult> GetUserInfoByUserIdAsync(string userId)
         => Ok(await _service.GetUserInfoByUserIdAsync(userId));
    }
}
