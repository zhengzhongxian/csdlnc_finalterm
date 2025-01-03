using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var result = await _subjectService.GetAllSubjectsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(string id)
        {
            var result = await _subjectService.GetSubjectByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectCreateUpdateDTO subjectDto)
        {
            var result = await _subjectService.CreateSubjectAsync(subjectDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(string id, SubjectCreateUpdateDTO subjectDto)
        {
            var result = await _subjectService.UpdateSubjectAsync(id, subjectDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            var result = await _subjectService.DeleteSubjectAsync(id);
            return Ok(result);
        }
    }
}
