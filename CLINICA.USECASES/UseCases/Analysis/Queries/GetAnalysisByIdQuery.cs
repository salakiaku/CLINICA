using CLINICA.APPLICATION.DTOS.Analysis.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Queries
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetByIdAnalysisResponseDTO>>
    {
        public int Id { get; set; }
    }
}
