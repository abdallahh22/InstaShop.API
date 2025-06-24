using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Rate 
    {
        public int? RateId { get; set; }
        public int? StoreId { get; set; }
        public store store { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? Rating { get; set; }
        public bool? IsHighestRating { get; set; }
        public string? comment { get; set; }
    }
}
