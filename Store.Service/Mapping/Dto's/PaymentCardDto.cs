using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class PaymentCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string CardType { get; set; }
        public string AppUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
