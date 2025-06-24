using Store.Services.Mapping.Dto_s;
using Store.Services.Paginations;

namespace Store.Services.Services.ProductService
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(int? id, ProductDto productDto);
        Task<ProductDto> DeleteProductAsync(int? Id);
        Task<ProductDto> GetProductByIdAsync(int? Id);
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<PaginatedResult<ProductDto>> GetSProductsPagedAsync(int pageNumber, int pageSize);
        Task<List<ProductDto>> SearchProductsAsync(string Keyword);
        

    }
}
