using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithProductsByIdAsync(int? Id);
        Task<List<Category>> GetCategoriesByStoreIdAsync(int storeId);
    }
}
