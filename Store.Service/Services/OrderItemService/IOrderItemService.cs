using Store.Services.Mapping.Dto_s;

namespace Store.Services.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<OrderItemsDto> CreateOrderItemAsync(OrderItemsDto OrderItemsDto);
        Task<OrderItemsDto> UpdateOrderItemAsync(int? id, OrderItemsDto OrderItemsDto);
        Task<OrderItemsDto> DeleteOrderItemAsync(int? Id);
        Task<OrderItemsDto> GetOrderItemByIdAsync(int? Id);
        Task<IEnumerable<OrderItemsDto>> GetAllOrderItemAsync();
        Task<OrderItemsDto> GetOrderItemWithDetailesAsync(int? orderId);
    }
}
