using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<Order> GetOrderWithDetailesAsync(int? orderId);
        Task<Order> DeleteOrderwithItemsAsync(int? orderId);
        Task<IEnumerable<Order>> GetOrdersByDriverIdAsync(int driverId);
        Task<Order> GetOrderWithRatingsAsync(int orderId);
        Task<List<Order>> GetUserOrdersAsync(string userId);
        Task<List<Order>> GetOrderByUserIdAsync(string userId);
    }
}
