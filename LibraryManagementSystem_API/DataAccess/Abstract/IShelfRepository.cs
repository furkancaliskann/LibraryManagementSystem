using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IShelfRepository : IGenericRepository<Shelf>
    {
        Task<Shelf?> GetByLocationAsync(string location);
    }
}
