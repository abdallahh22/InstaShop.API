using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketService
{
    public interface IBasketService
    {
        Task<BasketDto> CreateBasketAsync(BasketDto BasketDto);
        Task<BasketDto> UpdateBasketAsync(int? id, BasketDto BasketDto);
        Task<BasketDto> DeleteBasketAsync(int? PlayerId);
        Task<BasketDto> GetBasketByIdAsync(int? Id);
        Task<IEnumerable<BasketDto>> GetAllBasketAsync();
        Task<BasketDto> AddProductToBasketAsync(int productId, int quantity);
        Task<BasketDto> RemoveProductFromBasketAsync(int productId);
        Task<BasketDto> DeleteBasketByPlayerIdAsync(string playerId);
        Task<List<BasketDto>> GetBasketByPlayerIdAsync(string playerId);
        Task<bool> CanProceedToCheckoutAsync(string playerId);
    }
}
