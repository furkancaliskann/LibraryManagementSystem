using Business.Dtos.Loan;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILoanService
    {
        Task<Result<IEnumerable<Loan>>> GetAllAsync();
        Task<Result<IEnumerable<Loan>>> GetWithoutDeletedAsync();
        Task<Result<Loan>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddLoanDto addLoanDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int loanId, UpdateLoanDto updateLoanDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
