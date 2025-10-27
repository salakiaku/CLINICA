using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.DocumentTypes.Responses
{
    public class GetAllDocumentTypeResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? State { get; set; }
        public DateTime AuditCreatedDay { get; set; }
    }
}
