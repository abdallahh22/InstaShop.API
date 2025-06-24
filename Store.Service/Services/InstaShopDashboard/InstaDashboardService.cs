
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.MobileDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.InstaShopDashboard
{
    public class InstaDashboardService : IInstaDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly storeDbContext _context;

        public InstaDashboardService(IUnitOfWork unitOfWork,
            UserManager<AppUser> userManager,
            IMapper mapper,
            storeDbContext context)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddContactMessageAsync(ContactMessageDto contactMessageDto)
        {
            var contactUs = new ContactUs
            {
                Message = contactMessageDto.Message
            };
            await _unitOfWork.ContactUs.AddContactMessageAsync(contactUs);
        }

        public async Task<List<CategoriesDto>> GetCategoriesByStoreIdAsync(int storeId)
        {
            if (storeId == null)
                throw new Exception("Category Id cannot be null");
            try
            {
                var category = await _unitOfWork.Categories.GetCategoriesByStoreIdAsync(storeId);
                if (category is null)
                    throw new Exception("Not Found");
                return _mapper.Map<List<CategoriesDto>>(category);

            }
            catch (Exception ex)
            {

                throw new Exception("Not Found", ex);
            }
        }

        public async Task<InstaShopDashboardDto> GetInstaDashboardDataAsync()
        {
            var types = await _unitOfWork.StoreTypes.GetAllAsync();


            var uniqueStores = (await _unitOfWork.Stores.GetAllAsync())
                .Where(s => s.IsUniqueStore == true)
                .OrderBy(s => s.Name_Ar)
                .ThenBy(s => s.DeliveryTime)
               .Select(store => new MinimalUniqueStoreDto
               {
                   StoreName = store.Name_Ar,
                   DeliveryTime = store.DeliveryTime,
                   Image_path = store.Image_path
               })
               .ToList();

            var storesWithDiscounts = (await _unitOfWork.Stores.GetAllAsync())
                .Where(store => store.hasOffer == true)
                .Select(store => new MinimalDiscountDto
                {
                    StoreName = store.Name_Ar,
                    Location = store.Location,
                    DeliveryTime = store.DeliveryTime,
                    Image_path = store.Image_path
                })
                .ToList();


            var freeDeliveryStores = (await _unitOfWork.Stores.GetAllAsync())
                                   .Where(s => s.IsDeliveryFree == true)
                                   .ToList();

            return new InstaShopDashboardDto
            {
                StoreType = types.Select(c => new MinimalStoreTypeDto
                {
                    StoreType = c.Name_Ar,
                    Icon_path = c.Icon_path
                }).ToList(),

                UniqueStores = uniqueStores.Select(s => new MinimalUniqueStoreDto
                {
                    StoreName = s.StoreName,
                    DeliveryTime = s.DeliveryTime,
                    Image_path = s.Image_path
                }).ToList(),

                Discount = storesWithDiscounts.Select(d => new MinimalDiscountDto
                {
                    StoreName = d.StoreName,
                    Location = d.Location,
                    DeliveryTime = d.DeliveryTime,
                    Image_path = d.Image_path
                }).ToList(),

                FreeDeliveryStores = freeDeliveryStores.Select(s => new MinimalStoreDto
                {
                    StoreName = s.Name_Ar,
                    Location = s.Location,
                    DeliveryTime = s.DeliveryTime,
                    Image_path = s.Image_path
                }).ToList(),
            };


        }

        public async Task<List<GetAllStoresDto>> GetInstaShopStores()
        {
            return await _unitOfWork.Stores
                .GetAll()
                .Select(store => new GetAllStoresDto
                {
                    StoreName = store.Name_Ar,
                    Location = store.Location,
                    DeliveryTime = store.DeliveryTime,
                    Image_path = store.Image_path,
                    StoreTypeName = store.StoreType != null ? store.StoreType.Name_Ar : "Unknown"
                })
                .ToListAsync();
        }


        public async Task<UsersInfoDto> GetUserInfoByUserIdAsync(string userId)
        {
            var user = await _context.Set<AppUser>()
            .Where(u => u.Id == userId) 
            .Select(u => new UsersInfoDto
            {
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).FirstOrDefaultAsync(); 
                return user;
        }

        public async Task<List<OrderDetailesDto>> GetUserOrdersAsync(string userId)
        {
            var orders = (await _unitOfWork.Orders.GetUserOrdersAsync(userId));
            var result = orders.Select(order => new OrderDetailesDto
            {
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                DeliveryAddress = order.Address,
                StoreName = order.Store.Name_Ar,
                PaymentMethod = order.transactions.FirstOrDefault()?.PaymentMethod,
                OrderPrice = order.OrderPrice,
                TotalPrice = order.TotalPrice
            }).ToList();

            return result;
        }

        public async Task<(List<UsersInfoDto> DriverUsers, List<UsersInfoDto> StoreUsers)> GetUsersInfoDtoDataAsync()
        {
            var driverAppUserIds = await _unitOfWork.Delivery
                .GetAll()
                .Include(d => d.AppUser)
                .ToListAsync();

            var storeAppUserIds = await _unitOfWork.Stores
                .GetAll()
                .Include(s => s.AppUser)
                .ToListAsync();

            var driverUsers = driverAppUserIds
                .Where(d => d.AppUser != null)
                .Select(d => new UsersInfoDto
                {
                    //UserId = d.AppUserId,
                    FullName = d.AppUser.FullName,
                    Email = d.AppUser.Email,
                    PhoneNumber = d.AppUser.PhoneNumber
                })
                .ToList();

            var storeUsers = storeAppUserIds
                .Where(s => s.AppUser != null)
                .Select(s => new UsersInfoDto
                {
                    //UserId = s.AppUserId,
                    FullName = s.AppUser.FullName,
                    Email = s.AppUser.Email,
                    PhoneNumber = s.AppUser.PhoneNumber,
                })
                .ToList();

            return (DriverUsers: driverUsers, StoreUsers: storeUsers);
        }


        




    }
}
