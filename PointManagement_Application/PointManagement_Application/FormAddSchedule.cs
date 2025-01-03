using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
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
    public partial class FormAddSchedule : Form
    {
        private string examId;
        private string selectedStudentId;

        public FormAddSchedule(string examId)
        {
            InitializeComponent();
            this.examId = examId;
            LoadStudentsNotInScheduleAsync();
        }

        private async Task LoadStudentsNotInScheduleAsync()
        {
            try
            {
                var students = await ApiHelper.GetAsync<List<OtherStudentDTO>>($"Schedule/students-not-in-schedule/{examId}");

                if (students != null)
                {
                    PopulateStudentsDataGrid(students);
                }
                else
                {
                    //MessageBox.Show("Không có sinh viên nào chưa được thêm vào lịch thi.");
                    DGschedule.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}");
            }
        }

        private void PopulateStudentsDataGrid(List<OtherStudentDTO> students)
        {
            DGschedule.Rows.Clear();

            foreach (var student in students)
            {
                int rowIndex = DGschedule.Rows.Add();
                DataGridViewRow row = DGschedule.Rows[rowIndex];
                row.Cells["studentId"].Value = student.StudentId;
                row.Cells["studentName"].Value = student.StudentName;
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void DGschedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGschedule.Rows.Count)
            {
                DataGridViewRow row = DGschedule.Rows[e.RowIndex];
                selectedStudentId = row.Cells["studentId"].Value?.ToString();
            }
        }

        private async void Bcreatschedule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStudentId))
            {
                //MessageBox.Show("Vui lòng chọn một sinh viên để thêm vào lịch thi.");
                return;
            }

            using (var formSeat = new FormSeat(examId, selectedStudentId))
            {
                formSeat.StartPosition = FormStartPosition.Manual;

                formSeat.Location = new Point(
                    this.Location.X + (this.Width - formSeat.Width) / 2,
                    this.Location.Y + (this.Height - formSeat.Height) / 2
                );

                formSeat.ShowDialog();

                if (formSeat.IsSeatAssigned)
                {
                    await LoadStudentsNotInScheduleAsync();

                    if (this.Owner is FormMainDetailExam mainDetailExam)
                    {
                        await mainDetailExam.LoadScheduleAsync();
                    }
                }
            }
        }
    }
}
