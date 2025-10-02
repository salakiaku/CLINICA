using CLINICA.DOMAIN.Entities;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using CLINICA.Interface;
using Dapper;
using System.Data;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Analysis> GetAnalysisByIdAsync(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisById";

            var parameters = new DynamicParameters();
            parameters.Add("Id", analysisId);

            var analysis = await connection
              .QuerySingleOrDefaultAsync<Analysis>(query, param:parameters, commandType:CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysisAsync()
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisList";
            var analysis = await connection.QueryAsync<Analysis>(query, CommandType.StoredProcedure);
            return analysis;

        }
    }
}
