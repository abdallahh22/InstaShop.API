using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Offer : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
