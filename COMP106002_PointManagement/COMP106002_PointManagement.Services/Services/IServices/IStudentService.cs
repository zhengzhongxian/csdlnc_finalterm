using COMP106002_PointManagement.Repositories.CoreHeplers;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IStudentService
    {
        Task<ServiceResponse<IEnumerable<StudentDTO>>> GetAllStudentsAsync();
        Task<ServiceResponse<StudentDTO?>> GetStudentByIdAsync(string id);
        Task<ServiceResponse<bool>> CreateStudentAsync(StudentCU_DTO studentDto, string madeby, int location_id);
        Task<ServiceResponse<bool>> UpdateStudentAsync(string made_by, string id, StudentUpdateDTO studentDto);
        Task<ServiceResponse<bool>> DeleteStudentAsync(string made_by, string id);
        Task<ServiceResponse<IEnumerable<StudentDTO>>> GetStudentsByFacultyIdAsync(string facultyId);
        Task<ServiceResponse<IEnumerable<StudentScoreDTO>>> GetStudentScoresInSemesterAsync(string studentId, int semesterId);
        Task<ServiceResponse<IEnumerable<MgStudentDTO>>> GetStudentInMongo(int locationId);
        Task<ServiceResponse<bool>> DeleteStudentinMongo(string studentId, string madeby);
        Task<ServiceResponse<List<StudentWithMetadataDTO>>> GetStudentWithMetadataAsync();
        Task<ServiceResponse<bool>> Transfer(string transfer_by, int location_id);
        Task<ServiceResponse<bool>> Restore(string restore_by, int location_id);
        Task<ServiceResponse<bool>> CreateStudentinSqlAsync(StudentCU_DTO studentDto, string made_by, int location_id);
        Task<ServiceResponse<List<StudentDTO>>> GetStudentByFacultyAndAcademicYear(string facultyId, string academicyear_id, int location_id);
        Task<ServiceResponse<List<StudentDTO>>> Search(string search, int location_id);
        Task<ServiceResponse<IEnumerable<StudentDTO>>> GetAllStudentsByLocationAsync(int location_id);
        Task<ServiceResponse<Auditable>> GetMetadata(string auditable_id);
    }
}
