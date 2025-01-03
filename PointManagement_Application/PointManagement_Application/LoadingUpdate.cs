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
    public partial class LoadingUpdate : Form
    {
        public LoadingUpdate(string txt)
        {
            InitializeComponent();
            txttb.Text = txt;
        }

        private void txttb_Click(object sender, EventArgs e)
        {
            
        }
    }
}
