using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Order 
    {
        public int Id { get; set; } 
        public DateTime ConfirmedAt { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Address { get; set; }
        public string? OrderNumber { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? SpecialRequest { get; set; }
        public string? CouponValue { get; set; }
        public string? Payments { get; set; }
        public int? OrderStatusId { get; set; }
        public OrdeStatus? OrderStatus { get; set; }
        public ICollection<OrderItem>? orderItems { get; set; }
        public int? StoreId { get; set; }
        public store Store { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? DriverId { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.InProgress;
        public DateTime Dliver_Date { get; set; }
        public DateTime Dliver_Time { get; set; }
        public string? Invoice_photo { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Transaction> transactions { get; set; }
    }
}
