namespace Business.Abstract
{
    public interface IPasswordHasher
    {
        byte[] HashPassword(string password);
        bool VerifyPassword(string password, byte[] storedHash);
    }
}
