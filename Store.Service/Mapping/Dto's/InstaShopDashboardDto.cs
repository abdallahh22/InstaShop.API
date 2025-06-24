using Store.Services.Mapping.Dto_s.MobileDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class InstaShopDashboardDto
    {
        public List<MinimalStoreTypeDto>? StoreType { get; set; }
        public List<MinimalUniqueStoreDto>? UniqueStores { get; set; } 
        public List<MinimalDiscountDto>? Discount { get; set; }
        public List<MinimalStoreDto>? FreeDeliveryStores { get; set; }
      
    }
}
