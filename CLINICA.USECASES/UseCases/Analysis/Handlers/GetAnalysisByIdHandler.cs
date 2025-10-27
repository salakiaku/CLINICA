using AutoMapper;
using CLINICA.APPLICATION.DTOS.Analysis.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Queries;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Handlers
{
    public class GetAnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetByIdAnalysisResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Analysi> _analysisRepository;

        public GetAnalysisByIdHandler(IMapper mapper, IGenericRepository<Analysi> analysisRepository)
        {
            _mapper = mapper;
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<GetByIdAnalysisResponseDTO>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetByIdAnalysisResponseDTO>();

            try
            {
                var domain = await _analysisRepository.GetByIdAsync(STP.STPAnalysisGetById, new { id = request.AnalysisId});

                if (domain is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.GetNotFound;

                }
                else
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<GetByIdAnalysisResponseDTO>(domain);
                    response.Message = GlobalMessages.GetSuccess;
                }
                    
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
