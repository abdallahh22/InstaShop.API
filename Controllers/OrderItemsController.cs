using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.OrderItemService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllOrderItem")]
        public async Task<IActionResult> GetAllOrderItemAsync()
            => Ok(await _service.GetAllOrderItemAsync());

        [Cache(5)]
        [HttpGet("GetOrderItemDetailes")]
        public async Task<IActionResult> GetOrderItemWithDetailesAsync(int? itemId)
            => Ok(await _service.GetOrderItemWithDetailesAsync(itemId));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateOrderItem")]
        public async Task<IActionResult> CreateOrderItemAsync(OrderItemsDto dto)
            => Ok(await _service.CreateOrderItemAsync(dto));

        [Cache(5)]
        [HttpGet("GetOrderItemById")]
        public async Task<IActionResult> GetOrderItemByIdAsync(int? id)
            => Ok(await _service.GetOrderItemByIdAsync(id));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateOrderItem")]
        public async Task<IActionResult> UpdateOrderItemAsync(int? id, OrderItemsDto dto)
            => Ok(await _service.UpdateOrderItemAsync(id, dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpDelete("DeleteOrderItem")]
        public async Task<IActionResult> DeleteOrderItemAsync(int? id)
            => Ok(await _service.DeleteOrderItemAsync(id));


    }
}
