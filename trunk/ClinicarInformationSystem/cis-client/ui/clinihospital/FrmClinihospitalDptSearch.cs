using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_model.clinicar;
using cis_model.sys;
using SCommon.SQL;
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
    public partial class FrmClinihospitalDptSearch : SCommon.SControl.SBaseDockForm
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
        /// 增、删、改操作权限
        /// </summary>
        public bool operationPower = true;
        /// <summary>
        /// 医院代码（用户选择科室医院过滤）
        /// </summary>
        public string hospitalcod;        

        #endregion

        #region + 构造方法
        public FrmClinihospitalDptSearch()
        {
            InitializeComponent();
            this.dataGridView1.DoubleClick += DgrdView_DoubleClick;
        }

        #endregion

        #region + 事件
        private void FrmClinicarDpt_Load(object sender, EventArgs e)
        {
            //不允许手动添加行
            this.dataGridView1.AllowUserToAddRows = false;
            //不自动生成列
            this.dataGridView1.AutoGenerateColumns = false;

            //从服务器外网查询医院信息
            DataTable _dtOutSide = MySQLHelper.ExecuteDataTable(SqlUtil.F_OutsideConnectionString, CommandType.Text, "select code,name, hospitalcode, hospitalname,  enabled, remark from t_clinihospital_dpt");
            if (_dtOutSide != null && Convert.IsDBNull(_dtOutSide) == false && _dtOutSide.Rows.Count > 0)
            {
                this.dataGridView1.DataSource = _dtOutSide;
            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
        }

        #endregion

        private ClinicarDpt GetCurrentRowData()
        {
            ClinicarDpt entity = null;
            if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarDpt>)this.dataGridView1.DataSource)[this.dataGridView1.CurrentRow.Index];
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
            if (this.dataGridView1.RowCount <= 0) return;
            if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Index >= 0)
            {
                DialogResult = DialogResult.OK;
                f_StringCode = this.dataGridView1.CurrentRow.Cells["code"].Value == null ? "" : this.dataGridView1.CurrentRow.Cells["code"].Value.ToString();
                f_StringName = this.dataGridView1.CurrentRow.Cells["name"].Value == null ? "" : this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
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
