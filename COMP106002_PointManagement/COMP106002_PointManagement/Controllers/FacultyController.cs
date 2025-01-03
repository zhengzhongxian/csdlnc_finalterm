using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: api/Faculty
        [HttpGet]
        public async Task<IActionResult> GetAllFaculties()
        {
            var response = await _facultyService.GetAllFacultiesAsync();
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        // GET: api/Faculty/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacultyById(string id)
        {
            var response = await _facultyService.GetFacultyByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}
