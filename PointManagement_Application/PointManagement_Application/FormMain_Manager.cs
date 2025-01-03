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
    public partial class FormMain_Manager : Form
    {

        bool menutime = true;
        private const int MaxSidebarWidth = 250;
        private const int MinSidebarWidth = 90;
        private const int StepSize = 10;
        private bool isManageStudentActive = false;
        private bool isManageExamActive = false;
        private bool isManageClassActive = false;
        private Flogin Flogin;
        public FormMain_Manager(Flogin flogin)
        {
            InitializeComponent();
            FormHelper.EnableDrag(this);
            FormHelper.EnableDrag(MainPanel, this);
            FormHelper.EnableDrag(guna2PictureBox1, this);
            Flogin = flogin;
        }

        private void FormMain_Manager_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tmenu.Start(); 
        }

        private void Tmenu_Tick(object sender, EventArgs e)
        {

            Flp_MenuSB.SuspendLayout();
            Bmenu.SuspendLayout();
            BmanageStudent.SuspendLayout();
            BmanageExam.SuspendLayout();
            BmanageClass.SuspendLayout();
            Bchangepassword.SuspendLayout();
            Blogout.SuspendLayout();
            if (menutime)
            {
                // Mở rộng sidebar
                Flp_MenuSB.Width += StepSize;
                BmanageStudent.Width += StepSize;
                Bmenu.Width += StepSize;
                BmanageExam.Width += StepSize;
                BmanageClass.Width += StepSize;
                Bchangepassword.Width += StepSize;
                Blogout.Width += StepSize;
                if (Flp_MenuSB.Width >= MaxSidebarWidth)
                {
                    Tmenu.Stop(); // Dừng Timer khi đạt kích thước tối đa
                    Bmenu.Text = "        Management";
                    BmanageStudent.Text = "      Manage Student";
                    BmanageExam.Text = "  Manage Exam";
                    BmanageClass.Text = "  Manage Class";
                    Bchangepassword.Text = "        Manage Account";
                    Blogout.Text = "       Log out";
                    menutime = false;
                }
            }
            else
            {
                Bmenu.Width -= StepSize;
                BmanageStudent.Width -= StepSize;
                Flp_MenuSB.Width -= StepSize;
                BmanageExam.Width -= StepSize;
                BmanageClass.Width -= StepSize;
                Bchangepassword.Width -= StepSize;
                Blogout.Width -= StepSize;
                BmanageExam.Text = string.Empty;
                Bmenu.Text = string.Empty;
                BmanageStudent.Text = string.Empty;
                BmanageClass.Text = string.Empty;
                Bchangepassword.Text = string.Empty;
                Blogout.Text = string.Empty;
                
                if (Flp_MenuSB.Width <= MinSidebarWidth)
                {
                    Tmenu.Stop();
                    menutime = true;
                }
            }

            Flp_MenuSB.ResumeLayout();
            Bmenu.ResumeLayout();
            BmanageStudent.ResumeLayout();
            BmanageClass.ResumeLayout();
            BmanageExam.ResumeLayout();
            Bchangepassword.ResumeLayout();
            Blogout.ResumeLayout();
        }

        public void ShowFormInPanel(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(form);
            MainPanel.Tag = form;

            form.BringToFront();
            form.Show();
        }

        private void BmanageStudent_Click(object sender, EventArgs e)
        {
            if (isManageStudentActive)
                return;

            isManageStudentActive = true;
            isManageExamActive = false;
            isManageClassActive = false;

            if (MainPanel.Controls.OfType<FormMainExams>().FirstOrDefault() is FormMainExams formMainExams && formMainExams.IsAnyExamFormOpen)
            {
                return;
            }

            if (MainPanel.Controls.OfType<FormMainStudent>().FirstOrDefault() is FormMainStudent formMainStudent && (formMainStudent.isAddStudentFormOpen || formMainStudent.isUpdateStudentFormOpen))
            {
                return;
            }
            var formstudet = new FormMainStudent(this)
            {
                Tag = this.Tag,
            };

            ShowFormInPanel(formstudet);
        }

        private void BmanageExam_Click(object sender, EventArgs e)
        {
            if (isManageExamActive)
                return;
            isManageExamActive = true;
            isManageStudentActive = false;
            isManageClassActive = false;

            if (MainPanel.Controls.OfType<FormMainExams>().FirstOrDefault() is FormMainExams formMainExams && formMainExams.IsAnyExamFormOpen)
            {
                return;
            }

            if (MainPanel.Controls.OfType<FormMainStudent>().FirstOrDefault() is FormMainStudent formMainStudent && (formMainStudent.isAddStudentFormOpen || formMainStudent.isUpdateStudentFormOpen))
            {
                return;
            }

            var formMainExam = new FormMainExams(this)
            {
                Tag = this.Tag
            };

            ShowFormInPanel(formMainExam);
        }

        public void ShowCenteredForm(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );
            form.ShowDialog(this);
        }

        private void BmanageClass_Click(object sender, EventArgs e)
        {
            if (isManageClassActive)
            {
                return;
            }
            isManageClassActive = true;
            isManageExamActive = false;
            isManageStudentActive = false;
            var formMainclass = new FormMainClass(this)
            {
                Tag= this.Tag
            };

            ShowFormInPanel(formMainclass);
        }

        private void Bchangepassword_Click(object sender, EventArgs e)
        {
            var formchangepassword = new FormChangePassword
            {
                StartPosition = FormStartPosition.Manual,
            };
            int x = this.Location.X + (this.Width - formchangepassword.Width) / 2;
            int y = this.Location.Y + (this.Height - formchangepassword.Height) / 2;
            formchangepassword.Location = new Point(x, y);
            formchangepassword.TopLevel = true;
            formchangepassword.Tag = this.Tag;
            var result = formchangepassword.ShowDialog();
            if (result == DialogResult.OK)
            {
                var formtb = new FormTbChangePasswordSuccess
                {
                    StartPosition = FormStartPosition.CenterParent,
                    //Location = new Point(x, y),
                    TopLevel = true,
                };
                formtb.ShowDialog();
            }
        }

        private void Blogout_Click(object sender, EventArgs e)
        {
            Flogin.Show();
            this.Close();
        }
    }
}
