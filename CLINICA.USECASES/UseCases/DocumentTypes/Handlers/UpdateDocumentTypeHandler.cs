using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Handlers
{
    public class UpdateDocumentTypeHandler : IRequestHandler<UpdateDocumentTypeCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<DocumentType> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDocumentTypeHandler(IGenericRepository<DocumentType> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<DocumentType>(request.UpdateDocumentTypeRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);



                var domainSuccess = await _repository.ExecAsync(STP.STPDocumentTypeUpdate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess = domainSuccess;
                response.Message = domainSuccess ? GlobalMessages.PutSuccess : GlobalMessages.PutFailed;
                response.Data = domainSuccess;
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
