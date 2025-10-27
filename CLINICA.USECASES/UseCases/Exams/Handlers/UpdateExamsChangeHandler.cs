using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Handlers
{
    public class UpdateExamsChangeHandler : IRequestHandler<UpdateExamsChangeCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Exam> _analysisRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExamsChangeHandler(IGenericRepository<Exam> analysisRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateExamsChangeCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseResponse<bool>();
            _unitOfWork.BeginTransaction();

            try
            {
                var domainSuccess = await _analysisRepository.ExecAsync(STP.STPExamsUpdateState, new { Id = request.Id, State = request.State }, _unitOfWork.Transaction);

                if (domainSuccess)
                {
                    responses.IsSuccess = true;
                    responses.Data = true;
                    responses.Message = GlobalMessages.PutSuccess;
                }

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                responses.IsSuccess = false;
                responses.Message = GlobalMessages.DeleteFailed + "\n " + ex.Message;

                _unitOfWork?.Rollback();
            }

            return responses;
        }
    }
}
