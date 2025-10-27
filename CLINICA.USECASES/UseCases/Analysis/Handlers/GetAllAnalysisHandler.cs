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
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>>
    {
        private readonly IGenericRepository<Analysi> _analysisRepository;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IGenericRepository<Analysi> analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>();
            try
            {

                var domain = await _analysisRepository.GetAllAsync(STP.STPAnalysisGetByFilters,null! );

                if(domain is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDTO>>(domain);
                    response.Message = GlobalMessages.GetSuccess;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.GetNotFound;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess=false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
