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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(storeDbContext context) : base(context)
        {
        }

        public async Task<Order> DeleteOrderwithItemsAsync(int? orderId)
        {
            var order = await _context.Orders
                                     .Include(o => o.orderItems)
                                     .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new Exception("Order not found");

           _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrderByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.AppUserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDriverIdAsync(int driverId)
        {
            return await _context.Orders
                         .Where(o => o.DriverId == driverId)
                         .ToListAsync();
        }

        public async Task<Order> GetOrderWithDetailesAsync(int? orderId)
        {
            var order = await _context.Orders.Include(o => o.orderItems).ThenInclude(o => o.Product).Include(o => o.Store).Include(o => o.Rates)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task<Order> GetOrderWithRatingsAsync(int orderId)
        {
            var order = await _context.Set<Order>()
           .Include(s => s.Rates)
           .FirstOrDefaultAsync(s => s.Id == orderId);

            return order ?? throw new Exception("Not Found");
        }

        public async Task<List<Order>> GetUserOrdersAsync(string userId)
        {
            return await _context.Orders
                   .Where(o => o.AppUserId == userId)
                   .Include(o => o.Store)
                   .Include(o => o.transactions)
                   .ToListAsync();
        }
    }
}
