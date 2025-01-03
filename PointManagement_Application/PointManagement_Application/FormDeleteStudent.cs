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
    public partial class FormDeleteStudent : Form
    {
        public bool IsConfirmed { get; private set; } = false;
        public FormDeleteStudent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bclick_yes_Click(object sender, EventArgs e)
        {
            IsConfirmed = true;
            this.Close();
        }

        private void Bclick_no_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }

        private void FormDeleteStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
