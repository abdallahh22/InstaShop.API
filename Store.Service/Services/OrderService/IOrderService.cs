using Store.Services.Mapping.Dto_s;

namespace Store.Services.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderDto OrderDto);
        Task<OrderDto> UpdateOrderAsync(int? id, OrderDto OrderDto);
        Task<OrderDto> GetOrderByIdAsync(int? Id);
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
        Task<OrderDto> GetOrderWithDetailesAsync(int? orderId);
        Task<OrderDto> DeleteOrderwithItemsAsync(int? orderId);
        Task<IEnumerable<OrderDto>> GetOrdersByDriverAsync(int driverId);
        Task<OrderDto> GetOrderWithRatingsAsync(int? orderId);
        Task<List<OrderDto>> GetOrderByUserIdAsync(string userId);
    }
}
