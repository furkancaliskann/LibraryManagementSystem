using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Author?> GetByNameAsync(string name)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
