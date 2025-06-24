using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderStatusService
{
    public class OrdeStatusService : IOrdeStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdeStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderStatusDto> CreateOrderStatusAsync(OrderStatusDto OrderStatusDto)
        {
            if (OrderStatusDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var OrderStatus = _mapper.Map<OrdeStatus>(OrderStatusDto);
                await _unitOfWork.OrderStatus.AddAsync(OrderStatus);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderStatusDto>(OrderStatus);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<OrderStatusDto> DeleteOrderStatusAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var OrderStatus = await _unitOfWork.OrderStatus.GetByIdAsync(Id);
                if (OrderStatus is null)
                    throw new Exception("Id is null");
                await _unitOfWork.OrderStatus.DeleteAsync(OrderStatus);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderStatusDto>(OrderStatus);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<OrderStatusDto>> GetAllOrderStatusAsync()
        {
            var OrderStatus = await _unitOfWork.OrderStatus.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderStatusDto>>(OrderStatus);
        }


        public async Task<OrderStatusDto> GetOrderStatusByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var OrderStatus = await _unitOfWork.OrderStatus.GetByIdAsync(Id);
                if (OrderStatus is null)
                    throw new Exception("OrderStatus Not Found");
                return _mapper.Map<OrderStatusDto>(OrderStatus);
            }
            catch (Exception ex)
            {

                throw new Exception("OrderStatus Not Found", ex);
            }
        }

        public async Task<OrderStatusDto> UpdateOrderStatusAsync(int? id, OrderStatusDto OrderStatusDto)
        {
            if (OrderStatusDto == null)
                throw new ArgumentNullException(nameof(OrderStatusDto), "OrderStatus cannot be null.");

            try
            {
                var OrderStatus = await _unitOfWork.OrderStatus.GetByIdAsync(id);
                if (OrderStatus == null)
                    throw new Exception($"OrderStatus with Id {id} not found.");
                _mapper.Map(OrderStatusDto, OrderStatus);
                await _unitOfWork.OrderStatus.UpdateAsync(OrderStatus);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OrderStatusDto>(OrderStatus);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }
    }
}
