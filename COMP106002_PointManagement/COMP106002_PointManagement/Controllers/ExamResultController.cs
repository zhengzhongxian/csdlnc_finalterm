using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;

        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamResults()
        {
            var response = await _examResultService.GetAllExamResultsAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamResultById(string id)
        {
            var response = await _examResultService.GetExamResultByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExamResult([FromBody] ExamResultCU_DTO examResultDto)
        {
            var response = await _examResultService.CreateExamResultAsync(examResultDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpPut("{id}/lecturer")]
        public async Task<IActionResult> UpdateExamResult(string id, [FromQuery] string lecturerId)
        {
            var response = await _examResultService.UpdateExamResultAsync(id, lecturerId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}/score")]
        public async Task<IActionResult> UpdateStudentScore(string id, [FromQuery] decimal score)
        {
            var response = await _examResultService.UpdateStudentScoreAsync(id, score);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamResult(string id)
        {
            var response = await _examResultService.DeleteExamResultAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Message);
        }


        [HttpGet("lecturer/{lecturerId}/exams")]
        public async Task<IActionResult> GetExamsByLecturer(string lecturerId)
        {
            var response = await _examResultService.GetExamsByLecturerAsync(lecturerId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("lecturer/{lecturerId}/exam/{examId}/students")]
        public async Task<IActionResult> GetStudentsByLecturerInExam(string lecturerId, string examId)
        {
            var response = await _examResultService.GetStudentsByLecturerInExamAsync(lecturerId, examId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("student/{studentId}/exam/{examId}")]
        public async Task<IActionResult> GetStudentExamResultInExam(string studentId, string examId)
        {
            var response = await _examResultService.GetStudentExamResultInExamAsync(studentId, examId);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
