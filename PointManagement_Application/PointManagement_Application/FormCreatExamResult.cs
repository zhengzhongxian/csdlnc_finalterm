using Newtonsoft.Json;
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
    public partial class FormCreatExamResult : Form
    {
        private string selectedStudentId;
        private string examId;
        private FormMain_Manager _parentForm;
        private string selectedStatus;
        private string selectedSheduleId;
        private FormMainDetailExam _maindetailexam;
        public FormCreatExamResult(string selectedStudentId, string examId, FormMain_Manager parentForm, string selectedStatus, string selectedSheduleId, FormMainDetailExam maindetailexam)
        {
            InitializeComponent();
            this.selectedStudentId = selectedStudentId;
            this.examId = examId;
            this._parentForm = parentForm;
            this.selectedStatus = selectedStatus;
            this.selectedSheduleId = selectedSheduleId;
            _maindetailexam = maindetailexam;
        }

        private async void FormCreatExamResult_Load(object sender, EventArgs e)
        {
            try
            {
                var lecturers = await ApiHelper.GetAsync<List<SimplifiedLecturerDTO>>($"Exam/{examId}/lecturers");

                CBlecturer.Items.Clear();
                if (lecturers != null && lecturers.Any())
                {
                    foreach (var lecturer in lecturers)
                    {
                        CBlecturer.Items.Add(new ComboBoxItem
                        {
                            Text = lecturer.LecturerName,
                            Value = lecturer.LecturerId
                        });
                    }
                }
                else
                {
                    CBlecturer.Items.Add(new ComboBoxItem
                    {
                        Text = "Not lecturer available",
                        Value = null
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách giảng viên: {ex.Message}");
                CBlecturer.Items.Add(new ComboBoxItem
                {
                    Text = "Not lecturer available",
                    Value = null
                });
            }
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            if (CBlecturer.SelectedItem == null)
            {
                labelfalse.Visible = true;
                CBlecturer.BorderColor = Color.Red;
                return;
            }

            try
            {
                // Lấy giảng viên đã chọn
                var selectedLecturer = CBlecturer.SelectedItem as ComboBoxItem;
                if (selectedLecturer == null || string.IsNullOrEmpty(selectedLecturer.Value))
                {
                    MessageBox.Show("Vui lòng chọn một giảng viên.");
                    return;
                }

                var examResultData = new
                {
                    StudentId = selectedStudentId,
                    ExamId = examId,
                    LecturerId = selectedLecturer.Value
                };
                //MessageBox.Show(JsonConvert.SerializeObject(examResultData, Formatting.Indented));
                var createResultResponse = await ApiHelper.PostAsync<object, ServiceResponse<bool>>("ExamResult", examResultData);

                if (!createResultResponse.Success || !createResultResponse.Data)
                {
                    MessageBox.Show($"Lỗi khi tạo kết quả thi: {createResultResponse.Message}");
                    return;
                }

                var updateStatusResponse = await ApiHelper.PutAsync<object, ServiceResponse<bool>>($"Schedule/{selectedSheduleId}/status-to-2", null);

                if (!updateStatusResponse.Success || !updateStatusResponse.Data)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái: {updateStatusResponse.Message}");
                    return;
                }
                Task.Run(() =>
                {
                    var formSuccess = new FormTbAddExamResultSuccess();
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
                if (_maindetailexam is FormMainDetailExam parentDetailExam)
                {
                    // Gọi phương thức để load lại DGschedule
                    parentDetailExam.BeginInvoke(new Action(async () => await parentDetailExam.LoadScheduleAsync()));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}
