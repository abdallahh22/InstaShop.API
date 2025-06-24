using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class WalletDto
    {
        public int Id { get; set; }
        public string Wallet_Name { get; set; }
        public decimal Wallet_Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Is_Deleted { get; set; }
        public string UserId { get; set; }
    }
}
