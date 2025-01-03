using AutoMapper;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ScheduleDTO>>> GetSchedulesByExamIdAsync(string examId)
        {
            var response = new ServiceResponse<IEnumerable<ScheduleDTO>>();

            try
            {
                var schedules = await _scheduleRepository.GetSchedulesByExamIdAsync(examId);
                if (schedules == null || !schedules.Any())
                {
                    response.Success = true;
                    response.Message = "Không tìm thấy lịch thi cho kỳ thi này.";
                    response.Data= new List<ScheduleDTO>();
                }
                else
                {
                    response.Data = schedules;
                    response.Message = "Lấy danh sách lịch thi thành công.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi lấy danh sách lịch thi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> CreateScheduleAsync(ScheduleCreateUpdateDTO scheduleDto)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                // Kiểm tra nếu ghế đã được chọn
                var isSeatOccupied = await _scheduleRepository.IsSeatOccupiedAsync(scheduleDto.ExamId, scheduleDto.SeatNumber);
                if (isSeatOccupied)
                {
                    response.Success = false;
                    response.Message = "Ghế đã được chọn.";
                    return response;
                }

                // Tạo lịch thi mới
                await _scheduleRepository.CreateScheduleAsync(scheduleDto);
                response.Data = true;
                response.Message = "Tạo lịch thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi tạo lịch thi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateScheduleAsync(string scheduleId, int seatNumber)
        {
            var response = new ServiceResponse<bool>();

            try
            {

                var isSeatOccupied = await _scheduleRepository.IsSeatOccupiedAsync(scheduleId, seatNumber);
                if (isSeatOccupied)
                {
                    response.Success = false;
                    response.Message = "Ghế đã được chọn.";
                    return response;
                }

                await _scheduleRepository.UpdateScheduleAsync(scheduleId, seatNumber);
                response.Data = true;
                response.Message = "Cập nhật lịch thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi cập nhật lịch thi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteScheduleAsync(string examId, string studentId)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                await _scheduleRepository.DeleteScheduleAsync(examId, studentId);
                response.Data = true;
                response.Message = "Xóa sinh viên khỏi kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi xóa sinh viên khỏi kỳ thi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<int>>> GetOccupiedSeatsAsync(string examId)
        {
            var response = new ServiceResponse<IEnumerable<int>>();

            try
            {
                var occupiedSeats = await _scheduleRepository.GetOccupiedSeatsAsync(examId);
                if (occupiedSeats == null || !occupiedSeats.Any())
                {
                    response.Success = false;
                    response.Message = "Không có ghế nào đã được chọn.";
                }
                else
                {
                    response.Data = occupiedSeats;
                    response.Message = "Lấy danh sách ghế đã chọn thành công.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi lấy danh sách ghế đã chọn: {ex.Message}";
            }

            return response;
        }
        public async Task<ServiceResponse<IEnumerable<OtherStudentDTO>>> GetStudentsNotInScheduleAsync(string examId)
        {
            var response = new ServiceResponse<IEnumerable<OtherStudentDTO>>();

            try
            {
                // Kiểm tra xem examId có hợp lệ không
                if (string.IsNullOrEmpty(examId))
                {
                    response.Success = false;
                    response.Message = "ExamId không được để trống.";
                    return response;
                }

                var studentsNotInSchedule = await _scheduleRepository.GetStudentsNotInScheduleAsync(examId);

                if (studentsNotInSchedule == null)
                {
                    response.Success = true;
                    response.Message = "Không tìm thấy sinh viên.";
                    return response;
                }

                response.Data = studentsNotInSchedule;
                response.Message = "Lấy danh sách sinh viên chưa được thêm vào lịch thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<int>>> GetAvailableSeatsAsync(string examId)
        {
            var response = new ServiceResponse<IEnumerable<int>>();
            try
            {
                var availableSeats = await _scheduleRepository.GetAvailableSeatsAsync(examId);
                if (availableSeats == null || !availableSeats.Any())
                {
                    response.Success = true;
                    response.Message = "Không có ghế trống.";
                }
                else
                {
                    response.Data = availableSeats;
                    response.Message = "Lấy danh sách ghế trống thành công.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateScheduleStatusToTwoAsync(string scheduleId)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                await _scheduleRepository.UpdateScheduleStatusToTwoAsync(scheduleId);
                response.Data = true;
                response.Message = "Cập nhật trạng thái lịch thi sang 2 thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi cập nhật trạng thái: {ex.Message}";
            }

            return response;
        }
    }
}
