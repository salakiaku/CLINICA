using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.DTOS.Analysis.Responses;


namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Queries
{
    public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>>
    { 
    }
}
