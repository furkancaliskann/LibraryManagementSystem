using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class BookCopyRepository : GenericRepository<BookCopy>, IBookCopyRepository
    {
        public BookCopyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
