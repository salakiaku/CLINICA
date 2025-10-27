using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Commands;
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

namespace CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Handlers
{
    public class CreateDocumentTypeHandler : IRequestHandler<CreateDocumentTypeCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<DocumentType> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDocumentTypeHandler(IGenericRepository<DocumentType> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<DocumentType>(request.CreateDocumentTypeRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);



                var domainSuccess = await _repository.ExecAsync(STP.STPDocumentTypeCreate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();

                response.IsSuccess = domainSuccess;
                response.Message= domainSuccess?  GlobalMessages.PostSuccess : GlobalMessages.PostFailed;
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
