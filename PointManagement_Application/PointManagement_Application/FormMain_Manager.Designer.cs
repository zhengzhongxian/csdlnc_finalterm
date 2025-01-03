namespace PointManagement_Application
{
    partial class FormMain_Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain_Manager));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Flp_MenuSB = new System.Windows.Forms.FlowLayoutPanel();
            this.Bmenu = new System.Windows.Forms.Button();
            this.BmanageStudent = new System.Windows.Forms.Button();
            this.BmanageExam = new System.Windows.Forms.Button();
            this.BmanageClass = new System.Windows.Forms.Button();
            this.Bchangepassword = new System.Windows.Forms.Button();
            this.Blogout = new System.Windows.Forms.Button();
            this.Tmenu = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Flp_MenuSB.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // Flp_MenuSB
            // 
            this.Flp_MenuSB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(189)))), ((int)(((byte)(225)))));
            this.Flp_MenuSB.Controls.Add(this.Bmenu);
            this.Flp_MenuSB.Controls.Add(this.BmanageStudent);
            this.Flp_MenuSB.Controls.Add(this.BmanageExam);
            this.Flp_MenuSB.Controls.Add(this.BmanageClass);
            this.Flp_MenuSB.Controls.Add(this.Bchangepassword);
            this.Flp_MenuSB.Controls.Add(this.Blogout);
            this.Flp_MenuSB.Dock = System.Windows.Forms.DockStyle.Left;
            this.Flp_MenuSB.Location = new System.Drawing.Point(0, 0);
            this.Flp_MenuSB.Name = "Flp_MenuSB";
            this.Flp_MenuSB.Size = new System.Drawing.Size(90, 513);
            this.Flp_MenuSB.TabIndex = 0;
            // 
            // Bmenu
            // 
            this.Bmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bmenu.FlatAppearance.BorderSize = 0;
            this.Bmenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Bmenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Bmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bmenu.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bmenu.ForeColor = System.Drawing.Color.White;
            this.Bmenu.Image = ((System.Drawing.Image)(resources.GetObject("Bmenu.Image")));
            this.Bmenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bmenu.Location = new System.Drawing.Point(0, 0);
            this.Bmenu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.Bmenu.Name = "Bmenu";
            this.Bmenu.Padding = new System.Windows.Forms.Padding(5);
            this.Bmenu.Size = new System.Drawing.Size(90, 58);
            this.Bmenu.TabIndex = 0;
            this.Bmenu.UseVisualStyleBackColor = true;
            this.Bmenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // BmanageStudent
            // 
            this.BmanageStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BmanageStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.BmanageStudent.FlatAppearance.BorderSize = 0;
            this.BmanageStudent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BmanageStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BmanageStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BmanageStudent.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BmanageStudent.ForeColor = System.Drawing.Color.White;
            this.BmanageStudent.Image = ((System.Drawing.Image)(resources.GetObject("BmanageStudent.Image")));
            this.BmanageStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BmanageStudent.Location = new System.Drawing.Point(0, 108);
            this.BmanageStudent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.BmanageStudent.Name = "BmanageStudent";
            this.BmanageStudent.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BmanageStudent.Size = new System.Drawing.Size(90, 52);
            this.BmanageStudent.TabIndex = 1;
            this.BmanageStudent.UseVisualStyleBackColor = true;
            this.BmanageStudent.Click += new System.EventHandler(this.BmanageStudent_Click);
            // 
            // BmanageExam
            // 
            this.BmanageExam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BmanageExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.BmanageExam.FlatAppearance.BorderSize = 0;
            this.BmanageExam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BmanageExam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BmanageExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BmanageExam.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BmanageExam.ForeColor = System.Drawing.Color.White;
            this.BmanageExam.Image = ((System.Drawing.Image)(resources.GetObject("BmanageExam.Image")));
            this.BmanageExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BmanageExam.Location = new System.Drawing.Point(0, 165);
            this.BmanageExam.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.BmanageExam.Name = "BmanageExam";
            this.BmanageExam.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BmanageExam.Size = new System.Drawing.Size(90, 52);
            this.BmanageExam.TabIndex = 2;
            this.BmanageExam.UseVisualStyleBackColor = true;
            this.BmanageExam.Click += new System.EventHandler(this.BmanageExam_Click);
            // 
            // BmanageClass
            // 
            this.BmanageClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BmanageClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.BmanageClass.FlatAppearance.BorderSize = 0;
            this.BmanageClass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BmanageClass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BmanageClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BmanageClass.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BmanageClass.ForeColor = System.Drawing.Color.White;
            this.BmanageClass.Image = ((System.Drawing.Image)(resources.GetObject("BmanageClass.Image")));
            this.BmanageClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BmanageClass.Location = new System.Drawing.Point(0, 222);
            this.BmanageClass.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.BmanageClass.Name = "BmanageClass";
            this.BmanageClass.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BmanageClass.Size = new System.Drawing.Size(90, 52);
            this.BmanageClass.TabIndex = 3;
            this.BmanageClass.UseVisualStyleBackColor = true;
            this.BmanageClass.Click += new System.EventHandler(this.BmanageClass_Click);
            // 
            // Bchangepassword
            // 
            this.Bchangepassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bchangepassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bchangepassword.FlatAppearance.BorderSize = 0;
            this.Bchangepassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Bchangepassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Bchangepassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bchangepassword.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bchangepassword.ForeColor = System.Drawing.Color.White;
            this.Bchangepassword.Image = ((System.Drawing.Image)(resources.GetObject("Bchangepassword.Image")));
            this.Bchangepassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bchangepassword.Location = new System.Drawing.Point(0, 279);
            this.Bchangepassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Bchangepassword.Name = "Bchangepassword";
            this.Bchangepassword.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Bchangepassword.Size = new System.Drawing.Size(90, 52);
            this.Bchangepassword.TabIndex = 4;
            this.Bchangepassword.UseVisualStyleBackColor = true;
            this.Bchangepassword.Click += new System.EventHandler(this.Bchangepassword_Click);
            // 
            // Blogout
            // 
            this.Blogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Blogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.Blogout.FlatAppearance.BorderSize = 0;
            this.Blogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Blogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Blogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Blogout.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blogout.ForeColor = System.Drawing.Color.White;
            this.Blogout.Image = ((System.Drawing.Image)(resources.GetObject("Blogout.Image")));
            this.Blogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Blogout.Location = new System.Drawing.Point(0, 336);
            this.Blogout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Blogout.Name = "Blogout";
            this.Blogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Blogout.Size = new System.Drawing.Size(90, 52);
            this.Blogout.TabIndex = 5;
            this.Blogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Blogout.UseVisualStyleBackColor = true;
            this.Blogout.Click += new System.EventHandler(this.Blogout_Click);
            // 
            // Tmenu
            // 
            this.Tmenu.Interval = 10;
            this.Tmenu.Tick += new System.EventHandler(this.Tmenu_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.guna2PictureBox1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(90, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(875, 513);
            this.MainPanel.TabIndex = 1;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(875, 513);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FormMain_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 513);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Flp_MenuSB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain_Manager";
            this.Text = "FormMain_Manager";
            this.Load += new System.EventHandler(this.FormMain_Manager_Load);
            this.Flp_MenuSB.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.FlowLayoutPanel Flp_MenuSB;
        private System.Windows.Forms.Button Bmenu;
        private System.Windows.Forms.Timer Tmenu;
        private System.Windows.Forms.Button BmanageStudent;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private System.Windows.Forms.Button BmanageExam;
        private System.Windows.Forms.Button BmanageClass;
        private System.Windows.Forms.Button Bchangepassword;
        private System.Windows.Forms.Button Blogout;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}