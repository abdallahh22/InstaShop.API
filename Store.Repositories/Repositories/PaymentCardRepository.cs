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
    public class PaymentCardRepository : GenericRepository<PaymentCard>, IPaymentCardRepository
    {
        private readonly storeDbContext _context;

        public PaymentCardRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentCard>> GetByUserIdAsync(string userId)
        {
            return await _context.PaymentCards.Where(card => card.AppUserId == userId).ToListAsync();
        }
    }
}
