using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClipboardEVE
{
    public partial class Form2 : Form
    {

        bool once = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (once)
            {
                this.Close();
            }
            once = true;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
