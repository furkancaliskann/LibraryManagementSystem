using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class FineSeed : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasData(
                new Fine
                {
                    Id = 1,
                    LoanId = 3,
                    FineAmount = 5,
                    Paid = false,
                    PaidDate = null,
                    IsDeleted = false,
                }
            );
        }
    }
}
