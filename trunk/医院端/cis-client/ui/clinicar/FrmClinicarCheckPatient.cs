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
    public partial class FrmClinicarCheckPatient : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "CheckNumber", "Name", "GenderName", "Birthday","CertificateNumber","Tel"
        };

        /// <summary>
        /// 业务层
        /// </summary>
        private ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();

        /// <summary>
        /// 列表
        /// </summary>
        private readonly DataGridView dgrdView;

        /// <summary>
        /// ClinicarCheck 实体类，用于双击传值
        /// </summary>
        private ClinicarCheck f_DataEntityTransmit;
        [Category("User-Defined"), Description("获取 ClinicarCheck 实体类")]
        public ClinicarCheck F_DataEntityTransmit
        {
            get { return f_DataEntityTransmit; }
        }

        #endregion

        #region + 构造方法
        public FrmClinicarCheckPatient()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
            this.dgrdView.DoubleClick += DgrdView_DoubleClick;
        }

        #endregion

        #region + 事件
        private void FrmClinicarCheckPatient_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarCheck> page = clinicarCheckBiz.FindByPagination(pageNum, pageSize, this.ucTxt_checkNumber.Text, this.ucTxt_name.Text, this.ucTxt_cre.Text);
            IList<ClinicarCheck> list = page != null ? page.Data : new List<ClinicarCheck>();
            SGridViewUtil.BindingData<ClinicarCheck>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        private ClinicarCheck GetCurrentRowData()
        {
            ClinicarCheck entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheck>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
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
            ClinicarCheck entity = this.GetCurrentRowData();
            f_DataEntityTransmit = new ClinicarCheck();
            if (entity != null)
            {
                f_DataEntityTransmit = entity;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
