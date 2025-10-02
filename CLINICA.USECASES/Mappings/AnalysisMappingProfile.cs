using AutoMapper;
using CLINICA.APPLICATION.DTOS.Analysis.Responses;
using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class AnalysisMappingProfile :  Profile
    {
        
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDTO>()
                .ForMember(dest => dest.State, option => option.MapFrom(src => src.State == 1 ? "Activo" : "Inactivo"));

            CreateMap<Analysis, GetByIdAnalysisResponseDTO>()
               .ForMember(dest => dest.State, option => option.MapFrom(src => src.State == 1 ? "Activo" : "Inactivo"));

        }
    }
}
