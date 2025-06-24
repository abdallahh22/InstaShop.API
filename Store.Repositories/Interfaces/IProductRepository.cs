using Store.Data.Entities;
using Store.Services.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<PaginatedResult<Product>> GetProductsPagedAsync( int pageNumber, int pageSize);
        Task<List<Product>> SearchProductsAsync(string keyword);
      
    }
}
