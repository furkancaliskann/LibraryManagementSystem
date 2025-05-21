using AutoMapper;
using Business.Abstract;
using Business.Dtos.User;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<UpdateUserDto> _updateUserDtoValidator;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, 
            IValidator<UpdateUserDto> updateUserDtoValidator) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _updateUserDtoValidator = updateUserDtoValidator;
        }

        public async Task<Result<IEnumerable<GetUserDto>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var mappedUsers = _mapper.Map<IEnumerable<GetUserDto>>(users);
            return Result<IEnumerable<GetUserDto>>.SuccessResultWithData(mappedUsers);
        }

        public async Task<Result<GetUserDto>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result<GetUserDto>.FailedResult("User not found!", ResultCodes.NotFound);

            var mappedUser = _mapper.Map<GetUserDto>(user);
            return Result<GetUserDto>.SuccessResultWithData(mappedUser);
        }

        public async Task<Result<User>> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return Result<User>.FailedResult("User not found!", ResultCodes.NotFound);

            return Result<User>.SuccessResultWithData(user);
        }

        public async Task<Result<bool>> AddAsync(User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);

            if (existingUser != null)
                return Result<bool>.FailedResult("This email has already been registered!", ResultCodes.Conflict);

            await _userRepository.AddAsync(user);
            var result = await _userRepository.SaveChangesAsync();

            if(!result)
                return Result<bool>.FailedResult("An error occurred while adding the user!", ResultCodes.ServerError);

            return Result<bool>.SuccessResultWithData(true);
        }

        public async Task<Result<bool>> UpdateAsync(int? loggedUserId, UpdateUserDto updateUserDto)
        {
            if (loggedUserId == null)
                return Result<bool>.FailedResult("Unauthorized action!", ResultCodes.Forbidden);

            var validatorResult = _updateUserDtoValidator.Validate(updateUserDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingUser = await _userRepository.GetByIdAsync(loggedUserId.Value);

            if (existingUser == null)
                return Result<bool>.FailedResult("User not found!", ResultCodes.NotFound);

            if (!_passwordHasher.VerifyPassword(updateUserDto.CurrentPassword, existingUser.PasswordHash))
                return Result<bool>.FailedResult("Invalid password!", ResultCodes.Unauthorized);

            if (existingUser.Email != updateUserDto.Email)
            {
                var emailExists = await _userRepository.GetByEmailAsync(updateUserDto.Email);
                if (emailExists != null)
                    return Result<bool>.FailedResult("This email is already taken!", ResultCodes.Conflict);
            }

            _mapper.Map(updateUserDto, existingUser);

            if (!string.IsNullOrWhiteSpace(updateUserDto.NewPassword))
            {
                existingUser.PasswordHash = _passwordHasher.HashPassword(updateUserDto.NewPassword);
            }

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();

            return Result<bool>.SuccessResultWithData(true);
        }
    }
}
