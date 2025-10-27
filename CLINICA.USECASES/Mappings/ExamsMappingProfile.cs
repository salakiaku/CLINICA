using AutoMapper;
using CLINICA.APPLICATION.DTOS.Exams.Requests;
using CLINICA.APPLICATION.DTOS.Exams.Responses;
using CLINICA.DOMAIN.Entities;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class ExamsMappingProfile : Profile
    {
        public ExamsMappingProfile()
        {
            CreateMap<Exam,GetByIdExamsResponseDTO>();
            CreateMap<CreateExamRequestDTO, Exam>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<UpdateExamRequestDTO, Exam>()
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.User));
        }
    }
}
