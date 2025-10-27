using CLINICA.APPLICATION.USECASES.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Commons.Exceptions
{
    public class MyValidationException : Exception
    {
        public IEnumerable<BaseError>? Errors { get; }

        public MyValidationException() : base()
        {
                Errors = new List<BaseError>();
        }

        public MyValidationException(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }
    }
}
