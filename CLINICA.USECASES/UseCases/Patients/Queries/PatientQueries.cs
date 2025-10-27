using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Patients.Queries
{
    public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDTO>>>
    {
    }
    public class GetByIdPatientQuery : IRequest<BaseResponse<GetByIdPatientResponseDTO>>
    {
        public int Id { get; set; }
    }
}
