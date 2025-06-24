using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.ProductService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [Cache(5)]
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
            => Ok(await _service.GetAllProductAsync());

        [Cache(5)]
        [HttpGet("GetProductById{Id}")]
        public async Task<IActionResult> GetProductById(int? Id)
            => Ok(await _service.GetProductByIdAsync(Id));

        [Cache(5)]
        [HttpGet("GetProductsWithPaginations")]
        public async Task<IActionResult> GetProductsPagedAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
           => Ok(await _service.GetSProductsPagedAsync(pageNumber, pageSize));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDto dto)
            => Ok(await _service.CreateProductAsync(dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int? id, ProductDto dto)
            => Ok(await _service.UpdateProductAsync(id, dto));

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int? id)
            => Ok(await _service.DeleteProductAsync(id));

        [HttpGet("search-Products")]
        public async Task<IActionResult> SearchProducts(string keyword)
            => Ok(await _service.SearchProductsAsync(keyword));


    }
}
