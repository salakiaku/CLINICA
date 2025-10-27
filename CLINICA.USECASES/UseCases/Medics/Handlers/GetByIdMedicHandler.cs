using CLINICA.APPLICATION.DTOS.Medics.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Medics.Queries;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Handlers
{
    public class GetByIdMedicHandler : IRequestHandler<GetByIdMedicQuery, BaseResponse<GetByIdMedicResponseDTO>>
    {
        private readonly IMedicRepository _repository;

        public GetByIdMedicHandler(IMedicRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<GetByIdMedicResponseDTO>> Handle(GetByIdMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetByIdMedicResponseDTO>();

            try
            {
                var data = await _repository.GetByIdMedicAsync(STP.STPMedicsGetById, new { Id = request.Id });
           
                if(data is not null)
                {
                    response.IsSuccess = true;
                    response.Data = data;
                    response.Message = GlobalMessages.GetSuccess;
                }
                else
                {
                    response.IsSuccess = false;
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
