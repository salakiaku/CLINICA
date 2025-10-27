using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.DocumentTypes.Requests
{
    public class CreateDocumentTypeRequestDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string User { get; set; }
    }
}
