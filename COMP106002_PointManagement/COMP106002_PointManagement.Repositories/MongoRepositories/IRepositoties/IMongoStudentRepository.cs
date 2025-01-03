using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties
{
    public interface IMongoStudentRepository
    {
        Task<List<MgStudentDTO>> GetAllStudentsAsync(int locationId);
        Task<MgStudentDTO> GetStudentByIdAsync(string studentId);
        Task AddStudentAsync(MgStudentDTO student);
        Task UpdateStudentAsync(MgStudentDTO student);
        Task DeleteStudentAsync(string studentId);
        //Task<string> GenerateStudentIdAsync(string? academicYearId, string? educationSystemId, string? facultyId, int locationId);
    }
}
