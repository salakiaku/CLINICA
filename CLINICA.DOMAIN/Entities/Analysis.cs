using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.Entities
{
    public class Analysis
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public DateTime AuditCreatedDate { get; set; }
    }
}
