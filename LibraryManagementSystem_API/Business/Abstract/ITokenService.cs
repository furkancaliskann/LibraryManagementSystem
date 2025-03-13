using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
