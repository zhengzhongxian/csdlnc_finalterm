using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using PointManagement_Application.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.Service.Implement
{
    public class StudentService : IStudentService
    {
        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            return await ApiHelper.GetAsync<List<StudentDTO>>("Student");
        }
        public async Task<string> DeleteStudentAsync(string studentId)
        {
            return await ApiHelper.DeleteAsync<string>($"Student/{studentId}");
        }
        public async Task<string> CreateStudentAsync(StudentCreateDTO studentDto)
        {
            return await ApiHelper.PostAsync<StudentCreateDTO, string>("Student", studentDto);
        }
        public async Task<string> UpdateStudentAsync(string studentId, StudentUpdateDTO studentDto)
        {
            return await ApiHelper.PutAsync<StudentUpdateDTO, string>($"Student/{studentId}", studentDto);
        }
    }
}
