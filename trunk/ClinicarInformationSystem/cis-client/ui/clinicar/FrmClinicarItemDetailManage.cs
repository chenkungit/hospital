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
    public partial class FrmClinicarItemDetailManage : SCommon.SControl.SBaseForm
    {
        /// <summary>
        /// 子表业务层
        /// </summary>
        private ClinicarItemtDetailBiz clinicarDetailBiz = new ClinicarItemtDetailBiz();

        /// <summary>
        ///  主表实体类
        /// </summary>
        public ClinicarItem DataEntityItem { get; set; }

        /// <summary>
        /// 明细表实体类
        /// </summary>
        public ClinicarItemDetail DataEntityDetail { get; set; }

        public FrmClinicarItemDetailManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarItemDetailManage_Load(object sender, EventArgs e)
        {
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.uTxt_code.Enabled = false;
                this.Fill2Win();
            }
            else
            {
                uTxt_itemCode.Text = DataEntityItem.Id;
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

                    this.DataEntityDetail = new ClinicarItemDetail();
                    this.Fill2Entity();
                    rst = clinicarDetailBiz.Insert(this.DataEntityDetail);
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = clinicarDetailBiz.Update(this.DataEntityDetail);
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
                UcMessageBox.Warning("请输入项目代码！", "提示");
                this.uTxt_code.Focus();
                return false;
            }

            if (this.uTxt_name.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入项目名称！", "提示");
                this.uTxt_name.Focus();
                return false;
            }

            if (this.uTxt_unit.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入单位！", "提示");
                this.uTxt_unit.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntityDetail.Id = this.uTxt_code.Text;
            this.DataEntityDetail.DetailName = this.uTxt_name.Text;
            this.DataEntityDetail.Unit = this.uTxt_unit.Text;
            this.DataEntityDetail.ItemCode = this.uTxt_itemCode.Text;
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            this.uTxt_code.Text = this.DataEntityDetail.Id;
            this.uTxt_name.Text = this.DataEntityDetail.DetailName;
            this.uTxt_unit.Text = this.DataEntityDetail.Unit;
            this.uTxt_itemCode.Text = this.DataEntityDetail.ItemCode;
        }
    }
}
