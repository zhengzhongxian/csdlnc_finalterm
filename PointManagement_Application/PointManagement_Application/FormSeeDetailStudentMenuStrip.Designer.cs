namespace PointManagement_Application
{
    partial class FormSeeDetailStudentMenuStrip
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
            this.Bsee_details = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Binfo = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // Bsee_details
            // 
            this.Bsee_details.BorderRadius = 6;
            this.Bsee_details.BorderThickness = 2;
            this.Bsee_details.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bsee_details.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bsee_details.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bsee_details.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bsee_details.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bsee_details.FillColor = System.Drawing.SystemColors.Control;
            this.Bsee_details.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bsee_details.ForeColor = System.Drawing.Color.Black;
            this.Bsee_details.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(200)))), ((int)(((byte)(228)))));
            this.Bsee_details.Location = new System.Drawing.Point(0, 0);
            this.Bsee_details.Margin = new System.Windows.Forms.Padding(0);
            this.Bsee_details.Name = "Bsee_details";
            this.Bsee_details.Size = new System.Drawing.Size(154, 36);
            this.Bsee_details.TabIndex = 1;
            this.Bsee_details.Text = "See Details";
            this.Bsee_details.Click += new System.EventHandler(this.Bsee_details_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // Binfo
            // 
            this.Binfo.BorderRadius = 6;
            this.Binfo.BorderThickness = 2;
            this.Binfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Binfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Binfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Binfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Binfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Binfo.FillColor = System.Drawing.SystemColors.Control;
            this.Binfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Binfo.ForeColor = System.Drawing.Color.Black;
            this.Binfo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(200)))), ((int)(((byte)(228)))));
            this.Binfo.Location = new System.Drawing.Point(0, 36);
            this.Binfo.Margin = new System.Windows.Forms.Padding(0);
            this.Binfo.Name = "Binfo";
            this.Binfo.Size = new System.Drawing.Size(154, 38);
            this.Binfo.TabIndex = 2;
            this.Binfo.Text = "Info";
            this.Binfo.Click += new System.EventHandler(this.Binfo_Click);
            // 
            // FormSeeDetailStudentMenuStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 74);
            this.Controls.Add(this.Binfo);
            this.Controls.Add(this.Bsee_details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(154, 74);
            this.MinimumSize = new System.Drawing.Size(154, 74);
            this.Name = "FormSeeDetailStudentMenuStrip";
            this.Text = "FormSeeDetailStudentMenuStrip";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button Bsee_details;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button Binfo;
    }
}