using AutoMapper;
using CLINICA.APPLICATION.DTOS.Patients.Requests;
using CLINICA.APPLICATION.DTOS.Patients.Responses;
using CLINICA.DOMAIN.Entities;
using CLINICA.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<CreatePatientRequestDTO, Patient>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<UpdatePatientRequestDTO, Patient>()
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<Patient, GetAllPatientResponseDTO>();
            CreateMap<Patient, GetByIdPatientResponseDTO>();

                
                
        }
    }
}
