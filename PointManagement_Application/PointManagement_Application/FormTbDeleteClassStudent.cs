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
    public partial class FormTbDeleteClassStudent : Form
    {
        public bool IsConfirmed { get; private set; } = false;

        public FormTbDeleteClassStudent()
        {
            InitializeComponent();
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
    }
}
