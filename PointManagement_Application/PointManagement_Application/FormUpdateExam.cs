using Newtonsoft.Json;
using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormUpdateExam : Form
    {
        private readonly string examId;
        private DateTime previousExamDay;
        private string previousTimeSlot;
        private int previousDuration;
        public FormMain_Manager MainManagerForm { get; set; }
        public FormUpdateExam(string examId)
        {
            InitializeComponent();
            this.examId = examId;
            CBexamtype.Items.AddRange(new string[] { "Midterm", "Final", "Talent Test" });
            CBduration.Items.AddRange(new string[] { "60", "90", "120", "150", "180" });
        }
        public async void PopulateFields(ExamDTO exam)
        {
            // Populate fields with existing exam details
            previousExamDay = exam.ExamDate;
            previousTimeSlot = exam.TimeSlot;
            previousDuration = exam.Duration;

            await LoadSubjectsAsync(exam.SubjectName);
            await LoadRoomsAsync(exam.RoomName);
            await LoadLecturersAsync(exam.InvigilatorName);

            DTexamday.Value = exam.ExamDate;
            DTtimeslot.Value = DateTime.ParseExact(exam.TimeSlot, "HH:mm:ss", null);
            CBduration.SelectedItem = exam.Duration.ToString();
            CBexamtype.SelectedItem = exam.ExamType;
        }
        private async Task LoadSubjectsAsync(string selectedSubjectName)
        {
            var subjects = await ApiHelper.GetDataAsync<List<SubjectDTO>>("Subject");
            CBsubject.Items.Clear();
            foreach (var subject in subjects)
            {
                CBsubject.Items.Add(new ComboBoxItem { Text = subject.SubjectName, Value = subject.SubjectId });
                if (subject.SubjectName == selectedSubjectName)
                {
                    CBsubject.SelectedItem = CBsubject.Items[CBsubject.Items.Count - 1];
                }
            }
        }
        private async Task LoadRoomsAsync(string selectedRoomName)
        {
            var rooms = await ApiHelper.GetAsync<List<RoomDTO>>("Room");
            CBroom.Items.Clear();
            foreach (var room in rooms)
            {
                CBroom.Items.Add(new ComboBoxItem { Text = room.RoomName, Value = room.RoomId });
                if (room.RoomName == selectedRoomName)
                {
                    CBroom.SelectedItem = CBroom.Items[CBroom.Items.Count - 1];
                }
            }
        }
        private async Task LoadLecturersAsync(string selectedInvigilatorName)
        {
            var lecturers = await ApiHelper.GetAsync<List<LecturerDTO>>("Lecturer");
            CBinvigilator.Items.Clear();
            foreach (var lecturer in lecturers)
            {
                CBinvigilator.Items.Add(new ComboBoxItem { Text = lecturer.Name, Value = lecturer.LecturerId });
                if (lecturer.Name == selectedInvigilatorName)
                {
                    CBinvigilator.SelectedItem = CBinvigilator.Items[CBinvigilator.Items.Count - 1];
                }
            }
        }
        private async Task UpdateRoomAndLecturerAvailability()
        {
            DateTime currentExamDay = DTexamday.Value;
            string currentTimeSlot = DTtimeslot.Value.ToString("HH:mm:ss");
            int currentDuration = CBduration.SelectedItem != null ? int.Parse(CBduration.SelectedItem.ToString()) : 0;

            if (currentExamDay != previousExamDay || currentTimeSlot != previousTimeSlot || currentDuration != previousDuration)
            {
                var selectedRoom = CBroom.SelectedItem as ComboBoxItem;
                var selectedInvigilator = CBinvigilator.SelectedItem as ComboBoxItem;

                if (currentDuration > 0)
                {
                    var availableRooms = await ApiHelper.GetAsync<List<RoomDTO>>(
                        $"Exam/available-rooms?examDate={currentExamDay:yyyy-MM-dd}&timeSlot={currentTimeSlot}&duration={currentDuration}&excludeExamId={examId}"
                    );
                    var availableLecturers = await ApiHelper.GetAsync<List<LecturerDTO>>(
                        $"Exam/available-lecturers?examDate={currentExamDay:yyyy-MM-dd}&timeSlot={currentTimeSlot}&duration={currentDuration}&excludeExamId={examId}"
                    );

                    UpdateComboBoxItems(CBroom, availableRooms.Select(room => new ComboBoxItem { Text = room.RoomName, Value = room.RoomId }).ToList(), selectedRoom);
                    UpdateComboBoxItems(CBinvigilator, availableLecturers.Select(lecturer => new ComboBoxItem { Text = lecturer.Name, Value = lecturer.LecturerId }).ToList(), selectedInvigilator);
                }

                previousExamDay = currentExamDay;
                previousTimeSlot = currentTimeSlot;
                previousDuration = currentDuration;
            }
        }
    
        private void UpdateComboBoxItems(ComboBox comboBox, List<ComboBoxItem> newItems, ComboBoxItem previousSelection)
        {
            for (int i = comboBox.Items.Count - 1; i >= 0; i--)
            {
                var item = comboBox.Items[i] as ComboBoxItem;
                if (item != null && !newItems.Any(newItem => newItem.Value == item.Value))
                {
                    comboBox.Items.RemoveAt(i);
                }
            }

            foreach (var newItem in newItems)
            {
                if (!comboBox.Items.Cast<ComboBoxItem>().Any(item => item.Value == newItem.Value))
                {
                    comboBox.Items.Add(newItem);
                }
            }

            if (previousSelection != null && comboBox.Items.Cast<ComboBoxItem>().Any(item => item.Value == previousSelection.Value))
            {
                comboBox.SelectedItem = previousSelection;
            }
            else
            {
                comboBox.SelectedItem = null;
            }

            if (comboBox.Items.Count == 0)
            {
                comboBox.Items.Add(new ComboBoxItem { Text = "No available options", Value = "" });
                comboBox.SelectedIndex = 0;
            }
        }

        private async void Bsubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            var selectedSubject = CBsubject.SelectedItem as ComboBoxItem;
            var selectedRoom = CBroom.SelectedItem as ComboBoxItem;
            var selectedInvigilator = CBinvigilator.SelectedItem as ComboBoxItem;
            var selectedExamType = CBexamtype.SelectedItem?.ToString();
            DateTime examDate = DTexamday.Value;
            string timeSlot = DTtimeslot.Value.ToString("HH:mm:ss");
            int duration = int.Parse(CBduration.SelectedItem.ToString());

            var updatedExam = new ExamCreateDTO
            {
                SubjectId = selectedSubject.Value,
                RoomId = selectedRoom.Value,
                ExamDate = examDate.ToString("yyyy-MM-dd"),
                TimeSlot = timeSlot,
                Duration = duration,
                InvigilatorId = selectedInvigilator.Value,
                ExamType = selectedExamType
            };

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5000/api/");

                    string token = this.Tag?.ToString();
                    if (string.IsNullOrEmpty(token))
                    {
                        MessageBox.Show("Token không hợp lệ. Vui lòng đăng nhập lại.");
                        return;
                    }

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(JsonConvert.SerializeObject(updatedExam), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"Exam/{examId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("Cập nhật kỳ thi thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Lỗi khi cập nhật kỳ thi: {responseBody}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi gửi yêu cầu: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}");
            }
        }

        private bool ValidateFormInputs()
        {
            return CBsubject.SelectedItem != null &&
                   CBroom.SelectedItem != null &&
                   DTexamday.Value != null &&
                   DTtimeslot.Value != null &&
                   CBduration.SelectedItem != null &&
                   CBinvigilator.SelectedItem != null &&
                   CBexamtype.SelectedItem != null;
        }

        private async void DTtimeslot_ValueChanged(object sender, EventArgs e)
        {
            await UpdateRoomAndLecturerAvailability();
        }

        private async void DTexamday_ValueChanged(object sender, EventArgs e)
        {
            await UpdateRoomAndLecturerAvailability();
        }

        private async void CBduration_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateRoomAndLecturerAvailability();
        }
    }
}
