using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> LoginAsync(LoginDTO loginDto);
        Task<ServiceResponse<bool>> RegisterAsync(RegisterDTO registerDto, string role);
        Task<ServiceResponse<bool>> ChangePasswordAsync(string userid, ChangePasswordDTO changePasswordDto);
    }
}
