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
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Patient> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientHandler(IGenericRepository<Patient> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Patient>(request.CreatePatientRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var domainSuccess = await _repository.ExecAsync(STP.STPPatientsCreate, parameters, _unitOfWork.Transaction);

                response.IsSuccess = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PostSuccess : GlobalMessages.PostFailed;
                response.Data = domainSuccess;

                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

                _unitOfWork?.Rollback();
            }

            return response;
        }
    }
}
