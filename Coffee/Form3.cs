using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now2 = DateTime.Now;
            label1.Text=now2.ToLongTimeString();
            label2.Text=now2.ToLongDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
