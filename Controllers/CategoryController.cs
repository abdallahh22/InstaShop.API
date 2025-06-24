using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Helpers;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.CategoryService;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

       
        [HttpGet("GetAllCategories")]
        [Cache(5)]
        public async Task<IActionResult> GetAllCatigoriesAsync()
            => Ok(await _service.GetAllCategoryAsync());


        [Cache(5)]
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetByIdAsync(int? id)
            => Ok(await _service.GetCategoryByIdAsync(id));

        [Cache(5)]
        [HttpGet("GetCategoryWithProductsById")]
        public async Task<IActionResult> GetCategoryWithProductsByIdAsync(int? categoryId)
            => Ok(await _service.GetCategoryWithProductsByIdAsync(categoryId)); 

        [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreatecategoryAsync(CategoryDto category)
            => Ok(await _service.CreateCategoryAsync(category));

       [Authorize(Roles = "Admin,StoreOwner,Supporter")]
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(int? id,CategoryDto category)
            => Ok(await _service.UpdateCategoryAsync(id,category));

        [Authorize(Roles = "Admin,StoreOwner")]
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int? id)
            => Ok(await _service.DeleteCategoryAsync(id));

    }
}
