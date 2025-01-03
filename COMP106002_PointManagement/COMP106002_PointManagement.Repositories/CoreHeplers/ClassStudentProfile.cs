using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class ClassStudentProfile : Profile
    {
        public ClassStudentProfile()
        {
            CreateMap<ClassStudent, ClassStudentDTO>()
                .ForMember(dest => dest.Score,
                    opt => opt.MapFrom(src => src.Score.HasValue ? src.Score.ToString() : "N/A"))
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src => src.Student != null ? src.Student.StudentName : "N/A"))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));

            CreateMap<ClassStudentCreateDTO, ClassStudent>();
            CreateMap<ClassStudentUpdateDTO, ClassStudent>();
        }
    }
}
