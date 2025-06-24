using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Coupone_Value { get; set; }
        public string? Coupone_Name { get; set; }
        public bool? Is_Valied { get; set; }
        public bool? Is_Deleted { get; set; }
        public bool? Is_percent { get; set; }
        public int? StoreId { get; set; }
        public store Store { get; set; }
        public CouponUser CouponUser { get; set; }
    }
}
