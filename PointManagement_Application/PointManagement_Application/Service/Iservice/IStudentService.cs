using PointManagement_Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.Service.Iservice
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<string> DeleteStudentAsync(string studentId);
        Task<string> CreateStudentAsync(StudentCreateDTO studentDto);
        Task<string> UpdateStudentAsync(string studentId, StudentUpdateDTO studentDto);
    }
}
