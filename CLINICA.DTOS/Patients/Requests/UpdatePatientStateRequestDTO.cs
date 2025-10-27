using System.ComponentModel.DataAnnotations;

namespace CLINICA.APPLICATION.DTOS.Patients.Requests
{
    public class UpdatePatientStateRequestDTO
    {
        [Required(ErrorMessage = "Forneça o Id")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public int State { get; set; }



    }
}
