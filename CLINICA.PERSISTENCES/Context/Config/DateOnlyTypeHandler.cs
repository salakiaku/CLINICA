using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.INFRASTRUTURE.PERSISTENCES.Context.Config
{
    public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            // Converter para formato compatível com o banco (yyyy-MM-dd)
            parameter.Value = value.ToDateTime(TimeOnly.MinValue);
            parameter.DbType = DbType.Date; // Apenas a parte da data
        }

        public override DateOnly Parse(object value)
        {
            return DateOnly.FromDateTime(Convert.ToDateTime(value));
        }
    }
}
