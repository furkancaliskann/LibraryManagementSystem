using Business.Dtos.Auth;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<Result<TokenDto>> RegisterAsync(RegisterDto registerDto);
        Task<Result<TokenDto>> LoginAsync(LoginDto loginDto);
    }
}
