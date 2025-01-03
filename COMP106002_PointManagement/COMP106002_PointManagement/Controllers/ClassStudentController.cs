using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassStudentController : ControllerBase
    {
        private readonly IClassStudentService _service;

        public ClassStudentController(IClassStudentService service)
        {
            _service = service;
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetClassStudentsByClassId(string classId)
        {
            var response = await _service.GetClassStudentsByClassIdAsync(classId);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassStudentById(string id)
        {
            var response = await _service.GetClassStudentByIdAsync(id);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddClassStudent([FromBody] ClassStudentCreateDTO classStudentDto)
        {
            var response = await _service.AddClassStudentAsync(classStudentDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassStudent(string id, [FromBody] ClassStudentUpdateDTO classStudentDto)
        {
            var response = await _service.UpdateClassStudentAsync(id, classStudentDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassStudent(string id)
        {
            var response = await _service.DeleteClassStudentAsync(id);
            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }

        [HttpGet("not-in-subject/{subjectId}")]
        public async Task<IActionResult> GetStudentsNotInSubject(string subjectId)
        {
            var response = await _service.GetStudentsNotInSubjectAsync(subjectId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
