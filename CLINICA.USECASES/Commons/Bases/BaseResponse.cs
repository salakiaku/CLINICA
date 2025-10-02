using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess {  get; set; }
        public string? Message { get; set; }
        public T? Data {  get; set; }

        public IEnumerable<BaseError> Errors { get; set; }

    }
}
