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
    public partial class FrmClinicarAllCheckAdviceManage : SCommon.SControl.SBaseForm
    {
        private ClinicarAllCheckBiz clinicarAllCheckBiz = new ClinicarAllCheckBiz();
        public ClinicarAllCheck DataEntity { get; set; }
        public string checkNumber;
        public string strAdvice;
        public string strDisease;
        public FrmClinicarAllCheckAdviceManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.Fill2Win();
            }else
            {
                ucRic_remark.Text = strAdvice;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
            else if (sender == this.btn_save)
            {
                if (this.Save())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            SResult rst = new SResult();
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New) //新增
            {
                this.DataEntity = new ClinicarAllCheck();
                this.Fill2Entity();
                rst = clinicarAllCheckBiz.Insert(this.DataEntity);
            }
            else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.Fill2Entity();
                rst = clinicarAllCheckBiz.Update(this.DataEntity);
            }
            if (rst.success)
            {
                UcMessageBox.Information(rst.message, "提示");
            }
            else
            {
                UcMessageBox.Error(rst.message, "提示");
            }
            return rst.success;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.Advice = this.ucRic_remark.Text;
            this.DataEntity.CheckNumber = this.checkNumber;
            this.DataEntity.Disease = this.strDisease;
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            this.ucRic_remark.Text = this.DataEntity.Advice;
        }
    }
}
