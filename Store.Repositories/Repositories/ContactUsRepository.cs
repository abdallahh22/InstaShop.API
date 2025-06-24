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
    public class ContactUsRepository : GenericRepository<ContactUs>, IContactUsRepository
    {
        private readonly storeDbContext _context;

        public ContactUsRepository(storeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddContactMessageAsync(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
            await _context.SaveChangesAsync();
        }
    }
}
