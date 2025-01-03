using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormMainDetailExam : Form
    {
        private string examId;
        private readonly FormMain_Manager _parentForm;
        private string selectedStudentId;
        private string selectedSheduleId;
        //private FormMainExams _parentForm;
        private FormMainExams parentForm;
        private string selectedStatus;
        private string selectedResultId;
        private string selectedLecturerId;
        private string selectedLecturerName;
        private string selectedEmailLecturer;
        private string selectedStudentName;
        private string selectedScore;
        private string selectedSubjectName;
        public FormMainDetailExam(string examId, string subjectName, string roomName, string invigilatorName, FormMain_Manager _parentForm, FormMainExams parentForm, string selectedSubject)
        {
            InitializeComponent();
            this.examId = examId;
            ExamID.Text = $"ExamID: {examId}";
            Subject.Text = $"Subject Name: {subjectName}";
            Room.Text = $"Room Name: {roomName}";
            Invigilator.Text = $"Invigilator: {invigilatorName}";
            this._parentForm = _parentForm;
            this.parentForm = parentForm;
            this.selectedSubjectName = subjectName;
            FormHelper.EnableDrag(this, _parentForm);
            LoadScheduleAsync();
        }

        private void guna2Shapes3_Click(object sender, EventArgs e)
        {

        }
        public async Task LoadScheduleAsync()
        {
            try
            {
                var schedules = await ApiHelper.GetAsync<List<ScheduleDTO>>($"Schedule/exam/{examId}");

                if (schedules != null && schedules.Count > 0)
                {
                    PopulateScheduleDataGrid(schedules);
                }
                else
                {
                    guna2HtmlLabel2.Visible = true;
                    DGschedule.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đéo có kì thi nào ở đây");
            }
        }

        private void PopulateScheduleDataGrid(List<ScheduleDTO> schedules)
        {
            DGschedule.Rows.Clear();

            foreach (var schedule in schedules)
            {
                int rowIndex = DGschedule.Rows.Add();
                DataGridViewRow row = DGschedule.Rows[rowIndex];

                row.Cells["scheduleId"].Value = schedule.ScheduleId;
                row.Cells["studentId"].Value = schedule.StudentId;
                row.Cells["studentName"].Value = schedule.StudentName;
                row.Cells["seatNumber"].Value = schedule.SeatNumber;
                row.Cells["Score"].Value = schedule.Score.HasValue
     ? (schedule.Score.Value).ToString("F1", System.Globalization.CultureInfo.InvariantCulture)
     : "N/A";
                row.Cells["LecturerName"].Value = schedule.LecturerName;
                row.Cells["LecturerId"].Value = !string.IsNullOrEmpty(schedule.LecturerId) ? schedule.LecturerId : "N/A";
                row.Cells["ResultId"].Value = !string.IsNullOrEmpty(schedule.ResultId) ? schedule.ResultId : "N/A";
                row.Cells["Status"].Value = schedule.Status;
                row.Cells["EmailLecturer"].Value = schedule.EmailLecturer;
            }
        }

        private async void Bdeleteschedule_Click(object sender, EventArgs e)
        {
            if (DGschedule.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn một lịch thi để xóa.");
                return;
            }

            if (string.IsNullOrEmpty(selectedStudentId) || string.IsNullOrEmpty(examId))
            {
                MessageBox.Show("Không thể xác định sinh viên hoặc kỳ thi.");
                return;
            }

            using (var formDelete = new FormTbDeleteSchedule())
            {
                formDelete.StartPosition = FormStartPosition.Manual;

                int x = _parentForm.Location.X + (_parentForm.Width - formDelete.Width) / 2;
                int y = _parentForm.Location.Y + (_parentForm.Height - formDelete.Height) / 2;
                formDelete.Location = new Point(x, y);

                formDelete.ShowDialog();

                if (formDelete.IsConfirmed)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(selectedResultId) && selectedResultId != "N/A")
                        {
                            await ApiHelper.DeleteAsync<string>($"ExamResult/{selectedResultId}");
                        }

                        var responseMessage = await ApiHelper.DeleteAsync<string>($"Schedule/exam/{examId}/student/{selectedStudentId}");

                        using (var formSuccess = new FormTbDeleteSucces())
                        {
                            formSuccess.StartPosition = FormStartPosition.Manual;

                            int successX = _parentForm.Location.X + (_parentForm.Width - formSuccess.Width) / 2;
                            int successY = _parentForm.Location.Y + (_parentForm.Height - formSuccess.Height) / 2;
                            formSuccess.Location = new Point(successX, successY);

                            formSuccess.ShowDialog();
                        }

                        await LoadScheduleAsync();

                        if (DGschedule.Rows.Count == 0)
                        {
                            DGschedule.Rows.Clear();
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("404"))
                        {
                            MessageBox.Show("Lịch thi này không tồn tại hoặc đã bị xóa trước đó.");
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi xảy ra khi xóa lịch thi: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void DGschedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGschedule.Rows[e.RowIndex];
                selectedStudentId = row.Cells["studentId"].Value.ToString();
                selectedSheduleId = row.Cells["scheduleId"].Value.ToString();
                selectedResultId = row.Cells["ResultId"].Value.ToString();
                selectedLecturerId = row.Cells["LecturerId"].Value.ToString();
                selectedLecturerName = row.Cells["LecturerName"].Value.ToString();
                selectedEmailLecturer = row.Cells["EmailLecturer"].Value.ToString();
                selectedStudentName = row.Cells["studentName"].Value.ToString();
                selectedScore = row.Cells["Score"].Value.ToString();
            }
        }

        private async void Bcreatschedule_Click(object sender, EventArgs e)
        {
            using (var formAddSchedule = new FormAddSchedule(examId))
            {
                formAddSchedule.StartPosition = FormStartPosition.Manual;

                formAddSchedule.Location = new Point(
                    _parentForm.Location.X + (_parentForm.Width - formAddSchedule.Width) / 2,
                    _parentForm.Location.Y + (_parentForm.Height - formAddSchedule.Height) / 2
                );

                var dialogResult = formAddSchedule.ShowDialog();

                await LoadScheduleAsync();
            }
        }

        private void Bupdateschedule_Click(object sender, EventArgs e)
        {
            if (DGschedule.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn một lịch thi để cập nhật.");
                return;
            }

            if (string.IsNullOrEmpty(selectedSheduleId) || string.IsNullOrEmpty(examId))
            {
                //MessageBox.Show("Không thể xác định lịch thi hoặc kỳ thi.");
                return;
            }

            using (var formUpdateSchedule = new FormUpdateSchedule(selectedSheduleId, examId))
            {
                formUpdateSchedule.StartPosition = FormStartPosition.Manual;

                formUpdateSchedule.Location = new Point(
                    _parentForm.Location.X + (_parentForm.Width - formUpdateSchedule.Width) / 2,
                    _parentForm.Location.Y + (_parentForm.Height - formUpdateSchedule.Height) / 2
                );

                var dialogResult = formUpdateSchedule.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    LoadScheduleAsync();
                }
            }
        }

        private void Bback_Click(object sender, EventArgs e)
        {
            this.Close();

            if (_parentForm != null)
            {
                parentForm.ReloadExamData();
                _parentForm.ShowFormInPanel(parentForm);
            }
        }

        private void DGschedule_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGschedule.ClearSelection();
                DGschedule.Rows[e.RowIndex].Selected = true;
                DataGridViewRow row = DGschedule.Rows[e.RowIndex];
                selectedStudentId = row.Cells["studentId"].Value?.ToString();
                selectedSheduleId = row.Cells["scheduleId"].Value?.ToString();
                selectedStatus = row.Cells["Status"].Value?.ToString();
                selectedResultId = row.Cells["ResultId"].Value?.ToString();
                selectedLecturerId = row.Cells["LecturerId"].Value?.ToString();
                selectedLecturerName = row.Cells["LecturerName"].Value?.ToString();
                selectedEmailLecturer = row.Cells["EmailLecturer"].Value?.ToString();
                selectedStudentName = row.Cells["studentName"].Value?.ToString();
                selectedScore = row.Cells["Score"].Value?.ToString();
                ShowFormMenuStripAtCursor(e);
            }
        }
        private void ShowFormMenuStripAtCursor(DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedSheduleId))
            {

                foreach (Form form in Application.OpenForms)
                {
                    if (form is FormExamMenuStrip menuStrip && !menuStrip.IsDisposed)
                    {
                        menuStrip.Close();
                        break;
                    }
                }

                var menuStripForm = new FormExamMenuStrip(selectedStudentId, examId, _parentForm, selectedStatus, selectedSheduleId,
                    this, selectedResultId, selectedLecturerId, selectedLecturerName, selectedEmailLecturer, selectedStudentName,
                    selectedScore, selectedSubjectName)
                {
                    StartPosition = FormStartPosition.Manual,
                    FormBorderStyle = FormBorderStyle.None,
                    ShowInTaskbar = false,
                    //Size = new Size(200, 100)
                };

                var cellPosition = DGschedule.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point formLocation = DGschedule.PointToScreen(new Point(cellPosition.Left, cellPosition.Bottom));
                menuStripForm.Location = formLocation;

                menuStripForm.Deactivate += (s, ev) => { menuStripForm.Close(); };

                menuStripForm.Show();
            }
        }

    }
}
