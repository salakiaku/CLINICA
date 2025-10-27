using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Analysis.Handlers
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Analysi> _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IGenericRepository<Analysi> analysisRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<bool>();
           
            _unitOfWork.BeginTransaction();
            try
            {
                var model = _mapper.Map<Analysi>(request.CreateAnalysisRequestDTO);

                //pega somente as propriedades com valores diferentes de Null
                var parameters = model.GetPropertiesWithValues();
                var domainSucess = await _analysisRepository.ExecAsync(STP.STPAnalysisCreate, parameters, _unitOfWork.Transaction);

                if (domainSucess)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.PostSuccess;
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
