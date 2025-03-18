using Business.Dtos.Publisher;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        Task<Result<IEnumerable<Publisher>>> GetAllAsync();
        Task<Result<IEnumerable<Publisher>>> GetWithoutDeletedAsync();
        Task<Result<Publisher>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddPublisherDto addPublisherDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int publisherId, UpdatePublisherDto updatePublisherDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
