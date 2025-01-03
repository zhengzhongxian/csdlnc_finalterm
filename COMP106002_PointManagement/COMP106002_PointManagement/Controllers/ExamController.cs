using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace COMP106002_PointManagement.API.Controllers
{
    // ExamController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllExams()
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _examService.GetAllExamsAsync(location_id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(string id)
        {
            var response = await _examService.GetExamByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateExam([FromBody] ExamCreateUpdateDTO examDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _examService.CreateExamAsync(examDto, userIdString, location_id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateExam(string id, [FromBody] ExamCreateUpdateDTO examDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _examService.UpdateExamAsync(id, examDto, userIdString, location_id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteExam(string id)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _examService.DeleteExamAsync(id, userIdString, location_id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpGet("available-rooms")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateOnly examDate, [FromQuery] TimeOnly timeSlot, [FromQuery] int duration, [FromQuery] string excludeExamId = null)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var result = await _examService.GetAvailableRoomsAsync(examDate, timeSlot, duration, location_id, excludeExamId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("available-lecturers")]
        public async Task<IActionResult> GetAvailableLecturers([FromQuery] DateOnly examDate, [FromQuery] TimeOnly timeSlot, [FromQuery] int duration, [FromQuery] string excludeExamId = null)
        {
            var result = await _examService.GetAvailableLecturersAsync(examDate, timeSlot, duration, excludeExamId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("faculty/{facultyId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetExamsByFacultyId(string facultyId)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _examService.GetExamsByFacultyIdAsync(facultyId, location_id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }


        [HttpGet("{examId}/lecturers")]
        public async Task<IActionResult> GetLecturersByExamId(string examId)
        {
            var response = await _examService.GetLecturersByExamIdAsync(examId);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpPost("transfer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Transfer()
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var result = await _examService.Transfer(userIdString, location_id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("restore")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Restore()
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var result = await _examService.Restore(userIdString, location_id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
