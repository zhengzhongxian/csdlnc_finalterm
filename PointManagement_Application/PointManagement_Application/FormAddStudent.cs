
using Microsoft.AspNetCore.SignalR.Client;
using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormAddStudent : Form
    {
        private Image defaultImage;
        public FormMain_Manager MainManagerForm { get; set; }
        private HubConnection hubConnection;
        private Loading loading;
        public FormAddStudent()
        {
            InitializeComponent();
            defaultImage = CPBstudent.Image;
        }

        private async void FormAddStudent_Load(object sender, EventArgs e)
        {
            await LoadFacultiesAsync();
            await LoadEducationSystemsAsync();
            await LoadAcademicYearsAsync();
            LoadGenderOptions();
           
        }
        private void LoadGenderOptions()
        {
            CBgender.Items.Add("Nam");
            CBgender.Items.Add("Nữ");
        }
        private async Task LoadFacultiesAsync()
        {
            var faculties = await ApiHelper.GetAsync<List<FacultyDTO>>("Faculty");
            foreach (var faculty in faculties)
            {
                CBfaculty.Items.Add(new ComboBoxItem { Text = faculty.FacultyName, Value = faculty.FacultyId });
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

        private async Task LoadAcademicYearsAsync()
        {
            var academicYears = await ApiHelper.GetAsync<List<AcademicYearDTO>>("AcademicYear");
            foreach (var ay in academicYears)
            {
                CBay.Items.Add(new ComboBoxItem { Text = ay.YearAcademicYear, Value = ay.IdAcademicYear });
            }
        }

        private async void Bsubmit_Click(object sender, EventArgs e)
        {
            Bsubmit.Enabled = false;
            var formloading = new Loading("Adding student, please wait...")
            {
                StartPosition = FormStartPosition.Manual
            };

            if (MainManagerForm != null)
            {
                int x = MainManagerForm.Location.X + (MainManagerForm.Width - formloading.Width) / 2;
                int y = MainManagerForm.Location.Y + (MainManagerForm.Height - formloading.Height) / 2;
                formloading.Location = new Point(x, y);
            }
            formloading.Show();
            string token = this.Tag?.ToString();
            string studentName = Tstudentname.Text;
            string phone = Tphone.Text;
            string email = Temail.Text;
            string gender = CBgender.SelectedItem?.ToString() ?? string.Empty;
            DateTime dob = DTdob.Value;
            string address = Taddress.Text;

            var selectedFaculty = CBfaculty.SelectedItem as ComboBoxItem;
            var selectedEs = CBes.SelectedItem as ComboBoxItem;
            var selectedAy = CBay.SelectedItem as ComboBoxItem;

            if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) ||
                selectedFaculty == null || selectedEs == null || selectedAy == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            string dobString = dob.ToString("yyyy-MM-dd");
            byte[] photoBytes = ConvertImageToByteArray(CPBstudent.Image);
            var newStudent = new StudentCreateDTO
            {
                StudentName = studentName,
                PhoneNumber = phone,
                Email = email,
                Gender = gender,
                DayOfBirth = dobString,
                Address = address,
                FacultyId = selectedFaculty.Value,
                IdEs = selectedEs.Value,
                IdAcademicYear = selectedAy.Value,
                ImageFile = photoBytes
            };

            try
            {
                var response = await ApiHelper.PostAsync<StudentCreateDTO, ServiceResponse<bool>>("Student", newStudent, token, true);

                if (response.Success && response.Data)
                {
                    formloading.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //loading.UpdateProgress(0, "Lỗi!");
                    MessageBox.Show($"Lỗi khi thêm sinh viên: {response.Message}");
                }
            }
            catch (HttpRequestException ex)
            {
                //loading.UpdateProgress(0, "Lỗi!");
                MessageBox.Show("So dien thoai hoac email trung");
            }
            catch (WebException ex)
            {
                //loading.UpdateProgress(0, "Lỗi!"); // Reset progress nếu có lỗi
                MessageBox.Show("Lỗi kết nối mạng: " + ex.Message);
            }
            catch (Exception ex)
            {
                //loading.UpdateProgress(0, "Lỗi!");
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
          /*  finally
            {
                loading.Close(); // Đóng form loading await hubConnection.Stop(); }
                hubConnection.Stop();
            }*/
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == defaultImage)
            {
                return null;
            }

            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void CPBstudent_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh cho sinh viên";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CPBstudent.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
