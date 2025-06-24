using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class CouponUserRepository : GenericRepository<CouponUser>, ICouponUserRepository
    {
        private readonly storeDbContext _context;

        public CouponUserRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CouponUser>> GetCouponsByUserIdAsync(string userId)
        {
            return await _context.CouponUsers
                                  .Where(x => x.UserId == userId)
                                  .Include(c => c.Coupon)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<CouponUser>> GetValidCouponsForUserAsync(string userId)
        {
            return await _context.CouponUsers
                          .Where(cu => cu.UserId == userId && cu.Is_valid == true)
                          .Include(cu => cu.Coupon) 
                          .ToListAsync();
        }

    }
}
