using Entities.Abstract;

namespace Entities.Concrete
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
