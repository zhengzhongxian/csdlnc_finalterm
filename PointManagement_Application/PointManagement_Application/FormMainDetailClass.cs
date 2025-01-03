using Guna.UI2.WinForms;
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
    public partial class FormMainDetailClass : Form
    {
        private readonly FormMain_Manager _parentForm;
        private FormMainClass _class;
        private string selectedclassId;
        private string selectedclassName;
        private string selectedsubjectid;
        private string selectedsubjectname;
        private string selectedlecturername;
        private string selectedclassstudentid;

        public FormMainDetailClass(string selectedclassId, string selectedclassName, string selectedsubjectid, 
            string selectedsubjectname, string selectedlecturername, FormMainClass _class, FormMain_Manager _parentForm)
        {
            InitializeComponent();
            this._parentForm = _parentForm;
            this._class = _class;
            this.selectedclassId = selectedclassId;
            this.selectedclassName = selectedclassName;
            this.selectedsubjectid = selectedsubjectid;
            this.selectedsubjectname = selectedsubjectname;
            this.selectedlecturername = selectedlecturername;
            Lclassid.Text += selectedclassId;
            Lclassname.Text += selectedclassName;
            Lsubjectname.Text += selectedsubjectname;
            Llecturername.Text += selectedlecturername;
            FormHelper.EnableDrag(this, _parentForm);
            LoadClassStudentAsync();
        }
        public async Task LoadClassStudentAsync()
        {
            try
            {
                var classStudents = await ApiHelper.GetAsync<List<ClassStudentDTO>>($"ClassStudent/class/{selectedclassId}");

                if (classStudents != null && classStudents.Count > 0)
                {
                    PopulateScheduleDataGrid(classStudents);
                    guna2HtmlLabel2.Visible = false;
                }
                else
                {
                    guna2HtmlLabel2.Visible = true;
                    DGclassstudent.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đéo có sinh viên nào ở đây");
            }
        }

        private void PopulateScheduleDataGrid(List<ClassStudentDTO> classStudents)
        {
            DGclassstudent.Rows.Clear();

            foreach (var classStudent in classStudents)
            {
                int rowIndex = DGclassstudent.Rows.Add();
                DataGridViewRow row = DGclassstudent.Rows[rowIndex];
                row.Cells["classstudentId"].Value = classStudent.Id;
                row.Cells["StudentId"].Value = classStudent.StudentId;
                row.Cells["StudentName"].Value= classStudent.StudentName;
                row.Cells["Score"].Value = classStudent.Score.HasValue
     ? (classStudent.Score.Value).ToString("F1", System.Globalization.CultureInfo.InvariantCulture)
     : "N/A";
            }
        }

        private void FormMainDetailClass_Load(object sender, EventArgs e)
        {

        }

        private async void Bdelete_Click(object sender, EventArgs e)
        {
            if (DGclassstudent.Rows.Count == 0) { return; }
            if (string.IsNullOrEmpty(selectedclassstudentid)) { return; }
            using (var formDelete = new FormTbDeleteClassStudent())
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

                        var responseMessage = await ApiHelper.DeleteAsync<string>($"ClassStudent/{selectedclassstudentid}");

                        using (var formSuccess = new FormTbDeleteSucces())
                        {
                            formSuccess.StartPosition = FormStartPosition.Manual;

                            int successX = _parentForm.Location.X + (_parentForm.Width - formSuccess.Width) / 2;
                            int successY = _parentForm.Location.Y + (_parentForm.Height - formSuccess.Height) / 2;
                            formSuccess.Location = new Point(successX, successY);

                            formSuccess.ShowDialog();
                        }

                        await LoadClassStudentAsync();

                        if (DGclassstudent.Rows.Count == 0)
                        {
                            DGclassstudent.Rows.Clear();
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
                            MessageBox.Show($"Lỗi xảy ra khi xóa sinh viên này khỏi lớp học: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void DGclassstudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGclassstudent.Rows[e.RowIndex];
                selectedclassstudentid = row.Cells["classstudentId"].Value.ToString();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            if (_parentForm != null)
            {
                _class.ReloadExamData();
                _parentForm.ShowFormInPanel(_class);
            }
        }

        private async void Badd_student_Click(object sender, EventArgs e)
        {
            using (var formAddSchedule = new FormAddClassStudent(selectedsubjectid,selectedclassId, this))
            {
                formAddSchedule.StartPosition = FormStartPosition.Manual;

                formAddSchedule.Location = new Point(
                    _parentForm.Location.X + (_parentForm.Width - formAddSchedule.Width) / 2,
                    _parentForm.Location.Y + (_parentForm.Height - formAddSchedule.Height) / 2
                );

                var dialogResult = formAddSchedule.ShowDialog();

                await LoadClassStudentAsync();
            }
        }

        private async void Bupdate_score_Click(object sender, EventArgs e)
        {
            if (DGclassstudent.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn một lịch thi để cập nhật.");
                return;
            }

            if (string.IsNullOrEmpty(selectedclassstudentid))
            {
                //MessageBox.Show("Không thể xác định lịch thi hoặc kỳ thi.");
                return;
            }
            var formupdatescore = new FormUpdateClassScore(selectedclassstudentid, this);
            formupdatescore.StartPosition = FormStartPosition.Manual;
            formupdatescore.Location= new Point(
                    _parentForm.Location.X + (_parentForm.Width - formupdatescore.Width) / 2,
                    _parentForm.Location.Y + (_parentForm.Height - formupdatescore.Height) / 2
            );
            var result = formupdatescore.ShowDialog();
            if (result == DialogResult.OK)
            {
                var formtb = new FormTbUpdateScoreSuccess
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };
                formtb.ShowDialog();
            }
            await LoadClassStudentAsync();
        }
    }
}
