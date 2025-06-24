using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<TransactionsDto> CreateTransactionAsync(TransactionsDto TransactionsDto);
        Task<TransactionsDto> UpdateTransactionAsync(int? id, TransactionsDto TransactionsDto);
        Task<TransactionsDto> DeleteTransactionAsync(int? Id);
        Task<TransactionsDto> GetTransactionByIdAsync(int? Id);
        Task<IEnumerable<TransactionsDto>> GetAllTransactionAsync();
        Task<List<TransactionsDto>> GetTransactionsByCardIdAsync(int paymentCardId);
        Task<List<TransactionsDto>> GetTransactionsByWalletIdAsync(int walletId);
    }
}
