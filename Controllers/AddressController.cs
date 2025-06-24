using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.AddressService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
             => Ok(await _service.GetAllAddressAsync());

        [Cache(5)]
        [HttpGet("GetAddressById")]
        public async Task<IActionResult> GetAddressByIdAsync(int Id)
             => Ok(await _service.GetAddressByIdAsync(Id));

        [HttpGet("GetAddressByUserId")]
        public async Task<IActionResult> GetAddressByUserId(string UserId)
          => Ok(await _service.GetAddressByUserId(UserId));

        [HttpPost("CreateAddress")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreateAddressAsync(AddressDto dto)
            => Ok(await _service.CreateAddressAsync(dto));

        [HttpPut("UpdateAddress")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateAddressAsync(int AddressId, AddressDto dto)
            => Ok(await _service.UpdateAddressAsync(AddressId, dto));

        [HttpDelete("DeleteAddress")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteAddressAsync(int? id)
            => Ok(await _service.DeleteAddressAsync(id));
    }
}
