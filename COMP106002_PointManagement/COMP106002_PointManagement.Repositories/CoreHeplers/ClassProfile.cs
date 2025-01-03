using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDTO>()
                 .ForMember(dest => dest.EsName, opt => opt.MapFrom(src => src.IdEsNavigation != null ? src.IdEsNavigation.NameEs : "N/A"))
                 .ForMember(dest => dest.LecturerName, opt => opt.MapFrom(src =>
                     src.IdLectuerSubjectNavigation != null && src.IdLectuerSubjectNavigation.Lecturer != null
                         ? src.IdLectuerSubjectNavigation.Lecturer.LecturerNavigation.Name
                         : "N/A")) 
                 .ForMember(dest => dest.LecturerId, opt => opt.MapFrom(src =>
                     src.IdLectuerSubjectNavigation != null && src.IdLectuerSubjectNavigation.Lecturer != null
                         ? src.IdLectuerSubjectNavigation.Lecturer.LecturerId
                         : "N/A")) 
                 .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src =>
                     src.IdLectuerSubjectNavigation != null && src.IdLectuerSubjectNavigation.Subject != null
                         ? src.IdLectuerSubjectNavigation.Subject.SubjectName
                         : "N/A")) 
                 .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src =>
                     src.IdLectuerSubjectNavigation != null && src.IdLectuerSubjectNavigation.Subject != null
                         ? src.IdLectuerSubjectNavigation.Subject.SubjectId
                         : "N/A")); 

            CreateMap<ClassCreateDTO, Class>();
            CreateMap<ClassUpdateDTO, Class>();
            CreateMap<Class, MgClass>().ReverseMap();
        }
    }
}
