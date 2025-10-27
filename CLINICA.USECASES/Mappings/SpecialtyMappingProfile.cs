using AutoMapper;
using CLINICA.APPLICATION.DTOS.Specialties.Requests;
using CLINICA.APPLICATION.DTOS.Specialties.Responses;
using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class SpecialtyMappingProfile : Profile
    {
        public SpecialtyMappingProfile()
        {
            CreateMap<Specialty, GetAllSpecialtyResponseDTO>();

            CreateMap<CreateSpecialtyRequestDTO, Specialty>()
                .ForMember(dest => dest.CreatedBy, option => option.MapFrom(src => src.User));
        }
    }
}
