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
    public class StoreTypeRepository : GenericRepository<StoreType>, IStoreTypeRepository
    {
        private readonly storeDbContext _context;

        public StoreTypeRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

    }

}
