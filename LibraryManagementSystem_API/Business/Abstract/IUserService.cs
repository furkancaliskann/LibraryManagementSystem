using Business.Dtos.User;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<Result<IEnumerable<GetUserDto>>> GetAllAsync();
        Task<Result<GetUserDto>> GetByIdAsync(int id);
        Task<Result<User>> GetByEmailAsync(string email); // this is for login
        Task<Result<bool>> AddAsync(User user);
        Task<Result<bool>> UpdateAsync(int? loggedUserId, UpdateUserDto updateUserDto);
    }
}
