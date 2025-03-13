using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
