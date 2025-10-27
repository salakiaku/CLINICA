using AutoMapper;
using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Queries;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Handlers
{
    public class GetExamByIdHandler : IRequestHandler<GetByIdExamQuery, BaseResponse<GetByIdExamsResponseDTO>>
    {
        private readonly IGenericRepository<Exam> _examsRepository;
        private readonly IMapper _mapper;

        public GetExamByIdHandler(IGenericRepository<Exam> examsRepository, IMapper mapper)
        {
            _examsRepository = examsRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetByIdExamsResponseDTO>> Handle(GetByIdExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetByIdExamsResponseDTO>();
            try
            {
                var exam = await _examsRepository.GetByIdAsync(STP.STPExamsGetById, new {request.Id});

                if (exam is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<GetByIdExamsResponseDTO>(exam);
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
