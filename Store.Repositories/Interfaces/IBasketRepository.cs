using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IBasketRepository : IGenericRepository<BasketTemp> 
    {
        Task<BasketTemp> AddProductToBasketAsync(int productId, int quantity);
        Task<BasketTemp> RemoveProductFromBasketAsync(int productId);
        Task<BasketTemp> DeleteBasketByPlayerIdAsync(string playerId);
        Task<List<BasketTemp>> GetBasketByPlayerIdAsync(string playerId);
    }
}
