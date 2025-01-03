using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerSubjectController : ControllerBase
    {
        private readonly ILecturerSubjectService _service;

        public LecturerSubjectController(ILecturerSubjectService service)
        {
            _service = service;
        }

        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetLecturerSubjectsBySubjectId(string subjectId)
        {
            var response = await _service.GetLecturerSubjectsBySubjectIdAsync(subjectId);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddLecturerSubject([FromBody] LecturerSubjectCreateDTO dto)
        {
            var response = await _service.AddLecturerSubjectAsync(dto);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateLecturerSubject(string id, [FromBody] LecturerSubjectUpdateDTO dto)
        {
            var response = await _service.UpdateLecturerSubjectAsync(id, dto);
            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturerSubject(string id)
        {
            var response = await _service.DeleteLecturerSubjectAsync(id);
            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }
    }
}
