using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<Data.Entities.Transaction>, ITransactionRepository
    {
        private readonly storeDbContext _context;

        public TransactionRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Data.Entities.Transaction>> GetTransactionsByCardIdAsync(int paymentCardId)
        {
            return await _context.Transactions
                .Where(t => t.PaymentCardId == paymentCardId)
                .ToListAsync();
        }

        public async Task<List<Data.Entities.Transaction>> GetTransactionsByWalletIdAsync(int walletId)
        {
            return await _context.Transactions
                .Where(t => t.WalletId == walletId)
                .ToListAsync();
        }
    }
}
