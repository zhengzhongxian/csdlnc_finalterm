using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using PointManagement_Application.Service.Implement;
using PointManagement_Application.Service.Iservice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormMainStudent : Form
    {
        private readonly IStudentService _studentService;
        private string selectedStudentId;
        public string currentFacultyId;
        private readonly FormMain_Manager _parentForm;
        public bool isAddStudentFormOpen = false;
        public bool isUpdateStudentFormOpen = false;
        private FormSeeDetailStudentMenuStrip studentDetails;
        public FormMainStudent(FormMain_Manager parentForm)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _parentForm = parentForm;
            FormHelper.EnableDrag(this, _parentForm);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private async Task LoadAcademicYear()
        {
            try
            {
                CBacademicyear.Items.Clear();
                CBacademicyear.Items.Add(new ComboBoxItem
                {
                    Text = "--Select Academic Year--",
                    Value = null
                });
                var academic = await ApiHelper.GetAsync<List<AcademicYearDTO>>("AcademicYear");
                if (academic !=null && academic.Count > 0)
                {
                    foreach (var adc in academic)
                    {
                        CBacademicyear.Items.Add(new ComboBoxItem
                        {
                            Text = adc.IdAcademicYear,
                            Value = adc.IdAcademicYear
                        });
                    }
                }
                CBacademicyear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khóa (academic_year): {ex.Message}");
            }
        }

        private async Task LoadFacultiesAsync()
        {
            try
            {
                CBfaculty.Items.Clear();
                CBfaculty.Items.Add(new ComboBoxItem
                {
                    Text = "--Select Faculty--",
                    Value = null
                });

                var faculties = await ApiHelper.GetAsync<List<FacultyDTO>>("Faculty");

                if (faculties != null && faculties.Count > 0)
                {
                    foreach (var faculty in faculties)
                    {
                        CBfaculty.Items.Add(new ComboBoxItem
                        {
                            Text = faculty.FacultyName,
                            Value = faculty.FacultyId
                        });
                    }
                }
                CBfaculty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khoa: {ex.Message}");
            }
        }

        private async void FormMainStudent_Load(object sender, EventArgs e)
        {

            await LoadFacultiesAsync();

            await LoadAcademicYear();
        }

        private void DGstudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGstudent.Rows[e.RowIndex];
                selectedStudentId = row.Cells["studentId"].Value.ToString();
            }
        }

        private async void Bdelete_student_Click(object sender, EventArgs e)
        {
            if (isAddStudentFormOpen || isUpdateStudentFormOpen) return;

            if (string.IsNullOrEmpty(selectedStudentId))
            {
                //MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                return;
            }

            using (var formDelete = new FormDeleteStudent())
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
                        var responseMessage = await _studentService.DeleteStudentAsync(selectedStudentId);

                        var successForm = new FormTbDeleteSucces
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Owner = _parentForm
                        };
                        successForm.ShowDialog();

                        await LoadStudentsByFilter();

                        if (DGstudent.Rows.Count == 0)
                        {
                            selectedStudentId = null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("404"))
                        {
                            MessageBox.Show("Sinh viên này không tồn tại hoặc đã bị xóa trước đó.");
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi xảy ra khi xóa sinh viên: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void CBfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadStudentsByFilter();
        }

        public async Task LoadStudentsByFilter()
        {
            try
            {
                string token = this.Tag?.ToString();
                var selectedFaculty = CBfaculty.SelectedItem as ComboBoxItem;
                string facultyId = selectedFaculty?.Value;

                var selectedAcademicYear = CBacademicyear.SelectedItem as ComboBoxItem;
                string academicYearId = selectedAcademicYear?.Value;

                string apiUrl = "Student/FacultyandAcademic?";
                if (!string.IsNullOrEmpty(facultyId))
                {
                    apiUrl += $"facultyId={facultyId}&";
                }
                if (!string.IsNullOrEmpty(academicYearId))
                {
                    apiUrl += $"academicyear_id={academicYearId}";
                }

                var students = await ApiHelper.GetAsync<List<StudentDTO>>(apiUrl, token, true);

                DGstudent.Rows.Clear();
                if (students != null && students.Count > 0)
                {
                    foreach (var student in students)
                    {
                        int rowIndex = DGstudent.Rows.Add();
                        DataGridViewRow row = DGstudent.Rows[rowIndex];

                        row.Cells["studentId"].Value = student.StudentId;
                        row.Cells["studentName"].Value = student.StudentName;
                        row.Cells["email"].Value = student.Email;
                        row.Cells["phoneNumber"].Value = student.PhoneNumber;
                        row.Cells["gender"].Value = student.Gender;
                        row.Cells["dayofbirth"].Value = student.DayOfBirth?.ToString("dd/MM/yyyy");
                        row.Cells["address"].Value = student.Address;
                        row.Cells["academicYearName"].Value = student.AcademicYearName;
                        row.Cells["educationSystemName"].Value = student.EducationSystemName;
                        row.Cells["facultyName"].Value = student.FacultyName;
                        row.Cells["Auditable"].Value = student.AuditableId;
                    }
                }
                else
                {
                    DGstudent.Rows.Clear(); // Không có sinh viên, xóa DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }


        private async void Bcreat_student_Click(object sender, EventArgs e)
        {
            if (isAddStudentFormOpen || isUpdateStudentFormOpen) return;

            isAddStudentFormOpen = true;

            FormAddStudent formAddStudent = new FormAddStudent
            {
                StartPosition = FormStartPosition.Manual,
                MainManagerForm = _parentForm,
                Tag = this.Tag
            };

            int x = _parentForm.Location.X + (_parentForm.Width - formAddStudent.Width) / 2;
            int y = _parentForm.Location.Y + (_parentForm.Height - formAddStudent.Height) / 2;
            formAddStudent.Location = new Point(x, y);

            var dialogResult = formAddStudent.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {

                var successForm = new FormTbAddSuccess
                {
                    StartPosition = FormStartPosition.CenterParent,
                };
                successForm.ShowDialog();
            }

            isAddStudentFormOpen = false;
            await LoadStudentsByFilter();
        }

        private async void Bupdate_student_Click(object sender, EventArgs e)
        {
            if (isAddStudentFormOpen || isUpdateStudentFormOpen) return;

            if (string.IsNullOrEmpty(selectedStudentId))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để cập nhật.");
                return;
            }

            isUpdateStudentFormOpen = true;

            var student = await ApiHelper.GetAsync<StudentDTO>($"Student/{selectedStudentId}");

            if (student != null)
            {
                FormUpdateStudent updateForm = new FormUpdateStudent(selectedStudentId);
                updateForm.PopulateFields(student);
                updateForm.Tag = this.Tag;
                updateForm.StartPosition = FormStartPosition.Manual;
                updateForm.MainManagerForm = _parentForm;
                int x = _parentForm.Location.X + (_parentForm.Width - updateForm.Width) / 2;
                int y = _parentForm.Location.Y + (_parentForm.Height - updateForm.Height) / 2;
                updateForm.Location = new Point(x, y);

                var dialogResult = updateForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {

                    var successForm = new FormTbUpdateSuccess
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Owner = this
                    };
                    successForm.ShowDialog();
                }

                isUpdateStudentFormOpen = false;
                await LoadStudentsByFilter();
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin sinh viên.");
                isUpdateStudentFormOpen = false;
            }
        }

        private void DGstudent_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void DGstudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGstudent.ClearSelection();
                DGstudent.Rows[e.RowIndex].Selected = true;

                selectedStudentId = DGstudent.Rows[e.RowIndex].Cells["studentId"].Value.ToString();

                ShowStudentDetailFormAtCursor(e);
            }
        }
        private async void ShowStudentDetailFormAtCursor(DataGridViewCellMouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStudentId)) return;

            try
            {

                var student = await ApiHelper.GetAsync<StudentDTO>($"Student/{selectedStudentId}");
                if (student == null)
                {
                    MessageBox.Show("Không thể lấy thông tin sinh viên.");
                    return;
                }

                if (studentDetails != null && !studentDetails.IsDisposed)
                {
                    studentDetails.Close();
                }

                studentDetails = new FormSeeDetailStudentMenuStrip(student, _parentForm, this)
                {
                    StartPosition = FormStartPosition.Manual,
                    ShowInTaskbar = false,
                    AutoSize = false,
                    AutoScaleMode = AutoScaleMode.None,
                    Padding = new Padding(0)
                };

                var cellPosition = DGstudent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point formLocation = DGstudent.PointToScreen(new Point(cellPosition.Left, cellPosition.Bottom));
                studentDetails.Location = formLocation;

                studentDetails.Deactivate += (s, ev) => { studentDetails.Close(); };

                studentDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sinh viên: {ex.Message}");
            }
        }

        private async Task<List<StudentDTO>> SearchStudentsAsync(string query)
        {
            try
            {
                var students = await ApiHelper.GetAsync<List<StudentDTO>>($"Student/Search?search={query}");
                return students ?? new List<StudentDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API tìm kiếm: {ex.Message}");
                return new List<StudentDTO>();
            }
        }

        private async void Tsearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = Tsearch.Text;

            var students = await SearchStudentsAsync(searchQuery);

            UpdateDataGridView(students);
        }


        private void UpdateDataGridView(List<StudentDTO> students)
        {
            DGstudent.Rows.Clear();

            foreach (var student in students)
            {
                int rowIndex = DGstudent.Rows.Add();
                DataGridViewRow row = DGstudent.Rows[rowIndex];

                row.Cells["studentId"].Value = student.StudentId;
                row.Cells["studentName"].Value = student.StudentName;
                row.Cells["email"].Value = student.Email;
                row.Cells["phoneNumber"].Value = student.PhoneNumber;
                row.Cells["gender"].Value = student.Gender;
                row.Cells["dayofbirth"].Value = student.DayOfBirth?.ToString("dd/MM/yyyy");
                row.Cells["address"].Value = student.Address;
                row.Cells["academicYearName"].Value = student.AcademicYearName;
                row.Cells["educationSystemName"].Value = student.EducationSystemName;
                row.Cells["facultyName"].Value = student.FacultyName;
            }
        }

        private async void CBacademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadStudentsByFilter();
        }
    }
}
