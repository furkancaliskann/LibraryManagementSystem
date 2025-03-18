using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
