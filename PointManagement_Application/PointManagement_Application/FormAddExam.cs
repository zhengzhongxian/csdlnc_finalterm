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
    public partial class FormAddExam : Form
    {
        private bool isAllConditionsMet => DTexamday.Value != null && CBduration.SelectedItem != null && DTtimeslot.Value != null;
        private DateTime previousExamDay;
        private string previousTimeSlot;
        private int previousDuration;
        public FormMain_Manager MainManagerForm { get; set; }
        public FormAddExam()
        {
            InitializeComponent();
            LoadInitialData();
            CBexamtype.Items.AddRange(new string[] { "Midterm", "Final", "Talent Test" });
            CBduration.Items.AddRange(new string[] { "60", "90", "120", "150", "180" });
            previousExamDay = DTexamday.Value;
            previousTimeSlot = DTtimeslot.Value.ToString("HH:mm:ss");
            previousDuration = CBduration.SelectedItem != null ? int.Parse(CBduration.SelectedItem.ToString()) : 0;

        }
        private async void LoadInitialData()
        {
            await LoadSubjectsAsync();
            await LoadRoomsDefaultAsync();
            await LoadLecturersDefaultAsync();
        }
        private async Task LoadSubjectsAsync()
        {
            var subjects = await ApiHelper.GetDataAsync<List<SubjectDTO>>("Subject");
            CBsubject.Items.Clear();
            foreach (var subject in subjects)
            {
                CBsubject.Items.Add(new ComboBoxItem { Text = subject.SubjectName, Value = subject.SubjectId });
            }
            CBsubject.SelectedIndex = -1;
        }

        // Tải danh sách phòng mặc định
        private async Task LoadRoomsDefaultAsync()
        {
            string token = this.Tag?.ToString();
            var rooms = await ApiHelper.GetAsync<List<RoomDTO>>("Room", token, true);
            CBroom.Items.Clear();
            foreach (var room in rooms)
            {
                CBroom.Items.Add(new ComboBoxItem { Text = room.RoomName, Value = room.RoomId });
            }
            CBroom.SelectedIndex = -1; 
        }

        private async Task LoadLecturersDefaultAsync()
        {
            var lecturers = await ApiHelper.GetAsync<List<LecturerDTO>>("Lecturer");
            CBinvigilator.Items.Clear();
            foreach (var lecturer in lecturers)
            {
                CBinvigilator.Items.Add(new ComboBoxItem { Text = lecturer.Name, Value = lecturer.LecturerId });
            }
            CBinvigilator.SelectedIndex = -1;
        }

        private async Task LoadAvailableRoomsAsync()
        {
            string token = this.Tag?.ToString();
            string date = DTexamday.Value.ToString("yyyy-MM-dd");
            string time = DTtimeslot.Value.ToString("HH:mm:ss");
            int duration = int.Parse(CBduration.SelectedItem.ToString());

            var rooms = await ApiHelper.GetAsync<List<RoomDTO>>($"Exam/available-rooms?examDate={date}&timeSlot={time}&duration={duration}", token, true);
            CBroom.Items.Clear();
            foreach (var room in rooms)
            {
                CBroom.Items.Add(new ComboBoxItem { Text = room.RoomName, Value = room.RoomId });
            }
        }
        private async Task LoadAvailableLecturersAsync()
        {
            string date = DTexamday.Value.ToString("yyyy-MM-dd");
            string time = DTtimeslot.Value.ToString("HH:mm:ss");
            int duration = int.Parse(CBduration.SelectedItem.ToString());

            var lecturers = await ApiHelper.GetAsync<List<LecturerDTO>>($"Exam/available-lecturers?examDate={date}&timeSlot={time}&duration={duration}");
            CBinvigilator.Items.Clear();
            foreach (var lecturer in lecturers)
            {
                CBinvigilator.Items.Add(new ComboBoxItem { Text = lecturer.Name, Value = lecturer.LecturerId });
            }
        }
        private async Task UpdateRoomAndLecturerAvailability()
        {
            string token = this.Tag?.ToString();
            DateTime currentExamDay = DTexamday.Value;
            string currentTimeSlot = DTtimeslot.Value.ToString("HH:mm:ss");
            int currentDuration = CBduration.SelectedItem != null ? int.Parse(CBduration.SelectedItem.ToString()) : 0;
            //MessageBox.Show(currentDuration.ToString());
            if (currentExamDay != previousExamDay || currentTimeSlot != previousTimeSlot || currentDuration != previousDuration)
            {

                var selectedRoom = CBroom.SelectedItem as ComboBoxItem;
                var selectedInvigilator = CBinvigilator.SelectedItem as ComboBoxItem;

                if (currentDuration > 0)
                {
                    var availableRooms = await ApiHelper.GetAsync<List<RoomDTO>>($"Exam/available-rooms?examDate={currentExamDay:yyyy-MM-dd}&timeSlot={currentTimeSlot}&duration={currentDuration}", token, true);
                    var availableLecturers = await ApiHelper.GetAsync<List<LecturerDTO>>($"Exam/available-lecturers?examDate={currentExamDay:yyyy-MM-dd}&timeSlot={currentTimeSlot}&duration={currentDuration}");

                    // Cập nhật danh sách phòng
                    if (availableRooms != null && availableRooms.Any())
                    {
                        UpdateComboBoxItems(CBroom, availableRooms.Select(room => new ComboBoxItem { Text = room.RoomName, Value = room.RoomId }).ToList(), selectedRoom);
                    }
                    else
                    {
                        CBroom.Items.Clear();
                        CBroom.Items.Add(new ComboBoxItem { Text = "Not available", Value = "" });
                        CBroom.SelectedIndex = 0;
                    }

                    if (availableLecturers != null && availableLecturers.Any())
                    {
                        UpdateComboBoxItems(CBinvigilator, availableLecturers.Select(lecturer => new ComboBoxItem { Text = lecturer.Name, Value = lecturer.LecturerId }).ToList(), selectedInvigilator);
                    }
                    else
                    {
                        CBinvigilator.Items.Clear();
                        CBinvigilator.Items.Add(new ComboBoxItem { Text = "Not available", Value = "" });
                        CBinvigilator.SelectedIndex = 0;
                    }
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
        private async void CBduration_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateRoomAndLecturerAvailability();
        }
        private async Task CheckRoomAndLecturerAvailability()
        {
            string date = DTexamday.Value.ToString("yyyy-MM-dd");
            string time = DTtimeslot.Value.ToString("HH:mm:ss");
            int duration = int.Parse(CBduration.SelectedItem.ToString());

            await LoadAvailableRoomsAsync();
            await LoadAvailableLecturersAsync();

            if (CBroom.Items.Count > 0 && CBinvigilator.Items.Count > 0)
            {
                if (!CBroom.Items.Contains(CBroom.SelectedItem) || !CBinvigilator.Items.Contains(CBinvigilator.SelectedItem))
                {
                    CBroom.SelectedItem = null;
                    CBinvigilator.SelectedItem = null;
                }
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

            var newExam = new ExamCreateDTO
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

                    var content = new StringContent(JsonConvert.SerializeObject(newExam), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("Exam", content);

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("Tạo kỳ thi thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Lỗi khi tạo kỳ thi: {responseBody}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Lỗi xảy ra: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
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

        private async void DTtimeslot_ValueChanged_1(object sender, EventArgs e)
        {
            await UpdateRoomAndLecturerAvailability();
        }
    }
}
