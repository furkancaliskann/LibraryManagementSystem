using Business.Dtos.Fine;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFineService
    {
        Task<Result<IEnumerable<Fine>>> GetAllAsync();
        Task<Result<IEnumerable<Fine>>> GetWithoutDeletedAsync();
        Task<Result<Fine>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddFineDto addFineDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int loanId, UpdateFineDto updateFineDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
