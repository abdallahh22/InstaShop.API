using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; } // => success or failed
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? Description { get; set; }
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public int? PaymentCardId { get; set; }
        public PaymentCard PaymentCard { get; set; }
    }
}
