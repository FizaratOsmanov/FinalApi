﻿using Final.Core.Entities;
using Final.Data.Contexts;
using Final.Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Repository.Implementations
{
    public class ProductColorRepository : GenericRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(AppDbContext appDbContext) : base(appDbContext) { }

    }
}
