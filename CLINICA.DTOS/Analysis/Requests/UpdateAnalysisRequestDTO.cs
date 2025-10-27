using System.ComponentModel.DataAnnotations;

namespace CLINICA.APPLICATION.DTOS.Analysis.Requests
{
    public class UpdateAnalysisRequestDTO
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id deve ser maior que zero")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O id é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string UpdatedBy { get; set; }
    }
}
