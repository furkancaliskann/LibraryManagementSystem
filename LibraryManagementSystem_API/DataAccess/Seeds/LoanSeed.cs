using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class LoanSeed : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasData(
                new Loan
                {
                    Id = 1,
                    UserId = 3,
                    BookCopyId = 1,
                    LoanDate = new DateTime(2025, 03, 05),
                    DueDate = new DateTime(2025, 03, 12),
                    ReturnDate = null,
                    Status = LoanStatus.Borrowed,
                    IsDeleted = false,
                },

                new Loan
                {
                    Id = 2,
                    UserId = 3,
                    BookCopyId = 4,
                    LoanDate = new DateTime(2025, 03, 10),
                    DueDate = new DateTime(2025, 03, 17),
                    ReturnDate = new DateTime(2025, 03, 15),
                    Status = LoanStatus.Returned,
                    IsDeleted = false,
                },

                 new Loan
                 {
                     Id = 3,
                     UserId = 3,
                     BookCopyId = 5,
                     LoanDate = new DateTime(2025, 03, 15),
                     DueDate = new DateTime(2025, 03, 22),
                     ReturnDate = null,
                     Status = LoanStatus.Overdue,
                     IsDeleted = false,
                 }
            );
        }
    }
}
