using CLINICA.APPLICATION.DTOS.DocumentTypes.Requests;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.UseCases.DocumentTypes.Commands
{
    public class CreateDocumentTypeCommand :  IRequest<BaseResponse<bool>>
    {
        public CreateDocumentTypeRequestDTO CreateDocumentTypeRequestDTO { get; set; }
    }

    public class UpdateDocumentTypeCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateDocumentTypeRequestDTO  UpdateDocumentTypeRequestDTO { get; set; }
    }

    public class UpdateDocumentTypeStateCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int State { get; set; }
    }
}
