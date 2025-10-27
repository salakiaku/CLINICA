using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using FluentValidation.TestHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Patients.Handlers
{
    public class UpdatePatientStateHandler : IRequestHandler<UpdatePatientStateCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Patient> _repository;

        public UpdatePatientStateHandler(IUnitOfWork unitOfWork, IGenericRepository<Patient> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdatePatientStateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                _unitOfWork.BeginTransaction();

                var domainSuccess = await _repository.ExecAsync(STP.STPPatientsUpdateState, new { Id = request.Id, State = request.State });

               response.IsSuccess = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PutSuccess : GlobalMessages.PutFailed;
                response.Data = domainSuccess;

                _unitOfWork.Commit();
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
