using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(string id);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
        Task<bool> IsEmailOrPhoneExistsAsync(string email, string phoneNumber, string? excludeStudentId = null);
        Task<string> GenerateStudentIdAsync(string? academicYearId, string? educationSystemId, string? facultyId, int locationId);
        Task<IEnumerable<Student>> GetStudentsByFacultyIdAsync(string facultyId);
        Task<IEnumerable<StudentScoreDTO>> GetStudentScoresInSemesterAsync(string studentId, int semesterId);
        Task<List<Student>> Search(string search, int location_id);
        Task<List<Student>> GetStudentByFacultyAndAcademicYear(string facultyId, string academicyear_id, int location_id);
        Task<IEnumerable<Student>> GetAllStudentsByLocationAsync(int location_id);
    }
}
