using Entities.Abstract;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Bio { get; set; }
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
