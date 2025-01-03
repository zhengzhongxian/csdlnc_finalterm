using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormUpdateSchedule : Form
    {
        private string scheduleId;
        private string examId;
        public bool IsUpdated { get; private set; } = false;

        public FormUpdateSchedule(string scheduleId, string examId)
        {
            InitializeComponent();
            this.scheduleId = scheduleId;
            this.examId = examId;
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
                MessageBox.Show($"Lỗi khi tải danh sách ghế: {ex.Message}");
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

            try
            {

                var response = await ApiHelper.PutAsync<int, ServiceResponse<bool>>(
                    $"Schedule/{scheduleId}",
                    selectedSeat
                );

                if (response.Success && response.Data)
                {
                    IsUpdated = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Không thể cập nhật lịch thi: {response.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật lịch thi: {ex.Message}");
            }
        }
    }
}
