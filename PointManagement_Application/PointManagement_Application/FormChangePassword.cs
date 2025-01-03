using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            this.Height = 300;
            labelfalse.Visible = false;
        }

        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {
            this.Height = 300;
            labelfalse.Visible = false;
        }

        private void guna2TextBox3_Enter(object sender, EventArgs e)
        {
            this.Height = 300;
            labelfalse.Visible = false;
        }

        private async void Bok_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmnewpassword = txtConfirmNewPassword.Text;
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                labelfalse.Visible = true;
                labelfalse.Text = "Please fill in the information completely";
                this.Height = 327;
                return;
            }
            if (newPassword != confirmnewpassword)
            {
                labelfalse.Visible = true;
                labelfalse.Text = "New password and confirm new password do not match";
                this.Height = 327;
                return;
            }

            var changePasswordDto = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmNewPassword = confirmnewpassword,
            };
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7097/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.Tag?.ToString());
                    var content = new StringContent(JsonConvert.SerializeObject(changePasswordDto), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("Auth/change-password", content);

                    if (response.IsSuccessStatusCode)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        var textfalse = "Old Password incorrect";
                        labelfalse.Text = textfalse;
                        labelfalse.Visible = true;
                        this.Height = 327;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
