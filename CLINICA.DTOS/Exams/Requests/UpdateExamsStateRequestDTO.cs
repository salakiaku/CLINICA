using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Exams.Requests
{
    

    public class UpdateExamsStateRequestDTO
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id deve ser maior que zero")]
        public int Id { get; set; }
        public int State { get; set; }
    }
}
