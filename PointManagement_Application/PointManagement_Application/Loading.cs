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
    public partial class Loading : Form
    {
        public Loading(string txt)
        {
            InitializeComponent();
            txttb.Text = txt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        public void UpdateProgress(int progress, string message)
        {
            if (InvokeRequired) { Invoke(new Action<int, string>(UpdateProgress), progress, message); return; }
        }
    } 
}
