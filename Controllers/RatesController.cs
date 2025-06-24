using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.RateService;
using Store.Services.Services.RateService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRateService _service;

        public RatesController(IRateService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRates")]
        public async Task<IActionResult> GetAllRates()
             => Ok(await _service.GetAllRateAsync());

        [Cache(5)]
        [HttpGet("GetRateById")]
        public async Task<IActionResult> GetRateByIdAsync(int Id)
             => Ok(await _service.GetRateByIdAsync(Id));

        [HttpGet("GetRateByUserId")]
        public async Task<IActionResult> GetRateByUserId(string UserId)
          => Ok(await _service.GetRatesByUserIdAsync(UserId));

        [HttpPost("CreateRate")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreateRateAsync(RateDto dto)
            => Ok(await _service.CreateRateAsync(dto));

        [HttpPut("UpdateRate")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateRateAsync(int RateId, RateDto dto)
            => Ok(await _service.UpdateRateAsync(RateId, dto));

        [HttpDelete("DeleteRate")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteRateAsync(int? id)
            => Ok(await _service.DeleteRateAsync(id));
    }
}
