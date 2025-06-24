using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.CouponUserUserService
{
    public interface ICouponUserService
    {
        Task<CouponUserDto> CreateCouponUserAsync(CouponUserDto CouponUserDto);
        Task<CouponUserDto> UpdateCouponUserAsync(int? id, CouponUserDto CouponUserDto);
        Task<CouponUserDto> DeleteCouponUserAsync(int? Id);
        Task<CouponUserDto> GetCouponUserByIdAsync(int? Id);
        Task<IEnumerable<CouponUserDto>> GetAllCouponUserAsync();
        Task<IEnumerable<CouponUserDto>> GetCouponsByUserIdAsync(string userId);
        Task<IEnumerable<CouponUserDto>> GetValidCouponsForUserAsync(string userId);
    }
}
