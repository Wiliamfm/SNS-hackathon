using sns.domain.Entities.Common;

namespace sns.domain.Entities
{
    public class Role : AuditEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
