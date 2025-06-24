using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s.MobileDto_s
{
    public class OrderDetailesDto
    {
        public string OrderNumber { get; set; } 
        public DateTime OrderDate { get; set; } 
        public DateTime ConfirmedAt { get; set; } 
        public string DeliveryAddress { get; set; } 
        public string StoreName { get; set; }
        public string PaymentMethod { get; set; } 
        public decimal OrderPrice { get; set; } 
        public decimal TotalPrice { get; set; } 
    }
}
