using cis_business.biz.sys;
using cis_business.util;
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

namespace cis_client.ui.sys
{
    public partial class FrmSysUserManage : SCommon.SControl.SBaseForm
    {
        private SysUserBiz sysUserBiz = new SysUserBiz();
        public SysUser DataEntity { get; set; }

        public FrmSysUserManage()
        {
            InitializeComponent();
        }

        private void FrmSysUserManage_Load(object sender, EventArgs e)
        {
            // 用户类型
            this.ucCbo_userType.DataSource = Constant.GetDicData(DicSort.UserType).ToList();
            this.ucCbo_userType.DisplayMember = "Value";
            this.ucCbo_userType.ValueMember = "Key";
            this.ucCbo_userType.SelectedIndex = 0;

            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.Fill2Win();
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
                    this.DataEntity = new SysUser();
                    this.Fill2Entity();
                    rst = sysUserBiz.Insert(this.DataEntity);
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = sysUserBiz.Update(this.DataEntity);
                }
                if (rst.success)
                {
                    UcMessageBox.Information(rst.message);
                }
                else
                {
                    UcMessageBox.Error(rst.message);
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
            if (this.ucTxt_username.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入用户名！");
                this.ucTxt_username.Focus();
                return false;
            }

            if (this.ucTxt_password.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入密码！");
                this.ucTxt_password.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.Username = this.ucTxt_username.Text;
            this.DataEntity.Password = this.ucTxt_password.Text;
            this.DataEntity.UserType = this.ucCbo_userType.SelectedValue.ToString();
            this.DataEntity.Tel = this.ucTxt_tel.Text;
            this.DataEntity.Remark = this.ucTxt_remark.Text;
            this.DataEntity.FullName = this.ucTxt_full_name.Text;
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            this.ucTxt_username.Text = this.DataEntity.Username;
            this.ucTxt_password.Text = this.DataEntity.Password;
            this.ucCbo_userType.SelectedValue = this.DataEntity.UserType;
            this.ucTxt_full_name.Text = this.DataEntity.FullName;
            this.ucTxt_tel.Text = this.DataEntity.Tel;
            this.ucTxt_remark.Text = this.DataEntity.Remark;
        }
    }
}
