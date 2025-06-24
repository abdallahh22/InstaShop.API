using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.MobileDto_s;

namespace Store.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto CategoryDto)
        {
            if (CategoryDto is null)
                throw new ArgumentNullException(nameof(CategoryDto), "CategoryDto cannot be null");
            try
            {
                var category = new Category
              {
                    Name_Ar = CategoryDto.Name_Ar,
                    Name_En = CategoryDto.Name_En,
                    IsDeleted = CategoryDto.IsDeleted,
                    CreatedAt = DateTime.UtcNow, 
                    storeId = CategoryDto.StoreId
              };   
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "Category ID cannot be null.");
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(Id);
                if (category == null)
                    throw new Exception($"Category with ID {Id} not found.");
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {

                throw new Exception("Not Deleted", ex);
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
                var category = await _unitOfWork.Categories.GetAllAsync();
                return _mapper.Map<IEnumerable<CategoryDto>>(category);
        }

        

        public async Task<CategoryDto> GetCategoryByIdAsync(int? Id)
        {
            if (Id is null)
                throw new Exception("Category Id cannot be null");
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(Id);
                if (category is null)
                    throw new Exception("Not Found");
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryId Not Found", ex);
            }
        }

        public async Task<CategoryDto> GetCategoryWithProductsByIdAsync(int? Id)
        {
            if (Id is null)
                throw new Exception("Category Id cannot be null");
            try
            {
                var category = await _unitOfWork.Categories.GetCategoryWithProductsByIdAsync(Id);
                if (category is null)
                    throw new Exception("Not Found");
                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {

                throw new Exception("Not Found", ex);
            }
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int? id, CategoryDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(CategoryDto), "CategoryDto cannot be null.");

            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(id);
                if (category == null)
                    throw new Exception($"Category with Id {id} not found.");
                _mapper.Map(dto, category);
                await _unitOfWork.Categories.UpdateAsync(category);
                var mappedcategory = _mapper.Map<CategoryDto>(dto);
                return mappedcategory;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update category due to database issues.", ex);
            }

        }
    }
}
