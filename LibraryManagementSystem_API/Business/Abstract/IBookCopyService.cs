using Business.Dtos.BookCopy;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookCopyService
    {
        Task<Result<IEnumerable<BookCopy>>> GetAllAsync();
        Task<Result<IEnumerable<BookCopy>>> GetWithoutDeletedAsync();
        Task<Result<BookCopy>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddBookCopyDto addBookCopyDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int bookCopyId, UpdateBookCopyDto updateBookCopyDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
