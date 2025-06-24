using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class BasketDto
    {
        public int BasketId { get; set; }
        public string PlayerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Price { get; set; }
    }
}
