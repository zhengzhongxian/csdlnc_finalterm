using COMP106002_PointManagement.Repositories.Models.CU_DTO;
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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //[Authorize(Roles = "Lecturer")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsByLocation()
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _studentService.GetAllStudentsByLocationAsync(location_id);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _studentService.GetAllStudentsAsync();

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var response = await _studentService.GetStudentByIdAsync(id);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStudent(StudentCU_DTO studentDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _studentService.CreateStudentAsync(studentDto, userIdString, location_id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("sql")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStudentinSql(StudentCU_DTO studentDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var response = await _studentService.CreateStudentinSqlAsync(studentDto, userIdString, location_id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudent(string id, StudentUpdateDTO studentDto)
        {
            string userIdString = User.FindFirstValue("user_id");
            var response = await _studentService.UpdateStudentAsync(userIdString, id, studentDto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            string userIdString = User.FindFirstValue("user_id");
            var response = await _studentService.DeleteStudentAsync(userIdString, id);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Message);
        }

        [HttpGet("Faculty/{facultyId}")]
        public async Task<IActionResult> GetStudentsByFacultyId(string facultyId)
        {
            var response = await _studentService.GetStudentsByFacultyIdAsync(facultyId);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("{studentId}/semester/{semesterId}")]
        public async Task<IActionResult> GetStudentScoresInSemester(string studentId, int semesterId)
        {
            var response = await _studentService.GetStudentScoresInSemesterAsync(studentId, semesterId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet]
        [Route("studentwithmetadata")]
        public async Task<IActionResult> GetStudentWithMetadata()
        {
            var result = await _studentService.GetStudentWithMetadataAsync();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet]
        [Route("Mongo")]
        public async Task<IActionResult> GetStudentInMongoByLocation(int locationId)
        {
            var result = await _studentService.GetStudentInMongo(locationId);
            return result.Success ? Ok(result) : NotFound(result.Message);
        }

        [HttpDelete("Mongo/{studentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentInMongo(string studentId)
        {
            string userIdString = User.FindFirstValue("user_id");
            var result = await _studentService.DeleteStudentinMongo(studentId, userIdString);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("transfer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Transfer()
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            string userIdString = User.FindFirstValue("user_id");
            var result = await _studentService.Transfer(userIdString, location_id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("restore")]
        public async Task<IActionResult> Restore()
        {
            string userIdString = User.FindFirstValue("user_id");
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            var result = await _studentService.Restore(userIdString, location_id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("Search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchStudent(string search = null)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            if (search == null) return Ok(new List<StudentDTO>());
            var response = await _studentService.Search(search, location_id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("FacultyandAcademic")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStudentAndAcademicYear(string facultyid = null, string academicyear_id = null)
        {
            int location_id = int.Parse(User.FindFirstValue("location_id"));
            if (string.IsNullOrEmpty(facultyid) && string.IsNullOrEmpty(academicyear_id)) return Ok(new List<StudentDTO>());

            var response = await _studentService.GetStudentByFacultyAndAcademicYear(facultyid, academicyear_id, location_id);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("metadata")]
        public async Task<IActionResult> GetMetadata(string auditable_id)
        {
            var response = await _studentService.GetMetadata(auditable_id);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }
    }
}
