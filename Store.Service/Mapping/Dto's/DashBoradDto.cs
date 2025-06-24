using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class DashBoradDto
    {
        public int TotalOrders { get; set; }
        public int TotalDrivers { get; set; }
        public int TotalStores { get; set; }
        public decimal TotalEarnings { get; set; }
        public int PendingStores { get; set; }
        public IEnumerable<OrderDto> RecentOrders { get; set; }
        public IEnumerable<ProductDto> RecentProducts { get; set; }
        public IEnumerable<WalletDto> RecentWallets { get; set; }
    }
}
