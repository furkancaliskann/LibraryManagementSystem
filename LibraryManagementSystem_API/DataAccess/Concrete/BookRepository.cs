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

        public override async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<IEnumerable<Book>> GetWithoutDeletedAsync()
        {
            return await _context.Books
                .Where(b => !b.IsDeleted)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> GetByTitleAsync(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(a => a.Title == title);
        }
    }
}
