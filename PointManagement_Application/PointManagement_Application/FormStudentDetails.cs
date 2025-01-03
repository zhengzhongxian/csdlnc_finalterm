using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormStudentDetails : Form
    {
        private StudentDTO student;
        private FormMain_Manager _parentform;
        private Image defaultImage;
        private int selectedsemesterId;
        private FormMainStudent FormMainStudent;
        public FormStudentDetails(StudentDTO student, FormMain_Manager _parentform, FormMainStudent formMainStudent)
        {
            InitializeComponent();
            this.student = student;
            this._parentform=_parentform;
            LStudentId.Text += student.StudentId;
            LStudentName.Text += student.StudentName;
            LFaculty.Text += student.FacultyName;
            Lemail.Text += student.Email;
            LNumberphone.Text += student.PhoneNumber;
            Laddress.Text += student.Address;
            defaultImage = CPBstudent.Image;
            FormMainStudent = formMainStudent;

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
                catch
                {
                    CPBstudent.Image = defaultImage;
                }
            }
            else
            {
                CPBstudent.Image = defaultImage; 
            }

            LoadFacultiesAsync();
            FormHelper.EnableDrag(this,_parentform);
        }
        private async Task LoadFacultiesAsync()
        {
            try
            {
                var semester = await ApiHelper.GetAsync<List<SemesterDTO>>("Semester");

                if (semester != null && semester.Count > 0)
                {
                    CBsemester.Items.Clear();
                    foreach (var s in semester)
                    {
                        CBsemester.Items.Add(new ComboBoxItem
                        {
                            Text = s.SemesterName,
                            Value = s.SemesterId.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học kỳ: {ex.Message}");
            }
        }

        private void FormStudentDetails_Load(object sender, EventArgs e)
        {

        }

        private async void CBsemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedsemester = CBsemester.SelectedItem as ComboBoxItem;

            if (selectedsemester != null)
            {
                await LoadStudentsByFacultyAsync(selectedsemester.Value);
            }
        }

        public async Task LoadStudentsByFacultyAsync(string semesterid)
        {
            try
            {
                var students = await ApiHelper.GetAsync<List<StudentScoreDTO>>($"Student/{student.StudentId}/semester/{semesterid}");
                DGstudentdetails.Rows.Clear();
                if (students != null && students.Count > 0)
                {
                    decimal totalScore = 0;
                    int count = 0;

                    foreach (var student in students)
                    {
                        int rowIndex = DGstudentdetails.Rows.Add();
                        DataGridViewRow row = DGstudentdetails.Rows[rowIndex];

                        row.Cells["SubjectName"].Value = student.SubjectName;
                        row.Cells["ClassScore"].Value = student.ClassScore;
                        row.Cells["ExamScore"].Value = student.ExamScore;
                        row.Cells["ScoreSystem10"].Value = student.ScoreSystem10;
                        row.Cells["ScoreSystem4"].Value = student.ScoreSystem4;

                        if (student.ScoreSystem4.HasValue)
                        {
                            totalScore += student.ScoreSystem4.Value;
                            count++;
                        }
                    }

                    decimal averageScore = count > 0 ? totalScore / count : 0;

                    string outcome = GetAcademicOutcome(averageScore);

                    Loutcome.Text += $"{outcome} ({averageScore.ToString()})";
                }
                else
                {
                    DGstudentdetails.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }
        private string GetAcademicOutcome(decimal averageScore)
        {
            if (averageScore >= 3.6m)
            {
                return "Xuất sắc";
            }
            else if (averageScore >= 3.2m)
            {
                return "Giỏi";
            }
            else if (averageScore >= 2.5m)
            {
                return "Khá";
            }
            else if (averageScore >= 2.0m)
            {
                return "Trung bình";
            }
            else
            {
                return "Yếu";
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            _parentform.ShowFormInPanel(FormMainStudent);
        }
    }
}
