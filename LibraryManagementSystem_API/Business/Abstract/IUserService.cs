using Business.Dtos;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<Result<IEnumerable<User>>> GetUsersAsync();
        Task<Result<User>> GetUserByIdAsync(int id);
        Task<Result<User>> UpdateUserAsync(User user);
    }
}
