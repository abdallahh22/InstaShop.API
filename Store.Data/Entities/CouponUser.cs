using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class CouponUser
    {
        public int Id { get; set; }
        public int? CouponId { get; set; }
        public Coupon Coupon { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool? Is_valid { get; set; }
    }
}
