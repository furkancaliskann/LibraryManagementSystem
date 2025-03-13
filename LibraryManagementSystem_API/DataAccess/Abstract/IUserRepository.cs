using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
