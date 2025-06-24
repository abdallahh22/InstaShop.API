using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;

namespace Store.Services.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderItemsDto> CreateOrderItemAsync(OrderItemsDto OrderItemsDto)
        {
            if (OrderItemsDto == null) 
                throw new ArgumentNullException(nameof(OrderItemsDto),"OrderItem Not Found");
            try
            {
                var items = _mapper.Map<OrderItem>(OrderItemsDto);
                await _unitOfWork.OrderItems.AddAsync(items);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderItemsDto>(items);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<OrderItemsDto> DeleteOrderItemAsync(int? Id)
        {
            if (Id is null)
                throw new Exception("Not Found");
            try
            {
                var item = await _unitOfWork.OrderItems.GetByIdAsync(Id);
                if (item == null)
                    throw new Exception("Item not Found");
                await _unitOfWork.OrderItems.DeleteAsync(item);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderItemsDto>(item);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed",ex);
            }
        }

        public async Task<IEnumerable<OrderItemsDto>> GetAllOrderItemAsync()
        {
            var item = await _unitOfWork.OrderItems.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemsDto>>(item);
        }

        public async Task<OrderItemsDto> GetOrderItemByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id), "Id Not Found");
            try
            {
                var item = await _unitOfWork.OrderItems.GetByIdAsync(Id);
                if (item == null)
                    throw new Exception($"{nameof(Order)} does not exist");
                return _mapper.Map<OrderItemsDto>(item);
            }
            catch (Exception ex)
            {

                throw new Exception("Item Not Found", ex);
            }
        }

        public async Task<OrderItemsDto> GetOrderItemWithDetailesAsync(int? itemId)
        {
            if (itemId is null)
                throw new ArgumentNullException(nameof(itemId), "Id Not Found");
            var item = await _unitOfWork.OrderItems.GetOrderItemWithDetailsAsync(itemId);
            return _mapper.Map<OrderItemsDto>(item);
        }

        public async Task<OrderItemsDto> UpdateOrderItemAsync(int? id, OrderItemsDto OrderItemsDto)
        {
            if (OrderItemsDto is null)
                throw new ArgumentNullException("Order Not Found");
            try
            {
                if (id is null)
                    throw new ArgumentNullException(nameof(id), "Id Not Found");
                var item = await _unitOfWork.OrderItems.GetByIdAsync(id);
                _mapper.Map(OrderItemsDto, item);
                await _unitOfWork.OrderItems.UpdateAsync(item);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderItemsDto>(item);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }
        }
    }
}
