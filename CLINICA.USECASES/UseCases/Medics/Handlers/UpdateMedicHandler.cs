using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Handlers
{
    public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private IGenericRepository<Medic> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMedicHandler(IMapper mapper, IGenericRepository<Medic> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Medic>(request.UpdateMedicRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var domainSuccess = await _repository.ExecAsync(STP.STPMedicsUpdate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess = domainSuccess;
                response.Data = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PutSuccess : GlobalMessages.PutFailed;
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

    public class UpdateMedicStateHandler : IRequestHandler<UpdateMedicStateCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private IGenericRepository<Medic> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMedicStateHandler(IMapper mapper, IGenericRepository<Medic> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateMedicStateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();


                var domainSuccess = await _repository.ExecAsync(STP.STPMedicsUpdateState, new { Id =request.Id , State = request.State}, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess = domainSuccess;
                response.Data = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PutSuccess : GlobalMessages.PutFailed;
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
