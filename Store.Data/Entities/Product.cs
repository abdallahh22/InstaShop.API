using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Product : BaseEntity
    {
        public bool? IsUniqueProduct { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? Image_path { get; set; }
        public string? Price { get; set; }
        public string? Unit { get; set; }
        public int? CategoryId { get; set; }
        public Category category { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }  
        public ICollection<Offer> Offers { get; set; }  
        public ICollection<BasketTemp> BasketTemps { get; set; }  
    }
}
