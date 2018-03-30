using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCommon.SControl
{
    public partial class SBaseForm : Form
    {
        public UBaseLib.Enums.DialogStatus DialogStatus { get; set; }

        public SBaseForm()
        {
            InitializeComponent();
        }
    }
}
