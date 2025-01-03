using PointManagement_Application.DTOs;
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
    public partial class FormUpdateClassScore : Form
    {
        private string selectedclassstudentid;
        private FormMainDetailClass detailClass;
        public FormUpdateClassScore(string selectedclassstudentid, FormMainDetailClass detailClass)
        {
            InitializeComponent();
            this.selectedclassstudentid = selectedclassstudentid;
            this.detailClass = detailClass;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && (txtScore.Text.Contains('.') || txtScore.Text.Length == 0))
            {
                e.Handled = true;
                return;
            }

            if (!txtScore.Text.Contains('.') && txtScore.Text.Length > 0 && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtScore_Leave(object sender, EventArgs e)
        {
            if (txtScore.Text.EndsWith("."))
            {
                txtScore.Text += "0";
            }
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            if (txtScore.Text == string.Empty)
            {
                txtScore.BorderColor = Color.Red;
                labelfalse.Visible = true;
                return;
            }

            if (!decimal.TryParse(txtScore.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var score))
            {
                MessageBox.Show("Điểm nhập vào không hợp lệ.");
                return;
            }
            score = Math.Round(score, 1, MidpointRounding.ToEven);
            var newScore = new ClassStudentUpdateDTO { Score = score };

            var respone = await ApiHelper.PutAsync<ClassStudentUpdateDTO, ServiceResponse<bool>>($"ClassStudent/{selectedclassstudentid}",newScore);

            if (!respone.Success)
            {
                MessageBox.Show($"Lỗi khi cập nhật điểm: {respone.Message}");
                return;
            }

            //await detailClass.LoadClassStudentAsync();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
