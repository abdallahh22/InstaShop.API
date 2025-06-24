using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface ICouponRepository : IGenericRepository<Coupon>
    {
        Task<bool> IsCouponValidAsync(int couponId); 
        Task<IEnumerable<Coupon>> GetCouponsByStoreIdAsync(int storeId);
        Task<IEnumerable<Coupon>> SearchCouponsByNameAsync(string name);
    }
}
