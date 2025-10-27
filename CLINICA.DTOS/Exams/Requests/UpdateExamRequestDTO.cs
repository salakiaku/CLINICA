using System.ComponentModel.DataAnnotations;

namespace CLINICA.APPLICATION.DTOS.Exams.Requests
{
    public class UpdateExamRequestDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue)]
        public int AnalysisId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string User { get; set; }
    }
}
