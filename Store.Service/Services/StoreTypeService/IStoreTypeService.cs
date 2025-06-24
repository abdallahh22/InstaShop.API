using Store.Services.Mapping.Dto_s;

namespace Store.Services.Services.StoreTypeService
{
    public interface IStoreTypeService
    {
        Task<StoreTypeDto> CreateStoreTypeAsync(StoreTypeDto storeTypeDto);
        Task<StoreTypeDto> UpdateStoreTypeAsync(int? id, StoreTypeDto storeTypeDto);
        Task<StoreTypeDto> DeleteStoreTypeAsync(int? Id);
        Task<StoreTypeDto> GetStoreTypeByIdAsync(int? Id);
        Task<IEnumerable<StoreTypeDto>> GetAllStoreTypeAsync();
    }
}
