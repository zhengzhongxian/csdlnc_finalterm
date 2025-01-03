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
    public class OnlyGetallProfile : Profile
    {
        public OnlyGetallProfile()
        {
            CreateMap<Room, RoomDTO>();
            CreateMap<AcademicYear, AcademicYearDTO>();
            CreateMap<EducationSystem, EducationSystemDTO>();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
