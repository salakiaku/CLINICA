using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess {  get; set; }
        public string? Message { get; set; }
        public T? Data {  get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<BaseError> Errors { get; set; }

    }
}
