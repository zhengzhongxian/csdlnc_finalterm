
using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormAddClass : Form
    {
        public FormMain_Manager MainManagerForm { get; set; }
        public FormAddClass()
        {
            InitializeComponent();
        }

        private async void CBsubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedSubject = CBsubject.SelectedItem as ComboBoxItem;

            if (selectedSubject != null)
            {
                var subjectId = selectedSubject.Value;

                await LoadLecturerSubjectsAsync(subjectId);
            }
            else
            {
                CBlecturersubject.Items.Clear();
                CBlecturersubject.Enabled = false;
            }
        }
        private async Task LoadSubjectsAsync()
        {
            try
            {
                var subjects = await ApiHelper.GetDataAsync<List<SubjectDTO>>("Subject");

                CBsubject.Items.Clear();
                foreach (var subject in subjects)
                {
                    CBsubject.Items.Add(new ComboBoxItem
                    {
                        Text = subject.SubjectName,
                        Value = subject.SubjectId
                    });
                }

                CBsubject.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}");
            }
        }
        private async Task LoadEducationSystemsAsync()
        {
            var educationSystems = await ApiHelper.GetAsync<List<EducationSystemDTO>>("EducationSystem");
            foreach (var es in educationSystems)
            {
                CBes.Items.Add(new ComboBoxItem { Text = es.NameEs, Value = es.IdEs });
            }
        }

        private async Task LoadLecturerSubjectsAsync(string subjectId)
        {
            try
            {

                var lecturerSubjects = await ApiHelper.GetAsync<List<LecturerSubjectDTO>>($"LecturerSubject/{subjectId}");

                CBlecturersubject.Items.Clear();
                foreach (var lecturerSubject in lecturerSubjects)
                {
                    CBlecturersubject.Items.Add(new ComboBoxItem
                    {
                        Text = lecturerSubject.LecturerName,
                        Value = lecturerSubject.Id
                    });
                }

                CBlecturersubject.Enabled = true;
                CBlecturersubject.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách giảng viên: {ex.Message}");
                CBlecturersubject.Items.Clear();
                CBlecturersubject.Enabled = false;
            }
        }
        private void CBlecturersubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void FormAddClass_Load(object sender, EventArgs e)
        {
            await LoadSubjectsAsync();
            await LoadEducationSystemsAsync();
        }
        private bool ValidateFormInputs()
        {
            return CBes.SelectedItem != null &&
                   CBsubject.SelectedItem != null &&
                   CBlecturersubject.SelectedItem != null;
        }

        private async void Bsubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                labelfalse.Visible = true;
                return;
            }
            var selectedsubjectid = CBlecturersubject.SelectedItem as ComboBoxItem;
            DateTime startdate = DTstartdate.Value;
            DateTime enddate = DTenddate.Value;
            var selectedEs = CBes.SelectedItem as ComboBoxItem;
            var newClass = new ClassCreateDTO
            {
                StartDate = startdate.ToString("yyyy-MM-dd"),
                EndDate = enddate.ToString("yyyy-MM-dd"),
                IdLectuerSubject = selectedsubjectid.Value,
                IdEs = selectedEs.Value,
            };

            try
            {
                string token = this.Tag?.ToString();
                var response = await ApiHelper.PostAsync<ClassCreateDTO, ServiceResponse<bool>>("Class", newClass, token, true);

                if (response.Success && response.Data)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thêm lớp: {response.Message}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
