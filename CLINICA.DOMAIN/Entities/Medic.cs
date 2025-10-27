using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.Entities
{
    public class Medic : EntiBase
    {

        public string FullName { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public int DocTypeId { get; set; }
        public int SpecialtyId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public int State { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
