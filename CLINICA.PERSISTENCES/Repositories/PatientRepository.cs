using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext context, IUnitOfWork? unitOfWork = null) : base(context, unitOfWork)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDTO>> GetAllPatientAsync(string storedProcedure)
        {
            var connection = _dbContext.CreateConnection();

            var data = await connection.QueryAsync<GetAllPatientResponseDTO>(storedProcedure, commandType: CommandType.StoredProcedure);

            return data;
        }

        public async Task<GetByIdPatientResponseDTO> GetByIdPatientAsync(string storedProcedure, object parameter)
        {
            var connection = _dbContext.CreateConnection();

            var data = await connection.QuerySingleAsync<GetByIdPatientResponseDTO>(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}
