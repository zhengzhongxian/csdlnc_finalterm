using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            CreateMap<ExamResult, ExamResultDTO>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.StudentName))
                .ForMember(dest => dest.LecturerName, opt => opt.MapFrom(src => src.Lecturer.LecturerNavigation.Name))
                .ForMember(dest => dest.ExamName, opt => opt.MapFrom(src => src.Exam.Subject.SubjectName));

            CreateMap<ExamResultCU_DTO, ExamResult>();
            CreateMap<ExamResultUpdateDTO, ExamResult>();
        }
    }
}
