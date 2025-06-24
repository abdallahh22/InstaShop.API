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
    public class StoreWorkingDayRepository : GenericRepository<StoreWorkingDay>, IStoreWorkingDayRepository
    {
        private readonly storeDbContext _context;

        public StoreWorkingDayRepository(storeDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
