using CLINICA.APPLICATION.DTOS.Specialties.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Specialties.Commands
{
    public class CreateSpecialtyCommand : IRequest<BaseResponse<bool>>
    {
        public CreateSpecialtyRequestDTO CreateSpecialtyRequestDTO { get; set; }
    }

}
