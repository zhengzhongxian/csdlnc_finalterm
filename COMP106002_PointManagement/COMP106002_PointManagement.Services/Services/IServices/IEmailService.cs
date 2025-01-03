using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IEmailService
    {
        Task <ServiceResponse<bool>>SendEmailToLecturerAsync(string recipientEmail, string studentName, string lecturerName,
            string subjectName, string examId, string studentId, decimal score, string reason);
    }
}
