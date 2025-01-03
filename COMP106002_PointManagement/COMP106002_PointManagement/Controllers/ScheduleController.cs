using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetSchedulesByExamId(string examId)
        {
            var response = await _scheduleService.GetSchedulesByExamIdAsync(examId);

            if (!response.Success)
                return BadRequest(new List<ScheduleDTO>());

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleCreateUpdateDTO scheduleDto)
        {

            var response = await _scheduleService.CreateScheduleAsync(scheduleDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{scheduleId}")]
        public async Task<IActionResult> UpdateSchedule(string scheduleId, [FromBody] int seatNumber)
        {
            var response = await _scheduleService.UpdateScheduleAsync(scheduleId, seatNumber);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("exam/{examId}/student/{studentId}")]
        public async Task<IActionResult> DeleteSchedule(string examId, string studentId)
        {
            var response = await _scheduleService.DeleteScheduleAsync(examId, studentId);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }

        [HttpGet("exam/{examId}/occupied-seats")]
        public async Task<IActionResult> GetOccupiedSeats(string examId)
        {
            var response = await _scheduleService.GetOccupiedSeatsAsync(examId);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("students-not-in-schedule/{examId}")]
        public async Task<IActionResult> GetStudentsNotInSchedule(string examId)
        { 

            var response = await _scheduleService.GetStudentsNotInScheduleAsync(examId);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("exam/{examId}/available-seats")]
        public async Task<IActionResult> GetAvailableSeats(string examId)
        {
            var response = await _scheduleService.GetAvailableSeatsAsync(examId);
            if (!response.Success)
            {
                return BadRequest(new List<int>());
            }
            return Ok(response.Data);
        }

        [HttpPut("{scheduleId}/status-to-2")]
        public async Task<IActionResult> UpdateScheduleStatusToTwo(string scheduleId)
        {
            var response = await _scheduleService.UpdateScheduleStatusToTwoAsync(scheduleId);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
    }
}
