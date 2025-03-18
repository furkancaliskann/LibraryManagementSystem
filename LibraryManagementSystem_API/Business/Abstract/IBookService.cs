using Business.Dtos.Book;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService
    {
        Task<Result<IEnumerable<Book>>> GetAllAsync();
        Task<Result<IEnumerable<Book>>> GetWithoutDeletedAsync();
        Task<Result<Book>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddBookDto addBookDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int bookId, UpdateBookDto updateBookDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
