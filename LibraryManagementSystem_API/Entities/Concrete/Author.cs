namespace Entities.Concrete
{
    public class Author : BaseEntity
    {
        public required string Name { get; set; }
        public string? Bio { get; set; }
    }
}
