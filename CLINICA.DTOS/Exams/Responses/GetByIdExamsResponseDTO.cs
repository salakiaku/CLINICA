namespace CLINICA.APPLICATION.DTOS.Exams.Responses
{
    public class GetByIdExamsResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
        public DateTime AuditCreatedDay { get; set; }
        public DateTime AuditUpdatedDay { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
