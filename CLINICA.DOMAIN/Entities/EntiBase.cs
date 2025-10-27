namespace CLINICA.DOMAIN.Entities
{
    public abstract class EntiBase
    {
        public int Id { get; set; }
        public string? CreatedBy {  get; set; }
        public string? UpdatedBy {  get; set; }
        public DateTime AuditCreatedDay { get; set; }
        public DateTime AuditUpdatedDay { get; set; }

    }
}
