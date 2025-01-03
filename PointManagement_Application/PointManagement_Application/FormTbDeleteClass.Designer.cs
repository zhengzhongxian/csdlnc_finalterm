namespace PointManagement_Application
{
    partial class FormTbDeleteClass
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Bclick_yes = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Bclick_no = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(189)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 32);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you want to delete this class?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bclick_yes
            // 
            this.Bclick_yes.BorderRadius = 15;
            this.Bclick_yes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bclick_yes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bclick_yes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bclick_yes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bclick_yes.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bclick_yes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bclick_yes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            this.Bclick_yes.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(161)))), ((int)(((byte)(199)))));
            this.Bclick_yes.Font = new System.Drawing.Font("Arial Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bclick_yes.ForeColor = System.Drawing.SystemColors.Control;
            this.Bclick_yes.Location = new System.Drawing.Point(187, 52);
            this.Bclick_yes.Name = "Bclick_yes";
            this.Bclick_yes.Size = new System.Drawing.Size(104, 45);
            this.Bclick_yes.TabIndex = 3;
            this.Bclick_yes.Text = "YES";
            this.Bclick_yes.Click += new System.EventHandler(this.Bclick_yes_Click);
            // 
            // Bclick_no
            // 
            this.Bclick_no.BorderRadius = 15;
            this.Bclick_no.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bclick_no.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Bclick_no.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Bclick_no.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bclick_no.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Bclick_no.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Bclick_no.FillColor = System.Drawing.Color.Red;
            this.Bclick_no.FillColor2 = System.Drawing.Color.Crimson;
            this.Bclick_no.Font = new System.Drawing.Font("Arial Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bclick_no.ForeColor = System.Drawing.SystemColors.Control;
            this.Bclick_no.Location = new System.Drawing.Point(306, 52);
            this.Bclick_no.Name = "Bclick_no";
            this.Bclick_no.Size = new System.Drawing.Size(104, 45);
            this.Bclick_no.TabIndex = 4;
            this.Bclick_no.Text = "NO";
            this.Bclick_no.Click += new System.EventHandler(this.Bclick_no_Click);
            // 
            // FormTbDeleteClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 109);
            this.Controls.Add(this.Bclick_no);
            this.Controls.Add(this.Bclick_yes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTbDeleteClass";
            this.Text = "FormTbDeleteClass";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton Bclick_yes;
        private Guna.UI2.WinForms.Guna2GradientButton Bclick_no;
    }
}