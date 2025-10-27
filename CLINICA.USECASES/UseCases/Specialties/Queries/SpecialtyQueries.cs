using CLINICA.APPLICATION.DTOS.Specialties.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Specialties.Queries
{
    public class GetAllSpecialtyQuery: IRequest<BaseResponse<IEnumerable<GetAllSpecialtyResponseDTO>>>
    {
    }
}
