using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("Clinica")!;
        }

        public IDbConnection CreateConnection => new MySqlConnection(_connectionString);
    }
}
    