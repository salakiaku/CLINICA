using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Interface
{
    public interface IAnalysisRepository
    {
       Task<Analysis> GetAnalysisByIdAsync(int analysisId);
        Task<IEnumerable<Analysis>> ListAnalysisAsync();
    }
}
