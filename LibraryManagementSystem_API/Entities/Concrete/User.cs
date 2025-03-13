namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required byte[] PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum UserRole
    {
        Member,
        Staff,
        Admin
    }
}
