using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Distopya",
                    IsDeleted = false,
                },

                new Category
                {
                    Id = 2,
                    Name = "Siyasi Satir",
                    IsDeleted = false,
                },

                new Category
                {
                    Id = 3,
                    Name = "Tarihi Kurgu",
                    IsDeleted = false,
                },

                new Category
                {
                    Id = 4,
                    Name = "Fantastik",
                    IsDeleted = false,
                },

                new Category
                {
                    Id = 5,
                    Name = "Polisiye",
                    IsDeleted = false,
                }
            );
        }
    }
}
