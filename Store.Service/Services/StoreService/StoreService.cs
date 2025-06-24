using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.API.Helpers;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using Store.Services.Paginations;
using System.Reflection.Metadata;

namespace Store.Services.Services.StoreService
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly storeDbContext _context;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper, storeDbContext context )
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
            _context = context;
        }
        public async Task<StoreDto> CreateStoreAsync(StoreDto storeDto)
        {
            if (storeDto is null)
                throw new ArgumentNullException(nameof(storeDto), "Store cannot be null.");
            try
            {
                var store = _mapper.Map<store>(storeDto);
                store.Image_path = UploadFiles.UploadFile(storeDto.Image, "Images");
                await _unitOfWork.Stores.AddAsync(store);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreDto>(store);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<StoreDto> DeleteStoreAsync(int? Id)
        {
            try
            {
                var store = await _unitOfWork.Stores.GetByIdAsync(Id);
                if (store is null)
                    throw new Exception("Not Found");
                await _unitOfWork.Stores.DeleteAsync(store);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreDto>(store);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<StoreDto>> GetAllStoreAsync()
        {
           var store = await _unitOfWork.Stores.GetAllAsync();
             var storeDto = _mapper.Map<IEnumerable<StoreDto>>(store);
           return storeDto;

        }

        public async Task<StoreDto> GetStoreByIdAsync(int? Id)
        {
            try
            {
                var store = await _context.Stores
                     .Include(s => s.Rates)
                     .FirstOrDefaultAsync(s => s.Id == Id);

                if (store == null)
                    return null;

                var storeDto = _mapper.Map<StoreDto>(store);

                storeDto.Rates = store.Rates.Select(r => new RateDto
                {
                    Rating = r.Rating ?? 0,
                    Comment = r.comment
                }).ToList();

                return storeDto;
            }
            catch (Exception ex)
            {

                throw new Exception("Store Not Found", ex);
            }
        }

        public async Task<StoreDto> UpdateStoreAsync(int? id,StoreDto storeDto)
        {
            if (storeDto == null)
                throw new ArgumentNullException(nameof(storeDto), "StoreDto cannot be null.");
            try
            {
                var store = await _unitOfWork.Stores.GetByIdAsync(id);
                if (store == null)
                    throw new Exception($"Store with Id {id} not found.");
                _mapper.Map(storeDto, store);
                await _unitOfWork.Stores.UpdateAsync(store);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreDto>(store);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Not Found", ex);
            }

        }

        public async Task<PaginatedResult<StoreDto>> GetStoresPagedAsync(int? pageNumber, int? pageSize)
        {
            if (!pageNumber.HasValue || !pageSize.HasValue)
                throw new ArgumentException("Page number and page size must be provided.");
            try
            {
                var paginatedResult = await _unitOfWork.Stores.GetStoresPagedAsync(pageNumber.Value, pageSize.Value);

                var pagedResultDto = new PaginatedResult<StoreDto>
                {
                    TotalCount = paginatedResult.TotalCount,
                    Items = _mapper.Map<List<StoreDto>>(paginatedResult.Items)
                };

                return pagedResultDto;
            }
            catch (Exception ex)
            {

                throw new Exception("Store Not Found", ex);
            }
            
        }

        public async Task<StoreDto> GetStoreWithRatingsAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentException("Store Id cannot be null.");

            try
            {
                var storeEntity = await _unitOfWork.Stores.GetStoreWithRatingsAsync(Id.Value);
                if (storeEntity == null)
                    throw new KeyNotFoundException("Store with Ratings not found.");
                var storeDto = _mapper.Map<StoreDto>(storeEntity);
                return storeDto;
            }
            catch (Exception ex)
            {

                throw new Exception("Store Rate Not Found", ex);
            }
        }

    }
}
