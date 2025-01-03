using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace COMP106002_PointManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var response = await _classService.GetAllClassesAsync();
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(string id)
        {
            var response = await _classService.GetClassByIdAsync(id);
            if (!response.Success) return NotFound(response.Message);
            return Ok(response.Data);
        }

        [HttpGet("faculty/{facultyId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetClassesByFacultyId(string facultyId)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _classService.GetClassesByFacultyIdAsync(facultyId, location_id);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddClass([FromBody] ClassCreateDTO classDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _classService.AddClassAsync(classDto, location_id, userIdString);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateClass(string id, [FromBody] ClassUpdateDTO classDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            var response = await _classService.UpdateClassAsync(id, classDto, userIdString);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClass(string id)
        {
            string userIdString = User.FindFirstValue("user_id");
            var response = await _classService.DeleteClassAsync(id, userIdString);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Message);
        }
    }
}
