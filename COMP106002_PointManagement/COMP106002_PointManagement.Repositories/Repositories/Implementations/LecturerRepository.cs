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
    public class LecturerRepository : ILecturerRepository
    {
        private readonly PM_App _context;

        public LecturerRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lecturer>> GetAllLecturersAsync()
        {
            return await _context.Lecturers
                .Include(l => l.LecturerNavigation) // Bao gồm thông tin từ bảng User
                .ToListAsync();
        }

        public async Task<Lecturer?> GetLecturerByIdAsync(string id)
        {
            return await _context.Lecturers
                .Include(l => l.LecturerNavigation) 
                .FirstOrDefaultAsync(l => l.LecturerId == id);
        }

        public async Task CreateLecturerAsync(Lecturer lecturer)
        {
            await _context.Lecturers.AddAsync(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLecturerAsync(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLecturerAsync(string id)
        {
            var lecturer = await GetLecturerByIdAsync(id);
            if (lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEmailOrPhoneExistsAsync(string email, string phoneNumber, string? excludeLecturerId = null)
        {
            return await _context.Users.AnyAsync(u =>
            (u.Email == email || u.PhoneNumber == phoneNumber) &&
            (excludeLecturerId == null || u.UserId != excludeLecturerId));
        }
    }
}
