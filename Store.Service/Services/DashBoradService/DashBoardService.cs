using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.DashBoradService
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashBoardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DashBoradDto> GetDashboardDataAsync()
        {
            var totalOrders =  await _unitOfWork.Orders.CountAsync();
            var totalDrivers = await _unitOfWork.Delivery.CountAsync();
            var totalStores =  await _unitOfWork.Stores.CountAsync();
            var totalEarnings = await _unitOfWork.Orders.SumAsync(o => o.TotalPrice);
            var pendingStores = await _unitOfWork.Stores.CountAsync(s => s.StoreStatus == StoreStatus.Pending);
            var recentOrders = await _unitOfWork.Orders.GetTopAsync(o => o.OrderDate, 10);
            var recentProducts = await _unitOfWork.Products.GetTopAsync(o => o.CreatedAt, 10);
            var recentWallets = await _unitOfWork.Wallets.GetTopAsync(o => o.CreatedAt, 10);

            return new DashBoradDto
            {
                TotalStores = totalStores,
                TotalDrivers = totalDrivers,
                TotalEarnings = totalEarnings,
                TotalOrders = totalOrders,
                PendingStores = pendingStores,
                RecentOrders = _mapper.Map<IEnumerable<OrderDto>>(recentOrders),
                RecentProducts = _mapper.Map<IEnumerable<ProductDto>>(recentProducts),
                RecentWallets = _mapper.Map<IEnumerable<WalletDto>>(recentWallets)

            };
        }
    }
}
