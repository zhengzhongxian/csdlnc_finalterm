using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormUpdateExamResult : Form
    {
        private string selectedResultId;
        private string selectedLecturerId;
        private string selectedLecturerName;
        private string examId;
        private FormMainDetailExam _maindetailexam;
        public FormUpdateExamResult(string selectedResultId, string selectedLecturerId, string selectedLecturerName, string examId, FormMainDetailExam maindetailexam)
        {
            InitializeComponent();
            this.selectedResultId = selectedResultId;
            this.selectedLecturerId = selectedLecturerId;
            this.selectedLecturerName = selectedLecturerName;
            this.examId = examId;
            _maindetailexam = maindetailexam;
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            if (txtScore.Text == string.Empty)
            {
                labelfalse.Visible = true;
                txtScore.BorderColor = Color.Red;
                return;
            }

            try
            {

                var selectedLecturer = CBlecturer.SelectedItem as ComboBoxItem;
                if (selectedLecturer == null || string.IsNullOrEmpty(selectedLecturer.Value))
                {
                    MessageBox.Show("Vui lòng chọn một giảng viên.");
                    return;
                }

                if (!decimal.TryParse(txtScore.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var score))
                {
                    MessageBox.Show("Điểm nhập vào không hợp lệ.");
                    return;
                }

                score = Math.Round(score, 1, MidpointRounding.ToEven);
                //MessageBox.Show(score.ToString());
                var updateScoreResponse = await ApiHelper.PutAsync<string, ServiceResponse<bool>>(
                    $"ExamResult/{selectedResultId}/score?score={score.ToString(CultureInfo.InvariantCulture)}", null);

                if (!updateScoreResponse.Success)
                {
                    MessageBox.Show($"Lỗi khi cập nhật điểm: {updateScoreResponse.Message}");
                    return;
                }

                var updateLecturerResponse = await ApiHelper.PutAsync<string, ServiceResponse<bool>>(
                    $"ExamResult/{selectedResultId}/lecturer?lecturerId={selectedLecturer.Value}", null);

                if (!updateLecturerResponse.Success)
                {
                    MessageBox.Show($"Lỗi khi cập nhật giảng viên: {updateLecturerResponse.Message}");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

                // Hiển thị thông báo thành công
                Task.Run(() =>
                {
                    var formSuccess = new FormTbUpdateExamResultSuccess();
                    formSuccess.StartPosition = FormStartPosition.Manual;
                    formSuccess.Location = new Point(
                        Application.OpenForms[0].Location.X + (Application.OpenForms[0].Width - formSuccess.Width) / 2,
                        Application.OpenForms[0].Location.Y + (Application.OpenForms[0].Height - formSuccess.Height) / 2
                    );

                    Application.OpenForms[0].BeginInvoke((Action)(() =>
                    {
                        formSuccess.TopMost = true;
                        formSuccess.ShowDialog();
                    }));
                });
                if (_maindetailexam is FormMainDetailExam parentDetailExam)
                {
                    parentDetailExam.BeginInvoke(new Action(async () => await parentDetailExam.LoadScheduleAsync()));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void FormUpdateExamResult_Load(object sender, EventArgs e)
        {
            CBlecturer.Items.Clear();
            CBlecturer.Items.Add(new ComboBoxItem
            {
                Text = selectedLecturerName,
                Value = selectedLecturerId
            });
            CBlecturer.SelectedIndex = 0;
        }

        private async void CBlecturer_DropDown(object sender, EventArgs e)
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
            }
        }

        private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && (txtScore.Text.Contains('.') || txtScore.Text.Length == 0))
            {
                e.Handled = true;
                return;
            }

            if (!txtScore.Text.Contains('.') && txtScore.Text.Length > 0 && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtScore_Leave(object sender, EventArgs e)
        {
            if (txtScore.Text.EndsWith("."))
            {
                txtScore.Text += "0";
            }
        }
    }
}
