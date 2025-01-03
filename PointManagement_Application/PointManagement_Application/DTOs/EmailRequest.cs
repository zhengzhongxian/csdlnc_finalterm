using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class EmailRequest
    {
        public string RecipientEmail { get; set; }
        public string StudentName { get; set; }
        public string LecturerName { get; set; }
        public string SubjectName { get; set; }
        public string ExamId { get; set; }
        public string StudentId { get; set; }
        public string Score { get; set; }
        public string Reason { get; set; }
    }
}
