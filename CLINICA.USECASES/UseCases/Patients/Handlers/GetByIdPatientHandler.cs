using AutoMapper;
using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Queries;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Patients.Handlers
{
    public class GetByIdPatientHandler : IRequestHandler<GetByIdPatientQuery, BaseResponse<GetByIdPatientResponseDTO>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdPatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetByIdPatientResponseDTO>> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetByIdPatientResponseDTO>();

            try
            {
                var domain = await _repository.GetByIdPatientAsync(STP.STPPatientsGetById, new {request.Id});

                if (domain is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<GetByIdPatientResponseDTO>(domain);
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
