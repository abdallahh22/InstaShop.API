using Store.Data.Entities;
using Store.Services.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IStoreRepository : IGenericRepository<store>
    {
        Task<store> GetStoreWithRatingsAsync(int storeId);
        Task<PaginatedResult<store>> GetStoresPagedAsync(int pageNumber, int pageSize);
    }
}
