namespace sns.domain.Entities.Common
{
    public abstract class AuditEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
