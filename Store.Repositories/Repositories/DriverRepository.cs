﻿using Microsoft.EntityFrameworkCore;
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
    public class DriverRepository : GenericRepository<DeliveryDriver>, IDriverRepository
    {
        private readonly storeDbContext _context;

        public DriverRepository(storeDbContext context) : base(context)
        {
           _context = context;
        }

       
    }
}
