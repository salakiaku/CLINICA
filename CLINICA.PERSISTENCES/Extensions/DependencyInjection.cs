using CLINICA.DOMAIN.INTERFACES;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Context.Config;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Repositories;
using Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfraPersistence(this  IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());//para converter 
            services.AddScoped<ApplicationDbContext>();

            #region Repositories

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExamsRepository, ExamsRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicRepository, MedicRepository>();
            #endregion
            return services;
        }
    }
}
