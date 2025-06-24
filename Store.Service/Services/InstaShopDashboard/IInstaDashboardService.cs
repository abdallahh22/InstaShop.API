using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.MobileDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.InstaShopDashboard
{
    public interface IInstaDashboardService
    {
        Task<InstaShopDashboardDto> GetInstaDashboardDataAsync();
        Task<List<GetAllStoresDto>> GetInstaShopStores();
        Task AddContactMessageAsync(ContactMessageDto contactMessageDto);
        Task<List<CategoriesDto>> GetCategoriesByStoreIdAsync(int storeId);
        Task<(List<UsersInfoDto> DriverUsers, List<UsersInfoDto> StoreUsers)> GetUsersInfoDtoDataAsync();
        Task<List<OrderDetailesDto>> GetUserOrdersAsync(string userId);
        Task<UsersInfoDto> GetUserInfoByUserIdAsync(string userId);

    }
}
