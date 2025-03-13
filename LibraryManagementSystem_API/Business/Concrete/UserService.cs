using Business.Abstract;
using Business.Dtos;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<User>>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Result<IEnumerable<User>>.SuccessResultWithData(users);
        }

        public async Task<Result<User>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result<User>.FailedResult("User not found!", ResultCodes.NotFound);

            return Result<User>.SuccessResultWithData(user);
        }

        public Task<Result<User>> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
