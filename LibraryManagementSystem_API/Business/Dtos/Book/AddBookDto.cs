namespace Business.Dtos.Book
{
    public class AddBookDto
    {
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public required string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
