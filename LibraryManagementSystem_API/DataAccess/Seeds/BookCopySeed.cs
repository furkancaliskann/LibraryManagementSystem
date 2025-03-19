using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class BookCopySeed : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.HasData(
                new BookCopy
                {
                    Id = 1,
                    BookId = 1 ,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Borrowed,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 2,
                    BookId = 1,
                    CopyNumber = "002",
                    Status = BookCopyStatus.Available,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 3,
                    BookId = 1,
                    CopyNumber = "003",
                    Status = BookCopyStatus.Borrowed,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 4,
                    BookId = 2,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 5,
                    BookId = 2,
                    CopyNumber = "002",
                    Status = BookCopyStatus.Available,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 6,
                    BookId = 3,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 1,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 7,
                    BookId = 4,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 2,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 8,
                    BookId = 4,
                    CopyNumber = "002",
                    Status = BookCopyStatus.Available,
                    ShelfId = 2,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 9,
                    BookId = 5,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 2,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 10,
                    BookId = 6,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 2,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 11,
                    BookId = 6,
                    CopyNumber = "002",
                    Status = BookCopyStatus.Available,
                    ShelfId = 2,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 12,
                    BookId = 7,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 3,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 13,
                    BookId = 8,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 3,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 14,
                    BookId = 8,
                    CopyNumber = "002",
                    Status = BookCopyStatus.Available,
                    ShelfId = 3,
                    IsDeleted = false,
                },

                new BookCopy
                {
                    Id = 15,
                    BookId = 9,
                    CopyNumber = "001",
                    Status = BookCopyStatus.Available,
                    ShelfId = 3,
                    IsDeleted = false,
                }

            );
        }
    }
}
