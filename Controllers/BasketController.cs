using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.BasketService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }


        [HttpGet("GetAllBasket")]
        public async Task<IActionResult> GetAllBasket()
           => Ok(await _service.GetAllBasketAsync());

        [Cache(5)]
        [HttpGet("GetBasketById")]
        public async Task<IActionResult> GetBasketByIdAsync(int Id)
             => Ok(await _service.GetBasketByIdAsync(Id));

        [HttpGet("GetBasketByPlayerIdAsync")]
        public async Task<IActionResult> GetBasketByPlayerIdAsync(string playerId)
           => Ok(await _service.GetBasketByPlayerIdAsync(playerId));


        [HttpPost("CreateBasket")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreateBasketAsync(BasketDto dto)
            => Ok(await _service.CreateBasketAsync(dto));


        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        [HttpPost("AddProductToBasket")]
        public async Task<IActionResult> AddProductToBasketAsync(int productId, int quantity)
          => Ok(await _service.AddProductToBasketAsync(productId, quantity));

        [HttpPut("UpdateBasket")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateBasketAsync(int BasketId, BasketDto dto)
            => Ok(await _service.UpdateBasketAsync(BasketId, dto));

        [HttpDelete("DeleteBasket")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteBasketAsync(int? id)
            => Ok(await _service.DeleteBasketAsync(id));


        [HttpDelete("RemoveProductFromBasket")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> RemoveProductFromBasketAsync(int productId)
            => Ok(await _service.RemoveProductFromBasketAsync(productId));

        [HttpDelete("DeleteBasketByPlayerIdAsync")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteBasketByPlayerIdAsync(string playerId)
         => Ok(await _service.DeleteBasketByPlayerIdAsync(playerId));

        [HttpPost("proceed-to-checkout")]
        public async Task<IActionResult> ProceedToCheckout(string playerId)
        {
            try
            {
                var canProceed = await _service.CanProceedToCheckoutAsync(playerId);

                if (canProceed)
                {
                    return Ok(new { message = "Continue to next" });
                }
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Please SignIn to continue" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", details = ex.Message });
            }

            return BadRequest(new { message = "Can't Continue" });
        }

    }
}
