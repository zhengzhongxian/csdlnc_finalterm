using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP106002_PointManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task <IActionResult> SendMailToLecturer(string recipientEmail, string studentName, string lecturerName,
            string subjectName, string examId, string studentId, decimal score, string reason)
        {
            var result = await _emailService.SendEmailToLecturerAsync(recipientEmail, studentName, lecturerName,
                subjectName, examId, studentId, score, reason);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else return BadRequest(result.Message);
        }
    }
}
