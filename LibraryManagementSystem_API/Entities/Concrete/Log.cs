namespace Entities.Concrete
{
    public class Log : BaseEntity
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
