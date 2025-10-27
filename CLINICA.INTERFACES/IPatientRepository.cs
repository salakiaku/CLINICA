using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.DOMAIN.Entities;

namespace CLINICA.DOMAIN.INTERFACES
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDTO>> GetAllPatientAsync(string storedProcedure);
        Task<GetByIdPatientResponseDTO> GetByIdPatientAsync(string storedProcedure, object parameter);
    }
}
