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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly storeDbContext _context;

        public UnitOfWork(storeDbContext context)
        {
            _context = context;
            Stores = new StoreRepository(_context);
            Rates = new RateRepository(_context);
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context, this);
            StoreTypes = new StoreTypeRepository(_context);
            Orders = new OrderRepository(_context);
            OrderItems = new OrderItemRepository(_context);
            Delivery = new DriverRepository(_context);
            Coupons = new CouponRepository(_context);
            couponUsers = new CouponUserRepository(_context);
            Transactions = new TransactionRepository(_context);
            Wallets = new WalletRepository(_context);
            Offers = new OfferRepository(_context);
            Notifications = new NotificationRepository(_context);
            NotificationUser = new NotificationUserRepository(_context);
            HelpQuestions = new helpQuestionsRepository(_context);
            ContactUs = new ContactUsRepository(_context);
            Chat = new ChatRepository(_context);
            OrderStatus = new OrderStatusRepository(_context);
            Basket = new BasketRepository(_context);
            SearchHistories = new SearchHistoryRepository(_context);
            PaymentCards = new PaymentCardRepository(_context);
            Addresses = new AddressRepository(_context);
           
            
        }
         public IStoreRepository Stores { get; set; }
         public IRateRepository Rates { get; set; }
         public ICategoryRepository Categories { get; set; }
         public IProductRepository Products { get; set; }
         public IStoreTypeRepository StoreTypes { get; set; }
         public IOrderRepository Orders { get; set; }
         public IOrderItemRepository OrderItems { get; set; }
         public IDriverRepository Delivery { get; set; }
         public ICouponRepository Coupons { get; set; }
         public ICouponUserRepository couponUsers { get; set; }
         public ITransactionRepository Transactions { get; set; }
         public IWalletRepository Wallets { get; set; }
         public IOfferRepository Offers { get; set; }
         public INotificationRepository Notifications { get; set; }
         public INotificationUserRepository NotificationUser { get; set; }
         public IhelpQuestionsRepository HelpQuestions { get; set; }
         public IContactUsRepository ContactUs { get; set; }
         public IChatRepository Chat { get; set; }
         public IOrderStatusRepository OrderStatus { get; set; }
         public IBasketRepository Basket { get; set; }
         public ISearchHistoryRepository SearchHistories { get; set; }
         public IPaymentCardRepository PaymentCards { get; set; }
         public IAddressRepository Addresses { get; set; }
        


        public async Task<int> SaveChanges()
           => await _context.SaveChangesAsync();
        
    }
}
