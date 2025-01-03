using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        // GET: api/Lecturer
        [HttpGet]
        public async Task<IActionResult> GetAllLecturers()
        {
            var response = await _lecturerService.GetAllLecturersAsync();
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        // GET: api/Lecturer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturerById(string id)
        {
            var response = await _lecturerService.GetLecturerByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        // POST: api/Lecturer
        [HttpPost]
        public async Task<IActionResult> CreateLecturer([FromBody] LecturerCreateUpdateDTO lecturerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _lecturerService.CreateLecturerAsync(lecturerDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetLecturerById), new { id = lecturerDto.Email }, response.Message);
        }

        // PUT: api/Lecturer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLecturer(string id, [FromBody] LecturerCreateUpdateDTO lecturerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _lecturerService.UpdateLecturerAsync(id, lecturerDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }

        // DELETE: api/Lecturer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer(string id)
        {
            var response = await _lecturerService.DeleteLecturerAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }
}
