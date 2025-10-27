using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using Dapper;
using System.Data;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
{
    public class ExamsRepository : GenericRepository<Exam>,IExamsRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamsRepository(ApplicationDbContext context, IUnitOfWork? unitOfWork = null) : base(context, unitOfWork)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamsResponseDTO>> GetAllExamsAsync(string storedProcedure)
        {
            var connection =  _context.CreateConnection();

            var result = await connection.QueryAsync<GetAllExamsResponseDTO>(storedProcedure, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
