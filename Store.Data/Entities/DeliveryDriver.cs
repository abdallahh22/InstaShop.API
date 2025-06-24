using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class DeliveryDriver 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TruckId { get; set; }
        public string PersonalId_Photo { get; set; }
        public string LicenseId_Photo { get; set; }
        public string ProfilePhoto { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public bool? IsAvailable { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
