using AutoMapper;
using Business.Abstract;
using Business.Dtos.Auth;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginDto> _loginDtoValidator;
        private readonly IValidator<RegisterDto> _registerDtoValidator;
        private readonly ILogService _logService;

        public AuthService(ITokenService tokenService, IUserService userService, IPasswordHasher passwordHasher, IMapper mapper,
            IValidator<LoginDto> loginDtoValidator, IValidator<RegisterDto> registerDtoValidator, ILogService logService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _loginDtoValidator = loginDtoValidator;
            _registerDtoValidator = registerDtoValidator;
            _logService = logService;
        }

        public async Task<Result<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            var validationResult = _loginDtoValidator.Validate(loginDto);

            if (!validationResult.IsValid)
                return Result<TokenDto>.FailedResult(validationResult.ToString(), ResultCodes.BadRequest);

            var result = await _userService.GetByEmailAsync(loginDto.Email);

            if(!result.IsSuccess || result.Data == null)
                return Result<TokenDto>.FailedResult(result.ErrorMessage, result.StatusCode);

            if (!_passwordHasher.VerifyPassword(loginDto.Password, result.Data.PasswordHash))
                return Result<TokenDto>.FailedResult("Invalid credentials", ResultCodes.Unauthorized);

            var token = _tokenService.GenerateToken(result.Data);

            await _logService.AddAsync(result.Data.Id, 
                "'" + result.Data.Name + " " + result.Data.Surname + "' has successfully logged in.");

            return Result<TokenDto>.SuccessResultWithData(new TokenDto { Token = token });
        }

        public async Task<Result<TokenDto>> RegisterAsync(RegisterDto registerDto)
        {
            var validationResult = await _registerDtoValidator.ValidateAsync(registerDto);

            if (!validationResult.IsValid)
                return Result<TokenDto>.FailedResult(validationResult.ToString(), ResultCodes.BadRequest);

            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password);

            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = hashedPassword;
            user.Role = "Member";

            var result = await _userService.AddAsync(user);

            if(!result.IsSuccess || !result.Data)
                return Result<TokenDto>.FailedResult(result.ErrorMessage, result.StatusCode);

            var token = _tokenService.GenerateToken(user);
            var tokenDto = new TokenDto { Token = token };

            await _logService.AddAsync(user.Id, 
                "'" + user.Name + " " + user.Surname + "' has registered using the email address " + "'" + user.Email + "'");
            
            return Result<TokenDto>.SuccessResultWithData(tokenDto);
        }
    }
}
