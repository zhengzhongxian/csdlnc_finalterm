namespace PointManagement_Application
{
    partial class FormStudentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudentDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.DGstudentdetails = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSystem10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSystem4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CPBstudent = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.CBsemester = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Loutcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LStudentId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LStudentName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LFaculty = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.Laddress = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LNumberphone = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Lemail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGstudentdetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPBstudent)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(74, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(711, 73);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 17;
            this.guna2PictureBox1.TabStop = false;
            // 
            // DGstudentdetails
            // 
            this.DGstudentdetails.AllowUserToAddRows = false;
            this.DGstudentdetails.AllowUserToResizeColumns = false;
            this.DGstudentdetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGstudentdetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGstudentdetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGstudentdetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGstudentdetails.ColumnHeadersHeight = 37;
            this.DGstudentdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.ClassScore,
            this.ExamScore,
            this.ScoreSystem10,
            this.ScoreSystem4});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGstudentdetails.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGstudentdetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudentdetails.Location = new System.Drawing.Point(12, 500);
            this.DGstudentdetails.Name = "DGstudentdetails";
            this.DGstudentdetails.RowHeadersVisible = false;
            this.DGstudentdetails.RowHeadersWidth = 51;
            this.DGstudentdetails.RowTemplate.Height = 40;
            this.DGstudentdetails.RowTemplate.ReadOnly = true;
            this.DGstudentdetails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGstudentdetails.Size = new System.Drawing.Size(844, 348);
            this.DGstudentdetails.TabIndex = 18;
            this.DGstudentdetails.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGstudentdetails.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGstudentdetails.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGstudentdetails.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGstudentdetails.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGstudentdetails.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGstudentdetails.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudentdetails.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGstudentdetails.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGstudentdetails.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGstudentdetails.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGstudentdetails.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGstudentdetails.ThemeStyle.HeaderStyle.Height = 37;
            this.DGstudentdetails.ThemeStyle.ReadOnly = false;
            this.DGstudentdetails.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGstudentdetails.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGstudentdetails.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGstudentdetails.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGstudentdetails.ThemeStyle.RowsStyle.Height = 40;
            this.DGstudentdetails.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudentdetails.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SubjectName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SubjectName.HeaderText = "Subject Name";
            this.SubjectName.MinimumWidth = 300;
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Width = 300;
            // 
            // ClassScore
            // 
            this.ClassScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClassScore.DefaultCellStyle = dataGridViewCellStyle4;
            this.ClassScore.HeaderText = "Proccess Score";
            this.ClassScore.MinimumWidth = 250;
            this.ClassScore.Name = "ClassScore";
            this.ClassScore.Width = 250;
            // 
            // ExamScore
            // 
            this.ExamScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamScore.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExamScore.HeaderText = "End Score";
            this.ExamScore.MinimumWidth = 250;
            this.ExamScore.Name = "ExamScore";
            this.ExamScore.ReadOnly = true;
            this.ExamScore.Width = 250;
            // 
            // ScoreSystem10
            // 
            this.ScoreSystem10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScoreSystem10.DefaultCellStyle = dataGridViewCellStyle6;
            this.ScoreSystem10.HeaderText = "Total Score (System 10)";
            this.ScoreSystem10.MinimumWidth = 250;
            this.ScoreSystem10.Name = "ScoreSystem10";
            this.ScoreSystem10.Width = 250;
            // 
            // ScoreSystem4
            // 
            this.ScoreSystem4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScoreSystem4.DefaultCellStyle = dataGridViewCellStyle7;
            this.ScoreSystem4.HeaderText = "Total Score (System 4)";
            this.ScoreSystem4.MinimumWidth = 250;
            this.ScoreSystem4.Name = "ScoreSystem4";
            this.ScoreSystem4.Width = 250;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 464);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(215, 30);
            this.guna2HtmlLabel1.TabIndex = 19;
            this.guna2HtmlLabel1.Text = "Learning outcomes:";
            // 
            // CPBstudent
            // 
            this.CPBstudent.Image = ((System.Drawing.Image)(resources.GetObject("CPBstudent.Image")));
            this.CPBstudent.ImageRotate = 0F;
            this.CPBstudent.Location = new System.Drawing.Point(358, 91);
            this.CPBstudent.Name = "CPBstudent";
            this.CPBstudent.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CPBstudent.Size = new System.Drawing.Size(140, 129);
            this.CPBstudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CPBstudent.TabIndex = 24;
            this.CPBstudent.TabStop = false;
            // 
            // CBsemester
            // 
            this.CBsemester.BackColor = System.Drawing.Color.Transparent;
            this.CBsemester.BorderRadius = 10;
            this.CBsemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBsemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBsemester.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBsemester.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBsemester.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBsemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBsemester.ItemHeight = 30;
            this.CBsemester.Location = new System.Drawing.Point(582, 458);
            this.CBsemester.Name = "CBsemester";
            this.CBsemester.Size = new System.Drawing.Size(274, 36);
            this.CBsemester.TabIndex = 25;
            this.CBsemester.SelectedIndexChanged += new System.EventHandler(this.CBsemester_SelectedIndexChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(582, 422);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(215, 30);
            this.guna2HtmlLabel2.TabIndex = 26;
            this.guna2HtmlLabel2.Text = "Semester:";
            // 
            // Loutcome
            // 
            this.Loutcome.AutoSize = false;
            this.Loutcome.BackColor = System.Drawing.Color.Transparent;
            this.Loutcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loutcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Loutcome.Location = new System.Drawing.Point(582, 848);
            this.Loutcome.Name = "Loutcome";
            this.Loutcome.Size = new System.Drawing.Size(250, 30);
            this.Loutcome.TabIndex = 27;
            this.Loutcome.Text = "Classification: ";
            // 
            // LStudentId
            // 
            this.LStudentId.AutoSize = false;
            this.LStudentId.BackColor = System.Drawing.Color.Transparent;
            this.LStudentId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStudentId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LStudentId.Location = new System.Drawing.Point(17, 48);
            this.LStudentId.Name = "LStudentId";
            this.LStudentId.Size = new System.Drawing.Size(341, 30);
            this.LStudentId.TabIndex = 28;
            this.LStudentId.Text = "Student ID: ";
            // 
            // LStudentName
            // 
            this.LStudentName.AutoSize = false;
            this.LStudentName.BackColor = System.Drawing.Color.Transparent;
            this.LStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LStudentName.Location = new System.Drawing.Point(17, 84);
            this.LStudentName.Name = "LStudentName";
            this.LStudentName.Size = new System.Drawing.Size(341, 30);
            this.LStudentName.TabIndex = 29;
            this.LStudentName.Text = "StudentName: ";
            // 
            // LFaculty
            // 
            this.LFaculty.AutoSize = false;
            this.LFaculty.BackColor = System.Drawing.Color.Transparent;
            this.LFaculty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LFaculty.Location = new System.Drawing.Point(17, 120);
            this.LFaculty.Name = "LFaculty";
            this.LFaculty.Size = new System.Drawing.Size(341, 30);
            this.LFaculty.TabIndex = 30;
            this.LFaculty.Text = "Faculty: ";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.Laddress);
            this.guna2GroupBox1.Controls.Add(this.LNumberphone);
            this.guna2GroupBox1.Controls.Add(this.Lemail);
            this.guna2GroupBox1.Controls.Add(this.LFaculty);
            this.guna2GroupBox1.Controls.Add(this.LStudentName);
            this.guna2GroupBox1.Controls.Add(this.LStudentId);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.MediumVioletRed;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 239);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(844, 177);
            this.guna2GroupBox1.TabIndex = 31;
            this.guna2GroupBox1.Text = "Student Information";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Laddress
            // 
            this.Laddress.AutoSize = false;
            this.Laddress.BackColor = System.Drawing.Color.Transparent;
            this.Laddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Laddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Laddress.Location = new System.Drawing.Point(500, 120);
            this.Laddress.Name = "Laddress";
            this.Laddress.Size = new System.Drawing.Size(341, 30);
            this.Laddress.TabIndex = 33;
            this.Laddress.Text = "Address: ";
            // 
            // LNumberphone
            // 
            this.LNumberphone.AutoSize = false;
            this.LNumberphone.BackColor = System.Drawing.Color.Transparent;
            this.LNumberphone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumberphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LNumberphone.Location = new System.Drawing.Point(500, 84);
            this.LNumberphone.Name = "LNumberphone";
            this.LNumberphone.Size = new System.Drawing.Size(341, 30);
            this.LNumberphone.TabIndex = 32;
            this.LNumberphone.Text = "Number Phone: ";
            // 
            // Lemail
            // 
            this.Lemail.AutoSize = false;
            this.Lemail.BackColor = System.Drawing.Color.Transparent;
            this.Lemail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Lemail.Location = new System.Drawing.Point(500, 48);
            this.Lemail.Name = "Lemail";
            this.Lemail.Size = new System.Drawing.Size(341, 30);
            this.Lemail.TabIndex = 31;
            this.Lemail.Text = "Email: ";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(856, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(18, 890);
            this.guna2Panel1.TabIndex = 32;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 878);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(856, 12);
            this.guna2Panel3.TabIndex = 34;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.Image")));
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(120, 120);
            this.guna2CircleButton1.Location = new System.Drawing.Point(762, 153);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(90, 80);
            this.guna2CircleButton1.TabIndex = 35;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // FormStudentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(876, 888);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.Loutcome);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.CBsemester);
            this.Controls.Add(this.CPBstudent);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.DGstudentdetails);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStudentDetails";
            this.Text = "FormStudentDetails";
            this.Load += new System.EventHandler(this.FormStudentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGstudentdetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPBstudent)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView DGstudentdetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSystem10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSystem4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox CPBstudent;
        private Guna.UI2.WinForms.Guna2ComboBox CBsemester;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel Loutcome;
        private Guna.UI2.WinForms.Guna2HtmlLabel LStudentId;
        private Guna.UI2.WinForms.Guna2HtmlLabel LStudentName;
        private Guna.UI2.WinForms.Guna2HtmlLabel LFaculty;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Laddress;
        private Guna.UI2.WinForms.Guna2HtmlLabel LNumberphone;
        private Guna.UI2.WinForms.Guna2HtmlLabel Lemail;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
    }
}