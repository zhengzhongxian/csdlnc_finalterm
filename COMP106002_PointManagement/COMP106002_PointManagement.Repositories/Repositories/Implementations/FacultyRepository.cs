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
    public class FacultyRepository : IFacultyRepository
    {
        private readonly PM_App _context;

        public FacultyRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty?> GetFacultyByIdAsync(string id)
        {
            return await _context.Faculties.FirstOrDefaultAsync(f => f.FacultyId == id);
        }
    }
}
