using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateOrderAsync(OrderDto OrderDto)
        {
            if (OrderDto == null)
                throw new ArgumentNullException(nameof(OrderDto), "OrderDto cannot be null.");
            try
            {
                // Calculate Total Amount !
                OrderDto.TotalPrice = OrderDto.OrderPrice + OrderDto.DeliveryPrice;
                var driver = await _unitOfWork.Delivery.GetByIdAsync(OrderDto.DriverId.Value);
                if (driver == null)
                    throw new Exception($"Driver with ID {OrderDto.DriverId} not found.");
                var order = _mapper.Map<Order>(OrderDto);
                var deliverystatus = (DeliveryStatus)OrderDto.DeliveryStatus;
                order.DeliveryStatus = deliverystatus;
                order.DeliveryDriver = driver;
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChanges();
                var resultDto = _mapper.Map<OrderDto>(order);
                resultDto.DriverName = driver.FullName;
                return resultDto;
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<OrderDto> DeleteOrderwithItemsAsync(int? orderId)
        {
            if (orderId is null)
                throw new ArgumentNullException(nameof(orderId), "Not Found");
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                    throw new Exception("Order Not Found!");
                await _unitOfWork.Orders.DeleteOrderwithItemsAsync(orderId);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderDto>(order);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            var order = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(order);   
        }

        public async Task<OrderDto> GetOrderByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id), "Id Not Found");
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(Id);
                if (order == null)
                    throw new Exception($"{nameof(Order)} Not Found");
                return _mapper.Map<OrderDto>(order);
            }
            catch (Exception ex)
            {

                throw new Exception("Order Not Found", ex);
            }
        }

        public async Task<List<OrderDto>> GetOrderByUserIdAsync(string userId)
        {
            var orders = await _unitOfWork.Orders.GetOrderByUserIdAsync(userId);
            if (orders == null)
                throw new Exception("UserId is null");
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByDriverAsync(int driverId)
        {
            if (driverId <= 0)
                throw new ArgumentException("Invalid Driver ID");
            try
            {

                var orders = await _unitOfWork.Orders.GetOrdersByDriverIdAsync(driverId);

                if (orders == null || !orders.Any())
                    throw new Exception("No orders found for this driver");

                return _mapper.Map<IEnumerable<OrderDto>>(orders);
            }
            catch (Exception ex)
            {

                throw new Exception("Order By Driver Not Found", ex);
            }

        }

        public async Task<OrderDto> GetOrderWithDetailesAsync(int? orderId)
        {
            if (orderId is null)
                throw new ArgumentNullException(nameof(orderId), "Id Not Found");
            var order = await _unitOfWork.Orders.GetOrderWithDetailesAsync(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> GetOrderWithRatingsAsync(int? orderId)
        {
            if (orderId is null)
                throw new ArgumentException("Order Id cannot be null.");

            try
            {
                var orderEntity = await _unitOfWork.Orders.GetOrderWithRatingsAsync(orderId.Value);
                if (orderEntity == null)
                    throw new KeyNotFoundException("Store with Ratings not found.");
                var orderDto = _mapper.Map<OrderDto>(orderEntity);
                return orderDto;
            }
            catch (Exception ex)
            {

                throw new Exception("Order Rate Not Found", ex);
            }
        }

        public async Task<OrderDto> UpdateOrderAsync(int? id, OrderDto OrderDto)
        {
            if (OrderDto is null)
                throw new ArgumentNullException("Order Not Found");
            try
            {
                if (id is null)
                    throw new ArgumentNullException(nameof(id), "Id Not Found");
                var order = await _unitOfWork.Orders.GetByIdAsync(id);
                _mapper.Map(OrderDto, order);
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderDto>(order);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }
     
        }
    }
}
