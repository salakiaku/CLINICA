using System.ComponentModel.DataAnnotations;

namespace CLINICA.APPLICATION.DTOS.Analysis.Requests
{
    public class UpdateAnalysisSateRequestDTO
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id deve ser maior que zero")]
        public int Id { get; set; }
        public int State { get; set; }
    }
}
