using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetByNameAsync(string name);
    }
}
