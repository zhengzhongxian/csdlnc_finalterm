﻿using System;
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
    public partial class FormTbUpdateSuccess : Form
    {
        public FormTbUpdateSuccess()
        {
            InitializeComponent();
        }

        private void Bok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
