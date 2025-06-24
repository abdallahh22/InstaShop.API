using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int? StoreId { get; set; }
       public string UserId { get; set; }
        public int? DriverId { get; set; }
        public string DriverName { get; set; }
        public string? Address { get; set; }
        public DateTime ConfirmedAt { get; set; } = DateTime.Now;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderPrice { get; set; }
        public decimal DeliveryPrice { get; set; } 
        public decimal TotalPrice { get; set; }
        public string? SpecialRequest { get; set; }
        public string? CouponValue { get; set; }
        public string? Payments { get; set; }
        public int OrderStatusId { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryName => ((DeliveryStatus)DeliveryStatus).ToString();
        public DateTime Dliver_Date { get; set; }
        public DateTime Dliver_Time { get; set; }
        public string? Invoice_photo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
       public ICollection<OrderItemsDto> OrderItems { get; set; }
       public ICollection<RateDto> Rates { get; set; }
    }
}
