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
    public partial class FrmClinicarItemManage : SCommon.SControl.SBaseForm
    {
        private ClinicarItemBiz clinicarItemBiz = new ClinicarItemBiz();
        public ClinicarItem DataEntity { get; set; }

        public FrmClinicarItemManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarItemManage_Load(object sender, EventArgs e)
        {
            //初始化控件
            //设备编号
            uCbo_DeviceCode.DataSource = Constant.GetDeviceCodeData(DicSort.DeviceCode).ToList();
            uCbo_DeviceCode.DisplayMember = "Value";
            uCbo_DeviceCode.ValueMember = "Key";
            uCbo_DeviceCode.SelectedIndex = -1;

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

                    this.DataEntity = new ClinicarItem();
                    this.Fill2Entity();
                    rst = clinicarItemBiz.Insert(this.DataEntity);
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = clinicarItemBiz.Update(this.DataEntity);
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
            //if (this.uTxt_code.Text.Trim().Length == 0)
            //{
            //    UcMessageBox.Warning("请输入项目代码！", "提示");
            //    this.uTxt_code.Focus();
            //    return false;
            //}

            if (this.uTxt_name.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入项目名称！", "提示");
                this.uTxt_name.Focus();
                return false;
            }

            if (this.uTxt_DtpCode.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入科室编号！", "提示");
                this.uTxt_DtpCode.Focus();
                return false;
            }

            //if (uchk_enabled.Checked && uCbo_DeviceCode.SelectedValue!=null && !uCbo_DeviceCode.SelectedValue.ToString().Equals(""))
            //{

            //    if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New) //新增
            //    {
            //        bool isExist = clinicarItemBiz.CheckIsExistForDeviceCode(uCbo_DeviceCode.SelectedValue.ToString(), "");
            //        if (isExist)
            //        {
            //            UcMessageBox.Warning("该设备已被使用！", "设备编号重复");
            //            this.uCbo_DeviceCode.Focus();
            //            return false;
            //        }
            //    }
            //    else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            //    {
            //        bool isExist = clinicarItemBiz.CheckIsExistForDeviceCode(uCbo_DeviceCode.SelectedValue.ToString(), uTxt_code.Text.Trim());
            //        if (isExist)
            //        {
            //            UcMessageBox.Warning("该设备已被使用！", "设备编号重复");
            //            this.uCbo_DeviceCode.Focus();
            //            return false;
            //        }
            //    }
            //}

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
            this.DataEntity.DptCode = this.uTxt_DtpCode.Text;
            this.DataEntity.DptName = this.uTxt_DtpName.Text;
            this.DataEntity.DeviceCode = (this.uCbo_DeviceCode.SelectedValue) == null ? "" : (this.uCbo_DeviceCode.SelectedValue.ToString());
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
            this.uTxt_DtpCode.Text = this.DataEntity.DptCode;
            this.uTxt_DtpName.Text = this.DataEntity.DptName;
            this.uCbo_DeviceCode.SelectedValue = this.DataEntity.DeviceCode;
        }

        /// <summary>
        /// 科室编号双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTxt_DtpCode_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarDpt frmClinicarDpt = new FrmClinicarDpt();
            frmClinicarDpt.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarDpt.operationPower = false;
            frmClinicarDpt.ShowDialog();
            if (frmClinicarDpt.DialogResult == DialogResult.OK)
            {
                uTxt_DtpCode.Text = frmClinicarDpt.F_StringCode;
                uTxt_DtpName.Text = frmClinicarDpt.F_StringName;
            }
        }
    }
}
