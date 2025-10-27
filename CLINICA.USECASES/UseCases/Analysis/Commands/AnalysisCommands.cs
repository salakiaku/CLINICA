using CLINICA.APPLICATION.DTOS.Analysis.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public CreateAnalysisRequestDTO CreateAnalysisRequestDTO { get; set; }
    }
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateAnalysisRequestDTO UpdateAnalysisRequestDTO { get; set; }
    }
    public class UpdateAnalysisStateCommand : IRequest<BaseResponse<bool>>
    {
        public int Id {  set; get; }
        public int State {  set; get; }
    }
}
