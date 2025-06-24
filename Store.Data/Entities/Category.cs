using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Category : BaseEntity
    {
        public string? Icon_path { get; set; }
        public int? storeId { get; set; }
        public store store { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
