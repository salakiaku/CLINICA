using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using Dapper;
using System.Data;



    namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
    {
        public class GenericRepository<T> : IGenericRepository<T> where T : EntiBase
        {
            private readonly ApplicationDbContext _context;
            private readonly IUnitOfWork? _unitOfWork;

            public GenericRepository(ApplicationDbContext context, IUnitOfWork? unitOfWork = null)
            {
                _context = context;
                _unitOfWork = unitOfWork;
            }

            private IDbConnection GetConnection(IDbTransaction? transaction)
            {
                // Usa a conexão da transação se existir, senão cria uma nova
                return transaction?.Connection ?? _unitOfWork?.Connection ?? _context.CreateConnection();
            }

            public async Task<bool> ExecAsync(string storedProcedure, object parameters, IDbTransaction? transaction = null)
            {
                var connection = GetConnection(transaction);
                var objectParam = new DynamicParameters(parameters);

                var affectedRows = await connection.ExecuteAsync(
                    storedProcedure,
                    param: objectParam,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction
                );

                return affectedRows > 0;
            }

            public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure, object? parameters = null, IDbTransaction? transaction = null)
            {
                var connection = GetConnection(transaction);

                return await connection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction
                );
            }

            public async Task<T?> GetByIdAsync(string storedProcedure, object parameters, IDbTransaction? transaction = null)
            {
                var connection = GetConnection(transaction);
                var objectParams = new DynamicParameters(parameters);

                return await connection.QueryFirstOrDefaultAsync<T>(
                    storedProcedure,
                    param: objectParams,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction
                );
            }
        }
    }


