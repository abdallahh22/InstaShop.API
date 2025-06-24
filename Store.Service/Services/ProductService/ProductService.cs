using AutoMapper;
using Store.API.Helpers;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Services.Mapping.Dto_s;
using Store.Services.Paginations;

namespace Store.Services.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var product = _mapper.Map<Product>(productDto);
                product.Image_path = UploadFiles.UploadFile(productDto.Image, "Products");
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<ProductDto> DeleteProductAsync(int? Id)
        {
           if(Id is null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(Id);
                if (product == null)
                    throw new Exception("Product Not Found");
                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
           var product = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(Id);
                if (product == null)
                    throw new Exception("Id is Null");
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw new Exception("Product Not Found", ex);
            }
        }

        public async Task<PaginatedResult<ProductDto>> GetSProductsPagedAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                throw new ArgumentException("Page number and page size must be greater than zero.");

            try
            {
                var products = await _unitOfWork.Products
              .GetProductsPagedAsync(pageNumber, pageSize);

                var paginatedResult = new PaginatedResult<ProductDto>
                {
                    TotalCount = products.TotalCount,
                    Items = _mapper.Map<List<ProductDto>>(products.Items)
                };

                return paginatedResult;
            }
            catch (Exception ex)
            {

                throw new Exception("Products Not Found");
            }
        }

        public async Task<ProductDto> UpdateProductAsync(int? id, ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto), "StoreDto cannot be null.");
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                    throw new Exception($"Store with Id {id} not found.");
                _mapper.Map(productDto, product);
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed");
            }
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string Keyword)
        {
            var search = await _unitOfWork.Products.SearchProductsAsync(Keyword);
            return _mapper.Map<List<ProductDto>>(search);
        }

    }
}
