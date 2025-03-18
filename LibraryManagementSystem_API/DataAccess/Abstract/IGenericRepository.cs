using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWithoutDeletedAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteByIdAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
