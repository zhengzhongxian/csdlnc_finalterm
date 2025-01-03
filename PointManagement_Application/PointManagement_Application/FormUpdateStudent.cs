using Newtonsoft.Json;
using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using PointManagement_Application.Service.Implement;
using PointManagement_Application.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormUpdateStudent : Form
    {
        private readonly IStudentService _studentService;
        private Image defaultImage;
        private string studentId;
        public FormMain_Manager MainManagerForm { get; set; }
        public FormUpdateStudent(string studentId)
        {
            InitializeComponent();
            _studentService = new StudentService();
            defaultImage = CPBstudent.Image;
            this.studentId = studentId;
        }
        private async Task LoadFacultiesAsync(string selectedFacultyName)
        {
            var faculties = await ApiHelper.GetAsync<List<FacultyDTO>>("Faculty");

            CBfaculty.Items.Clear();
            foreach (var faculty in faculties)
            {
                CBfaculty.Items.Add(new ComboBoxItem { Text = faculty.FacultyName, Value = faculty.FacultyId });

                if (faculty.FacultyName == selectedFacultyName)
                {
                    CBfaculty.SelectedItem = CBfaculty.Items[CBfaculty.Items.Count - 1];
                    CBfaculty.Enabled = false;
                }
            }
        }
        private async Task LoadEducationSystemsAsync(string selectedEducationSystemName)
        {
            var educationSystems = await ApiHelper.GetAsync<List<EducationSystemDTO>>("EducationSystem");

            CBes.Items.Clear();
            foreach (var es in educationSystems)
            {
                CBes.Items.Add(new ComboBoxItem { Text = es.NameEs, Value = es.IdEs });

                if (es.NameEs == selectedEducationSystemName)
                {
                    CBes.SelectedItem = CBes.Items[CBes.Items.Count - 1];
                    CBes.Enabled = false; 
                }
            }
        }
        private async Task LoadAcademicYearsAsync(string selectedAcademicYearName)
        {
            var academicYears = await ApiHelper.GetAsync<List<AcademicYearDTO>>("AcademicYear");

            CBay.Items.Clear();
            foreach (var ay in academicYears)
            {
                CBay.Items.Add(new ComboBoxItem { Text = ay.YearAcademicYear, Value = ay.IdAcademicYear });

                if (ay.YearAcademicYear == selectedAcademicYearName)
                {
                    CBay.SelectedItem = CBay.Items[CBay.Items.Count - 1];
                    CBay.Enabled = false;
                }
            }
        }
        public async void PopulateFields(StudentDTO student)
        {
            Tstudentname.Text = student.StudentName;
            Tphone.Text = student.PhoneNumber;
            Temail.Text = student.Email;
            DTdob.Value = student.DayOfBirth ?? DateTime.Now;
            Taddress.Text = student.Address;

            if (!string.IsNullOrEmpty(student.Photo))
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    {
                        byte[] imageData = client.DownloadData(student.Photo);
                        using (var ms = new MemoryStream(imageData))
                        {
                            CPBstudent.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi tải ảnh từ URL. Sử dụng ảnh mặc định.");
                    CPBstudent.Image = defaultImage;
                }
            }
            else
            {
                CPBstudent.Image = defaultImage;
            }

            CBgender.Items.Clear();
            CBgender.Items.Add("Nam");
            CBgender.Items.Add("Nữ");

            if (student.Gender == "Nam")
            {
                CBgender.SelectedItem = "Nam";
            }
            else if (student.Gender == "Nữ")
            {
                CBgender.SelectedItem = "Nữ";
            }

            await LoadFacultiesAsync(student.FacultyName);
            await LoadEducationSystemsAsync(student.EducationSystemName);
            await LoadAcademicYearsAsync(student.AcademicYearName);

        }

        private void FormUpdateStudent_Load(object sender, EventArgs e)
        {

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

        private async void Bsubmit_Click(object sender, EventArgs e)
        {
            Bsubmit.Enabled = false;
            var formloading = new LoadingUpdate("Updating info student, please wait...")
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
            string gender = CBgender.SelectedItem?.ToString() ?? string.Empty;
            string studentName = Tstudentname.Text;
            string phone = Tphone.Text;
            string email = Temail.Text;
            DateTime dob = DTdob.Value;
            string address = Taddress.Text;

            if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            var updatedStudent = new StudentUpdateDTO
            {
                StudentName = studentName,
                PhoneNumber = phone,
                Email = email,
                DayOfBirth = dob.ToString("yyyy-MM-dd"),
                Address = address,
                Gender = gender,
                //Photo = ConvertImageToByteArray(CPBstudent.Image),
            };

            if (CPBstudent.Image != defaultImage)
            {
                var photoBytes = ConvertImageToByteArray(CPBstudent.Image);
                if (photoBytes != null)
                {
                    updatedStudent.ImageFile = photoBytes;
                }
            }
            else
            {
                updatedStudent.ImageFile = null;
            }

            try
            {

                var response = await ApiHelper.PutAsync<StudentUpdateDTO, ServiceResponse<bool>>($"Student/{studentId}", updatedStudent, token, true);
                if (response.Success && response.Data)
                {
                    formloading.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Lỗi khi cập nhật sinh viên: {response.Message}");
                }
            }
            catch (HttpRequestException ex)
            {
                var errorMessage = ex.Message;
                MessageBox.Show($"Lỗi xảy ra: {ex.Message}\nChi tiết: {errorMessage}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private byte[] ConvertImageToByteArray(Image image)
        {

            if (image == defaultImage || image == null)
            {
                return null;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Lưu hình ảnh vào MemoryStream với định dạng PNG để tránh lỗi GDI+
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
            catch (ExternalException ex)
            {
                
                return null;
            }
        }
    }
}
