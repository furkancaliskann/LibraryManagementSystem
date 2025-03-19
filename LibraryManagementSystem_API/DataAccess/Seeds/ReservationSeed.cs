using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class ReservationSeed : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasData(
                new Reservation
                {
                    Id = 1,
                    UserId = 3,
                    BookCopyId = 7,
                    ReservationDate = new DateTime(2025, 03, 19, 12, 0, 0),
                    Status = ReservationStatus.Pending,
                    IsDeleted = false,
                },

                new Reservation
                {
                    Id = 2,
                    UserId = 3,
                    BookCopyId = 8,
                    ReservationDate = new DateTime(2025, 03, 19, 12, 0, 0),
                    Status = ReservationStatus.Cancelled,
                    IsDeleted = false,
                }
            );
        }
    }
}
