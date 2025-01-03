using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IEducationSystemRepository
    {
        Task<IEnumerable<EducationSystem>> GetAllEducationSystemsAsync();
    }
}
