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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly storeDbContext _context;

        public AddressRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressByUserId(string UserId)
        {
            return await _context.Addresses.Where(u => u.AppUserId == UserId).ToListAsync();
        }
    }
}
