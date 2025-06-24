using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.WalletService
{
    public interface IWalletService
    {
        Task<WalletDto> CreateWalletAsync(WalletDto WalletDto);
        Task<WalletDto> UpdateWalletAsync(int? id, WalletDto WalletDto);
        Task<WalletDto> DeleteWalletAsync(int? Id);
        Task<WalletDto> GetWalletByIdAsync(int? Id);
        Task<IEnumerable<WalletDto>> GetAllWalletAsync();
        Task<WalletDto> GetWalletByUserIdAsync(string userId);
    }
}
