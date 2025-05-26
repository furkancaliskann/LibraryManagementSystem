using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class BookCopyRepository : GenericRepository<BookCopy>, IBookCopyRepository
    {
        public BookCopyRepository(AppDbContext context) : base(context)
        {
        }
        public override async Task<BookCopy?> GetByIdAsync(int id)
        {
            return await _context.BookCopies.Include(b => b.Shelf).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public override async Task<IEnumerable<BookCopy>> GetAllAsync()
        {
            return await _context.BookCopies
                .Include(b => b.Book)
                .Include(b => b.Book!.Author)
                .Include(b => b.Book!.Publisher)
                .Include(b => b.Book!.Category)
                .Include(b => b.Shelf)
                .AsNoTracking()
                .ToListAsync();
        }
        public Task<BookCopy?> GetWithCopyNumber(string copyNumber)
        {
            return _context.BookCopies.AsNoTracking().FirstOrDefaultAsync(x => x.CopyNumber == copyNumber);
        }
    }
}
