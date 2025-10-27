using AutoMapper;
using CLINICA.APPLICATION.DTOS.Medics.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Queries;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Handlers
{
    public class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery, BaseResponse<IEnumerable<GetAllMedicResponseDTO>>>
    {
        private readonly IMedicRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMedicHandler(IMedicRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllMedicResponseDTO>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllMedicResponseDTO>>();

            try
            {
                var domain = await _repository.GetAllMedicAsync(STP.STPMedicsGetByFilters);

                if (domain is not null && domain.Any())
                {
                    response.IsSuccess = true;
                    response.Data = domain;
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

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
