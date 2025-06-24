using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public enum StoreStatus
    {
        Open = 1,
        Closed = 2,
        Pending = 3,
        Undermaintenance = 4,
        Suspended = 5
    }
}
