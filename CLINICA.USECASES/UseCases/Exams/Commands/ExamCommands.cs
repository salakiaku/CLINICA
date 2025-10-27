using CLINICA.APPLICATION.DTOS.Exams.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Commands
{
    public class CreateExamCommand : IRequest<BaseResponse<bool>>
    {
        public CreateExamRequestDTO CreateExamRequestDTO { get; set; }
    }
    public class UpdateExamCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateExamRequestDTO UpdateExamRequestDTO { get; set; }
    }
    public class DeleteExamCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
    public class UpdateExamsChangeCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { set; get; }
        public int State { set; get; }
    }
}
