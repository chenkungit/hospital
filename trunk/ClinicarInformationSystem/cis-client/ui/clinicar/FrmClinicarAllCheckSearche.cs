using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_business.util;
using cis_model.clinicar;
using cis_model.sys;
using SCommon.SUtil;
using System;
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
    public partial class FrmClinicarAllCheckSearch: SCommon.SControl.SBaseForm
    {
        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();
        /// <summary>
        /// 检查结果表业务层
        /// </summary>
        private ClinicarCheckResultBiz clinicarCheckResultBiz = new ClinicarCheckResultBiz();
        /// <summary>
        /// 检查表业务层
        /// </summary>
        ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();
        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "CheckNumber", "Name","GenderName","Age","CertificateNumber",
        };
        public ClinicarAllCheck DataEntity { get; set; }
        public string checkNumber;

        public FrmClinicarAllCheckSearch()
        {
            InitializeComponent();
        }

        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
            uChk_fjwc.Checked = true;
            uChk_fjwwc.Checked = true;
            uChk_zjwc.Checked = true;

        }
    }
}
