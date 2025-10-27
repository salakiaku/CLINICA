using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.INTERFACES
{
    public interface IExamsRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamsResponseDTO>> GetAllExamsAsync(string storedProcedure);
    }
}
