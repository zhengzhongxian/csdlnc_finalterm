using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.RoomName))
                .ForMember(dest => dest.InvigilatorName, opt => opt.MapFrom(src => src.Invigilator.LecturerNavigation.Name)).ReverseMap();

            CreateMap<ExamCreateUpdateDTO, Exam>().ReverseMap();
            CreateMap<Exam, MgExam>().ReverseMap();

            CreateMap<Room, RoomDTO>();
            CreateMap<Room,Create_RoomDTO>().ReverseMap();
            CreateMap<Room, MgRoom>().ReverseMap();
        }
    }
}
