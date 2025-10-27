using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Handlers
{
    public class DeleteMedicHandler : IRequestHandler<DeleteMedicCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private IGenericRepository<Medic> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicHandler(IMapper mapper, IGenericRepository<Medic> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();


                var domainSuccess = await _repository.ExecAsync(STP.STPMedicsDelete, new {Id = request.Id}, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess = domainSuccess;
                response.Data = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.DeleteSuccess : GlobalMessages.DeleteFailed;
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
