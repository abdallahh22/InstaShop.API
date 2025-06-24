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
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        private readonly storeDbContext _context;

        public RateRepository(storeDbContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesWithHighestMarkedAsync(int rateId)
        {
            var rates = await _context.Set<Rate>()
                .Where(r => r.store.Id == rateId)
                .ToListAsync();
            var highestRating = rates.Max(r => r.Rating);

            foreach (var rate in rates)
            {
                rate.IsHighestRating = rate.Rating == highestRating;
            }

            return rates ?? throw new Exception("Not Found");
        }

        public async Task<Rate> GetHighestRateByStoreIdAsync(int rateId)
        {
            var rates = await _context.Set<Rate>()
          .Where(r => r.store.Id == rateId)
          .OrderByDescending(r => r.Rating)
          .FirstOrDefaultAsync();

            return rates ?? throw new Exception("Not Found");

        }

        public async Task<IEnumerable<Rate>> GetRatesByUserIdAsync(string userId)
        {
            return await _context.Rates
                .Where(r => r.AppUserId == userId)
                .Select(r => new Rate
                {
                    Rating = r.Rating,
                    comment = r.comment
                })
                .ToListAsync();
        }
    }
}
