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
    public class LecturerSubjectProfile : Profile
    {
        public LecturerSubjectProfile()
        {
            CreateMap<LecturerSubject, LecturerSubjectDTO>()
                .ForMember(dest => dest.LecturerName, opt => opt.MapFrom(src => src.Lecturer.LecturerNavigation.Name));

            CreateMap<LecturerSubjectCreateDTO, LecturerSubject>();
            CreateMap<LecturerSubjectUpdateDTO, LecturerSubject>();
        }
    }
}
