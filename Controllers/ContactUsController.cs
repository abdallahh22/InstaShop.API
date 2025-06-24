using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.IContactUsService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _service;

        public ContactUsController(IContactUsService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllContactUs")]
        public async Task<IActionResult> GetAllContactUs()
             => Ok(await _service.GetAllContactUsAsync());

        [Cache(5)]
        [HttpGet("GetContactUsById")]
        public async Task<IActionResult> GetContactUsByIdAsync(int Id)
             => Ok(await _service.GetContactUsByIdAsync(Id));

        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        [HttpPost("CreateContactUs")]
        public async Task<IActionResult> CreateContactUsAsync(ContactUsDto dto)
            => Ok(await _service.CreateContactUsAsync(dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateContactUs")]
        public async Task<IActionResult> UpdateContactUsAsync(int ContactUsId, ContactUsDto dto)
            => Ok(await _service.UpdateContactUsAsync(ContactUsId, dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpDelete("DeleteContactUs")]
        public async Task<IActionResult> DeleteContactUsAsync(int? id)
            => Ok(await _service.DeleteContactUsAsync(id));
    }
}
