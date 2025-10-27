using AutoMapper;
using CLINICA.APPLICATION.DTOS.Analysis.Requests;
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
            CreateMap<Analysi, GetAllAnalysisResponseDTO>()
                .ForMember(dest => dest.State, option => option.MapFrom(src => src.State == 1 ? "Activo" : "Inactivo"));

            CreateMap<CreateAnalysisRequestDTO, Analysi>();
            CreateMap<UpdateAnalysisRequestDTO, Analysi>();



            CreateMap<Analysi, GetByIdAnalysisResponseDTO>()
               .ForMember(dest => dest.State, option => option.MapFrom(src => src.State == 1 ? "Activo" : "Inactivo"));

        }
    }
}
