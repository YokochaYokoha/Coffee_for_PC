using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee
{
  
    public partial class Form4 : Form

    {
        Form1 back2main;
        public Form4()
        {
            InitializeComponent();
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
timer1.Enabled = false;
            string aa = label1.Text;
            this.webView21.CoreWebView2.Navigate(aa + "");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate(label1.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoForward();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            back2main = new Form1();
            back2main.receiver.Text = webView21.CoreWebView2.Source;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(webView21.CoreWebView2.Source, true);
            MessageBox.Show("コピーしました。");
        }
    }
}
