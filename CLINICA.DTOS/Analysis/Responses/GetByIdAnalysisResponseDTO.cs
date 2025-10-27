namespace CLINICA.APPLICATION.DTOS.Analysis.Responses
{
    public class GetByIdAnalysisResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public DateTime AuditCreatedDay { get; set; }
        public DateTime AuditUpdatedDay { get; set; }
    }
}
