using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface ICouponUserRepository : IGenericRepository<CouponUser>
    {
        Task<IEnumerable<CouponUser>> GetCouponsByUserIdAsync(string userId);
        Task<IEnumerable<CouponUser>> GetValidCouponsForUserAsync(string userId);
    }
}
