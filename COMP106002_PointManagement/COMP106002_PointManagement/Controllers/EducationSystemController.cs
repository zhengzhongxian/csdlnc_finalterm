using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationSystemController : ControllerBase
    {
        private readonly IEducationSystemService _educationSystemService;

        public EducationSystemController(IEducationSystemService educationSystemService)
        {
            _educationSystemService = educationSystemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEducationSystems()
        {
            var response = await _educationSystemService.GetAllEducationSystemsAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
