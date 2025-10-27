using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Analysis.Requests
{
    public class CreateAnalysisRequestDTO
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string? CreatedBy { get; set; }
    }
}
