using Store.Services.Mapping.Dto_s;
using Store.Services.Paginations;

namespace Store.Services.Services.StoreService
{
    public interface IStoreService
    {
        Task<StoreDto> CreateStoreAsync(StoreDto storeDto);
        Task<StoreDto> UpdateStoreAsync(int? id,StoreDto storeDto);
        Task<StoreDto> DeleteStoreAsync(int? Id);
        Task<StoreDto> GetStoreByIdAsync(int? Id);
        Task<IEnumerable<StoreDto>> GetAllStoreAsync();
        Task<StoreDto> GetStoreWithRatingsAsync(int? Id);
        Task<PaginatedResult<StoreDto>> GetStoresPagedAsync(int? pageNumber, int? pageSize);
    }
}
