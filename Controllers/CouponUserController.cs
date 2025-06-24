using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.CouponeService;
using Store.Services.Services.CouponUserUserService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponUserController : ControllerBase
    {
        private readonly ICouponUserService _service;

        public CouponUserController(ICouponUserService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllCouponUsers")]
        public async Task<IActionResult> GetAllCouponsAsync()
            => Ok(await _service.GetAllCouponUserAsync());

        [Cache(5)]
        [HttpGet("GetCouponUserById")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
            => Ok(await _service.GetCouponUserByIdAsync(id));

        [Cache(5)]
        [HttpGet("GetCouponsByUserId")]
        public async Task<IActionResult> GetCouponsByUserIdAsync(string userId)
            => Ok(await _service.GetCouponsByUserIdAsync(userId));

        [Cache(5)]
        [HttpGet("GetValidCouponsForUser")]
        public async Task<IActionResult> GetValidCouponsForUserAsync(string userId)
            => Ok(await _service.GetValidCouponsForUserAsync(userId));

        [HttpPost("CreateCouponUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateCouponUserAsync(CouponUserDto dto)
            => Ok(await _service.CreateCouponUserAsync(dto));

        [HttpPut("UpdateCouponUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateCouponAsync(int id, CouponUserDto dto)
            => Ok(await _service.UpdateCouponUserAsync(id, dto));

        [HttpDelete("DeleteCouponUser")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteCouponUSerAsync(int id)
            => Ok(await _service.DeleteCouponUserAsync(id));
    }
}
