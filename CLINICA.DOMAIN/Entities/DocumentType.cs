using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.Entities
{
    public class DocumentType : EntiBase
    {
        public string Name { get; set; }
        public int State { get; set; }

    }
}
