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

        public Task<BookCopy?> GetWithCopyNumber(string copyNumber)
        {
            return _context.BookCopies.AsNoTracking().FirstOrDefaultAsync(x => x.CopyNumber == copyNumber);
        }
    }
}
