using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
