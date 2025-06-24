using Store.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IStoreRepository Stores { get; }
        IRateRepository Rates { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IStoreTypeRepository StoreTypes { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IDriverRepository Delivery { get; }
        ICouponRepository Coupons { get; }
        ICouponUserRepository couponUsers { get; }
        ITransactionRepository Transactions { get; }
        IWalletRepository Wallets { get; }
        IOfferRepository Offers { get; }
        INotificationRepository Notifications { get; }
        INotificationUserRepository NotificationUser { get; }
        IhelpQuestionsRepository HelpQuestions { get; }
        IContactUsRepository ContactUs { get; }
        IChatRepository Chat { get; }
        IOrderStatusRepository OrderStatus { get; }
        IBasketRepository Basket { get; }
        ISearchHistoryRepository SearchHistories { get; }
        IPaymentCardRepository PaymentCards { get; }
        IAddressRepository Addresses { get; }


        Task<int> SaveChanges();
    }
}
