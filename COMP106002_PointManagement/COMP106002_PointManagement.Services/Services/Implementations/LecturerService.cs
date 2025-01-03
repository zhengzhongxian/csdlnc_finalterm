using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LecturerService(ILecturerRepository lecturerRepository, IMapper mapper, IConfiguration configuration)
        {
            _lecturerRepository = lecturerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<IEnumerable<LecturerDTO>>> GetAllLecturersAsync()
        {
            var response = new ServiceResponse<IEnumerable<LecturerDTO>>();

            try
            {
                var lecturers = await _lecturerRepository.GetAllLecturersAsync();
                response.Data = _mapper.Map<IEnumerable<LecturerDTO>>(lecturers);
                response.Message = "Lấy danh sách giảng viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> CreateLecturerAsync(LecturerCreateUpdateDTO lecturerDto)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                if (string.IsNullOrEmpty(lecturerDto.Email) || string.IsNullOrEmpty(lecturerDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Email và số điện thoại không được để trống.";
                    return response;
                }

                var emailExists = await _lecturerRepository.IsEmailOrPhoneExistsAsync(lecturerDto.Email, lecturerDto.PhoneNumber);
                if (emailExists)
                {
                    response.Success = false;
                    response.Message = "Email hoặc số điện thoại đã tồn tại.";
                    return response;
                }

                var lecturerId = Guid.NewGuid().ToString();

                var user = _mapper.Map<User>(lecturerDto);
                user.UserId = lecturerId;
                user.Username = lecturerDto.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(_configuration["Secret:DefaultLecturerPassword"]);
                user.Role = "lecturer";
                user.Photo = lecturerDto.Photo;
                user.CreatedAt = DateTime.UtcNow;

                // Tạo đối tượng Lecturer
                var lecturer = _mapper.Map<Lecturer>(lecturerDto);
                lecturer.LecturerId = lecturerId;
                lecturer.LecturerNavigation = user;

                // Lưu vào DB
                await _lecturerRepository.CreateLecturerAsync(lecturer);
                response.Data = true;
                response.Message = "Giảng viên đã được tạo thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> UpdateLecturerAsync(string id, LecturerCreateUpdateDTO lecturerDto)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var existingLecturer = await _lecturerRepository.GetLecturerByIdAsync(id);
                if (existingLecturer == null)
                {
                    response.Success = false;
                    response.Message = "Giảng viên không tồn tại.";
                    return response;
                }

                if (string.IsNullOrEmpty(lecturerDto.Email) || string.IsNullOrEmpty(lecturerDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Email và số điện thoại không được để trống.";
                    return response;
                }

                var emailExists = await _lecturerRepository.IsEmailOrPhoneExistsAsync(lecturerDto.Email, lecturerDto.PhoneNumber, id);
                if (emailExists)
                {
                    response.Success = false;
                    response.Message = "Email hoặc số điện thoại đã tồn tại.";
                    return response;
                }

                // Cập nhật thông tin giảng viên
                var updatedLecturer = _mapper.Map(lecturerDto, existingLecturer);
                var updatedUser = _mapper.Map(lecturerDto, existingLecturer.LecturerNavigation);

                updatedUser.UpdatedAt = DateTime.UtcNow; // Cập nhật thời gian
                updatedUser.Username = existingLecturer.LecturerNavigation.Username; // Giữ nguyên Username

                await _lecturerRepository.UpdateLecturerAsync(updatedLecturer);
                response.Data = true;
                response.Message = "Cập nhật giảng viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteLecturerAsync(string id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var lecturer = await _lecturerRepository.GetLecturerByIdAsync(id);
                if (lecturer == null)
                {
                    response.Success = false;
                    response.Message = "Giảng viên không tồn tại.";
                    return response;
                }

                await _lecturerRepository.DeleteLecturerAsync(id);

                response.Data = true;
                response.Message = "Xóa giảng viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
        public async Task<ServiceResponse<LecturerDTO>> GetLecturerByIdAsync(string id)
        {
            var response = new ServiceResponse<LecturerDTO>();

            try
            {
                var lecturer = await _lecturerRepository.GetLecturerByIdAsync(id);
                if (lecturer == null)
                {
                    response.Success = false;
                    response.Message = "Giảng viên không tồn tại.";
                    return response;
                }

                var lecturerDto = _mapper.Map<LecturerDTO>(lecturer);
                lecturerDto.Photo = lecturer.LecturerNavigation.Photo; // Trả về ảnh giảng viên

                response.Data = lecturerDto;
                response.Message = "Lấy thông tin giảng viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
    }
}
