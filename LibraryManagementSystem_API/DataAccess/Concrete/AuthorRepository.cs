using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
