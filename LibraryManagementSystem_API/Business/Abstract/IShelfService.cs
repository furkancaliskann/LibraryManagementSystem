using Business.Dtos.Shelf;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IShelfService
    {
        Task<Result<IEnumerable<Shelf>>> GetAllAsync();
        Task<Result<IEnumerable<Shelf>>> GetWithoutDeletedAsync();
        Task<Result<Shelf>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddShelfDto addShelfDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int shelfId, UpdateShelfDto updateShelfDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
