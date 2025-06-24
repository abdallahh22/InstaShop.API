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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly storeDbContext _context;

        public CategoryRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesByStoreIdAsync(int storeId)
        {
            return await _context.Categories
                      .Where(c => c.storeId == storeId)
                      .ToListAsync();
        }

        public async Task<Category> GetCategoryWithProductsByIdAsync(int? categoryId)
        {
            return await _context.Categories
         .Include(c => c.products)
         .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
