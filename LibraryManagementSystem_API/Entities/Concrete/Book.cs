namespace Entities.Concrete
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public required string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}