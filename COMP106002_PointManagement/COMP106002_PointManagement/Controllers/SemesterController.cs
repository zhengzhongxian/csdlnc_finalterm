using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _service;

        public SemesterController(ISemesterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSemesters()
        {
            var response = await _service.GetAllSemestersAsync();
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }
    }
}
