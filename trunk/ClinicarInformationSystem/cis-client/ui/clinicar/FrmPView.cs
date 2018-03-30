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
    public partial class FrmPView : Form
    {
        public Image image;
        public FrmPView()
        {
            InitializeComponent();
            Load += FrmPView_Load;

        }

        private void FrmPView_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = image;
        }
    }
}
