using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class ShelfSeed : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.HasData(
                new Shelf
                {
                    Id = 1,
                    Location = "Shelf-001",
                    IsDeleted = false,
                },

                new Shelf
                {
                    Id = 2,
                    Location = "Shelf-002",
                    IsDeleted = false,
                },

                new Shelf
                {
                    Id = 3,
                    Location = "Shelf-003",
                    IsDeleted = false,
                },

                new Shelf
                {
                    Id = 4,
                    Location = "Shelf-004",
                    IsDeleted = false,
                },

                new Shelf
                {
                    Id = 5,
                    Location = "Shelf-005",
                    IsDeleted = false,
                }
            );
        }
    }
}
