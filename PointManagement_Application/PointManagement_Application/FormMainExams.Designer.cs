namespace PointManagement_Application
{
    partial class FormMainExams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainExams));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Bcreat_exam = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Bupdate_exam = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Bdelete_exam = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CBfaculty = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DGexam = new Guna.UI2.WinForms.Guna2DataGridView();
            this.examId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vacantSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invigilatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGexam)).BeginInit();
            this.SuspendLayout();
            // 
            // Tsearch
            // 
            this.Tsearch.BorderRadius = 20;
            this.Tsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Tsearch.DefaultText = "";
            this.Tsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Tsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Tsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Tsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Tsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Tsearch.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tsearch.ForeColor = System.Drawing.Color.Gray;
            this.Tsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Tsearch.Location = new System.Drawing.Point(14, 14);
            this.Tsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Tsearch.Name = "Tsearch";
            this.Tsearch.PasswordChar = '\0';
            this.Tsearch.PlaceholderText = "";
            this.Tsearch.SelectedText = "";
            this.Tsearch.Size = new System.Drawing.Size(830, 45);
            this.Tsearch.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(802, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Bcreat_exam
            // 
            this.Bcreat_exam.BorderRadius = 15;
            this.Bcreat_exam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bcreat_exam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bcreat_exam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bcreat_exam.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bcreat_exam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bcreat_exam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.Bcreat_exam.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(156)))), ((int)(((byte)(193)))));
            this.Bcreat_exam.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bcreat_exam.ForeColor = System.Drawing.Color.White;
            this.Bcreat_exam.Image = ((System.Drawing.Image)(resources.GetObject("Bcreat_exam.Image")));
            this.Bcreat_exam.ImageOffset = new System.Drawing.Point(0, -2);
            this.Bcreat_exam.ImageSize = new System.Drawing.Size(40, 40);
            this.Bcreat_exam.Location = new System.Drawing.Point(12, 73);
            this.Bcreat_exam.Name = "Bcreat_exam";
            this.Bcreat_exam.Size = new System.Drawing.Size(180, 55);
            this.Bcreat_exam.TabIndex = 6;
            this.Bcreat_exam.Text = "Create Exam";
            this.Bcreat_exam.Click += new System.EventHandler(this.Bcreat_exam_Click);
            // 
            // Bupdate_exam
            // 
            this.Bupdate_exam.BorderRadius = 15;
            this.Bupdate_exam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bupdate_exam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bupdate_exam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bupdate_exam.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bupdate_exam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bupdate_exam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(146)))), ((int)(((byte)(57)))));
            this.Bupdate_exam.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(48)))));
            this.Bupdate_exam.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bupdate_exam.ForeColor = System.Drawing.Color.White;
            this.Bupdate_exam.Image = ((System.Drawing.Image)(resources.GetObject("Bupdate_exam.Image")));
            this.Bupdate_exam.ImageSize = new System.Drawing.Size(40, 40);
            this.Bupdate_exam.Location = new System.Drawing.Point(198, 73);
            this.Bupdate_exam.Name = "Bupdate_exam";
            this.Bupdate_exam.Size = new System.Drawing.Size(180, 55);
            this.Bupdate_exam.TabIndex = 7;
            this.Bupdate_exam.Text = "Update Exam";
            this.Bupdate_exam.Click += new System.EventHandler(this.Bupdate_exam_Click);
            // 
            // Bdelete_exam
            // 
            this.Bdelete_exam.BorderRadius = 15;
            this.Bdelete_exam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bdelete_exam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bdelete_exam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bdelete_exam.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bdelete_exam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bdelete_exam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(3)))), ((int)(((byte)(8)))));
            this.Bdelete_exam.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.Bdelete_exam.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bdelete_exam.ForeColor = System.Drawing.Color.White;
            this.Bdelete_exam.Image = ((System.Drawing.Image)(resources.GetObject("Bdelete_exam.Image")));
            this.Bdelete_exam.ImageSize = new System.Drawing.Size(40, 40);
            this.Bdelete_exam.Location = new System.Drawing.Point(384, 73);
            this.Bdelete_exam.Name = "Bdelete_exam";
            this.Bdelete_exam.Size = new System.Drawing.Size(180, 55);
            this.Bdelete_exam.TabIndex = 8;
            this.Bdelete_exam.Text = "Delete Exam";
            this.Bdelete_exam.Click += new System.EventHandler(this.Bdelete_exam_Click);
            // 
            // CBfaculty
            // 
            this.CBfaculty.BackColor = System.Drawing.Color.Transparent;
            this.CBfaculty.BorderRadius = 10;
            this.CBfaculty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBfaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBfaculty.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBfaculty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBfaculty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBfaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBfaculty.ItemHeight = 30;
            this.CBfaculty.Location = new System.Drawing.Point(570, 92);
            this.CBfaculty.Name = "CBfaculty";
            this.CBfaculty.Size = new System.Drawing.Size(274, 36);
            this.CBfaculty.TabIndex = 9;
            this.CBfaculty.SelectedIndexChanged += new System.EventHandler(this.CBfaculty_SelectedIndexChanged);
            // 
            // DGexam
            // 
            this.DGexam.AllowUserToAddRows = false;
            this.DGexam.AllowUserToResizeColumns = false;
            this.DGexam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGexam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGexam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGexam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGexam.ColumnHeadersHeight = 37;
            this.DGexam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.examId,
            this.subjectName,
            this.roomName,
            this.examDate,
            this.timeSlot,
            this.duration,
            this.vacantSeat,
            this.invigilatorName,
            this.examType});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGexam.DefaultCellStyle = dataGridViewCellStyle12;
            this.DGexam.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGexam.Location = new System.Drawing.Point(14, 158);
            this.DGexam.Name = "DGexam";
            this.DGexam.RowHeadersVisible = false;
            this.DGexam.RowHeadersWidth = 51;
            this.DGexam.RowTemplate.Height = 40;
            this.DGexam.RowTemplate.ReadOnly = true;
            this.DGexam.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGexam.Size = new System.Drawing.Size(830, 411);
            this.DGexam.TabIndex = 10;
            this.DGexam.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGexam.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGexam.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGexam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGexam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGexam.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGexam.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGexam.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGexam.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGexam.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGexam.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGexam.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGexam.ThemeStyle.HeaderStyle.Height = 37;
            this.DGexam.ThemeStyle.ReadOnly = false;
            this.DGexam.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGexam.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGexam.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGexam.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGexam.ThemeStyle.RowsStyle.Height = 40;
            this.DGexam.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGexam.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGexam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGexam_CellClick);
            this.DGexam.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGexam_CellMouseClick);
            // 
            // examId
            // 
            this.examId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.examId.DefaultCellStyle = dataGridViewCellStyle3;
            this.examId.HeaderText = "Exam ID";
            this.examId.MinimumWidth = 160;
            this.examId.Name = "examId";
            this.examId.Width = 160;
            // 
            // subjectName
            // 
            this.subjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.subjectName.DefaultCellStyle = dataGridViewCellStyle4;
            this.subjectName.HeaderText = "Subject Name";
            this.subjectName.MinimumWidth = 160;
            this.subjectName.Name = "subjectName";
            this.subjectName.Width = 160;
            // 
            // roomName
            // 
            this.roomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.roomName.DefaultCellStyle = dataGridViewCellStyle5;
            this.roomName.HeaderText = "Room Name";
            this.roomName.MinimumWidth = 180;
            this.roomName.Name = "roomName";
            this.roomName.ReadOnly = true;
            this.roomName.Width = 180;
            // 
            // examDate
            // 
            this.examDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.examDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.examDate.HeaderText = "Exam Date";
            this.examDate.MinimumWidth = 180;
            this.examDate.Name = "examDate";
            this.examDate.ReadOnly = true;
            this.examDate.Width = 180;
            // 
            // timeSlot
            // 
            this.timeSlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.timeSlot.DefaultCellStyle = dataGridViewCellStyle7;
            this.timeSlot.HeaderText = "Time Slot";
            this.timeSlot.MinimumWidth = 150;
            this.timeSlot.Name = "timeSlot";
            this.timeSlot.ReadOnly = true;
            this.timeSlot.Width = 150;
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.duration.DefaultCellStyle = dataGridViewCellStyle8;
            this.duration.HeaderText = "Duration";
            this.duration.MinimumWidth = 150;
            this.duration.Name = "duration";
            this.duration.Width = 150;
            // 
            // vacantSeat
            // 
            this.vacantSeat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.vacantSeat.DefaultCellStyle = dataGridViewCellStyle9;
            this.vacantSeat.HeaderText = "Vacant Seat";
            this.vacantSeat.MinimumWidth = 150;
            this.vacantSeat.Name = "vacantSeat";
            this.vacantSeat.Width = 150;
            // 
            // invigilatorName
            // 
            this.invigilatorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.invigilatorName.DefaultCellStyle = dataGridViewCellStyle10;
            this.invigilatorName.HeaderText = "Invigilator";
            this.invigilatorName.MinimumWidth = 150;
            this.invigilatorName.Name = "invigilatorName";
            this.invigilatorName.ReadOnly = true;
            this.invigilatorName.Width = 150;
            // 
            // examType
            // 
            this.examType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.examType.DefaultCellStyle = dataGridViewCellStyle11;
            this.examType.HeaderText = "Exam Type";
            this.examType.MinimumWidth = 150;
            this.examType.Name = "examType";
            this.examType.ReadOnly = true;
            this.examType.Width = 150;
            // 
            // FormMainExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(858, 581);
            this.Controls.Add(this.DGexam);
            this.Controls.Add(this.CBfaculty);
            this.Controls.Add(this.Bdelete_exam);
            this.Controls.Add(this.Bupdate_exam);
            this.Controls.Add(this.Bcreat_exam);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Tsearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainExams";
            this.Text = "FormMainExams";
            this.Load += new System.EventHandler(this.FormMainExams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGexam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox Tsearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton Bcreat_exam;
        private Guna.UI2.WinForms.Guna2GradientButton Bupdate_exam;
        private Guna.UI2.WinForms.Guna2GradientButton Bdelete_exam;
        private Guna.UI2.WinForms.Guna2ComboBox CBfaculty;
        private Guna.UI2.WinForms.Guna2DataGridView DGexam;
        private System.Windows.Forms.DataGridViewTextBoxColumn examId;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn examDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn vacantSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn invigilatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn examType;
    }
}