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

            Browser1.Load("https://google.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("https://") || textBox1.Text.Contains("http://"))
            {
                string namesite = textBox1.Text;
                try
                {
                    Uri uri = new Uri(namesite);
                    Browser1.Load(uri.ToString());
                }
                catch (Exception)
                {
                    Uri uri = new Uri("https://google.com");
                    Browser1.Load(uri.ToString());
                    MessageBox.Show("Wrong URL");
                }
                File.AppendAllText("history.t$", textBox1.Text + "\n");
            }
            else
            {
                Uri uri = new Uri("https://google.com/search?q=" + textBox1.Text);
                Browser1.Load(uri.ToString());

                File.AppendAllText("history.t$", "google: " + textBox1.Text + "\n");
            }

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

        private void Browser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Browser1.Address;
            if (Browser1. == true)
            {
                textBox1.Clear();
            }
        }
    }
}
