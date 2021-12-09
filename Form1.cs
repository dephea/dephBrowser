using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace dephBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            textBox1.Text = "https://google.com/";
            Browser1.Load(textBox1.Text);

            Browser1.AddressChanged += Browser1_AddressChanged;
            textBox1.Click += textBox1_Click;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Browser1.Load(textBox1.Text);
          
                /*string namesite = textBox1.Text;
                try
                {
                    Uri uri = new Uri(namesite);
                    Browser1.Load(namesite);
                }
                catch (Exception)
                {
                    Uri uri = new Uri("https://google.com");
                    Browser1.Load(uri.ToString());
                    MessageBox.Show("Wrong URL");
                }*/
            
            /*else
            {
                Uri uri = new Uri("https://google.com/search?q=" + textBox1.Text);
                Browser1.Load(uri.ToString());
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser1.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser1.Back();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Browser1.Forward();
        }

        private void Browser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                textBox1.Text = e.Address;
            }));
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
