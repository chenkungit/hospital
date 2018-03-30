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
    public partial class FrmBaseDataManage : SCommon.SControl.SBaseForm
    {
        private SysBaseDataBiz SysBaseDataBiz = new SysBaseDataBiz();
        public SysBaseData DataEntity { get; set; }

        public FrmBaseDataManage()
        {
            InitializeComponent();
        }

        private void FrmSysBaseDataManage_Load(object sender, EventArgs e)
        {
            // 数据类型
            this.ucCbo_sort.DataSource = Constant.GetDataType(DicSort.DataType).ToList();
            this.ucCbo_sort.DisplayMember = "Value";
            this.ucCbo_sort.ValueMember = "Key";
            //this.ucCbo_pcode.DataSource = SysBaseDataBiz.FindByType("01");
            //this.ucCbo_pcode.DisplayMember = "name";
            //this.ucCbo_pcode.ValueMember = "code";
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                this.Fill2Win();
            }
            else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New)//新增
            {
                this.ucCbo_sort.SelectedIndex = 0;
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
                    this.DataEntity = new SysBaseData();
                    this.Fill2Entity();
                    rst = SysBaseDataBiz.Insert(this.DataEntity);
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = SysBaseDataBiz.Update(this.DataEntity);
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
            if (this.ucTxt_code.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入代码！");
                this.ucTxt_code.Focus();
                return false;
            }

            if (this.ucTxt_name.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入名称！");
                this.ucTxt_name.Focus();
                return false;
            }
            if (this.ucCbo_sort.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入字典类型！");
                this.ucCbo_sort.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.Id = this.ucTxt_code.Text;
            this.DataEntity.Name = this.ucTxt_name.Text;
            this.DataEntity.Sort = this.ucCbo_sort.SelectedValue==null?"": this.ucCbo_sort.SelectedValue.ToString();
            this.DataEntity.Pcode = this.ucCbo_pcode.SelectedValue==null?"": this.ucCbo_pcode.SelectedValue.ToString();
            this.DataEntity.Remark = this.ucTxt_remark.Text;
            this.DataEntity.Enabled = this.uChk_enabled.Checked;
            this.DataEntity.DisplayOrder = Convert.ToInt16(this.ucText_display_order.Text);
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            this.ucTxt_code.Text = this.DataEntity.Id;
            this.ucTxt_name.Text = this.DataEntity.Name;
            this.ucCbo_sort.SelectedValue = this.DataEntity.Sort;
            this.ucCbo_pcode.SelectedValue = this.DataEntity.Pcode;
            this.ucTxt_remark.Text = this.DataEntity.Remark;
            this.uChk_enabled.Checked = this.DataEntity.Enabled;
            this.ucText_display_order.Text = this.DataEntity.DisplayOrder.ToString();
         
        }
    }
}
