namespace PointManagement_Application
{
    partial class FormMainStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainStudent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CBfaculty = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Tsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Bcreat_student = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Bupdate_student = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Bdelete_student = new Guna.UI2.WinForms.Guna2GradientButton();
            this.DGstudent = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CBacademicyear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.studentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educationSystemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.academicYearName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayofbirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGstudent)).BeginInit();
            this.SuspendLayout();
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
            this.CBfaculty.Location = new System.Drawing.Point(570, 73);
            this.CBfaculty.Name = "CBfaculty";
            this.CBfaculty.Size = new System.Drawing.Size(274, 36);
            this.CBfaculty.TabIndex = 1;
            this.CBfaculty.SelectedIndexChanged += new System.EventHandler(this.CBfaculty_SelectedIndexChanged);
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
            this.Tsearch.TabIndex = 3;
            this.Tsearch.TextChanged += new System.EventHandler(this.Tsearch_TextChanged);
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
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // Bcreat_student
            // 
            this.Bcreat_student.BorderRadius = 15;
            this.Bcreat_student.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bcreat_student.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bcreat_student.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bcreat_student.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bcreat_student.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bcreat_student.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.Bcreat_student.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(156)))), ((int)(((byte)(193)))));
            this.Bcreat_student.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bcreat_student.ForeColor = System.Drawing.Color.White;
            this.Bcreat_student.Image = ((System.Drawing.Image)(resources.GetObject("Bcreat_student.Image")));
            this.Bcreat_student.ImageOffset = new System.Drawing.Point(0, -2);
            this.Bcreat_student.ImageSize = new System.Drawing.Size(40, 40);
            this.Bcreat_student.Location = new System.Drawing.Point(12, 73);
            this.Bcreat_student.Name = "Bcreat_student";
            this.Bcreat_student.Size = new System.Drawing.Size(180, 55);
            this.Bcreat_student.TabIndex = 5;
            this.Bcreat_student.Text = "Add Student";
            this.Bcreat_student.TextFormatNoPrefix = true;
            this.Bcreat_student.Click += new System.EventHandler(this.Bcreat_student_Click);
            // 
            // Bupdate_student
            // 
            this.Bupdate_student.BorderRadius = 15;
            this.Bupdate_student.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bupdate_student.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bupdate_student.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bupdate_student.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bupdate_student.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bupdate_student.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(146)))), ((int)(((byte)(57)))));
            this.Bupdate_student.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(48)))));
            this.Bupdate_student.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bupdate_student.ForeColor = System.Drawing.Color.White;
            this.Bupdate_student.Image = ((System.Drawing.Image)(resources.GetObject("Bupdate_student.Image")));
            this.Bupdate_student.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Bupdate_student.ImageOffset = new System.Drawing.Point(-3, 0);
            this.Bupdate_student.ImageSize = new System.Drawing.Size(50, 50);
            this.Bupdate_student.Location = new System.Drawing.Point(198, 73);
            this.Bupdate_student.Name = "Bupdate_student";
            this.Bupdate_student.Size = new System.Drawing.Size(180, 55);
            this.Bupdate_student.TabIndex = 6;
            this.Bupdate_student.Text = "Edit Info";
            this.Bupdate_student.TextFormatNoPrefix = true;
            this.Bupdate_student.TextOffset = new System.Drawing.Point(10, 0);
            this.Bupdate_student.Click += new System.EventHandler(this.Bupdate_student_Click);
            // 
            // Bdelete_student
            // 
            this.Bdelete_student.BorderRadius = 15;
            this.Bdelete_student.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bdelete_student.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bdelete_student.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bdelete_student.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bdelete_student.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bdelete_student.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(3)))), ((int)(((byte)(8)))));
            this.Bdelete_student.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.Bdelete_student.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bdelete_student.ForeColor = System.Drawing.Color.White;
            this.Bdelete_student.Image = ((System.Drawing.Image)(resources.GetObject("Bdelete_student.Image")));
            this.Bdelete_student.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Bdelete_student.ImageOffset = new System.Drawing.Point(-6, 0);
            this.Bdelete_student.ImageSize = new System.Drawing.Size(50, 47);
            this.Bdelete_student.Location = new System.Drawing.Point(384, 73);
            this.Bdelete_student.Name = "Bdelete_student";
            this.Bdelete_student.Size = new System.Drawing.Size(180, 55);
            this.Bdelete_student.TabIndex = 7;
            this.Bdelete_student.Text = "Delete";
            this.Bdelete_student.TextFormatNoPrefix = true;
            this.Bdelete_student.TextOffset = new System.Drawing.Point(5, 0);
            this.Bdelete_student.Click += new System.EventHandler(this.Bdelete_student_Click);
            // 
            // DGstudent
            // 
            this.DGstudent.AllowUserToAddRows = false;
            this.DGstudent.AllowUserToResizeColumns = false;
            this.DGstudent.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGstudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGstudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGstudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGstudent.ColumnHeadersHeight = 37;
            this.DGstudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentId,
            this.Auditable,
            this.studentName,
            this.facultyName,
            this.educationSystemName,
            this.academicYearName,
            this.email,
            this.phoneNumber,
            this.gender,
            this.dayofbirth,
            this.address});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGstudent.DefaultCellStyle = dataGridViewCellStyle13;
            this.DGstudent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudent.Location = new System.Drawing.Point(14, 158);
            this.DGstudent.Name = "DGstudent";
            this.DGstudent.RowHeadersVisible = false;
            this.DGstudent.RowHeadersWidth = 51;
            this.DGstudent.RowTemplate.Height = 40;
            this.DGstudent.RowTemplate.ReadOnly = true;
            this.DGstudent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGstudent.Size = new System.Drawing.Size(830, 411);
            this.DGstudent.TabIndex = 8;
            this.DGstudent.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGstudent.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGstudent.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGstudent.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGstudent.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGstudent.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGstudent.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudent.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGstudent.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGstudent.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGstudent.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGstudent.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGstudent.ThemeStyle.HeaderStyle.Height = 37;
            this.DGstudent.ThemeStyle.ReadOnly = false;
            this.DGstudent.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGstudent.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGstudent.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGstudent.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGstudent.ThemeStyle.RowsStyle.Height = 40;
            this.DGstudent.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGstudent.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGstudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGstudent_CellClick);
            this.DGstudent.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGstudent_CellMouseClick);
            // 
            // CBacademicyear
            // 
            this.CBacademicyear.BackColor = System.Drawing.Color.Transparent;
            this.CBacademicyear.BorderColor = System.Drawing.Color.White;
            this.CBacademicyear.BorderRadius = 10;
            this.CBacademicyear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBacademicyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBacademicyear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBacademicyear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBacademicyear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBacademicyear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBacademicyear.ItemHeight = 30;
            this.CBacademicyear.Location = new System.Drawing.Point(572, 115);
            this.CBacademicyear.Name = "CBacademicyear";
            this.CBacademicyear.Size = new System.Drawing.Size(274, 36);
            this.CBacademicyear.TabIndex = 9;
            this.CBacademicyear.SelectedIndexChanged += new System.EventHandler(this.CBacademicyear_SelectedIndexChanged);
            // 
            // studentId
            // 
            this.studentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.studentId.DefaultCellStyle = dataGridViewCellStyle3;
            this.studentId.HeaderText = "Student ID";
            this.studentId.MinimumWidth = 160;
            this.studentId.Name = "studentId";
            this.studentId.Width = 160;
            // 
            // Auditable
            // 
            this.Auditable.HeaderText = "Auditable";
            this.Auditable.MinimumWidth = 6;
            this.Auditable.Name = "Auditable";
            this.Auditable.Visible = false;
            this.Auditable.Width = 108;
            // 
            // studentName
            // 
            this.studentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.studentName.DefaultCellStyle = dataGridViewCellStyle4;
            this.studentName.HeaderText = "Student Name";
            this.studentName.MinimumWidth = 160;
            this.studentName.Name = "studentName";
            this.studentName.Width = 160;
            // 
            // facultyName
            // 
            this.facultyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.facultyName.DefaultCellStyle = dataGridViewCellStyle5;
            this.facultyName.HeaderText = "Faculty";
            this.facultyName.MinimumWidth = 180;
            this.facultyName.Name = "facultyName";
            this.facultyName.ReadOnly = true;
            this.facultyName.Width = 180;
            // 
            // educationSystemName
            // 
            this.educationSystemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.educationSystemName.DefaultCellStyle = dataGridViewCellStyle6;
            this.educationSystemName.HeaderText = "Education System";
            this.educationSystemName.MinimumWidth = 180;
            this.educationSystemName.Name = "educationSystemName";
            this.educationSystemName.ReadOnly = true;
            this.educationSystemName.Width = 180;
            // 
            // academicYearName
            // 
            this.academicYearName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.academicYearName.DefaultCellStyle = dataGridViewCellStyle7;
            this.academicYearName.HeaderText = "Academic Year";
            this.academicYearName.MinimumWidth = 150;
            this.academicYearName.Name = "academicYearName";
            this.academicYearName.ReadOnly = true;
            this.academicYearName.Width = 150;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.email.DefaultCellStyle = dataGridViewCellStyle8;
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 150;
            this.email.Name = "email";
            this.email.Width = 150;
            // 
            // phoneNumber
            // 
            this.phoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phoneNumber.DefaultCellStyle = dataGridViewCellStyle9;
            this.phoneNumber.HeaderText = "Phone Number";
            this.phoneNumber.MinimumWidth = 150;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Width = 150;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gender.DefaultCellStyle = dataGridViewCellStyle10;
            this.gender.HeaderText = "Gender";
            this.gender.MinimumWidth = 150;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 150;
            // 
            // dayofbirth
            // 
            this.dayofbirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dayofbirth.DefaultCellStyle = dataGridViewCellStyle11;
            this.dayofbirth.HeaderText = "Day of Birth";
            this.dayofbirth.MinimumWidth = 150;
            this.dayofbirth.Name = "dayofbirth";
            this.dayofbirth.ReadOnly = true;
            this.dayofbirth.Width = 150;
            // 
            // address
            // 
            this.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.address.DefaultCellStyle = dataGridViewCellStyle12;
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 150;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 150;
            // 
            // FormMainStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(858, 581);
            this.Controls.Add(this.CBacademicyear);
            this.Controls.Add(this.DGstudent);
            this.Controls.Add(this.Bdelete_student);
            this.Controls.Add(this.Bupdate_student);
            this.Controls.Add(this.Bcreat_student);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Tsearch);
            this.Controls.Add(this.CBfaculty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainStudent";
            this.Text = "FormMainStudent";
            this.Load += new System.EventHandler(this.FormMainStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGstudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox CBfaculty;
        private Guna.UI2.WinForms.Guna2TextBox Tsearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientButton Bcreat_student;
        private Guna.UI2.WinForms.Guna2GradientButton Bdelete_student;
        private Guna.UI2.WinForms.Guna2GradientButton Bupdate_student;
        private Guna.UI2.WinForms.Guna2DataGridView DGstudent;
        private Guna.UI2.WinForms.Guna2ComboBox CBacademicyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditable;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn facultyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn educationSystemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn academicYearName;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayofbirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
    }
}