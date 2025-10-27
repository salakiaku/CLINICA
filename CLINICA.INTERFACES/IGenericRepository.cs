using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.INTERFACES
{
    public interface IGenericRepository<T> where T : EntiBase
    {

        Task<IEnumerable<T>> GetAllAsync(string storedProcedure, object parameters, IDbTransaction? transaction = null);
        Task<T> GetByIdAsync(string storedProcedure, object parameters, IDbTransaction? transaction = null);

        Task<bool> ExecAsync(string storedProcedure, object parameters, IDbTransaction? transaction = null);
    }
}
