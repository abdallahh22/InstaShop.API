using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services.SearchHistoryService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchHistoryService _service;

        public SearchController(ISearchHistoryService service)
        {
            _service = service;
        }

        [HttpGet("recent-search")]
        public async Task<IActionResult> GetRecentSearches([FromQuery] int count = 4)
        {
            var recentSearches = await _service.GetRecentSearchesAsync(count);
            return Ok(recentSearches);
        }

        [HttpPost("add-search")]
        public async Task<IActionResult> AddSearch([FromBody] string keyword)
        {
            await _service.AddSearchHistoryAsync(keyword);
            return Ok();
        }

        [HttpDelete("DeleteOldestSearch")]
        public async Task<IActionResult> DeleteOldestSearch()
        {
            await _service.DeleteOldestSearchAsync();
            return Ok();
        }

    }
}
