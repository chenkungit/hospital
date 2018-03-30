using cis_business.biz.clinicar;
using cis_business.biz.sys;
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
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarDpt : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 科室编号
        /// </summary>
        private String f_StringCode;
        [Category("User-Defined"), Description("获取 科室编号")]
        public String F_StringCode
        {
            get { return f_StringCode; }
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        private String f_StringName;
        [Category("User-Defined"), Description("获取 科室名称")]
        public String F_StringName
        {
            get { return f_StringName; }
        }

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "Id","HospitalCode","HospitalName", "Name", "Enabled", "Remark"
        };

        /// <summary>
        /// 业务层
        /// </summary>
        private ClinicarDptBiz clinicarDptBiz = new ClinicarDptBiz();

        /// <summary>
        /// 列表
        /// </summary>
        private readonly DataGridView dgrdView;

        /// <summary>
        /// 增、删、改操作权限
        /// </summary>
        public bool operationPower = true;
        /// <summary>
        /// 医院代码（用户选择科室医院过滤）
        /// </summary>
        public string hospitalcod;        

        #endregion

        #region + 构造方法
        public FrmClinicarDpt()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
            this.dgrdView.DoubleClick += DgrdView_DoubleClick;
        }

        #endregion

        #region + 事件
        private void FrmClinicarDpt_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
            if (!operationPower)
            {
                btn_new.Visible = false;
                btn_mod.Visible = false;
                btn_del.Visible = false;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmClinicarDptManage frm = new FrmClinicarDptManage();
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
            ClinicarDpt entity = this.GetCurrentRowData();
            if (entity != null)
            {
                FrmClinicarDptManage frm = new FrmClinicarDptManage();
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
            ClinicarDpt entity = this.GetCurrentRowData();
            if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
            {
                clinicarDptBiz.Delete(entity.Id);
                this.ucDgv_list.Search(1);
            }
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarDpt> page = clinicarDptBiz.FindByPagination(pageNum, pageSize, this.ucTxt_code.Text, this.ucTxt_name.Text,hospitalcod);
            IList<ClinicarDpt> list = page != null ? page.Data : new List<ClinicarDpt>();
            SGridViewUtil.BindingData<ClinicarDpt>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        private ClinicarDpt GetCurrentRowData()
        {
            ClinicarDpt entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarDpt>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                UcMessageBox.Warning("请先选择一行数据", "提示");
            }
            return entity;
        }

        /// <summary>
        /// 表格双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrdView_DoubleClick(object sender, EventArgs e)
        {
            if (operationPower) return;

            ClinicarDpt entity = this.GetCurrentRowData();
            if (entity != null)
            {
                DialogResult = DialogResult.OK;
                f_StringCode = entity.Id;
                f_StringName = entity.Name;
                Close();
            }
        }
        /// <summary>
        /// 科室排班
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_scheduling_Click(object sender, EventArgs e)
        //{
        //    if (!operationPower) return;
        //    ClinicarDpt entity = this.GetCurrentRowData();
        //    if (entity != null)
        //    {
        //        DialogResult = DialogResult.OK;
        //        FrmClinicarDptSechedulManage cdsm = new FrmClinicarDptSechedulManage();
        //        cdsm.f_stringCode = entity.Id;
        //        cdsm.f_stringName = entity.Name;
        //        cdsm.ShowDialog();
        //    }
        //}
    }
}
