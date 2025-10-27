using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Queries
{
    public class GetAllExamsQuery : IRequest<BaseResponse<IEnumerable<GetAllExamsResponseDTO>>>
    {
    }
    public class GetByIdExamQuery: IRequest<BaseResponse<GetByIdExamsResponseDTO>>
    {
        public int Id { get; set; }
    }
}
