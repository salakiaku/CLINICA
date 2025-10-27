using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Medics.Responses
{
    public class GetAllMedicResponseDTO
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
        public string Specialty { get; set; }
        public int State { get; set; }

    }


    public class GetByIdMedicResponseDTO
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
        public string Specialty { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime AuditCreatedDay { get; set; }
        public DateTime AuditUpdatedDay { get; set; }
        public int State { get; set; }

    }
}
