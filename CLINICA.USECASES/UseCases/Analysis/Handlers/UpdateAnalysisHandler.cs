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
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Analysi> _analysisRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAnalysisHandler(IGenericRepository<Analysi> analysisRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            _unitOfWork.BeginTransaction();

            try
            {
                var domainSucess = await _analysisRepository.ExecAsync(STP.STPAnalysisUpdate, (_mapper.Map<Analysi>(request.UpdateAnalysisRequestDTO)));

                if (domainSucess)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.PutSuccess;
                }
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
