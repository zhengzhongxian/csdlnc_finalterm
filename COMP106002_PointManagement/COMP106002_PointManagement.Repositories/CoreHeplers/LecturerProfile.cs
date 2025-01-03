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
    public class LecturerProfile : Profile
    {
        public LecturerProfile()
        {
            CreateMap<Lecturer, LecturerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LecturerNavigation.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.LecturerNavigation.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.LecturerNavigation.PhoneNumber))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.LecturerNavigation.Photo));
            CreateMap<LecturerCreateUpdateDTO, Lecturer>();

            CreateMap<LecturerCreateUpdateDTO, User>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

            CreateMap<Lecturer, SimplifiedLecturerDTO>()
           .ForMember(dest => dest.LecturerName, opt => opt.MapFrom(src => src.LecturerNavigation.Name));
        }
    }
}
