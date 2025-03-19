using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class PublisherSeed : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Secker & Warburg",
                    IsDeleted = false,
                },

                new Publisher
                {
                    Id = 2,
                    Name = "Harper & Brothers",
                    IsDeleted = false,
                },

                new Publisher
                {
                    Id = 3,
                    Name = "Allen & Unwin",
                    IsDeleted = false,
                },

                new Publisher
                {
                    Id = 4,
                    Name = "Collins Crime Club",
                    IsDeleted = false,
                }
            );
        }
    }
}
