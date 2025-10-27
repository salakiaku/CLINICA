using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Patients.Responses
{
    public class GetAllPatientResponseDTO
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
        public int State { get; set; }

    }
}
