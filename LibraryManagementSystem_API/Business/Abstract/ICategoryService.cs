using Business.Dtos.Category;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetAllAsync();
        Task<Result<IEnumerable<Category>>> GetWithoutDeletedAsync();
        Task<Result<Category>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, AddCategoryDto addCategoryDo);
        Task<Result<bool>> UpdateAsync(string? userRole, int categoryId, UpdateCategoryDto updateCategoryDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
