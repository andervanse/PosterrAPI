

namespace Posterr.Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
