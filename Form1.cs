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
            ChromiumWebBrowser Browser1 = new ChromiumWebBrowser(textBox1.Text);
            Browser1.Parent = tabControl1.SelectedTab;
            //this.pContainer.Controls.Add(Browser1);

            Browser1.AddressChanged += Browser1_AddressChanged;
            Browser1.TitleChanged += Browser1_TitleChanged;
            textBox1.Click += textBox1_Click;
            textBox1.KeyDown += textBox1_KeyDown;

            //tabControl1.Click += TabControl1_Click;
        }

      

        private void button5_Click(object sender, EventArgs e)
        {

            ChromiumWebBrowser Browser1 = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            
            /*if (Uri.IsWellFormedUriString(textBox1.Text, UriKind.Absolute))
            { 
                    Browser1.Load(textBox1.Text);
            }*/

            bool checkIfDot(string s)
            {
                if (s.Contains("."))
                {
                    return true;
                }
                return false;
            }


            /////////////////////////////////////////////////////////



            if (Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute))
            {
                if (checkIfDot(textBox1.Text)) 
                { 
                    Browser1.Load(textBox1.Text); 
                }
                else
                {
                    Browser1.Load("https://www.google.com/search?q=" + textBox1.Text);
                }    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser Browser1 = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (Browser1 != null)
                Browser1.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser Browser1 = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (Browser1 != null)
            {
                if (Browser1.CanGoBack)
                {
                    Browser1.Back();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser Browser1 = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (Browser1 != null)
            {
                if (Browser1.CanGoForward)
                {
                    Browser1.Forward();
                }
            }
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


        private void Browser1_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                tabControl1.SelectedTab.Text = e.Title;
            }));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            ChromiumWebBrowser Browser1 = new ChromiumWebBrowser("https://google.com");
            Browser1.Parent = tab;
            Browser1.Dock = DockStyle.Fill;
            textBox1.Text = "https://google.com";
            Browser1.AddressChanged += Browser1_AddressChanged;
            Browser1.TitleChanged += Browser1_TitleChanged;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button5_Click(this, new EventArgs());

                e.SuppressKeyPress = true;
            }
        }
    }
}
