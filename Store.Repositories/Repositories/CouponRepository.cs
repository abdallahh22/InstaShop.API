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
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        private readonly storeDbContext _context;

        public CouponRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> GetCouponsByStoreIdAsync(int storeId)
        {
            return await _context.Coupons
                                  .Where(c => c.StoreId == storeId && c.Is_Deleted == false)
                                  .ToListAsync();
        }

        public async Task<bool> IsCouponValidAsync(int couponId)
        {
            return await _context.Coupons.AnyAsync(c => c.Id == couponId && c.Is_Valied == true && c.Is_Deleted == false);
        }

        public async Task<IEnumerable<Coupon>> SearchCouponsByNameAsync(string name)
        {
            return await _context.Coupons
                                  .Where(c => c.Coupone_Name.Contains(name) && c.Is_Deleted == false)
                                  .ToListAsync();
        }
    }
}
