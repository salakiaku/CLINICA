using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories;
using CLINICA.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfraPersistence(this  IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            #region Repositories

            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            #endregion
            return services;
        }
    }
}
