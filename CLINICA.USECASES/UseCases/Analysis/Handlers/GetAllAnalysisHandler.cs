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
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDTO>>();
            try
            {

                var domain = await _analysisRepository.ListAnalysisAsync();

                if(domain is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDTO>>(domain);
                    response.Message = domain.Count() > 1 ? $"{domain.Count()} Registros encontrados" : $"{response.Data.Count()} Registro encontrado";
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
