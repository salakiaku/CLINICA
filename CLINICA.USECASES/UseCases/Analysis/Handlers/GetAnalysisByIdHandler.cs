using AutoMapper;
using CLINICA.APPLICATION.DTOS.Analysis.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Queries;
using CLINICA.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Handlers
{
    public class GetAnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetByIdAnalysisResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAnalysisRepository _analysisRepository;

        public GetAnalysisByIdHandler(IMapper mapper, IAnalysisRepository analysisRepository)
        {
            _mapper = mapper;
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<GetByIdAnalysisResponseDTO>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetByIdAnalysisResponseDTO>();

            try
            {
                var domain = await _analysisRepository.GetAnalysisByIdAsync(request.Id);

                if (domain is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Nenhum registro encontrado!";

                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetByIdAnalysisResponseDTO>(domain);
                response.Message = "Consulta realizada com sucesso!";
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
