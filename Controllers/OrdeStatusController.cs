using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.OrderStatusService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdeStatusController : ControllerBase
    {
        private readonly IOrdeStatusService _service;

        public OrdeStatusController(IOrdeStatusService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllOrderStatus")]
        public async Task<IActionResult> GetAllOrderStatusAsync()
             => Ok(await _service.GetAllOrderStatusAsync());

        [Cache(5)]
        [HttpGet("GetOrderStatusById")]
        public async Task<IActionResult> GetByIdAsync(int? id)
            => Ok(await _service.GetOrderStatusByIdAsync(id));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateOrderStatus")]
        public async Task<IActionResult> CreateOrderStatusAsync(OrderStatusDto OrderStatus)
            => Ok(await _service.CreateOrderStatusAsync(OrderStatus));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatusAsync(int? id, OrderStatusDto OrderStatus)
             => Ok(await _service.UpdateOrderStatusAsync(id, OrderStatus));

        [Authorize(Roles = "Admin,StoreOwner")]
        [HttpDelete("DeleteOrderStatus")]
        public async Task<IActionResult> DeleteOrderStatusAsync(int? id)
            => Ok(await _service.DeleteOrderStatusAsync(id));
    }
}
