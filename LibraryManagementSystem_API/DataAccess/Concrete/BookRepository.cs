using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Book?> GetByTitleAsync(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(a => a.Title == title);
        }
    }
}
