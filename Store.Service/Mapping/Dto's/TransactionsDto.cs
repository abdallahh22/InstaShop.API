using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class TransactionsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WalletId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; } 
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? Description { get; set; }
        public int? PaymentCardId { get; set; }
    }
}
