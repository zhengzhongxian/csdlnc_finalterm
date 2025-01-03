using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var result = await _locationService.GetLocations();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocationbyId(int locationId)
        {
            var result = await _locationService.GetLocationbyId(locationId);
            return result.Success ? Ok(result.Data) : NotFound(result.Message);
        }
    }
}
