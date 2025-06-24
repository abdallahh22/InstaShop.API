using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Store.Services.Services.CouponeService
{
    public class CouponService : ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouponService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CouponDto> CreateCouponAsync(CouponDto CouponDto)
        {
            if (CouponDto == null)
                throw new ArgumentNullException(nameof(CouponDto));
            try
            {
                var coupon = _mapper.Map<Coupon>(CouponDto);
                await _unitOfWork.Coupons.AddAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }


        public async Task<CouponDto> DeleteCouponAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "Coupon Id cannot be null.");
            try
            {
                var coupon = await _unitOfWork.Coupons.GetByIdAsync(Id);
                if (coupon is null)
                    throw new ArgumentException($"Coupon with Id {Id} not found.");
                await _unitOfWork.Coupons.DeleteAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<CouponDto>> GetAllCouponAsync()
        {
            var coupon = await _unitOfWork.Coupons.GetAllAsync();
            return _mapper.Map<IEnumerable<CouponDto>>(coupon);
        }

        public async Task<CouponDto> GetCouponByIdAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "Coupon ID cannot be null.");
            try
            {
                var coupon = await _unitOfWork.Coupons.GetByIdAsync(Id);
                if (coupon is null)
                    throw new ArgumentException("Coupon Not Found");
                return _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Coupon Id Not Found", ex);
            } 
        }

        public async Task<IEnumerable<CouponDto>> GetCouponsByStoreIdAsync(int storeId)
        {
            if (storeId == null)
                    throw new ArgumentNullException("storeId Is Null");
                try
                {
                    var coupon = await _unitOfWork.Coupons.GetCouponsByStoreIdAsync(storeId);
                    return _mapper.Map<IEnumerable<CouponDto>>(coupon);
                }
                catch (Exception ex)
                {

                    throw new Exception("Not Found", ex);
                }
        }

        public async Task<bool> IsCouponValidAsync(int couponId)
        {
            if (couponId == null)
                throw new Exception("Id is Null");
            var coupon = await _unitOfWork.Coupons.IsCouponValidAsync(couponId);
            return coupon;
        }
        
        public async Task<IEnumerable<CouponDto>> SearchCouponsByNameAsync(string name)
        {
          var coupon = await _unitOfWork.Coupons.SearchCouponsByNameAsync(name);
            return _mapper.Map<IEnumerable<CouponDto>>(coupon);
        }


        public async Task<CouponDto> UpdateCouponAsync(int? id, CouponDto CouponDto)
        {
            if (CouponDto is null)
                throw new ArgumentNullException(nameof(CouponDto), "CouponDto cannot be null.");
            try
            {
                var coupon = await _unitOfWork.Coupons.GetByIdAsync(id);
                if (coupon is null)
                    throw new Exception("Coupon Not Found");
                _mapper.Map(CouponDto, coupon);
                await _unitOfWork.Coupons.UpdateAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to update Coupon due to database issues.", ex);
            }
        }
    }
}



