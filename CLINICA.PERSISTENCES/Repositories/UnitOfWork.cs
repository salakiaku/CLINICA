using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using System.Data;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbConnection _connection;
        private IDbTransaction? _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _connection = _context.CreateConnection();
        }

        public void BeginTransaction()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction == null)
                    throw new InvalidOperationException("Nenhuma transação foi iniciada.");

                if (_connection.State != ConnectionState.Open)
                    _connection.Open(); // garante que está aberta

                _transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer commit: {ex.Message}");
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _connection.State == ConnectionState.Open)
                    _transaction.Rollback();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer rollback: {ex.Message}");
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            DisposeTransaction();

            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection.Dispose();
            }
        }

        public IDbTransaction Transaction => _transaction!;
        public IDbConnection Connection => _connection!;
    }
}
