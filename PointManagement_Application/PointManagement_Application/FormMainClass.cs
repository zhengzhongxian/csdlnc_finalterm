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
    public partial class FormMainClass : Form
    {
        private readonly FormMain_Manager _parentForm;
        public string currentFacultyId;
        private string selectedclassId;
        private string selectedclassName;
        private string selectedsubjectid;
        private string selectedsubjectname;
        private string selectedlecturername;

        public FormMainClass(FormMain_Manager formMain_Manager)
        {
            InitializeComponent();
            this._parentForm = formMain_Manager;
            FormHelper.EnableDrag(this, _parentForm);
        }
        private async Task LoadFacultiesAsync()
        {
            try
            {
                string token = this.Tag?.ToString();
                var faculties = await ApiHelper.GetAsync<List<FacultyDTO>>("Faculty", token, true);

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

        private async Task LoadClassesByFacultyAsync(string facultyId)
        {
            try
            {
                string token = this.Tag?.ToString();

                var classes = await ApiHelper.GetAsync<List<ClassDTO>>($"Class/Faculty/{facultyId}", token , true);
                DGclass.Rows.Clear();

                if (classes != null && classes.Count > 0)
                {
                    foreach (var cls in classes)
                    {
                        int rowIndex = DGclass.Rows.Add();
                        DataGridViewRow row = DGclass.Rows[rowIndex];

                        row.Cells["ClassId"].Value = cls.ClassId;
                        row.Cells["ClassName"].Value = cls.ClassName;
                        row.Cells["Quantity"].Value = cls.Quantity;
                        row.Cells["SubjectId"].Value = cls.SubjectId;
                        row.Cells["SubjectName"].Value = cls.SubjectName;
                        row.Cells["startdate"].Value = cls.StartDate.ToString("dd/MM/yyyy");
                        row.Cells["EndDate"].Value = cls.EndDate.ToString("dd/MM/yyyy");
                        row.Cells["LecturerName"].Value = cls.LecturerName;
                        row.Cells["LecturerId"].Value = cls.LecturerId;
                        row.Cells["IdLectuerSubject"].Value = cls.IdLectuerSubject;
                        row.Cells["IdEs"].Value = cls.IdEs;
                        row.Cells["es"].Value = cls.EsName;
                    }
                }
                else
                {
                    DGclass.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp: {ex.Message}");
            }
        }

        private async void FormMainClass_Load(object sender, EventArgs e)
        {
            await LoadFacultiesAsync();
        }

        private async void CBfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFaculty = CBfaculty.SelectedItem as ComboBoxItem;

            if (selectedFaculty != null)
            {
                currentFacultyId = selectedFaculty.Value;
                await LoadClassesByFacultyAsync(currentFacultyId);
            }
        }

        private async void Baddclass_Click(object sender, EventArgs e)
        {
            FormAddClass formAddClass = new FormAddClass
            {
                StartPosition = FormStartPosition.Manual,
                MainManagerForm= _parentForm,
                Tag = this.Tag,
            };
            int x = _parentForm.Location.X + (_parentForm.Width - formAddClass.Width) / 2;
            int y = _parentForm.Location.Y + (_parentForm.Height - formAddClass.Height) / 2;
            formAddClass.Location = new Point(x, y);
            var dialogresult = formAddClass.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                var successForm = new FormTbAddClassSuccess
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };
                successForm.ShowDialog();
            }

            if (!string.IsNullOrEmpty(currentFacultyId))
            {
                await LoadClassesByFacultyAsync(currentFacultyId);
            }
        }

        private void DGclass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridView = DGclass.Rows[e.RowIndex];
                selectedclassId = dataGridView.Cells["ClassId"].Value.ToString();
                selectedclassName = dataGridView.Cells["ClassName"].Value.ToString();
                selectedsubjectid = dataGridView.Cells["SubjectId"].Value.ToString();
                selectedsubjectname = dataGridView.Cells["SubjectName"].Value.ToString();
                selectedlecturername = dataGridView.Cells["LecturerName"].Value.ToString();
            }
        }

        private async void Bdelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedclassId))
            {
                //MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                return;
            }
            using (var formDelete = new FormTbDeleteClass())
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
                        var responseMessage = await ApiHelper.DeleteAsync<string>($"Class/{selectedclassId}");

                        var successForm = new FormTbDeleteSucces
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Owner = _parentForm
                        };
                        successForm.ShowDialog();

                        if (!string.IsNullOrEmpty(currentFacultyId))
                        {
                            await LoadClassesByFacultyAsync(currentFacultyId);
                        }
                        else
                        {
                            DGclass.Rows.Clear();
                        }

                        if (DGclass.Rows.Count == 0)
                        {
                            selectedclassId = null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("404"))
                        {
                            MessageBox.Show("Lớp này không tồn tại hoặc đã bị xóa trước đó.");
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi xảy ra khi xóa Lớp học: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void Bupdate_class_Click(object sender, EventArgs e)
        {
            var formtbupdate = new FormTbProccessing
            {
                StartPosition = FormStartPosition.Manual,
            };
            int x = _parentForm.Location.X + (_parentForm.Width - formtbupdate.Width) / 2;
            int y = _parentForm.Location.Y + (_parentForm.Height - formtbupdate.Height) / 2;
            formtbupdate.Location = new Point(x, y);
            formtbupdate.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedclassId))
            {
                //MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                return;
            }

            var formdetailclass = new FormMainDetailClass(selectedclassId, selectedclassName, selectedsubjectid, selectedsubjectname,
                selectedlecturername, this, _parentForm);
            _parentForm.ShowFormInPanel(formdetailclass);
            this.Hide();
        }
        public async void ReloadExamData()
        {
            if (!string.IsNullOrEmpty(currentFacultyId))
            {
                await LoadClassesByFacultyAsync(currentFacultyId);
            }
            else
            {
                DGclass.Rows.Clear();
            }
        }
    }
}
