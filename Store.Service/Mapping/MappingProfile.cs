using AutoMapper;
using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.MobileDto_s;

namespace Store.Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<store, StoreDto>()
             .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rates)) 
             .ForMember(dest => dest.StoreTypeId, opt => opt.MapFrom(src => src.StoreTypeId))
             .ForMember(dest => dest.StoreStatus, opt => opt.MapFrom(src => src.StoreStatus))
             .ForMember(dest => dest.IconPath, opt => opt.MapFrom(src => src.Icon_path)) 
             .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image_path))
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId))
             .ReverseMap(); 

            CreateMap<Rate, RateDto>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ReverseMap();

            CreateMap<Category, CategoryDto>()
             .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.products))
             .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.storeId))
             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name_Ar, opt => opt.MapFrom(src => src.Name_Ar))
             .ForMember(dest => dest.Name_En, opt => opt.MapFrom(src => src.Name_En))
             .ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)).ReverseMap();

            CreateMap<StoreType, StoreTypeDto>().ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Id)).ReverseMap();


            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rates))
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => src.OrderStatusId))
                .ForMember(dest => dest.DeliveryStatus, opt => opt.MapFrom(src => src.DeliveryStatus))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src =>src.orderItems))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.DriverId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DeliveryDriver.FullName))
                .ReverseMap();

            CreateMap<OrderItem,OrderItemsDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src =>src.OrderId))
                .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src =>src.Id))
                .ReverseMap();

            CreateMap<DeliveryDriver, DriverDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
                
           CreateMap<Coupon, CouponDto>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src=>src.StoreId))
                .ForMember(dest => dest.CouponId, opt => opt.MapFrom(src=>src.Id))
                .ReverseMap();

            CreateMap<CouponUser, CouponUserDto>()
                .ForMember(dest => dest.CouponId, opt => opt.MapFrom(src => src.CouponId))
                .ForMember(dest => dest.CouponeUserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

            CreateMap<Transaction, TransactionsDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.PaymentCardId, opt => opt.MapFrom(src => src.PaymentCardId))
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.WalletId)).ReverseMap();

            CreateMap<Wallet, WalletDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId))
                .ReverseMap();

            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<NotificationUser, NotificationUserDto>()
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.NotificationId))
                .ForMember(dest => dest.N_UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId)).ReverseMap();


            CreateMap<HelpQuestions, helpQuestionsDto>()
                .ForMember(dest => dest.helpQuestionId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Chat, ChatDto>()
                .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<ContactUs, ContactUsDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.ContactUsId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<OrdeStatus, OrderStatusDto>().ReverseMap();
            //.ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id).ToList())).ReverseMap();

            CreateMap<PaymentCard, PaymentCardDto>().ReverseMap();

            CreateMap<StoreType, MinimalStoreTypeDto>().ReverseMap();
            CreateMap<store, MinimalStoreDto>().ReverseMap();
            CreateMap<store, MinimalDiscountDto>().ReverseMap();
            CreateMap<store, MinimalUniqueStoreDto>().ReverseMap();
            CreateMap<ContactUs, ContactMessageDto>().ReverseMap();
            CreateMap<Category , CategoriesDto>().ReverseMap();
            CreateMap<SearchHistory, SearchHistoryDto>().ReverseMap();

            CreateMap<Order, OrderDetailesDto>()
                 .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name_Ar))
            .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.transactions.FirstOrDefault().PaymentMethod))
                .ReverseMap();

            CreateMap<BasketTemp, BasketDto>()
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<AppUser, UsersInfoDto>()
           //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
