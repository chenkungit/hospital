using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_business.util;
using cis_model.clinicar;
using cis_model.sys;
using SCommon.SUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarCheckTotal : SCommon.SControl.SBaseDockForm
    {
        private ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();
        public ClinicarCheck DataEntity { get; set; }

        public FrmClinicarCheckTotal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void FrmClinicarCheckTotal_Load(object sender, EventArgs e)
        {
            uDtp_from.Value = DateTime.Now.AddDays(-7);
            uDtp_to.Value = DateTime.Now;
            Query();
        }

        private void Query()
        {
            //就诊人数
            IList list = clinicarCheckBiz.FindCheckTotol(uDtp_from.Value, uDtp_to.Value);
            if (list.Count > 0)
                lbl_jzrs.Text = list[0].ToString();
            else
                lbl_jzrs.Text = "0";
            //就诊男性人数
            IList Malelist = clinicarCheckBiz.FindCheckMaleTotol(uDtp_from.Value, uDtp_to.Value);
            if (Malelist.Count > 0)
                lbl_nan.Text = Malelist[0].ToString();
            else
                lbl_nan.Text = "0";
            //就诊女性人数
            IList FeMalelist = clinicarCheckBiz.FindCheckFeMaleTotol(uDtp_from.Value, uDtp_to.Value);
            if (FeMalelist.Count > 0)
                lbl_nv.Text = FeMalelist[0].ToString();
            else
                lbl_nv.Text = "0";
            //20岁以下
            IList list20 = clinicarCheckBiz.FindCheck20Total(uDtp_from.Value, uDtp_to.Value);
            if (list20.Count > 0)
                lbl_20.Text = list20[0].ToString();
            else
                lbl_20.Text = "0";
            //21-30岁以下
            IList list2030 = clinicarCheckBiz.FindCheck2030Total(uDtp_from.Value, uDtp_to.Value);
            if (list2030.Count > 0)
                this.lbl_2130.Text = list2030[0].ToString();
            else
                lbl_2130.Text = "0";
            //31-40岁以下
            IList list3140 = clinicarCheckBiz.FindCheck3140Total(uDtp_from.Value, uDtp_to.Value);
            if (list3140.Count > 0)
                this.lbl_3140.Text = list3140[0].ToString();
            else
                lbl_3140.Text = "0";
            //41-50岁以下
            IList list4150 = clinicarCheckBiz.FindCheck4150Total(uDtp_from.Value, uDtp_to.Value);
            if (list4150.Count > 0)
                this.lbl_4150.Text = list4150[0].ToString();
            else
                lbl_4150.Text = "0";
            //50以shang
            IList list50 = clinicarCheckBiz.FindCheck4150Total(uDtp_from.Value, uDtp_to.Value);
            if (list50.Count > 0)
                this.lbl_50.Text = list50[0].ToString();
            else
                lbl_50.Text = "0";
        }
    }
}
