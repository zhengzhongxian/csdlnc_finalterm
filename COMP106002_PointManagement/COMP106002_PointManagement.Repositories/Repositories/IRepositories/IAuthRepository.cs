using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(string userId);
        Task<bool> RegisterAsync(User user);
        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<string> LoginAsync(LoginDTO loginDto);
    }   
}
