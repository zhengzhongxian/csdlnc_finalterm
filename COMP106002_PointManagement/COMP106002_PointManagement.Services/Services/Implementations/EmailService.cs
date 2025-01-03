using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.Email;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSetting;
        private readonly SmtpClient _smtpClient;
        public EmailService(IOptions<EmailSetting> options)
        {
            _emailSetting = options.Value;
            _smtpClient = new SmtpClient(_emailSetting.Smtp.Host)
            {
                Port = _emailSetting.Smtp.Port,
                Credentials = new NetworkCredential(_emailSetting.Smtp.EmailAddress, _emailSetting.Smtp.Password),
                EnableSsl = _emailSetting.Smtp.EnableSsl
            };
        }

        public async Task<ServiceResponse<bool>> SendEmailToLecturerAsync(string recipientEmail, string studentName, string lecturerName, 
            string subjectName, string examId, string studentId, decimal score, string reason)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSetting.FromEmailAddress, _emailSetting.FromDisplayName),
                    Subject = "Xác nhận OTP đăng ký",
                    Body = GenerateEmailBody(studentName, lecturerName, subjectName, examId, studentId, score, reason),
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(recipientEmail);

                await _smtpClient.SendMailAsync(mailMessage);
                response.Success = true;
                response.Message = "Gửi mail thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Không thể gửi mail";
            }
            return response;
        }

        public string GenerateEmailBody(string studentName, string lecturerName,
            string subjectName, string examId, string studentId, decimal score, string reason)
        {
            return $@"<!DOCTYPE html>
<html lang=""en"">
  <head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>Thông Báo Phúc Khảo</title>
    <style>
      * {{
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: Arial, sans-serif;
      }}

      body {{
        background-color: #f9f9f9;
        color: #333;
        font-size: 16px;
        line-height: 1.5;
      }}

      .email-container {{
        background-color: #ffffff;
        width: 100%;
        max-width: 600px;
        margin: 20px auto;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
      }}

      .email-header {{
        background: linear-gradient(360deg, #3ed7f0, #5ab2f5);
        color: #ffffff;
        text-align: center;
        padding: 10px;
        border-radius: 8px 8px 0 0;
        font-size: 20px;
        font-weight: bold;
        height: 60px;
      }}

      .email-header img {{
        width: 40px;
        margin-right: 10px;
      }}

      .email-body {{
        margin-top: 20px;
        padding: 20px;
        background-color: #f9f9f9;
        border-radius: 8px;
        border: 1px solid #e0e0e0;
      }}

      .email-body h2 {{
        color: #333;
        font-size: 20px;
        font-weight: bold;
      }}

      .email-body p {{
        font-size: 14px;
        color: #555;
      }}

      .email-body ul {{
        list-style-type: none;
        padding-left: 20px;
        margin: 10px 0;
      }}

      .email-body ul li {{
        margin-bottom: 8px;
      }}

      .notification {{
        background: linear-gradient(90deg, #3ed7f0, #5ab2f5);
        color: white;
        padding: 25px;
        margin-top: 20px;
        border-radius: 8px;
        font-weight: bold;
        font-size: 20px;
        text-align: center;
      }}
      .notification p {{
        color: white;
      }}

      .email-footer {{
        text-align: center;
        margin-top: 20px;
        font-size: 12px;
        color: #888888;
      }}

      .email-footer a {{
        color: #2aa1c7;
        text-decoration: none;
      }}

      .button {{
        display: inline-block;
        background-color: #4caf50;
        color: #ffffff;
        padding: 10px 20px;
        text-decoration: none;
        border-radius: 5px;
        margin-top: 20px;
        font-size: 14px;
      }}

      .button:hover {{
        background-color: #45a049;
      }}
    </style>
  </head>
  <body>
    <div class=""email-container"">
      <!-- Header -->
      <div class=""email-header"">
        <span>Thông Báo Phúc Khảo</span>
      </div>

      <!-- Body -->
      <div class=""email-body"">
        <h2>Kính gửi Giảng viên {lecturerName},</h2>
        <p>
          Chúng tôi xin thông báo rằng một yêu cầu phúc khảo đã được gửi từ sinh
          viên <strong>{studentName}</strong> cho môn học
          <strong>{subjectName}</strong> trong kì thi <strong>{examId}</strong>.
        </p>
        <p>Thông tin chi tiết về yêu cầu phúc khảo:</p>
        <ul>
          <li><strong>Tên Sinh Viên:</strong> {studentName}</li>
          <li><strong>Mã Sinh Viên:</strong> {examId}</li>
          <li><strong>Điểm Hiện Tại:</strong> {score}</li>
          <li><strong>Lý Do Phúc Khảo:</strong> {reason}</li>
        </ul>
        <div class=""notification"">
          <p>
            Vui lòng xem xét và phản hồi lại yêu cầu phúc khảo của sinh viên.
          </p>
        </div>
      </div>

      <!-- Footer -->
      <div class=""email-footer"">
        <p>
          Nếu bạn cần hỗ trợ thêm, vui lòng liên hệ với chúng tôi qua email
          <a href=""mailto:trunghien2807@gmail.com"">support@example.com</a>.
        </p>
        <p>
          &copy; 2024 Trường Đại học Sư Phạm Thành Phố Hồ Chí Minh. Tất cả quyền
          được bảo lưu.
        </p>
      </div>
    </div>
  </body>
</html>
";
        }
    }
}
