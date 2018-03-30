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
    public partial class FrmBaseData : SCommon.SControl.SBaseDockForm
    {
        private String[] displayProperties =
        {
            "Code", "Name", "Enabled", "DisplayOrder","Remark"
        };
        private SysBaseDataBiz SysBaseDataBiz = new SysBaseDataBiz();
        private readonly DataGridView dgrdView;

        public FrmBaseData()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
        }

        #region + 事件
        private void FrmSysBaseData_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmBaseDataManage frm = new FrmBaseDataManage();
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
            SysBaseData entity = this.GetCurrentRowData();
            if (entity != null)
            {
                FrmBaseDataManage frm = new FrmBaseDataManage();
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
            SysBaseData entity = this.GetCurrentRowData();
            if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
            {
                SysBaseDataBiz.Delete(entity.Id);
                this.ucDgv_list.Search(1);
            }
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<SysBaseData> page = SysBaseDataBiz.FindByPagination(pageNum, pageSize, this.ucTxt_code.Text);
            IList<SysBaseData> list = page != null ? page.Data : new List<SysBaseData>();
            SGridViewUtil.BindingData<SysBaseData>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        private SysBaseData GetCurrentRowData()
        {
            SysBaseData entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<SysBaseData>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                UcMessageBox.Warning("请先选择一行数据");
            }
            return entity;
        }
    }
}
