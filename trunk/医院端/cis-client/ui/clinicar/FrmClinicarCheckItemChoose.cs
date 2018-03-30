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
    public partial class FrmClinicarCheckItemChoose : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 要显示的列
        /// </summary>
        private String[] displayProperties =
        {
            "Name","DptName"
        };

        /// <summary>
        /// 要显示的列  登记界面的检查项目表
        /// </summary>
        private String[] displayPropertiesTranmit =
        {
            "ItemCode", "ItemName","dptName","completed"
        };

        /// <summary>
        /// 登记表主表Id，子表外键
        /// </summary>
        private int f_CheckId = 0;

        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();

        /// <summary>
        /// 项目管理表业务层
        /// </summary>
        private ClinicarItemBiz clinicarItemBiz = new ClinicarItemBiz();

        /// <summary>
        /// 表格
        /// </summary>
        private readonly DataGridView dgrdView;

        /// <summary>
        /// 登记界面的检查项目表
        /// </summary>
        public DataGridView dataGridViewTranmit;

        #endregion

        #region + 构造方法
        /// <summary>
        /// </summary>
        /// 登记表主表Id，子表外键
        /// <param name="Id"></param>
        public FrmClinicarCheckItemChoose(int Id)
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
            this.dgrdView.DoubleClick += DgrdView_DoubleClick;
            f_CheckId = Id;
        }
        #endregion

        #region + 事件
        private void FrmClinicarCheckItemChoose_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_Click(object sender, EventArgs e)
        {
            fillBack();
        }

        private void DgrdView_DoubleClick(object sender, EventArgs e)
        {
            fillBack();
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarItem> page = clinicarItemBiz.FindByPagination(pageNum, pageSize, "", this.ucTxt_name.Text,"",this.ucTxt_DtpName.Text,true);
            IList<ClinicarItem> list = page != null ? page.Data : new List<ClinicarItem>();
            SGridViewUtil.BindingData<ClinicarItem>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        #region + 回填方法
        /// <summary>
        /// 
        /// </summary>
        private void fillBack()
        {
            ClinicarItem entity = null;     //项目管理实体类
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0 && f_CheckId != 0)
            {
                entity = ((BindingList<ClinicarItem>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
                SResult rst = new SResult();
                ClinicarCheckItem clinicarCheckItem = new ClinicarCheckItem();
                clinicarCheckItem.ItemCode = entity.Id;
                clinicarCheckItem.ItemName = entity.Name;
                clinicarCheckItem.DptCode = entity.DptCode;
                clinicarCheckItem.DptName = entity.DptName;
                clinicarCheckItem.CheckId = f_CheckId;
                rst = clinicarCheckItemBiz.Insert(clinicarCheckItem);

                if (rst.success)
                {
                    UcMessageBox.Information("添加成功！", "提示");
                }
                else
                {
                    UcMessageBox.Error(rst.message, "提示");
                }
                //刷新登记界面中的检查项目表
                SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindByPagination(1, 999, f_CheckId);
                IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
                SGridViewUtil.BindingData<ClinicarCheckItem>(list, this.dataGridViewTranmit, displayPropertiesTranmit);
            }
            else
            {
                UcMessageBox.Warning("请先选择一行数据", "提示");
            }
        }
        #endregion
    }
}
