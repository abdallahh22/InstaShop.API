using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services.DashBoradService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoradController : ControllerBase
    {
        private readonly IDashBoardService _service;

        public DashBoradController(IDashBoardService service)
        {
           _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
            => Ok(await _service.GetDashboardDataAsync());  
    }
}
