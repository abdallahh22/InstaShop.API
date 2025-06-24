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
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly storeDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(storeDbContext context, IUnitOfWork unitOfWork):base(context) 
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Product>> SearchProductsAsync(string keyword)
        {
            await _unitOfWork.SearchHistories.AddSearchHistoryAsync(keyword);

            return await _context.Products
                .Where(p => p.Name_Ar.ToLower().Contains(keyword.ToLower()) ||
                            p.Name_En.ToLower().Contains(keyword.ToLower()))
                .ToListAsync();
        }
        public async Task<PaginatedResult<Product>> GetProductsPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Set<Product>().AsQueryable();

            var totalCount = await query.CountAsync();

            var products = await query
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize)                    
                .ToListAsync();

            var pagedResult = new PaginatedResult<Product>
            {
               TotalCount = totalCount,
               PageNumber = pageNumber,
               PageSize = pageSize,
               Items = products
            };

            return pagedResult;
        }

    }



}
