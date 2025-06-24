using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class OfferDto 
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int ProductId { get; set; }
    }
}
