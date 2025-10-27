using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.DTOS.Exams.Responses
{
    public class GetAllExamsResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Analysis { get; set; }
        public string? StateExam { get; set; }
    }


}
