using Business.Dtos.Author;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        Task<Result<IEnumerable<Author>>> GetAllAsync();
        Task<Result<IEnumerable<Author>>> GetWithoutDeletedAsync();
        Task<Result<Author>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddAuthorDto addAuthorDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int authorId, UpdateAuthorDto updateAuthorDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
