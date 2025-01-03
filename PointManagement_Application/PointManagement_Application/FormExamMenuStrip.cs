using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormExamMenuStrip : Form
    {
        private string selectedStudentId;
        private string examId;
        private string selectedStatus;
        private readonly FormMain_Manager _parentForm;
        private string selectedSheduleId;
        private FormMainDetailExam _mainDetailExam;
        private string selectedResultId;
        private string selectedLecturerId;
        private string selectedLecturerName;
        private string selectedEmailLecturer;
        private string selectedStudentName;
        private string selectedScore;
        private string SubjectName;
        public FormExamMenuStrip(string selectedStudentId, string examId, FormMain_Manager parentForm, string selectedStatus, string selectedSheduleId, FormMainDetailExam mainDetailExam
            , string selectedResultId, string selectedLecturerId, string selectedLecturerName,
            string selectedEmailLecturer, string selectedStudentName, string selectedScore, string subjectName)
        {
            InitializeComponent();
            this.selectedStudentId = selectedStudentId;
            this.examId = examId;
            this._parentForm = parentForm;
            this.selectedStatus = selectedStatus;
            this.selectedSheduleId = selectedSheduleId;
            _mainDetailExam = mainDetailExam;
            this.selectedLecturerName = selectedLecturerName;
            this.selectedResultId = selectedResultId;
            this.selectedLecturerId = selectedLecturerId;
            this.selectedEmailLecturer = selectedEmailLecturer;
            this.selectedStudentName = selectedStudentName;
            this.selectedScore = selectedScore;
            this.SubjectName = subjectName;
        }

        private void Bcreate_exam_result_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStudentId) || string.IsNullOrEmpty(examId))
            {
                MessageBox.Show("Không thể xác định sinh viên hoặc kỳ thi.");
                return;
            }

            if (selectedStatus != "1") 
            {
                using (var formNotCreatResult = new FormNotCreatResultExam())
                {
                    formNotCreatResult.StartPosition = FormStartPosition.Manual;
                    formNotCreatResult.Location = new Point(
                        _parentForm.Location.X + (_parentForm.Width - formNotCreatResult.Width) / 2,
                        _parentForm.Location.Y + (_parentForm.Height - formNotCreatResult.Height) / 2
                    );
                    formNotCreatResult.TopMost = true;
                    formNotCreatResult.Activate();
                    formNotCreatResult.ShowDialog();
                }
                return; 
            }

            var createExamResultForm = new FormCreatExamResult(selectedStudentId, examId, _parentForm, selectedStatus, selectedSheduleId, _mainDetailExam);

            createExamResultForm.StartPosition = FormStartPosition.Manual;
            createExamResultForm.Location = new Point(
                _parentForm.Location.X + (_parentForm.Width - createExamResultForm.Width) / 2,
                _parentForm.Location.Y + (_parentForm.Height - createExamResultForm.Height) / 2
            );

            createExamResultForm.TopMost = true;
            createExamResultForm.ShowDialog();
            createExamResultForm.Activate();

            this.Close();
        }

        private void Bupdate_exam_result_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Khong mo duoc");
            if (selectedStatus != "2")
            {

                using (var formNotUpdateResult = new FormNotUpdateResultExam())
                {
                    formNotUpdateResult.StartPosition = FormStartPosition.Manual;
                    formNotUpdateResult.Location = new Point(
                        _parentForm.Location.X + (_parentForm.Width - formNotUpdateResult.Width) / 2,
                        _parentForm.Location.Y + (_parentForm.Height - formNotUpdateResult.Height) / 2
                    );
                    formNotUpdateResult.TopMost = true;
                    formNotUpdateResult.Activate();
                    formNotUpdateResult.ShowDialog();
                }
                //this.Close();
                return;
            }

            var updateExamResultForm = new FormUpdateExamResult(selectedResultId, selectedLecturerId, selectedLecturerName,examId, _mainDetailExam);

            updateExamResultForm.StartPosition = FormStartPosition.Manual;
            updateExamResultForm.Location = new Point(
                _parentForm.Location.X + (_parentForm.Width - updateExamResultForm.Width) / 2,
                _parentForm.Location.Y + (_parentForm.Height - updateExamResultForm.Height) / 2
            );

            updateExamResultForm.TopMost = true;
            updateExamResultForm.ShowDialog();
            updateExamResultForm.Activate();

            this.Close();
        }

        private void Bcep_Click(object sender, EventArgs e)
        {
            if (selectedStatus != "2")
            {

                using (var formNotUpdateResult = new FormNotUpdateResultExam())
                {
                    formNotUpdateResult.StartPosition = FormStartPosition.Manual;
                    formNotUpdateResult.Location = new Point(
                        _parentForm.Location.X + (_parentForm.Width - formNotUpdateResult.Width) / 2,
                        _parentForm.Location.Y + (_parentForm.Height - formNotUpdateResult.Height) / 2
                    );
                    formNotUpdateResult.TopMost = true;
                    formNotUpdateResult.Activate();
                    formNotUpdateResult.ShowDialog();
                }
                //this.Close();
                return;
            }
            var formreason = new FormReason(selectedScore, selectedLecturerName, examId, selectedEmailLecturer, selectedStudentId, selectedStudentName, SubjectName, _parentForm, _mainDetailExam)
            {
                StartPosition = FormStartPosition.Manual,
            };
            formreason.Location = new Point(
                _parentForm.Location.X + (_parentForm.Width - formreason.Width) / 2,
                _parentForm.Location.Y + (_parentForm.Height - formreason.Height) / 2
            );
            formreason.Activate();
            formreason.TopMost = true;
            formreason.ShowDialog();
        }
    }
}
