namespace PointManagement_Application
{
    partial class FormAddExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddExam));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DTtimeslot = new MetroFramework.Controls.MetroDateTime();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CBexamtype = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CBinvigilator = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CBduration = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CBsubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CBroom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Bsubmit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.a = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.s = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DTexamday = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(189)))), ((int)(((byte)(225)))));
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(463, 47);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(463, 47);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Add a exam";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.DTtimeslot);
            this.panel1.Controls.Add(this.guna2HtmlLabel5);
            this.panel1.Controls.Add(this.CBexamtype);
            this.panel1.Controls.Add(this.CBinvigilator);
            this.panel1.Controls.Add(this.CBduration);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.CBsubject);
            this.panel1.Controls.Add(this.CBroom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Bsubmit);
            this.panel1.Controls.Add(this.guna2HtmlLabel8);
            this.panel1.Controls.Add(this.guna2HtmlLabel2);
            this.panel1.Controls.Add(this.a);
            this.panel1.Controls.Add(this.s);
            this.panel1.Controls.Add(this.guna2HtmlLabel3);
            this.panel1.Controls.Add(this.DTexamday);
            this.panel1.Controls.Add(this.guna2HtmlLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 557);
            this.panel1.TabIndex = 22;
            // 
            // DTtimeslot
            // 
            this.DTtimeslot.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTtimeslot.Location = new System.Drawing.Point(52, 372);
            this.DTtimeslot.MinimumSize = new System.Drawing.Size(0, 30);
            this.DTtimeslot.Name = "DTtimeslot";
            this.DTtimeslot.Size = new System.Drawing.Size(365, 30);
            this.DTtimeslot.TabIndex = 34;
            this.DTtimeslot.ValueChanged += new System.EventHandler(this.DTtimeslot_ValueChanged_1);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(52, 710);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel5.TabIndex = 33;
            this.guna2HtmlLabel5.Text = "Exam type";
            // 
            // CBexamtype
            // 
            this.CBexamtype.AutoRoundedCorners = true;
            this.CBexamtype.BackColor = System.Drawing.Color.Transparent;
            this.CBexamtype.BorderRadius = 17;
            this.CBexamtype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBexamtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBexamtype.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBexamtype.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBexamtype.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBexamtype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBexamtype.ItemHeight = 30;
            this.CBexamtype.Location = new System.Drawing.Point(52, 750);
            this.CBexamtype.Name = "CBexamtype";
            this.CBexamtype.Size = new System.Drawing.Size(365, 36);
            this.CBexamtype.TabIndex = 32;
            // 
            // CBinvigilator
            // 
            this.CBinvigilator.AutoRoundedCorners = true;
            this.CBinvigilator.BackColor = System.Drawing.Color.Transparent;
            this.CBinvigilator.BorderRadius = 17;
            this.CBinvigilator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBinvigilator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBinvigilator.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBinvigilator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBinvigilator.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBinvigilator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBinvigilator.ItemHeight = 30;
            this.CBinvigilator.Location = new System.Drawing.Point(52, 650);
            this.CBinvigilator.Name = "CBinvigilator";
            this.CBinvigilator.Size = new System.Drawing.Size(365, 36);
            this.CBinvigilator.TabIndex = 31;
            // 
            // CBduration
            // 
            this.CBduration.AutoRoundedCorners = true;
            this.CBduration.BackColor = System.Drawing.Color.Transparent;
            this.CBduration.BorderRadius = 17;
            this.CBduration.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBduration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBduration.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBduration.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBduration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBduration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBduration.ItemHeight = 30;
            this.CBduration.Location = new System.Drawing.Point(52, 555);
            this.CBduration.Name = "CBduration";
            this.CBduration.Size = new System.Drawing.Size(365, 36);
            this.CBduration.TabIndex = 30;
            this.CBduration.SelectedIndexChanged += new System.EventHandler(this.CBduration_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // CBsubject
            // 
            this.CBsubject.AutoRoundedCorners = true;
            this.CBsubject.BackColor = System.Drawing.Color.Transparent;
            this.CBsubject.BorderRadius = 17;
            this.CBsubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBsubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBsubject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBsubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBsubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBsubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBsubject.ItemHeight = 30;
            this.CBsubject.Location = new System.Drawing.Point(52, 163);
            this.CBsubject.Name = "CBsubject";
            this.CBsubject.Size = new System.Drawing.Size(365, 36);
            this.CBsubject.TabIndex = 25;
            // 
            // CBroom
            // 
            this.CBroom.AutoRoundedCorners = true;
            this.CBroom.BackColor = System.Drawing.Color.Transparent;
            this.CBroom.BorderRadius = 17;
            this.CBroom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBroom.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBroom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBroom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBroom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBroom.ItemHeight = 30;
            this.CBroom.Location = new System.Drawing.Point(52, 461);
            this.CBroom.Name = "CBroom";
            this.CBroom.Size = new System.Drawing.Size(365, 36);
            this.CBroom.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 880);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 10);
            this.panel2.TabIndex = 21;
            // 
            // Bsubmit
            // 
            this.Bsubmit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(112)))));
            this.Bsubmit.BorderRadius = 20;
            this.Bsubmit.BorderThickness = 3;
            this.Bsubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bsubmit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bsubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bsubmit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bsubmit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bsubmit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.Bsubmit.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bsubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(112)))));
            this.Bsubmit.Location = new System.Drawing.Point(124, 823);
            this.Bsubmit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.Bsubmit.Name = "Bsubmit";
            this.Bsubmit.Size = new System.Drawing.Size(206, 57);
            this.Bsubmit.TabIndex = 20;
            this.Bsubmit.Text = "Submit";
            this.Bsubmit.Click += new System.EventHandler(this.Bsubmit_Click);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.AutoSize = false;
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(52, 610);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel8.TabIndex = 19;
            this.guna2HtmlLabel8.Text = "Invigilator";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(52, 123);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel2.TabIndex = 2;
            this.guna2HtmlLabel2.Text = "Subject";
            // 
            // a
            // 
            this.a.AutoSize = false;
            this.a.BackColor = System.Drawing.Color.Transparent;
            this.a.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a.Location = new System.Drawing.Point(52, 320);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(148, 34);
            this.a.TabIndex = 5;
            this.a.Text = "Time slot";
            // 
            // s
            // 
            this.s.AutoSize = false;
            this.s.BackColor = System.Drawing.Color.Transparent;
            this.s.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.Location = new System.Drawing.Point(52, 223);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(148, 34);
            this.s.TabIndex = 6;
            this.s.Text = "Exam day";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(52, 421);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel3.TabIndex = 8;
            this.guna2HtmlLabel3.Text = "Room";
            // 
            // DTexamday
            // 
            this.DTexamday.BorderRadius = 15;
            this.DTexamday.Checked = true;
            this.DTexamday.FillColor = System.Drawing.Color.Black;
            this.DTexamday.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTexamday.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DTexamday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTexamday.Location = new System.Drawing.Point(52, 263);
            this.DTexamday.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTexamday.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTexamday.Name = "DTexamday";
            this.DTexamday.Size = new System.Drawing.Size(365, 36);
            this.DTexamday.TabIndex = 9;
            this.DTexamday.Value = new System.DateTime(2024, 10, 20, 20, 22, 40, 638);
            this.DTexamday.ValueChanged += new System.EventHandler(this.DTexamday_ValueChanged);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(52, 515);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel4.TabIndex = 10;
            this.guna2HtmlLabel4.Text = "Duration";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.CustomIconSize = 13F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(418, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 35;
            // 
            // FormAddExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 604);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddExam";
            this.Text = "FormAddExam";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button Bsubmit;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel a;
        private Guna.UI2.WinForms.Guna2HtmlLabel s;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTexamday;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox CBsubject;
        private Guna.UI2.WinForms.Guna2ComboBox CBroom;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2ComboBox CBinvigilator;
        private Guna.UI2.WinForms.Guna2ComboBox CBduration;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ComboBox CBexamtype;
        private MetroFramework.Controls.MetroDateTime DTtimeslot;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}