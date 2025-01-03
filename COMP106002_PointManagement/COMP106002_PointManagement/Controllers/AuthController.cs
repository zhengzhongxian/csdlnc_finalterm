using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            // Chỉ chấp nhận vai trò Admin hoặc Lecturer
            if (registerDto.Role != "Admin" && registerDto.Role != "Lecturer")
            {
                return BadRequest("Vai trò phải là 'Admin' hoặc 'Lecturer'.");
            }

            var result = await _authService.RegisterAsync(registerDto, registerDto.Role);

            if (!result.Success)
            {
                return BadRequest(result.Message); 
            }

            return Ok(result.Message);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            var result = await _authService.ChangePasswordAsync(userIdString, changePasswordDto);
            if (!result.Success)
            {
                return BadRequest(result); 
            }

            return Ok(result);
        }
    }
}
