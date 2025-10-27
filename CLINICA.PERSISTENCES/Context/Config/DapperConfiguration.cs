using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Context.Config
{
    public class DapperConfiguration
    {
        public static void Configure()
        {
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        }
    }
}
