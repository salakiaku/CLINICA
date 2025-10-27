using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Handlers
{
    public class UpdateAnalysisStateHandler : IRequestHandler<UpdateAnalysisStateCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Analysi> _analysisRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAnalysisStateHandler(IGenericRepository<Analysi> analysisRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisStateCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseResponse<bool>();
            _unitOfWork.BeginTransaction();

            try
            {
                var domainSuccess = await _analysisRepository.ExecAsync(STP.STPDocumentTypeUpdateState, new { Id = request.Id, State = request.State }, _unitOfWork.Transaction);

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
                responses.Message = GlobalMessages.DeleteFailed+ "\n "+ ex.Message;

                _unitOfWork?.Rollback();
            }

            return responses;
        }
    }
}
