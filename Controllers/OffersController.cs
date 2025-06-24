using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.OfferService;
using Store.Services.Services.OfferService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _service;

        public OffersController(IOfferService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllOffers")]
        public async Task<IActionResult> GetAllOffers()
            => Ok(await _service.GetAllOfferAsync());

        [Cache(5)]
        [HttpGet("GetOfferById")]
        public async Task<IActionResult> GetOfferByIdAsync(int Id)
            => Ok(await _service.GetOfferByIdAsync(Id));

        [HttpPost("CreateOffer")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> CreateOfferAsync(OfferDto dto)
            => Ok(await _service.CreateOfferAsync(dto));

        [HttpPut("UpdateOffer")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> UpdateOfferAsync(int OfferId, OfferDto dto)
            => Ok(await _service.UpdateOfferAsync(OfferId, dto));

        [HttpDelete("DeleteOffer")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        public async Task<IActionResult> DeleteOfferAsync(int? id)
            => Ok(await _service.DeleteOfferAsync(id));
    }
}
