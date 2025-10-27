using CLINICA.APPLICATION.DTOS.DocumentTypes.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Queries
{
    public class GetAllDocumentTypeQuery : IRequest<BaseResponse<IEnumerable<GetAllDocumentTypeResponseDTO>>>
    {
        public int State { get; set; } = 1;
    }
}
