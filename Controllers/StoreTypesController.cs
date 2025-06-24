using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.StoreTypeService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTypesController : ControllerBase
    {
        private readonly IStoreTypeService _service;

        public StoreTypesController(IStoreTypeService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllTypes")]
        public async Task<IActionResult> GetAllTypesAsync()
           => Ok(await _service.GetAllStoreTypeAsync());

        [Cache(5)]
        [HttpGet("GetStoreTypeById{Id}")]
        public async Task<IActionResult> GetTypeById(int? Id)
            => Ok(await _service.GetStoreTypeByIdAsync(Id));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateStoreType")]
        public async Task<IActionResult> CreateStoreType(StoreTypeDto dto)
            => Ok(await _service.CreateStoreTypeAsync(dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateStoreType")]
        public async Task<IActionResult> UpdateStoreType(int? id, StoreTypeDto dto)
             => Ok(await _service.UpdateStoreTypeAsync(id, dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpDelete("DeleteStoreType")]
        public async Task<IActionResult> DeleteStoreType(int? id)
            => Ok(await _service.DeleteStoreTypeAsync(id));
    }
}
