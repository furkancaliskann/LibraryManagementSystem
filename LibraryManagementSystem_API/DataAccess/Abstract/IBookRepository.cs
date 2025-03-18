using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetByTitleAsync(string name);
    }
}
