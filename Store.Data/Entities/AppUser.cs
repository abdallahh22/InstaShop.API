
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Order> Orders { get; set; } 
        public ICollection<store> Stores { get; set; }
        public ICollection<DeliveryDriver> Drivers { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<NotificationUser> NotificationUsers { get; set; }
        public ICollection<PaymentCard> PaymentCards { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public CouponUser CouponUser { get; set; }
      
    }
}
