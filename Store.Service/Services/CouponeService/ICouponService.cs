using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.CouponeService
{
    public interface ICouponService
    {
        Task<CouponDto> CreateCouponAsync(CouponDto CouponDto);
        Task<CouponDto> UpdateCouponAsync(int? id, CouponDto CouponDto);
        Task<CouponDto> DeleteCouponAsync(int? Id);
        Task<CouponDto> GetCouponByIdAsync(int? Id);
        Task<IEnumerable<CouponDto>> GetAllCouponAsync();
        Task<bool> IsCouponValidAsync(int couponId);
        Task<IEnumerable<CouponDto>> GetCouponsByStoreIdAsync(int storeId);
        Task<IEnumerable<CouponDto>> SearchCouponsByNameAsync(string name);
    }
}
