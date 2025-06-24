using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.CouponeService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CouponController : ControllerBase
    {
        private readonly ICouponService _service;

        public CouponController(ICouponService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllCoupons")]
        public async Task<IActionResult> GetAllCouponsAsync()
            => Ok(await _service.GetAllCouponAsync());

        [Cache(5)]
        [HttpGet("GetCouponById")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
            => Ok(await _service.GetCouponByIdAsync(id));

        [Cache(5)]
        [HttpGet("GetCouponsByStoreId")]
        public async Task<IActionResult> GetCouponsByStoreIdAsync(int StoreId)
            => Ok(await _service.GetCouponsByStoreIdAsync(StoreId));

        [HttpGet("IsCouponValid")]
        public async Task<IActionResult> IsCouponValidAsync(int id)
            => Ok(await _service.IsCouponValidAsync(id));

        [HttpGet("SearchCouponsByName")]
        public async Task<IActionResult> SearchCouponsByNameAsync(string name)
            => Ok(await _service.SearchCouponsByNameAsync(name));

        [HttpPost("CreateCoupon")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateCouponAsync(CouponDto dto)
            => Ok(await _service.CreateCouponAsync(dto));

        [HttpPut("UpdateCoupon")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateCouponAsync(int id, CouponDto dto)
            => Ok(await _service.UpdateCouponAsync(id, dto));

        [HttpDelete("DeleteCoupon")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteCouponAsync(int id)
            => Ok(await _service.DeleteCouponAsync(id));


    }
}
