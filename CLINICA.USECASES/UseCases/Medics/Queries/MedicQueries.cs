using CLINICA.APPLICATION.DTOS.Medics.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Queries
{
    public class GetAllMedicQuery :IRequest<BaseResponse< IEnumerable<GetAllMedicResponseDTO>>>
    {
    }
    public class GetByIdMedicQuery: IRequest<BaseResponse<GetByIdMedicResponseDTO>>
    {
        public int Id { get; set; } 
    }

}
