using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDTO, User>()
             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)) 
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username)) 
             .ForMember(dest => dest.Role, opt => opt.Ignore()) 
             .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<ChangePasswordDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
