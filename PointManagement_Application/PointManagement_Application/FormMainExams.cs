using Newtonsoft.Json;
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
    public partial class FormMainExams : Form
    {
        private bool isAddExamFormOpen = false;
        private bool isUpdateExamFormOpen = false;
        private string selectedExamId;
        public string currentFacultyId;
        private FormExamDetail examDetailForm;
        private readonly FormMain_Manager _parentForm;
        public bool IsAnyExamFormOpen => isAddExamFormOpen || isUpdateExamFormOpen;
        public FormMainExams(FormMain_Manager parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            FormHelper.EnableDrag(this, _parentForm);
        }

        private async void Bcreat_exam_Click(object sender, EventArgs e)
        {
            if (isAddExamFormOpen || isUpdateExamFormOpen) return;

            isAddExamFormOpen = true;

            FormAddExam formAddExam = new FormAddExam
            {
                StartPosition = FormStartPosition.Manual,
                MainManagerForm = _parentForm,
                Tag = this.Tag
            };

            int x = _parentForm.Location.X + (_parentForm.Width - formAddExam.Width) / 2;
            int y = _parentForm.Location.Y + (_parentForm.Height - formAddExam.Height) / 2;
            formAddExam.Location = new Point(x, y);

            var dialogResult = formAddExam.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {

                var successForm = new FormTbAddExamSuccess
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = _parentForm
                };
                successForm.ShowDialog();
            }

            isAddExamFormOpen = false;

            if (!string.IsNullOrEmpty(currentFacultyId))
            {
                await LoadExamsByFacultyAsync(currentFacultyId);
            }
        }

        private async void Bupdate_exam_Click(object sender, EventArgs e)
        {
            if (isAddExamFormOpen || isUpdateExamFormOpen) return;

            if (string.IsNullOrEmpty(selectedExamId))
            {
                MessageBox.Show("Vui lòng chọn một kỳ thi để cập nhật.");
                return;
            }

            isUpdateExamFormOpen = true;

            var exam = await ApiHelper.GetAsync<ExamDTO>($"Exam/{selectedExamId}");

            if (exam != null)
            {
                FormUpdateExam updateForm = new FormUpdateExam(selectedExamId);
                updateForm.Tag = this.Tag;
                updateForm.PopulateFields(exam);

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
                        Owner = _parentForm,
                    };
                    successForm.ShowDialog();
                }

                isUpdateExamFormOpen = false;

                if (!string.IsNullOrEmpty(currentFacultyId))
                {
                    await LoadExamsByFacultyAsync(currentFacultyId);
                }
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin kỳ thi.");
                isUpdateExamFormOpen = false;
            }
        }

        private async void FormMainExams_Load(object sender, EventArgs e)
        {
            await LoadFacultiesAsync();
        }
        private async Task LoadFacultiesAsync()
        {
            try
            {
                var faculties = await ApiHelper.GetAsync<List<FacultyDTO>>("Faculty");

                if (faculties != null && faculties.Count > 0)
                {
                    CBfaculty.Items.Clear(); 
                    foreach (var faculty in faculties)
                    {
                        CBfaculty.Items.Add(new ComboBoxItem
                        {
                            Text = faculty.FacultyName,
                            Value = faculty.FacultyId
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khoa: {ex.Message}");
            }
        }

        private async void CBfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFaculty = CBfaculty.SelectedItem as ComboBoxItem;

            if (selectedFaculty != null)
            {
                currentFacultyId = selectedFaculty.Value;
                await LoadExamsByFacultyAsync(currentFacultyId);
            }
        }
        public async Task LoadExamsByFacultyAsync(string facultyId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5000/api/");

                    string token = this.Tag?.ToString();
                    if (string.IsNullOrEmpty(token))
                    {
                        MessageBox.Show("Không tìm thấy token. Vui lòng đăng nhập lại.");
                        return;
                    }

                    // Thêm Authorization header với Bearer token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var response = await client.GetAsync($"Exam/faculty/{facultyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var exams = JsonConvert.DeserializeObject<List<ExamDTO>>(responseBody);

                        DGexam.Rows.Clear();
                        if (exams != null && exams.Count > 0)
                        {
                            foreach (var exam in exams)
                            {
                                int rowIndex = DGexam.Rows.Add();
                                DataGridViewRow row = DGexam.Rows[rowIndex];

                                row.Cells["examId"].Value = exam.ExamId;
                                row.Cells["subjectName"].Value = exam.SubjectName;
                                row.Cells["roomName"].Value = exam.RoomName;
                                row.Cells["examDate"].Value = exam.ExamDate.ToString("dd/MM/yyyy");
                                row.Cells["timeSlot"].Value = exam.TimeSlot;
                                row.Cells["duration"].Value = exam.Duration;
                                row.Cells["vacantSeat"].Value = exam.VacantSeat;
                                row.Cells["invigilatorName"].Value = exam.InvigilatorName;
                                row.Cells["examType"].Value = exam.ExamType;
                            }
                        }
                        else
                        {
                            DGexam.Rows.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể tải dữ liệu kỳ thi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async void Bdelete_exam_Click(object sender, EventArgs e)
        {
            if (isAddExamFormOpen || isUpdateExamFormOpen) return;
            if (string.IsNullOrEmpty(selectedExamId))
            {
                MessageBox.Show("Vui lòng chọn một kỳ thi để xóa.");
                return;
            }

            using (var formDelete = new FormTbDeleteExam())
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
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("https://localhost:5000/api/");

                            string token = this.Tag?.ToString();
                            if (string.IsNullOrEmpty(token))
                            {
                                MessageBox.Show("Không tìm thấy token. Vui lòng đăng nhập lại.");
                                return;
                            }

                            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                            var response = await client.DeleteAsync($"Exam/{selectedExamId}");

                            if (response.IsSuccessStatusCode)
                            {
                                var successForm = new FormTbDeleteSucces
                                {
                                    StartPosition = FormStartPosition.CenterParent,
                                    Owner = _parentForm
                                };
                                successForm.ShowDialog();

                                if (!string.IsNullOrEmpty(currentFacultyId))
                                {
                                    await LoadExamsByFacultyAsync(currentFacultyId);
                                }
                                else
                                {
                                    DGexam.Rows.Clear();
                                }

                                if (DGexam.Rows.Count == 0)
                                {
                                    selectedExamId = null;
                                }
                            }
                            else
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();
                                MessageBox.Show($"Không thể xóa kỳ thi: {responseBody}");
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("404"))
                        {
                            MessageBox.Show("Kỳ thi này không tồn tại hoặc đã bị xóa trước đó.");
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi xảy ra khi xóa kỳ thi: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void DGexam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGexam.Rows[e.RowIndex];
                selectedExamId = row.Cells["examId"].Value.ToString();
            }
        }

        private void DGexam_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGexam.ClearSelection();
                DGexam.Rows[e.RowIndex].Selected = true;

                selectedExamId = DGexam.Rows[e.RowIndex].Cells["examId"].Value.ToString();

                ShowExamDetailFormAtCursor(e);
            }
        }
        private void ShowExamDetailFormAtCursor(DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedExamId))
            {

                DataGridViewRow row = DGexam.Rows[e.RowIndex];
                string examId = row.Cells["examId"].Value?.ToString() ?? string.Empty;
                string subjectName = row.Cells["subjectName"].Value?.ToString() ?? string.Empty;
                string roomName = row.Cells["roomName"].Value?.ToString() ?? string.Empty;
                string invigilatorName = row.Cells["invigilatorName"].Value?.ToString() ?? string.Empty;

                // Đóng form nếu đã mở trước đó
                if (examDetailForm != null && !examDetailForm.IsDisposed)
                {
                    examDetailForm.Close();
                }

                examDetailForm = new FormExamDetail(examId, subjectName, roomName, invigilatorName, this, _parentForm)
                {
                    StartPosition = FormStartPosition.Manual,
                    Size = new Size(158, 27),
                    ShowInTaskbar = false,
                    FormBorderStyle = FormBorderStyle.None,
                    AutoSize = false,
                    AutoScaleMode = AutoScaleMode.None,
                    Padding = new Padding(0)
                };

                var cellPosition = DGexam.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point formLocation = DGexam.PointToScreen(new Point(cellPosition.Left, cellPosition.Bottom));
                examDetailForm.Location = formLocation;

                examDetailForm.Deactivate += (s, ev) => { examDetailForm.Close(); };

                examDetailForm.Show();
            }
        }

        public async void ReloadExamData()
        {
            if (!string.IsNullOrEmpty(currentFacultyId))
            {
                await LoadExamsByFacultyAsync(currentFacultyId);
            }
            else
            {
                DGexam.Rows.Clear();
            }
        }
    }
}
