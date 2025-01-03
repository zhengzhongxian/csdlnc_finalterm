using Newtonsoft.Json;
using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using PointManagement_Application.Service.Implement;
using PointManagement_Application.Service.Iservice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class Flogin : Form
    {
        private readonly IAuthService authService;
        public Flogin()
        {
            InitializeComponent();
            //Babout_us.Parent = this;
            //Bqualityofeducation.Parent = this;
            FormHelper.EnableDrag(this);
            FormHelper.EnableDrag(guna2Panel1,this);
            //authService = new AuthService();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Flogin_Load(object sender, EventArgs e)
        {

        }

        private void Flogin_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                this.ActiveControl = null;
            }*/
        }

        private async void Blogin_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_pass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập và mật khẩu.");
                return;
            }

            var loginDto = new LoginDTO { Username = username, Password = password };
            var response = await ApiHelper.PostAuthAsync("Auth/login", loginDto);

            if (!response.Success)
            {
                ShowLoginFalseForm();
                return;
            }

            string token = response.Data;
            JwtSecurityToken jwtToken = DecodeToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "user_id")?.Value;
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (roleClaim == "Admin")
            {
                FormMain_Manager mainManagerForm = new FormMain_Manager(this);
                mainManagerForm.Tag = token;
                mainManagerForm.StartPosition = FormStartPosition.Manual;
                mainManagerForm.Location = new Point(
                    this.Location.X + (this.Width - mainManagerForm.Width) / 2,
                    this.Location.Y + (this.Height - mainManagerForm.Height) / 2
                );
                mainManagerForm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào hệ thống quản lý.");
            }

            this.Hide();
        }

        private JwtSecurityToken DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(token);
        }
        private void ShowLoginFalseForm()
        {
            using (FormTbLoginFalse loginFalseForm = new FormTbLoginFalse())
            {

                loginFalseForm.StartPosition = FormStartPosition.Manual;

                loginFalseForm.Location = new Point(
                    this.Location.X + (this.Width - loginFalseForm.Width) / 2,
                    this.Location.Y + (this.Height - loginFalseForm.Height) / 2
                );

                loginFalseForm.ShowDialog();
            }
        }
    }
}
