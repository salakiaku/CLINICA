using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Patients.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientRequestCommand, BaseResponse<bool>>
    {
        private readonly IPatientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IPatientRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdatePatientRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var mapped = _mapper.Map<Patient>(request.UpdatePatientRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(mapped);


                var domainSucess = await _repository.ExecAsync(STP.STPPatientsUpdate, parameters, _unitOfWork.Transaction );


                _unitOfWork.Commit();


                response.IsSuccess = domainSucess;
                response.Data = domainSucess;
                response.Message = domainSucess? GlobalMessages.PutSuccess : GlobalMessages.PutFailed;
                 
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;

                _unitOfWork.Rollback();

            }

            return response;
        }
    }
}
