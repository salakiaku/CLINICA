namespace CLINICA.APPLICATION.DTOS.Patients.Responses
{
    public class GetByIdPatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string DocType { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime AuditCreatedDay { get; set; }
        public DateTime AuditUpdatedDay { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
