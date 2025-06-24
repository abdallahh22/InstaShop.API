using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class CouponUserDto
    {
        public int CouponeUserId { get; set; }
        public int? CouponId { get; set; }
        public string? UserId { get; set; }
        public bool? Is_valid { get; set; }
    }
}
