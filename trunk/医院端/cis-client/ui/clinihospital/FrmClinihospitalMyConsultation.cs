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
    public partial class FrmClinihospitalMyConsultation : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "HospitalName", "DeptName","ConsultationDate","Name","CheckNumber","Sex","Age","Tel","Medicalhistory","ApplyHospitalDate"
        };

        /// <summary>
        /// 业务层
        /// </summary>
        private ClinicarConsultationBiz clinicarConsultationBiz = new ClinicarConsultationBiz();

        /// <summary>
        /// 列表
        /// </summary>
        private readonly DataGridView dgrdView;

        #endregion

        #region + 构造方法
        public FrmClinihospitalMyConsultation()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
        }

        #endregion

        #region + 事件
        private void FrmClinihospitalMyConsultation_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            ClinicarConsultation entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity)) return;
            FrmClinihospitalMyConsultationManage myConsultationMangage = new FrmClinihospitalMyConsultationManage();
            myConsultationMangage.DataEntity = entity;
            myConsultationMangage.DialogStatus = DialogStatus.Modify;
            myConsultationMangage.ShowDialog();
            if (myConsultationMangage.DialogResult == DialogResult.OK)
            {
                this.ucDgv_list.Search(1);
            }
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarConsultation> page = clinicarConsultationBiz.FindByPagination(pageNum, pageSize, uDat_Start.Value.ToString("yyyy-MM-dd"), uDat_End.Value.ToString("yyyy-MM-dd"));
            IList<ClinicarConsultation> list = page != null ? page.Data : new List<ClinicarConsultation>();
            SGridViewUtil.BindingData<ClinicarConsultation>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        private ClinicarConsultation GetCurrentRowData()
        {
            ClinicarConsultation entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarConsultation>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                UcMessageBox.Warning("请先选择一行数据", "提示");
            }
            return entity;
        }

        /// <summary>
        /// 会诊详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deltail_Click(object sender, EventArgs e)
        {
            FrmClinicarConsultationManage consultant = new FrmClinicarConsultationManage();
            ClinicarConsultation entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity)) return;
            consultant.DialogStatus = DialogStatus.Modify;
            consultant.hospitalConsultation = true;
            consultant.DataEntity = entity;
            consultant.ShowDialog();
        }
    }
}
