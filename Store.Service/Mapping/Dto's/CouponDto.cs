using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string Coupone_value { get; set; }
        public string? Coupone_Name { get; set; }
        public bool? Is_Valied { get; set; }
        public bool? Is_Deleted { get; set; }
        public bool? Is_percent { get; set; }
        public int? StoreId { get; set; }
    }
}
