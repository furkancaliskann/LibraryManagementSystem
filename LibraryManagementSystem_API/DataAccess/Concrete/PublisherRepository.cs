using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Publisher?> GetByNameAsync(string name)
        {
            return await _context.Publishers.AsNoTracking().SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
