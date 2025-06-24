using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Context
{
    public class storeDbContext : IdentityDbContext<AppUser>
    {
        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<StoreType> StoreTypes { get; set; }
        public DbSet<store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrdeStatus> OrderStatus { get; set; }
        public DbSet<DeliveryDriver> Drivers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponUser> CouponUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<StoreWorkingDay> StoreWorkingDays { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<HelpQuestions> HelpQuestions { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<BasketTemp> BasketTemps { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<Address> Addresses { get; set; }

        #endregion

        public storeDbContext(DbContextOptions<storeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.store)
                .WithMany(s => s.Rates)
                .HasForeignKey(r => r.StoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.orderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeliveryDriver>()
                .HasMany(d => d.Orders)
                .WithOne(o => o.DeliveryDriver)
                .HasForeignKey(o => o.DriverId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Coupon>()
                .HasOne(c => c.CouponUser)
                .WithOne(cu => cu.Coupon)
                .HasForeignKey<CouponUser>(cu => cu.CouponId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CouponUser>()
                .HasOne(cu => cu.AppUser)
                .WithOne(appUser => appUser.CouponUser)
                .HasForeignKey<CouponUser>(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
