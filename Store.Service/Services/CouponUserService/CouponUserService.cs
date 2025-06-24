using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.CouponUserUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Store.Services.Services.CouponUserService
{
    public class CouponUserService : ICouponUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouponUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CouponUserDto> CreateCouponUserAsync(CouponUserDto CouponUserDto)
        {
            if (CouponUserDto == null)
                throw new ArgumentNullException(nameof(CouponUserDto));
            try
            {
                var coupon = _mapper.Map<CouponUser>(CouponUserDto);
                await _unitOfWork.couponUsers.AddAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponUserDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed");
            }
        }

        public async Task<CouponUserDto> DeleteCouponUserAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "CouponUser Id cannot be null.");
            try
            {
                var coupon = await _unitOfWork.couponUsers.GetByIdAsync(Id);
                if (coupon is null)
                    throw new ArgumentException($"CouponUser with Id {Id} not found.");
                await _unitOfWork.couponUsers.DeleteAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponUserDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed",ex);
            }
        }

        public async Task<IEnumerable<CouponUserDto>> GetAllCouponUserAsync()
        {
            var coupon = await _unitOfWork.couponUsers.GetAllAsync();
            return _mapper.Map<IEnumerable<CouponUserDto>>(coupon);
        }

        public async Task<IEnumerable<CouponUserDto>> GetCouponsByUserIdAsync(string userId)
        {
            if (userId == null)
                throw new Exception("Id Not Found");
            var coupon = await _unitOfWork.couponUsers.GetCouponsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<CouponUserDto>>(coupon);
        }

        public async Task<CouponUserDto> GetCouponUserByIdAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "CouponUser Id cannot be null.");
            try
            {
                var coupon = await _unitOfWork.couponUsers.GetByIdAsync(Id);
                if (coupon is null)
                    throw new ArgumentException("CouponUser Not Found");
                return _mapper.Map<CouponUserDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Not Found");
            }
        }

        public async Task<IEnumerable<CouponUserDto>> GetValidCouponsForUserAsync(string userId)
        {
            if (userId == null)
                throw new Exception("UserId Not Found");
            var coupon = await _unitOfWork.couponUsers.GetValidCouponsForUserAsync(userId);
            return _mapper.Map<IEnumerable<CouponUserDto>>(coupon);
        }

        public async Task<CouponUserDto> UpdateCouponUserAsync(int? id, CouponUserDto CouponUserDto)
        {
            if (CouponUserDto is null)
                throw new ArgumentNullException(nameof(CouponUserDto), "CouponUserDto cannot be null.");
            try
            {
                var coupon = await _unitOfWork.couponUsers.GetByIdAsync(id);
                if (coupon is null)
                    throw new Exception("CouponUser Not Found");
                _mapper.Map(CouponUserDto, coupon);
                await _unitOfWork.couponUsers.UpdateAsync(coupon);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<CouponUserDto>(coupon);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed");
            }
        }
    }
}
