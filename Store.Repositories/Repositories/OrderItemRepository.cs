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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly storeDbContext _context;

        public OrderItemRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<OrderItem> GetOrderItemWithDetailsAsync(int? orderItemId)
        {
            var orderItem = await _context.OrderItems
            .Include(oi => oi.Product)               
            .Include(oi => oi.Order)               
            .ThenInclude(o => o.Store)               
            .FirstOrDefaultAsync(oi => oi.Id == orderItemId); 

            return orderItem;
        }
    }
}
