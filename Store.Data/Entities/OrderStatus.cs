using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class OrdeStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
