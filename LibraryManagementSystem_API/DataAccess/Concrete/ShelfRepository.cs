using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ShelfRepository : GenericRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Shelf?> GetByLocationAsync(string location)
        {
            return await _context.Shelves.AsNoTracking().SingleOrDefaultAsync(x => x.Location == location);
        }
    }
}
