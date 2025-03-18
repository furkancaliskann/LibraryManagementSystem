using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<Publisher?> GetByNameAsync(string name);
    }
}
