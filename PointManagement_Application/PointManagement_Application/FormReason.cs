using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormReason : Form
    {
        private string selectedLecturerName;
        private string selectedEmailLecturer;
        private string selectedStudentName;
        private string selectedScore;
        private string SubjectName;
        private string selectedStudentId;
        private string examId;
        private readonly FormMain_Manager _parentForm;
        private FormMainDetailExam _mainDetailExam;

        public FormReason(string selectedScore, string selectedLecturerName, string examId,
            string selectedEmailLecturer, string selectedStudentId, string selectedStudentName,
            string SubjectName, FormMain_Manager _parentForm, FormMainDetailExam _mainDetailExam)
        {
            InitializeComponent();
            this.selectedLecturerName = selectedLecturerName;
            this.selectedEmailLecturer = selectedEmailLecturer;
            this.selectedStudentName = selectedStudentName;
            this.selectedScore = selectedScore;
            this.SubjectName = SubjectName;
            this.selectedStudentId = selectedStudentId;
            this.examId = examId;
            this._parentForm = _parentForm;
            this._mainDetailExam = _mainDetailExam;
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            string recipientEmail = selectedEmailLecturer;
            string studentName = selectedStudentName;
            string lecturerName = selectedLecturerName; 
            string subjectName = SubjectName; 
            string examId = this.examId;
            string studentId = selectedStudentId;
            string score = selectedScore;
            string reason = txtReason.Text;
            var emailRequest = new EmailRequest
            {
                RecipientEmail = recipientEmail,
                StudentName = studentName,
                LecturerName = lecturerName,
                SubjectName = subjectName,
                ExamId = examId,
                StudentId = studentId,
                Score = score,
                Reason = reason
            };
           try
           {
                string emailRequestInfo = $"RecipientEmail: {emailRequest.RecipientEmail}\n" +
                           $"StudentName: {emailRequest.StudentName}\n" +
                           $"LecturerName: {emailRequest.LecturerName}\n" +
                           $"SubjectName: {emailRequest.SubjectName}\n" +
                           $"ExamId: {emailRequest.ExamId}\n" +
                           $"StudentId: {emailRequest.StudentId}\n" +
                           $"Score: {emailRequest.Score}\n" +
                           $"Reason: {emailRequest.Reason}";

                // Hiển thị thông báo với nội dung emailRequest
                MessageBox.Show(emailRequestInfo, "Thông tin Email Request");
                var response = await ApiHelper.PostAsync<EmailRequest, ServiceResponse<bool>>("Email", emailRequest);

                if (!response.Success && !response.Data)
                {
                    return;
                }
                Task.Run(() =>
                {
                    var formSuccess = new FormTbSendSuccess();
                    formSuccess.StartPosition = FormStartPosition.Manual;
                    formSuccess.Location = new Point(
                        _parentForm.Location.X + (_parentForm.Width - formSuccess.Width) / 2,
                        _parentForm.Location.Y + (_parentForm.Height - formSuccess.Height) / 2
                    );

                    Application.OpenForms[0].BeginInvoke((Action)(() =>
                    {
                        formSuccess.TopMost = true;
                        formSuccess.ShowDialog();
                    }));
                });
                this.Close();
            }
           catch (Exception ex)
           {
                MessageBox.Show($"Lỗi: {ex.Message}");
           }
        }
    }
}
