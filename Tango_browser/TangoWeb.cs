using Sysyem;
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

namespace Tango_Browser
{
    public partial class TangoWebBrowser : Form
    {
       
        public TangoWebBrowser()
        {
            InitializeComponent();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtSerachOrUrl.Text = webBrowser1.Document.Url.AbsoluteUri;
            listView1.Items.Add(txtSerachOrUrl.Text);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack) webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward) webBrowser1.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/");
        }
        private void txtSerachonUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtSerachOrUrl.Text.Contains(".") && !txtSerachOrUrl.Text.Contains(" ") && txtSerachOrUrl.Text.Length > 0)
            {
                webBrowser1.Navigate("https://"+txtSerachOrUrl.Text);

            }
            else if (e.KeyChar == (char)13)
            {
                webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOrUrl.Text.Replace(" ", "+"));
            }
        }
        private void txtSerachOrUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtSerachOrUrl.Text.Contains(".") && !txtSerachOrUrl.Text.Contains(" ") && txtSerachOrUrl.Text.Length > 0)
            {
                    //ites a url
                    webBrowser1.Navigate("https://"+txtSerachOrUrl.Text);
             }
            else if (e.KeyData==Keys.Enter)
            {
                //its a search
                webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOrUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
            }
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/search?q=" + txtSerachOrUrl.Text.Replace(" ", "+") + "&sourceid=chrome&ie=UTF-8&oe=UTF-8");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        } 
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }
        ChromiumWebBrowser webBrowser;
        private void TangoWebBrowser_Load(object sender, EventArgs e)
        {
          webBrowser = new ChromiumWebBrowser(txtSerachOrUrl.Text);
          webBrowser.Dock = DockStyle.Fill;
          this.webBrowser1.Controls.Add(webBrowser);
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
        private void button4_Click(object sender, EventArgs e) => listView1.Items.Clear();
    }
}