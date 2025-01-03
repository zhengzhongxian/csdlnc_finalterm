namespace PointManagement_Application
{
    partial class FormUpdateExamResult
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
            this.label1 = new System.Windows.Forms.Label();
            this.CBlecturer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtScore = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Bok = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.labelfalse = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Available Lecturers List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBlecturer
            // 
            this.CBlecturer.BackColor = System.Drawing.Color.Transparent;
            this.CBlecturer.BorderRadius = 6;
            this.CBlecturer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBlecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBlecturer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBlecturer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CBlecturer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBlecturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBlecturer.ItemHeight = 30;
            this.CBlecturer.Location = new System.Drawing.Point(35, 39);
            this.CBlecturer.MaxDropDownItems = 5;
            this.CBlecturer.Name = "CBlecturer";
            this.CBlecturer.Size = new System.Drawing.Size(194, 36);
            this.CBlecturer.TabIndex = 4;
            this.CBlecturer.DropDown += new System.EventHandler(this.CBlecturer_DropDown);
            // 
            // txtScore
            // 
            this.txtScore.BorderRadius = 6;
            this.txtScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScore.DefaultText = "";
            this.txtScore.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtScore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScore.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtScore.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScore.Location = new System.Drawing.Point(35, 111);
            this.txtScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScore.Name = "txtScore";
            this.txtScore.PasswordChar = '\0';
            this.txtScore.PlaceholderText = "Example: 7.5";
            this.txtScore.SelectedText = "";
            this.txtScore.Size = new System.Drawing.Size(194, 36);
            this.txtScore.TabIndex = 5;
            this.txtScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScore_KeyPress);
            this.txtScore.Leave += new System.EventHandler(this.txtScore_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = " Score";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bok
            // 
            this.Bok.BorderRadius = 3;
            this.Bok.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bok.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Bok.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bok.ForeColor = System.Drawing.Color.White;
            this.Bok.Location = new System.Drawing.Point(251, 69);
            this.Bok.Name = "Bok";
            this.Bok.Size = new System.Drawing.Size(101, 47);
            this.Bok.TabIndex = 7;
            this.Bok.Text = "OK";
            this.Bok.TextFormatNoPrefix = true;
            this.Bok.Click += new System.EventHandler(this.Bok_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // labelfalse
            // 
            this.labelfalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfalse.ForeColor = System.Drawing.Color.Red;
            this.labelfalse.Location = new System.Drawing.Point(31, 151);
            this.labelfalse.Name = "labelfalse";
            this.labelfalse.Size = new System.Drawing.Size(273, 23);
            this.labelfalse.TabIndex = 39;
            this.labelfalse.Text = "Please enter score";
            this.labelfalse.Visible = false;
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(329, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 40;
            // 
            // FormUpdateExamResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 173);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.labelfalse);
            this.Controls.Add(this.Bok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.CBlecturer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUpdateExamResult";
            this.Text = "FormUpdateExamResult";
            this.Load += new System.EventHandler(this.FormUpdateExamResult_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox CBlecturer;
        private Guna.UI2.WinForms.Guna2TextBox txtScore;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button Bok;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label labelfalse;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}