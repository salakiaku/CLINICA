using CLINICA.APPLICATION.DTOS.Medics.Responses;
using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using Dapper;
using System.Data;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MedicRepository(ApplicationDbContext context, IUnitOfWork? unitOfWork = null) : base(context, unitOfWork)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDTO>> GetAllMedicAsync(string storedProcedure)
        {
            var connection = _dbContext.CreateConnection();

            var data = await connection.QueryAsync<GetAllMedicResponseDTO>(storedProcedure, commandType: CommandType.StoredProcedure);

            return data;
        }

        public async Task<GetByIdMedicResponseDTO> GetByIdMedicAsync(string storedProcedure, object parameter)
        {
            var connection = _dbContext.CreateConnection();

            var data = await connection.QueryFirstOrDefaultAsync<GetByIdMedicResponseDTO>(storedProcedure, parameter);
            return data!;
        }

       

       

       
    }
}
