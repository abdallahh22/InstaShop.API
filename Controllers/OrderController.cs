using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.OrderService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrderAsync()
            => Ok(await _service.GetAllOrderAsync());

        [Cache(5)]
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderByIdAsync(int? id)
            => Ok(await _service.GetOrderByIdAsync(id));

        [HttpGet("GetOrdersByUserId")]
        public async Task<IActionResult> GetOrderByUserIdAsync(string userId)
           => Ok(await _service.GetOrderByUserIdAsync(userId));

        [Cache(5)]
        [HttpGet("GetOrderWithDetailes")]
        public async Task<IActionResult> GetOrderWithDetailesAsync(int? id)
            => Ok(await _service.GetOrderWithDetailesAsync(id));

        [Cache(5)]
        [HttpGet("GetOrderWithRatings")]
        public async Task<IActionResult> GetOrderWithRatingsAsync(int? id)
           => Ok(await _service.GetOrderWithRatingsAsync(id));

        [Cache(5)]
        [HttpGet("GetOrdersByDriver/{driverId}")]
        public async Task<IActionResult> GetOrdersByDriverAsync(int driverId)
        {
            try
            {
                var orders = await _service.GetOrdersByDriverAsync(driverId);
                return Ok(orders);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [Authorize(Roles = "StoreOwner,Customer")]
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(OrderDto dto)
             => Ok(await _service.CreateOrderAsync(dto));

        [Authorize(Roles = "StoreOwner,Customer")]
        [HttpPut("UpdateOrderById")]
        public async Task<IActionResult> UpdateOrderAsync(int? id, OrderDto dto)
            => Ok(await _service.UpdateOrderAsync(id, dto));

        [Authorize(Roles = "StoreOwner,Customer")]
        [HttpDelete("DeleteOrderwithItems")]
        public async Task<IActionResult> DeleteOrderwithItemsAsync(int? id)
            => Ok(await _service.DeleteOrderwithItemsAsync(id));

    }
}
