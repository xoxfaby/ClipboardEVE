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
        public bool invalid;
        public string link;
        bool once = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (invalid)
            {
                label4.Visible = true;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
                this.Close();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(link); 
            this.Close();
        }
    }
}
