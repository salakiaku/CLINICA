using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.UTILITIES.HelperExtensions
{
    public static class GetEntityProperties
    {
        /// Metódo para pegar somente valores com as suas respectivas propriedades na sua execução da stored procedure(será passado como parameter)
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            var entityParams = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {

                object value = property.GetValue(entity)!;

                if(value != null)
                    entityParams[property.Name] = value;
            }
            return entityParams;
        }
    }
}
