using Entities.Abstract;

namespace Entities.Concrete
{
    public class Publisher : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
