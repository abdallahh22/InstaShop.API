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
    public class OrderStatusRepository : GenericRepository<OrdeStatus>, IOrderStatusRepository
    {
        private readonly storeDbContext _context;

        public OrderStatusRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        //public Task<List<OrdeStatus>> GetAllOrderStatuses()
        //{
        //    var orderStatuses = _context.OrderStatus
        ////        .Include(os => os.Orders) 
        ////        .ToList();

        //    //    return orderStatuses; 
        //}

    }
}
