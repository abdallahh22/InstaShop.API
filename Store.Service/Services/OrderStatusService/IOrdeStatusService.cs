using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderStatusService
{
    public interface IOrdeStatusService
    {
        Task<OrderStatusDto> CreateOrderStatusAsync(OrderStatusDto OrderStatusDto);
        Task<OrderStatusDto> UpdateOrderStatusAsync(int? id, OrderStatusDto OrderStatusDto);
        Task<OrderStatusDto> DeleteOrderStatusAsync(int? Id);
        Task<OrderStatusDto> GetOrderStatusByIdAsync(int? Id);
        Task<IEnumerable<OrderStatusDto>> GetAllOrderStatusAsync();
    }
}
