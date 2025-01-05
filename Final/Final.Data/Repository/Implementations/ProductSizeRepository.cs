using Final.Core.Entities;
using Final.Data.Contexts;
using Final.Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Repository.Implementations
{
    public class ProductSizeRepository : GenericRepository<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
