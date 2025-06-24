using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.HelpQustionsService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpQuestionsController : ControllerBase
    {
        private readonly IHelpService _service;

        public HelpQuestionsController(IHelpService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllHelpQuestions")]
        public async Task<IActionResult> GetAllhelpQuestions()
             => Ok(await _service.GetAllhelpQuestionsAsync());

        [Cache(5)]
        [HttpGet("GetHelpQuestionsById")]
        public async Task<IActionResult> GethelpQuestionsByIdAsync(int Id)
             => Ok(await _service.GethelpQuestionsByIdAsync(Id));

        [HttpPost("CreateHelpQuestions")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> CreatehelpQuestionsAsync(helpQuestionsDto dto)
            => Ok(await _service.CreatehelpQuestionsAsync(dto));

        [HttpPut("UpdateHelpQuestions")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> UpdatehelpQuestionsAsync(int helpQuestionsId, helpQuestionsDto dto)
            => Ok(await _service.UpdatehelpQuestionsAsync(helpQuestionsId, dto));

        [HttpDelete("DeleteHelpQuestions")]
        [Authorize(Roles = "Admin,StoreOwner,Supporter,Customer,Guest")]
        public async Task<IActionResult> DeletehelpQuestionsAsync(int? id)
            => Ok(await _service.DeletehelpQuestionsAsync(id));
    }
}
