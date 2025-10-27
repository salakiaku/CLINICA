using AutoMapper;
using CLINICA.APPLICATION.DTOS.Specialties.Responses;
using CLINICA.APPLICATION.USECASES.Commons.Bases;
using CLINICA.APPLICATION.USECASES.UseCases.Specialties.Queries;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.INTERFACES;
using CLINICA.UTILITIES.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLINICA.UTILITIES.Constants.StoredProcedures;

namespace CLINICA.APPLICATION.USECASES.UseCases.Specialties.Handlers
{
    public class GetAllSpecialtyHandler : IRequestHandler<GetAllSpecialtyQuery, BaseResponse<IEnumerable<GetAllSpecialtyResponseDTO>>>
    {
        private readonly IGenericRepository<Specialty> _specialtyRepository;
        private readonly IMapper _mapper;

        public GetAllSpecialtyHandler(IGenericRepository<Specialty> specialtyRepository, IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllSpecialtyResponseDTO>>> Handle(GetAllSpecialtyQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllSpecialtyResponseDTO>>();

            try
            {
                var domain = await _specialtyRepository.GetAllAsync(STP.STPSpecialitiesGetByFilters, new { });

                if (domain is not null && domain.Any())
                {

                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllSpecialtyResponseDTO>>(domain);
                    response.Message = GlobalMessages.GetSuccess;
                }
                else
                {
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
