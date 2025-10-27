using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Specialties.Requests
{
    public class CreateSpecialtyRequestDTO
    {
        [Required(ErrorMessage = "Forneça o nome da especialidade")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Forneça o usuário")]
        public string User { get; set; }
    }
}
