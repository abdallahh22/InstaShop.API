using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class store : BaseEntity
    {
        public bool? IsUniqueStore { get; set; }
        public string? Description_En { get; set; }
        public string? Description_Ar { get; set; }
        public int? StoreTypeId { get; set; }
        public StoreType StoreType { get; set; }
        public string? Location { get; set; }
        public decimal? Location_Lat { get; set; }
        public decimal? Location_Lang { get; set; }
        public string? Icon_path { get; set; }
        public string? Image_path { get; set; }
        public bool? IsOpen { get; set; }
        public bool? IsDeliveryFree { get; set; }
        public bool? hasOffer { get; set; }
        public string? OfferValue { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DeliveryTime { get; set; }
        public StoreStatus StoreStatus { get; set; } = StoreStatus.Pending;
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Category> categories { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<StoreWorkingDay> StoreWorkingDays { get; set; } = new List<StoreWorkingDay>();   
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
