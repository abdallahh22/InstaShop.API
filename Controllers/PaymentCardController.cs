using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.PaymentCardervice;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        private readonly IPaymentCardService _service;

        public PaymentCardController(IPaymentCardService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllPaymentCards")]
        public async Task<IActionResult> GetAllPaymentCards()
            => Ok(await _service.GetAllPaymentCardAsync());

        [Cache(5)]
        [HttpGet("GetPaymentCardById")]
        public async Task<IActionResult> GetPaymentCardByIdAsync(int Id)
            => Ok(await _service.GetPaymentCardByIdAsync(Id));

        [HttpGet("GetPaymentCardByUserIdAsync")]
        public async Task<IActionResult> GetPaymentCardByUserIdAsync(string appUserId)
            => Ok(await _service.GetPaymentCardByUserIdAsync(appUserId));

        [HttpPost("CreatePaymentCard")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreatePaymentCardAsync(PaymentCardDto dto)
            => Ok(await _service.CreatePaymentCardAsync(dto));

        [HttpPut("UpdatePaymentCard")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> UpdatePaymentCardAsync(int PaymentCardId, PaymentCardDto dto)
            => Ok(await _service.UpdatePaymentCardAsync(PaymentCardId, dto));

        [HttpDelete("DeletePaymentCard")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeletePaymentCardAsync(int? id)
            => Ok(await _service.DeletePaymentCardAsync(id));
    }
}
