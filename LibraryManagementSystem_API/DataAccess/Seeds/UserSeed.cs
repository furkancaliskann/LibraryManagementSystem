using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hashedPassword = HashPassword("123");

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@example.com",
                    PasswordHash = hashedPassword,
                    Role = "Admin",
                    Phone = "+90 000 000 0000",
                },
                new User
                {
                    Id = 2,
                    Name = "Employee",
                    Surname = "Employee",
                    Email = "employee@example.com",
                    PasswordHash = hashedPassword,
                    Role = "Employee",
                    Phone = "+90 111 111 1111",
                },
                new User
                {
                    Id = 3,
                    Name = "Furkan",
                    Surname = "Çalışkan",
                    Email = "furkancaliskan2022@gmail.com",
                    PasswordHash = hashedPassword,
                    Role = "Member",
                    Phone = "+90 542 523 4042",
                    Address = "Selçuklu/KONYA",
                }
            );
        }

        private byte[] HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
