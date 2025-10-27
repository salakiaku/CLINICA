using System.ComponentModel.DataAnnotations;

namespace CLINICA.APPLICATION.DTOS.Patients.Requests
{
    public class UpdatePatientRequestDTO
    {
        [Required(ErrorMessage = "Forneça o Nome do Paciente")]
        [Range(1,int.MaxValue )]
        public int Id { get; set; }
        [Required(ErrorMessage = "Forneça o Nome do Paciente")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Forneça o Nome do pai do Paciente")]
        public string FathersName { get; set; }
        [Required(ErrorMessage = "Forneça o Nome da mãe do Paciente")]
        public string MothersName { get; set; }
        [Required(ErrorMessage = "Forneça o Documento")]
        public int DocTypeId { get; set; }
        [Required(ErrorMessage = "Forneça o Nº do Documento")]
        public string IdentificationNumber { get; set; }
        [Required(ErrorMessage = "Forneça o Telefone")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Forneça o Gênero (M ou F)")]
        [RegularExpression("^[MFmf]$", ErrorMessage = "Gênero deve ser 'M' ou 'F'.")]
        public char Gender { get; set; } = 'M';
        [Required(ErrorMessage = "Forneça a Data de Nascimento")]
        public DateOnly BirthDate { get; set; }
        [Required(ErrorMessage = "Forneça o Usuário")]
        public string User { get; set; }


    }
}
