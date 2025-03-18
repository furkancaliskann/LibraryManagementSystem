using Entities.Concrete;

namespace Business.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
