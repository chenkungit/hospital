using cis_business.biz.sys;
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
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.sys
{
    public partial class FrmSysUser : SCommon.SControl.SBaseDockForm
    {
        private String[] displayProperties =
        {
            "Username", "FullName", "Tel", "Remark"
        };
        private SysUserBiz sysUserBiz = new SysUserBiz();
        private readonly DataGridView dgrdView;

        public FrmSysUser()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
        }

        #region + 事件
        private void FrmSysUser_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmSysUserManage frm = new FrmSysUserManage();
            frm.Text = "新增";
            frm.DialogStatus = DialogStatus.New;

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ucDgv_list.Search(1);
            }
            frm.Dispose();
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            SysUser entity = this.GetCurrentRowData();
            if (entity != null)
            {
                FrmSysUserManage frm = new FrmSysUserManage();
                frm.Text = "修改";
                frm.DialogStatus = DialogStatus.Modify;
                frm.DataEntity = entity;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ucDgv_list.Search(1);
                }
                frm.Dispose();
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            SysUser entity = this.GetCurrentRowData();
            if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
            {
                sysUserBiz.Delete(entity.Id);
                this.ucDgv_list.Search(1);
            }
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<SysUser> page = sysUserBiz.FindByPagination(pageNum, pageSize, this.ucTxt_username.Text, this.ucTxt_fullName.Text);
            IList<SysUser> list = page != null ? page.Data : new List<SysUser>();
            SGridViewUtil.BindingData<SysUser>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        private SysUser GetCurrentRowData()
        {
            SysUser entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<SysUser>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                UcMessageBox.Warning("请先选择一行数据");
            }
            return entity;
        }
    }
}
