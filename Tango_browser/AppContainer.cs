using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Tango_Browser
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }
        public override TitleBarTab CreateTab()
        {
            ///throw new NotImplementedException();
            return new TitleBarTab(this)
            {
                Content = new Form1
                {
                    Text = "Tango Browser"
                }
            };
        }
        private void AppContainer_Load(object sender, EventArgs e)
        {

        }
    }
}
