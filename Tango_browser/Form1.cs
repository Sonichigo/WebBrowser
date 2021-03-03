using System;
using EasyTabs;
using CefSharp.WinForms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Svg;
using CefSharp;

namespace Tango_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void initalizeChromium()
        {
            CefSettings settings= new CefSettings();
            webBrowser = new ChromiumWebBrowser("https://google.com");
            this.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
        }
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtSerachOnUrl.Text= webBrowser1.Url.AbsoluteUri;
            listView1.Items.Add(webBrowser1.Document.Url.AbsoluteUri);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack) webBrowser.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward) webBrowser.Forward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser.Load("https://www.google.com/");
        }
        public void txtSerachonUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtSerachOnUrl.Text.Contains(".") && !txtSerachOnUrl.Text.Contains(" ") && txtSerachOnUrl.Text.Length > 0)
            {
             webBrowser.Load("https://" + txtSerachOnUrl.Text);
                webBrowser1.Navigate("https://" + txtSerachOnUrl.Text);
            }
            else if (e.KeyChar == (char)13)
            {
              webBrowser.Load("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+"));
                webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
            }
        }
        private void txtSerachOrUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtSerachOnUrl.Text.Contains(".") && !txtSerachOnUrl.Text.Contains(" ") && txtSerachOnUrl.Text.Length > 0)
            {
                //ites a url
               webBrowser.Load("https://"+txtSerachOnUrl.Text);
               webBrowser1.Navigate("https://" + txtSerachOnUrl.Text);
            }
            else if (e.KeyData==Keys.Enter)
            {
                //its a search
                webBrowser.Load("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
                webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
            }
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
           webBrowser.Load("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
            webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOnUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /// Form2 frm = new Form2();
            ///frm.Show();
            timer2.Start();
            if (panel2.Height != 0)
            {
                panel2.Height = 0;
                timer2.Enabled = false;
            }
        } 
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Load("https://www.google.com");
        }
        ChromiumWebBrowser webBrowser;
        private void Form1_Load(object sender, EventArgs e)
        {
            initalizeChromium();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (panel1.Height != 0)
                {
                panel1.Height = 0;
                timer1.Enabled = false;
                }   
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel1.Height = 300;
            timer1.Stop();
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            panel2.Height = 300;
            timer2.Stop();
        }
        private void button4_Click(object sender, EventArgs e) => listView1.Items.Clear();
        private void txtSerachOnUrl_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(webBrowser.Address.ToString());
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
                this.listView1.BackColor = Color.YellowGreen;
        }
    }
}