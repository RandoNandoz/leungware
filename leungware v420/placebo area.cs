﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leungware_v420
{
    public partial class PLACEBO : Form
    {
        public PLACEBO()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _ = MessageBox.Show("We (randonandoz and rethinking.) arnt responsible for anything that happenes");
            var Clicker = new clicker();
            Clicker.Show();
        }
    }
}