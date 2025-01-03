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
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.StudentName : "N/A"))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src =>
                src.Exam != null && src.Exam.ExamResults != null
                    ? src.Exam.ExamResults
                        .Where(er => er.StudentId == src.StudentId)
                        .Select(er => er.Score)
                        .FirstOrDefault()
                    : (decimal?)null))
            .ForMember(dest => dest.LecturerName, opt => opt.MapFrom(src =>
                src.Exam != null && src.Exam.ExamResults != null
                    ? src.Exam.ExamResults
                        .Where(er => er.StudentId == src.StudentId && er.Lecturer != null && er.Lecturer.LecturerNavigation != null)
                        .Select(er => er.Lecturer.LecturerNavigation.Name)
                        .FirstOrDefault() ?? "N/A"
                    : "N/A"))
            .ForMember(dest => dest.LecturerId, opt => opt.MapFrom(src =>
                src.Exam != null && src.Exam.ExamResults != null
                    ? src.Exam.ExamResults
                        .Where(er => er.StudentId == src.StudentId && er.Lecturer != null)
                        .Select(er => er.Lecturer.LecturerId)
                        .FirstOrDefault()
                    : null))
            .ForMember(dest => dest.ResultId, opt => opt.MapFrom(src =>
                src.Exam != null && src.Exam.ExamResults != null
                    ? src.Exam.ExamResults
                        .Where(er => er.StudentId == src.StudentId)
                        .Select(er => er.ResultId)
                        .FirstOrDefault()
                    : null));

            CreateMap<ScheduleCreateUpdateDTO, Schedule>();
        }
    }
}
