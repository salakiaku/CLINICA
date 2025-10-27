using CLINICA.APPLICATION.DTOS.Medics.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Medics.Commands
{
    public class CreateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public CreateMedicRequestDTO CreateMedicRequestDTO { get; set; }
    }
    public class UpdateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateMedicRequestDTO UpdateMedicRequestDTO { get; set; }
    }
    public class DeleteMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }

    public class UpdateMedicStateCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int State { get; set; }
    }
}
