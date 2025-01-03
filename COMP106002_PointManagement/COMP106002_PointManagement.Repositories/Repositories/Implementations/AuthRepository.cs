using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PM_App _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(PM_App context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<bool> RegisterAsync(User user)
        {

            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return false; 
            }

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return false; 
            }

            if (string.IsNullOrEmpty(user.UserId))
            {
                user.UserId = Guid.NewGuid().ToString();
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (user.Role == "Lecturer")
            {
                var lecturer = new Lecturer
                {
                    LecturerId = user.UserId,
                    LecturerNavigation = user 
                };

                _context.Lecturers.Add(lecturer);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<string> LoginAsync(LoginDTO loginDto)
        {
            var user = await GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }

            // Tạo token JWT
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("user_id",user.UserId),
                new Claim("location_id",user.LocationId.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            user.LastAccessed = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null || !BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                return false; 
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword); 
            user.UpdatedAt = DateTime.Now; 

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
