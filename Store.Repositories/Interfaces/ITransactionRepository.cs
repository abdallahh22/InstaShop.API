using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Repository.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Data.Entities.Transaction>
    {
        Task<List<Data.Entities.Transaction>> GetTransactionsByCardIdAsync(int paymentCardId);
        Task<List<Data.Entities.Transaction>> GetTransactionsByWalletIdAsync(int walletId);
    }
}
