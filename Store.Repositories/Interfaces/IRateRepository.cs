using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IRateRepository:IGenericRepository<Rate>
    {
        Task<Rate> GetHighestRateByStoreIdAsync(int rateId);
        Task<IEnumerable<Rate>> GetAllRatesWithHighestMarkedAsync(int rateId);
        Task<IEnumerable<Rate>> GetRatesByUserIdAsync(string userId);
    }
}
