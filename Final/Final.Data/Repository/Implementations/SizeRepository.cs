using Final.Core.Entities;
using Final.Data.Contexts;
using Final.Data.Repository.Abstractions;

namespace Final.Data.Repository.Implementations
{
    public class SizeRepository: GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext appDbContext) : base(appDbContext) { }

    }
}
