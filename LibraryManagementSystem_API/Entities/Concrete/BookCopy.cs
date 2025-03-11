using Entities.Abstract;

namespace Entities.Concrete
{
    public class BookCopy : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public required Book Book { get; set; }
        public required string CopyNumber { get; set; }
        public BookCopyStatus Status { get; set; }
        public required string ShelfLocation { get; set; }
    }

    public enum BookCopyStatus
    {
        Available,
        Borrowed,
        Reserved
    }
}
