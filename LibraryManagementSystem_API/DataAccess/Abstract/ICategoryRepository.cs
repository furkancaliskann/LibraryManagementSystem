using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}
