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
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class ExamResultService : IExamResultService
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IMapper _mapper;

        public ExamResultService(IExamResultRepository examResultRepository, IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ExamResultDTO>>> GetAllExamResultsAsync()
        {
            var response = new ServiceResponse<IEnumerable<ExamResultDTO>>();
            try
            {
                var results = await _examResultRepository.GetAllExamResultsAsync();
                response.Data = _mapper.Map<IEnumerable<ExamResultDTO>>(results);
                response.Message = "Lấy danh sách kết quả thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ExamResultDTO>> GetExamResultByIdAsync(string resultId)
        {
            var response = new ServiceResponse<ExamResultDTO>();
            try
            {
                var result = await _examResultRepository.GetExamResultByIdAsync(resultId);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy kết quả thi.";
                    return response;
                }
                response.Data = _mapper.Map<ExamResultDTO>(result);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> CreateExamResultAsync(ExamResultCU_DTO examResultDto)
        {
            var response = new ServiceResponse<bool>();

            try
            {

                if (!await _examResultRepository.LecturerCanGradeSubjectAsync(examResultDto.LecturerId, examResultDto.ExamId))
                {
                    response.Success = false;
                    response.Message = "Giảng viên không thể chấm bài môn này.";
                    return response;
                }

                var examResult = _mapper.Map<ExamResult>(examResultDto);
                await _examResultRepository.CreateExamResultAsync(examResult);
                response.Data = true;
                response.Message = "Tạo kết quả thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateExamResultAsync(string resultId, string lecturerId)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var existingResult = await _examResultRepository.GetExamResultByIdAsync(resultId);
                if (existingResult == null)
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy kết quả thi.";
                    return response;
                }

                // Kiểm tra giảng viên có thể chấm bài cho môn học của kỳ thi (dùng ExamId để lấy SubjectId)
                if (!await _examResultRepository.LecturerCanGradeSubjectAsync(lecturerId, existingResult.ExamId))
                {
                    response.Success = false;
                    response.Message = "Giảng viên không thể chấm bài môn này.";
                    return response;
                }

                // Cập nhật giảng viên chấm thi
                existingResult.LecturerId = lecturerId;
                await _examResultRepository.UpdateExamResultAsync(existingResult);

                response.Data = true;
                response.Message = "Cập nhật giảng viên chấm thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteExamResultAsync(string resultId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                await _examResultRepository.DeleteExamResultAsync(resultId);
                response.Data = true;
                response.Message = "Xóa kết quả thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        // New methods

        public async Task<ServiceResponse<IEnumerable<ExamDTO>>> GetExamsByLecturerAsync(string lecturerId)
        {
            var response = new ServiceResponse<IEnumerable<ExamDTO>>();
            try
            {
                var exams = await _examResultRepository.GetExamsByLecturerAsync(lecturerId);
                response.Data = _mapper.Map<IEnumerable<ExamDTO>>(exams);
                response.Message = "Lấy danh sách kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ExamResultDTO>>> GetStudentsByLecturerInExamAsync(string lecturerId, string examId)
        {
            var response = new ServiceResponse<IEnumerable<ExamResultDTO>>();
            try
            {
                var results = await _examResultRepository.GetStudentsByLecturerInExamAsync(lecturerId, examId);
                response.Data = _mapper.Map<IEnumerable<ExamResultDTO>>(results);
                response.Message = "Lấy danh sách sinh viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ExamResultDTO>> GetStudentExamResultInExamAsync(string studentId, string examId)
        {
            var response = new ServiceResponse<ExamResultDTO>();
            try
            {
                var result = await _examResultRepository.GetStudentExamResultInExamAsync(studentId, examId);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy kết quả thi của sinh viên.";
                    return response;
                }
                response.Data = _mapper.Map<ExamResultDTO>(result);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateStudentScoreAsync(string resultId, decimal score)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                await _examResultRepository.UpdateStudentScoreAsync(resultId, score);
                response.Data = true;
                response.Message = "Cập nhật điểm thành công.";
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
