using AutoMapper;
using CLINICA.APPLICATION.DTOS.DocumentTypes.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Queries;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Handlers
{
    public class GetAllDocumentTypeHandler : IRequestHandler<GetAllDocumentTypeQuery, BaseResponse<IEnumerable<GetAllDocumentTypeResponseDTO>>>
    {
        private readonly IGenericRepository<DocumentType> _repository;
        private readonly IMapper _mapper;

        public GetAllDocumentTypeHandler(IGenericRepository<DocumentType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllDocumentTypeResponseDTO>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllDocumentTypeResponseDTO>>();
            try
            {

                var domain = await _repository.GetAllAsync(STP.STPDocumentTypeGetByFilters, new { State = request.State });

                if (domain is not null && domain.Any())
                {

                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllDocumentTypeResponseDTO>>(domain);
                    response.Message = GlobalMessages.GetSuccess;
                }
                else
                {
                    response.IsSuccess =false;
                    response.Message = GlobalMessages.GetNotFound;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
