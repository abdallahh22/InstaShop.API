using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.StoreService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }


        [Cache(5)]
        [HttpGet("GetAllStores")]
        public async Task<IActionResult> GetAllStoresAsync()
          => Ok(await _service.GetAllStoreAsync());

        [Cache(5)]
        [HttpGet("GetStoreById")]
        public async Task<IActionResult> GetStoreById(int? id)
            => Ok(await _service.GetStoreByIdAsync(id));

        [Cache(5)]
        [HttpGet("GetStoreWithRatings")]
        public async Task<IActionResult> GetStoreWithRatingsAsync(int? id)
            => Ok(await _service.GetStoreWithRatingsAsync(id));


        [Cache(5)]
        [HttpGet("GetStoresWithPaginations")]
        public async Task<IActionResult> GetStoresPagedAsync([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
            => Ok(await _service.GetStoresPagedAsync(pageNumber, pageSize));


        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreateStoreAsync(StoreDto storeDto)
           => Ok(await _service.CreateStoreAsync(storeDto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateStore")]
        public async Task<IActionResult> UpdateStoreAsync(int? id, [FromBody] StoreDto storeDto)
            => Ok(await _service.UpdateStoreAsync(id, storeDto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpDelete("DeleteStore")]
        public async Task<IActionResult> DeleteStoreAsync(int? id)
            => Ok(await _service.DeleteStoreAsync(id));
    }
}
