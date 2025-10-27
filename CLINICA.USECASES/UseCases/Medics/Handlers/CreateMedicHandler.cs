using AutoMapper;
using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Patients.Queries;
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

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Handlers
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private IGenericRepository<Medic> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedicHandler(IMapper mapper, IGenericRepository<Medic> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Medic>(request.CreateMedicRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var domainSuccess = await _repository.ExecAsync(STP.STPMedicsCreate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess= domainSuccess;
                response.Data= domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PostSuccess : GlobalMessages.PostFailed;
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
