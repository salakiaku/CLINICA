using AutoMapper;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Specialties.Commands;
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

namespace CLINICA.APPLICATION.USECASES.UseCases.Specialties.Handlers
{
    public class CreateSpecialtyHandler : IRequestHandler<CreateSpecialtyCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Specialty> _repository;
        private readonly IMapper _mapper;

        public CreateSpecialtyHandler(IUnitOfWork unitOfWork, IGenericRepository<Specialty> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _mapper.Map<Specialty>(request.CreateSpecialtyRequestDTO);
                var parameters = GetEntityProperties.GetPropertiesWithValues(domain);

                var result = await _repository.ExecAsync(STP.STPSpecialitiesCreate, parameters, _unitOfWork.Transaction);
                _unitOfWork.Commit();

                response.IsSuccess = result;
                response.Data = result;
                response.Message = result ? GlobalMessages.PostSuccess : GlobalMessages.PostFailed;


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
 