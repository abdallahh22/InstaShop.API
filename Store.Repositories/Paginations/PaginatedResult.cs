using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Paginations
{
    public class PaginatedResult<T>
    {
        public int TotalCount { get; set; } 
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }  
        public int PageSize { get; set; }
    }

}
