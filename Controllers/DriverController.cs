using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.DeliveryService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDliveryService _driver;

        public DriverController(IDliveryService driver)
        {
            _driver = driver;
        }

        [Cache(5)]
        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAllDrivers()
            => Ok(await _driver.GetAllDriverAsync());

        [Cache(5)]
        [HttpGet("GetDriverById")]
        public async Task<IActionResult> GetDriverByIdAsync(int Id)
            => Ok(await _driver.GetDriverByIdAsync(Id));

        [HttpPost("CreateDriver")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateDriverAsync(DriverDto dto)
            => Ok(await _driver.CreateDriverAsync(dto));

        [HttpPut("UpdateDriverInfo")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateDriverAsync(int driverId, DriverDto dto)
            => Ok(await _driver.UpdateDriverAsync(driverId, dto));

        [HttpDelete("DeleteDriver")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteDriverAsync(int? id)
            => Ok(await _driver.DeleteDriverAsync(id));


    }
}
