using Entities.Concrete;

namespace Business.Dtos.BookCopy
{
    public class UpdateBookCopyDto
    {
        public int BookId { get; set; }
        public required string CopyNumber { get; set; }
        public BookCopyStatus Status { get; set; }
        public required int ShelfId { get; set; }
    }
}
