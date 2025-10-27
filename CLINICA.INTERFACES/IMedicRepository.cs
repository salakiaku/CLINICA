using CLINICA.APPLICATION.DTOS.Medics.Responses;
using CLINICA.DOMAIN.Entities;

namespace CLINICA.DOMAIN.INTERFACES
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDTO>> GetAllMedicAsync(string storedProcedure);
        Task<GetByIdMedicResponseDTO> GetByIdMedicAsync(string storedProcedure, object parameter);
    }
}
