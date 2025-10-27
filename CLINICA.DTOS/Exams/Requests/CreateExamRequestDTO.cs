using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Exams.Requests
{
    public class CreateExamRequestDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue)]
        public int AnalysisId {  get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string User {  get; set; }
    }
}
