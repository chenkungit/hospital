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
    public partial class FrmClinicarDptManage : SCommon.SControl.SBaseForm
    {
        private ClinicarDptBiz clinicarDptBiz = new ClinicarDptBiz();
        public ClinicarDpt DataEntity { get; set; }

        public FrmClinicarDptManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.uTxt_code.Enabled = false;
                this.Fill2Win();
            }
            else
            {
                uchk_enabled.Checked = true;
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
            if (this.CheckBeforeSave())//保存前的校验
            {
                SResult rst = new SResult();
                if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New) //新增
                {
                    this.DataEntity = new ClinicarDpt();
                    this.Fill2Entity();
                    rst = clinicarDptBiz.Insert(this.DataEntity);
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = clinicarDptBiz.Update(this.DataEntity);
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
            return false;
        }

        /// <summary>
        /// 保存前的校验方法
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            if (this.uTxt_code.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入科室编号！","提示");
                this.uTxt_code.Focus();
                return false;
            }

            if (this.uTxt_name.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入科室名称！", "提示");
                this.uTxt_name.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.Id = this.uTxt_code.Text;
            this.DataEntity.Name = this.uTxt_name.Text;
            this.DataEntity.Enabled = this.uchk_enabled.Checked;
            this.DataEntity.Remark = this.ucRic_remark.Text;
            this.DataEntity.Hospitalcode = this.uTxt_hospitalcode.Text;
            this.DataEntity.Hospitalname = this.uTxt_hospitalname.Text;
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            this.uTxt_code.Text = this.DataEntity.Id;
            this.uTxt_name.Text = this.DataEntity.Name;
            this.uchk_enabled.Checked = this.DataEntity.Enabled;
            this.ucRic_remark.Text = this.DataEntity.Remark;
            this.uTxt_hospitalcode.Text = this.DataEntity.Hospitalcode;
            this.uTxt_hospitalname.Text = this.DataEntity.Hospitalname;
        }

        private void uTxt_hospitalcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void uTxt_hospitalcode_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarHospital frmClinicarHospital = new FrmClinicarHospital();
            frmClinicarHospital.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarHospital.operationPower = false;
            frmClinicarHospital.ShowDialog();
            if (frmClinicarHospital.DialogResult == DialogResult.OK)
            {
                uTxt_hospitalcode.Text = frmClinicarHospital.F_StringCode;
                uTxt_hospitalname.Text = frmClinicarHospital.F_StringName;
            }
        }
    }
}
