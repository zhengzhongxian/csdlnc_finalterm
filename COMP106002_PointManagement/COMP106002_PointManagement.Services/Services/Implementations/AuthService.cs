using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> LoginAsync(LoginDTO loginDto)
        {
            var response = new ServiceResponse<string>();

            var token = await _authRepository.LoginAsync(loginDto);
            if (string.IsNullOrEmpty(token))
            {
                response.Success = false;
                response.Message = "Tài khoản hoặc mật khẩu không đúng.";
                return response;
            }

            response.Data = token;
            response.Message = "Đăng nhập thành công.";
            return response;
        }

        public async Task<ServiceResponse<bool>> RegisterAsync(RegisterDTO registerDto, string role)
        {
            var response = new ServiceResponse<bool>();

            // Kiểm tra mật khẩu và xác nhận mật khẩu
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                response.Success = false;
                response.Message = "Mật khẩu và xác nhận mật khẩu không khớp.";
                return response;
            }

            // Kiểm tra vai trò có hợp lệ không
            if (registerDto.Role != "Admin" && registerDto.Role != "Lecturer")
            {
                response.Success = false;
                response.Message = "Vai trò phải là 'Admin' hoặc 'Lecturer'.";
                return response;
            }

            var user = _mapper.Map<User>(registerDto);
            user.Role = role;

            // Kiểm tra xem username đã tồn tại hay chưa
            var existingUser = await _authRepository.GetUserByUsernameAsync(registerDto.Username);
            if (existingUser != null)
            {
                response.Success = false;
                response.Message = "Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.";
                return response;
            }

            var existingEmail = await _authRepository.GetUserByUsernameAsync(registerDto.Email);
            if (existingEmail != null)
            {
                response.Success = false;
                response.Message = "Email đã tồn tại. Vui lòng chọn email khác.";
                return response;
            }

            var success = await _authRepository.RegisterAsync(user);
            if (!success)
            {
                response.Success = false;
                response.Message = "Đăng ký không thành công. Vui lòng thử lại.";
                return response;
            }
            /* if (string.IsNullOrEmpty(user.Password))
               {
                    response.Success = false;
                    response.Message = "Lỗi khi ánh xạ mật khẩu từ RegisterDTO sang User.";
                    return response;
                }*/

            response.Data = true;
            response.Message = "Đăng ký thành công.";
            return response;
        }

        public async Task<ServiceResponse<bool>> ChangePasswordAsync(string userid, ChangePasswordDTO changePasswordDto)
        {
            var response = new ServiceResponse<bool>();
            var success = await _authRepository.ChangePasswordAsync(userid, changePasswordDto.OldPassword, changePasswordDto.NewPassword);

            if (!success)
            {
                response.Success = false;
                response.Message = "Đổi mật khẩu không thành công. Mật khẩu cũ không đúng hoặc có lỗi.";
                return response;
            }

            response.Data = true;
            response.Message = "Đổi mật khẩu thành công.";
            return response;
        }
    }
}
