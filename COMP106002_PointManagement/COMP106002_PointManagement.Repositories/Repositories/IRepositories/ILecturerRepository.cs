using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface ILecturerRepository
    {
        Task<IEnumerable<Lecturer>> GetAllLecturersAsync();
        Task<Lecturer?> GetLecturerByIdAsync(string id);
        Task CreateLecturerAsync(Lecturer lecturer);
        Task UpdateLecturerAsync(Lecturer lecturer);
        Task DeleteLecturerAsync(string id);
        Task<bool> IsEmailOrPhoneExistsAsync(string email, string phoneNumber, string? excludeLecturerId = null);
    }
}
