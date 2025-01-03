using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly PM_App _context;

        public SemesterRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Semester>> GetAllSemestersAsync()
        {
            return await _context.Semesters.ToListAsync();
        }
    }
}
