using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.DOMAIN.INTERFACES
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void Dispose();
        void BeginTransaction();
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }


    }
}
