using Business.Abstract;
using Business.Dtos;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(ITokenService tokenService, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
                return Result<TokenDto>.FailedResult("Invalid credentials", ResultCodes.BadRequest);

            var token = _tokenService.GenerateToken(user);
            return Result<TokenDto>.SuccessResultWithData(new TokenDto { Token = token });
        }

        public async Task<Result<TokenDto>> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto.Email == "" || registerDto.Password == "")
                return Result<TokenDto>.FailedResult("Email and password cannot be empty!", ResultCodes.BadRequest);

            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);

            if (existingUser != null)
                return Result<TokenDto>.FailedResult("This email has already been registered!", ResultCodes.Conflict);

            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password);

            User user = new User
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                Role = "Member",
                Phone = registerDto.Phone,
                Address = registerDto.Address,
            };

            await _userRepository.AddAsync(user);
            var isSaved = await _userRepository.SaveChangesAsync();

            if(!isSaved)
                return Result<TokenDto>.FailedResult("An error occurred while saving user!", ResultCodes.ServerError);

            var token = _tokenService.GenerateToken(user);
            var tokenDto = new TokenDto { Token = token };

            return Result<TokenDto>.SuccessResultWithData(tokenDto);
        }
    }
}
