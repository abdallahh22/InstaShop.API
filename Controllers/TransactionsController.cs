using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.TransactionService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
            => Ok(await _service.GetAllTransactionAsync());

        [Cache(5)]
        [HttpGet("GetTransactionById")]
        public async Task<IActionResult> GetTransactionByIdAsync(int Id)
            => Ok(await _service.GetTransactionByIdAsync(Id));

        [HttpGet("GetTransactionsByCardId")]
        public async Task<IActionResult> GetTransactionsByCardIdAsync(int paymentCardId)
           => Ok(await _service.GetTransactionsByCardIdAsync(paymentCardId));

        [HttpGet("GetTransactionsByWalletId")]
        public async Task<IActionResult> GetTransactionsByWalletIdAsync(int walletId)
           => Ok(await _service.GetTransactionsByWalletIdAsync(walletId));

        [HttpPost("CreateTransaction")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreateTransactionAsync(TransactionsDto dto)
            => Ok(await _service.CreateTransactionAsync(dto));

        [HttpPut("UpdateTransaction")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> UpdateTransactionAsync(int TransactionId, TransactionsDto dto)
            => Ok(await _service.UpdateTransactionAsync(TransactionId, dto));

        [HttpDelete("DeleteTransaction")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeleteTransactionAsync(int? id)
            => Ok(await _service.DeleteTransactionAsync(id));
    }
}
