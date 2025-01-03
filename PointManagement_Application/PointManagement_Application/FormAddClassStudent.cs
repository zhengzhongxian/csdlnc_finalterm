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
    public partial class FormAddClassStudent : Form
    {
        private string selectedsubjectid;
        private string selectedStudentId;
        private string selectedclassId;
        private readonly FormMainDetailClass _class;
        public FormAddClassStudent(string selectedsubjectid, string selectedclassId, FormMainDetailClass _class)
        {
            InitializeComponent();
            this.selectedsubjectid = selectedsubjectid;
            LoadStudentsNotInScheduleAsync();
            this.selectedclassId = selectedclassId;
            this._class = _class;
        }

        private async Task LoadStudentsNotInScheduleAsync()
        {
            try
            {
                var students = await ApiHelper.GetAsync<List<OtherStudentDTO>>($"ClassStudent/not-in-subject/{selectedsubjectid}");

                if (students != null)
                {
                    PopulateStudentsDataGrid(students);
                }
                else
                {
                    MessageBox.Show("Không có sinh viên nào chưa được thêm vào lịch thi.");
                    DGnotinclassstudent.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}");
            }
        }

        private void PopulateStudentsDataGrid(List<OtherStudentDTO> students)
        {
            DGnotinclassstudent.Rows.Clear();

            foreach (var student in students)
            {
                int rowIndex = DGnotinclassstudent.Rows.Add();
                DataGridViewRow row = DGnotinclassstudent.Rows[rowIndex];
                row.Cells["studentId"].Value = student.StudentId;
                row.Cells["studentName"].Value = student.StudentName;
            }
        }

        private void DGnotinclassstudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGnotinclassstudent.Rows.Count)
            {
                DataGridViewRow row = DGnotinclassstudent.Rows[e.RowIndex];
                selectedStudentId = row.Cells["studentId"].Value?.ToString();
            }
        }

        private async void Bcreatclassstudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStudentId))
            {
                //MessageBox.Show("Vui lòng chọn một sinh viên để thêm vào lịch thi.");
                return;
            }
            var newStudent = new ClassStudentCreateDTO
            {
                StudentId = selectedStudentId,
                ClassId = selectedclassId
            };
            try
            {

                var response = await ApiHelper.PostAsync<ClassStudentCreateDTO, ServiceResponse<bool>>("ClassStudent", newStudent);

                if (response.Success && response.Data)
                {
                    await LoadStudentsNotInScheduleAsync();
                    await _class.LoadClassStudentAsync();
                    selectedStudentId = null;
                }
                else
                {
                    MessageBox.Show("Không thể thêm sinh viên vô lớp học: " + response.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên vô lớp học: {ex.Message}");
            }
        }
    }
}
