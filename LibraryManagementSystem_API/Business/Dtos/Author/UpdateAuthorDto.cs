namespace Business.Dtos.Author
{
    public class UpdateAuthorDto
    {
        public required string Name { get; set; }
        public string? Bio { get; set; }
    }
}
