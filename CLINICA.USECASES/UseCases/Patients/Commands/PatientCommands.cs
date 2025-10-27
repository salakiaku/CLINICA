using CLINICA.APPLICATION.DTOS.Patients.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Patients.Commands
{
    public class CreatePatientCommand : IRequest<BaseResponse< bool>>
    {
        public CreatePatientRequestDTO CreatePatientRequestDTO { get; set; }
    }

    public class UpdatePatientRequestCommand : IRequest<BaseResponse<bool>>
    {
        public UpdatePatientRequestDTO UpdatePatientRequestDTO { get; set; }
    } 

    public class UpdatePatientStateCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int State { get; set; }
    }

    public class DeletePatientRequetCommand: IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }


}
