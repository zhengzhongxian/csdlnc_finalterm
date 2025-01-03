using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRooms()
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _roomService.GetAllRoomsAsync(location_id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoom(Create_RoomDTO create_RoomDTO)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _roomService.AddRoom(create_RoomDTO, location_id);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }
    }
}
