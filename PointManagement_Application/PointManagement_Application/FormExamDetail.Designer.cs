namespace PointManagement_Application
{
    partial class FormExamDetail
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Bsee_details = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // Bsee_details
            // 
            this.Bsee_details.BorderRadius = 6;
            this.Bsee_details.BorderThickness = 2;
            this.Bsee_details.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bsee_details.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bsee_details.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bsee_details.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bsee_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bsee_details.FillColor = System.Drawing.SystemColors.Control;
            this.Bsee_details.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bsee_details.ForeColor = System.Drawing.Color.Black;
            this.Bsee_details.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(200)))), ((int)(((byte)(228)))));
            this.Bsee_details.Location = new System.Drawing.Point(0, 0);
            this.Bsee_details.Margin = new System.Windows.Forms.Padding(0);
            this.Bsee_details.Name = "Bsee_details";
            this.Bsee_details.Size = new System.Drawing.Size(154, 36);
            this.Bsee_details.TabIndex = 0;
            this.Bsee_details.Text = "See details";
            this.Bsee_details.Click += new System.EventHandler(this.Bsee_details_Click);
            // 
            // FormExamDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 36);
            this.Controls.Add(this.Bsee_details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(154, 36);
            this.MinimumSize = new System.Drawing.Size(154, 36);
            this.Name = "FormExamDetail";
            this.Text = "FormExamDetail";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button Bsee_details;
    }
}