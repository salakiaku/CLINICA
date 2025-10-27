using AutoMapper;
using CLINICA.APPLICATION.DTOS.Medics.Requests;
using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<CreateMedicRequestDTO, Medic>()
                .ForMember(dest => dest.CreatedBy, option => option.MapFrom(src => src.User));

            CreateMap<UpdateMedicRequestDTO, Medic>()
                .ForMember(dest => dest.UpdatedBy, option => option.MapFrom(src => src.User));
        }
    }
}
