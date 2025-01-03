using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.AcademicYearName, opt => opt.MapFrom(src => src.IdAcademicYearNavigation.YearAcademicYear))
                .ForMember(dest => dest.EducationSystemName, opt => opt.MapFrom(src => src.IdEsNavigation.NameEs))
                .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName)).ReverseMap();

            CreateMap<StudentCU_DTO, Student>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<StudentUpdateDTO, Student>()
           .ForMember(dest => dest.IdAcademicYear, opt => opt.Ignore())
           .ForMember(dest => dest.IdEs, opt => opt.Ignore())
           .ForMember(dest => dest.FacultyId, opt => opt.Ignore())
           .ForMember(dest => dest.Dayofbirth, opt => opt.MapFrom(src => src.Dayofbirth.HasValue
               ? DateOnly.FromDateTime(src.Dayofbirth.Value)
               : (DateOnly?)null));

            CreateMap<Student, OtherStudentDTO>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.StudentName));

            CreateMap<StudentScoreDTO, StudentScoreDTO>();
            CreateMap<StudentCU_DTO, MgStudentDTO>().ReverseMap();
            CreateMap<Student, MgStudentDTO>().ReverseMap();
            CreateMap<Student,StudentWithMetadataDTO>().ReverseMap();
        }
    }
}
