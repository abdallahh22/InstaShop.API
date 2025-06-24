using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class StoreRepository: GenericRepository<store>, IStoreRepository
    {
        private readonly storeDbContext _context;

        public StoreRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<store> GetStoreWithRatingsAsync(int storeId)
        {
            var store = await _context.Set<store>()
            .Include(s => s.Rates)  
            .FirstOrDefaultAsync(s => s.Id == storeId);

            return store ?? throw new Exception("Not Found");
        }


        public async Task<PaginatedResult<store>> GetStoresPagedAsync(int pageNumber, int pageSize)
        {
            var totalStoresCount = await _context.Set<store>().CountAsync(); 

            
            var stores = await _context.Set<store>()
                .Skip((pageNumber - 1) * pageSize)  
                .Take(pageSize)                    
                .Include(s => s.Rates)             
                .ToListAsync();

            return new PaginatedResult<store>
            {
                TotalCount = totalStoresCount,
                Items = stores
            };
        }

    }
}
