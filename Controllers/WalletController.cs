using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.WalletService;
using Store.Services.Services.WalletService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _service;

        public WalletController(IWalletService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllWallets")]
        public async Task<IActionResult> GetAllWallets()
            => Ok(await _service.GetAllWalletAsync());

        [Cache(5)]
        [HttpGet("GetWalletById")]
        public async Task<IActionResult> GetWalletByIdAsync(int Id)
            => Ok(await _service.GetWalletByIdAsync(Id));

        [Cache(5)]
        [HttpGet("GetWalletByUserId")]
        public async Task<IActionResult> GetWalletByUserIdAsync(string userId)
            => Ok(await _service.GetWalletByUserIdAsync(userId));

        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        [HttpPost("CreateWallet")]
        public async Task<IActionResult> CreateWalletAsync(WalletDto dto)
            => Ok(await _service.CreateWalletAsync(dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        [HttpPut("UpdateWallet")]
        public async Task<IActionResult> UpdateWalletAsync(int WalletId, WalletDto dto)
            => Ok(await _service.UpdateWalletAsync(WalletId, dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        [HttpDelete("DeleteWallet")]
        public async Task<IActionResult> DeleteWalletAsync(int? id)
            => Ok(await _service.DeleteWalletAsync(id));
    }
}
