using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Analysis.Commands;
using CLINICA.APPLICATION.USECASES.UseCases.Exams.Commands;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using CLINICA.UTILITIES.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Exams.Handlers
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, BaseResponse<bool>>
    {
        private readonly IGenericRepository<Exam> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExamHandler(IGenericRepository<Exam> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Exam>(request.CreateExamRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var domainSucess = await _repository.ExecAsync(STP.STPExamsCreate, parameters, _unitOfWork.Transaction);

                _unitOfWork.Commit();

              
                    response.IsSuccess = domainSucess;
                    response.Message = domainSucess ?  GlobalMessages.PostSuccess : GlobalMessages.PostFailed;


            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;

                _unitOfWork.Rollback();
            }
            return response;
        }
    }
}
