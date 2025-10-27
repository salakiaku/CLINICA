using AutoMapper;
using CLINICA.APPLICATION.DTOS.DocumentTypes.Requests;
using CLINICA.APPLICATION.DTOS.DocumentTypes.Responses;
using CLINICA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.APPLICATION.USECASES.Mappings
{
    public class DocumentTypeMappingProfile : Profile
    {
        public DocumentTypeMappingProfile()
        {
            CreateMap<CreateDocumentTypeRequestDTO, DocumentType>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<DocumentType, GetAllDocumentTypeResponseDTO>();

            CreateMap<UpdateDocumentTypeRequestDTO, DocumentType>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.User));
        }
    }
}
