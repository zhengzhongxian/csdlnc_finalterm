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
    public partial class FormSeat : Form
    {
        private string examId;
        private string studentId;
        public bool IsSeatAssigned { get; private set; } = false;

        public FormSeat(string examId, string studentId)
        {
            InitializeComponent();
            this.examId = examId;
            this.studentId = studentId;
            LoadAvailableSeatsAsync();
        }
        private async Task LoadAvailableSeatsAsync()
        {
            try
            {
                var availableSeats = await ApiHelper.GetAsync<List<int>>($"Schedule/exam/{examId}/available-seats");

                if (availableSeats != null && availableSeats.Count > 0)
                {
                    CBseat.Items.Clear();
                    foreach (var seat in availableSeats)
                    {
                        CBseat.Items.Add(seat);
                    }
                }
                else
                {
                    CBseat.Items.Clear(); 
                    CBseat.Items.Add("No seats available");
                    CBseat.SelectedIndex = 0;
                    CBseat.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách ghế trống: {ex.Message}");
            }
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            if (CBseat.SelectedItem == null)
            {
                labelfalse.Visible = true;
                CBseat.BorderColor = Color.Red;
                return;
            }

            int selectedSeat = (int)CBseat.SelectedItem;

            var scheduleDto = new ScheduleCreateUpdateDTO
            {
                ExamId = examId,
                StudentId = studentId,
                SeatNumber = selectedSeat
            };

            try
            {

                var response = await ApiHelper.PostAsync<ScheduleCreateUpdateDTO, ServiceResponse<bool>>("Schedule", scheduleDto);

                if (response.Success && response.Data)
                {

                    IsSeatAssigned = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm lịch thi: " + response.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm lịch thi: {ex.Message}");
            }
        }
    }
}
