using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Queries;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Handlers
{
    public class GetAllExamsHandler : IRequestHandler<GetAllExamsQuery, BaseResponse<IEnumerable<GetAllExamsResponseDTO>>>
    {
        private readonly IExamsRepository _examsRepository;

        public GetAllExamsHandler(IExamsRepository examsRepository)
        {
            _examsRepository = examsRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamsResponseDTO>>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamsResponseDTO>>();
            try
            {
                var exams = await _examsRepository.GetAllExamsAsync(STP.STPExamsGetByFilters);

                if (exams is not null && exams.Any())
                {
                    response.IsSuccess = true;
                    response.Data = exams;
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
