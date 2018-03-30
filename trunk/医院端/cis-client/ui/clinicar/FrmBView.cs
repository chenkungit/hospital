using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cis_client.ui.clinicar
{
    public partial class FrmBView : Form
    {
        public string url;
        public GeckoWebBrowser browser;
        public FrmBView()
        {
            InitializeComponent();
            var app_dir = Path.GetDirectoryName(Application.ExecutablePath);
            Gecko.Xpcom.Initialize(Path.Combine(app_dir, "xulrunner"));

            browser = new GeckoWebBrowser();
            browser.Dock = DockStyle.Fill;
            browser.Parent = this;
            this.Controls.Add(browser);
            Load += FrmBView_Load;

        }

        private void FrmBView_Load(object sender, EventArgs e)
        {
            browser.Navigate(url);
            browser.Show();
        }
    }
}
