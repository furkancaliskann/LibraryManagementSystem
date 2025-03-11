using Entities.Abstract;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public required Author Author { get; set; }
        public int PublisherId { get; set; }
        public required Publisher Publisher { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public required List<BookCopy> Copies { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}
