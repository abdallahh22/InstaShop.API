using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.MobileDto_s;

namespace Store.Services.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryDto CategoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int? id, CategoryDto CategoryDto);
        Task<CategoryDto> DeleteCategoryAsync(int? Id);
        Task<CategoryDto> GetCategoryByIdAsync(int? Id);
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetCategoryWithProductsByIdAsync(int? Id);
        
    }
}
