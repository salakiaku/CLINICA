using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Handlers
{
    public class UpdateExamHandler : IRequestHandler<UpdateExamCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Exam> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExamHandler(IGenericRepository<Exam> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Exam>(request.UpdateExamRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var domainSucess = await _repository.ExecAsync(STP.STPExamsUpdate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();


                response.IsSuccess = domainSucess;
                response.Message = domainSucess ? GlobalMessages.PutSuccess : GlobalMessages.PostFailed;


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
