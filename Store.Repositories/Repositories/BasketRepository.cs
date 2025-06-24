using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class BasketRepository : GenericRepository<BasketTemp>, IBasketRepository
    {
        private readonly storeDbContext _context;

        public BasketRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BasketTemp> AddProductToBasketAsync(int productId, int quantity)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {productId} not found.");
                }

                var existingBasketItem = await _context.BasketTemps
                    .FirstOrDefaultAsync(b => b.ProductId == productId);

                if (existingBasketItem != null)
                {
                    existingBasketItem.Quantity += quantity;
                    _context.BasketTemps.Update(existingBasketItem);
                    await _context.SaveChangesAsync();
                    return existingBasketItem;
                }
                else
                {
                    var newBasketItem = new BasketTemp
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price
                    };

                    await _context.BasketTemps.AddAsync(newBasketItem);
                    await _context.SaveChangesAsync();
                    return newBasketItem;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add product to basket", ex);
            }
        }

        public async Task<BasketTemp> RemoveProductFromBasketAsync(int productId)
        {
            try
            {
                var basketItem = await _context.BasketTemps
                    .FirstOrDefaultAsync(b => b.ProductId == productId);

                if (basketItem == null)
                {
                    throw new Exception("Product not found in the basket.");
                }

                _context.BasketTemps.Remove(basketItem);
                await _context.SaveChangesAsync();
                return basketItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove product from basket", ex);
            }
        }
        public async Task<BasketTemp> DeleteBasketByPlayerIdAsync(string playerId)
        {
            try
            {
                var basketItems = await _context.BasketTemps
                    .Where(b => b.PlayerId == playerId)
                    .ToListAsync();

                if (basketItems == null || !basketItems.Any())
                {
                    throw new Exception("Basket not found for the specified PlayerId.");
                }

                _context.BasketTemps.RemoveRange(basketItems);
                await _context.SaveChangesAsync();
                return basketItems.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the basket", ex);
            }
        }
        public async Task<List<BasketTemp>> GetBasketByPlayerIdAsync(string playerId)
        {
            try
            {
                var basketItems = await _context.BasketTemps
                    .Where(b => b.PlayerId == playerId)
                    .ToListAsync();

                if (basketItems == null || !basketItems.Any())
                {
                    throw new Exception("No basket items found for the specified PlayerId.");
                }

                return basketItems;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the basket", ex);
            }
        }


    }
}
