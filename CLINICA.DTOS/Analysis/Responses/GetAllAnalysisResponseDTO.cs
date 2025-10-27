using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Analysis.Responses
{
    public class GetAllAnalysisResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
    }
}
