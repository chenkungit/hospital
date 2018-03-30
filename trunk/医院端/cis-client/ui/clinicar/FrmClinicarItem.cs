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
    public partial class FrmClinicarItem : SCommon.SControl.SBaseDockForm
    {
        #region + 属性
        /// <summary>
        /// 项目表显示列
        /// </summary>
        private String[] displayProperties =
        {
            "Id", "Name","DptCode","DptName", "Remark", "Enabled"
        };

        /// <summary>
        /// 项目子表显示列
        /// </summary>
        private String[] displayPropertiesDetail =
        {
            "Id", "Name","Unit"
        };

        /// <summary>
        /// 项目表业务层
        /// </summary>
        private ClinicarItemBiz clinicarItemBiz = new ClinicarItemBiz();

        /// <summary>
        /// 项目表子表业务层
        /// </summary>
        private ClinicarItemtDetailBiz clinicarItemDetailBiz = new ClinicarItemtDetailBiz();

        /// <summary>
        /// 项目表
        /// </summary>
        private readonly DataGridView dgrdView;

        /// <summary>
        /// 项目子表
        /// </summary>
        private readonly DataGridView dgrdViewDetail;

        /// <summary>
        /// 判断光标在主表还是子表上（1主表，2子表）
        /// </summary>
        private int f_intIdext = 1;

        #endregion

        #region + 构造方法
        public FrmClinicarItem()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
            this.dgrdView.Click += DgrdView_Click;
            this.dgrdView.SelectionChanged += DgrdView_SelectionChanged;
            this.dgrdViewDetail = this.ucdgv_itemDetail.UcDataGridViewControl;
            this.dgrdViewDetail.Click += DgrdViewDetail_Click;
        }

        #endregion

        #region + 事件
        private void FrmClinicarItem_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (f_intIdext == 1)
            {
                FrmClinicarItemManage frm = new FrmClinicarItemManage();
                frm.Text = "新增";
                frm.DialogStatus = DialogStatus.New;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ucDgv_list.Search(1);
                }
                frm.Dispose();
            }
            else if (f_intIdext == 2)
            {
                ClinicarItem entity = this.GetCurrentRowData();
                if (entity == null) return;
                FrmClinicarItemDetailManage frm = new FrmClinicarItemDetailManage();
                frm.Text = "新增";
                frm.DialogStatus = DialogStatus.New;
                frm.DataEntityItem = entity;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    detailGridSearch(entity);
                }
                frm.Dispose();
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (f_intIdext == 1)
            {
                ClinicarItem entity = this.GetCurrentRowData();
                if (entity != null)
                {
                    FrmClinicarItemManage frm = new FrmClinicarItemManage();
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
            else if (f_intIdext == 2)
            {
                ClinicarItem entity = this.GetCurrentRowData();
                ClinicarItemDetail entityDetail = this.GetDetailCurrentRowData();
                
                if (entity != null && entityDetail != null)
                {
                    FrmClinicarItemDetailManage frm = new FrmClinicarItemDetailManage();
                    frm.Text = "修改";
                    frm.DialogStatus = DialogStatus.Modify;
                    frm.DataEntityItem = entity;
                    frm.DataEntityDetail = entityDetail;

                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        detailGridSearch(entity);
                    }
                    frm.Dispose();
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (f_intIdext == 1)
            {
                ClinicarItem entity = this.GetCurrentRowData();
                if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
                {
                    clinicarItemBiz.Delete(entity.Id);
                    //循环删除子表
                    if (dgrdViewDetail!=null && Convert.IsDBNull(dgrdViewDetail)==false && dgrdViewDetail.RowCount > 0)
                    {
                        for (int i=0;i < this.dgrdViewDetail.RowCount;i++)
                        {
                            clinicarItemDetailBiz.Delete(this.dgrdViewDetail.Rows[i].Cells[0].Value.ToString());
                        }
                    }
                    this.ucDgv_list.Search(1);
                }
            }
            else if (f_intIdext == 2)
            {
                ClinicarItem entityItem = this.GetCurrentRowData();
                ClinicarItemDetail entity = this.GetDetailCurrentRowData();
                if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
                {
                    clinicarItemDetailBiz.Delete(entity.Id);
                    detailGridSearch(entityItem);
                }
            }
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarItem> page = clinicarItemBiz.FindByPagination(1, 9999, this.ucTxt_code.Text, this.ucTxt_name.Text,this.ucTxt_DtpCode.Text,this.ucTxt_DtpName.Text,false);
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

        #region + 判断项目表行数据
        /// <summary>
        /// 主表
        /// </summary>
        /// <returns></returns>
        private ClinicarItem GetCurrentRowData()
        {
            ClinicarItem entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarItem>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                //UcMessageBox.Warning("请先选择一行数据", "提示");
            }
            return entity;
        }
        /// <summary>
        /// 子表
        /// </summary>
        /// <returns></returns>
        private ClinicarItemDetail GetDetailCurrentRowData()
        {
            ClinicarItemDetail entity = null;
            if (this.dgrdViewDetail.CurrentRow != null && this.dgrdViewDetail.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarItemDetail>)this.dgrdViewDetail.DataSource)[this.dgrdViewDetail.CurrentRow.Index];
            }
            else
            {
                //UcMessageBox.Warning("请先选择一行数据", "提示");
            }
            return entity;
        }
        #endregion

        #region + 项目表和明细表点击事件

        private void DgrdView_Click(object sender, EventArgs e)
        {
            f_intIdext = 1;
        }

        /// <summary>
        /// 主表行改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrdView_SelectionChanged(object sender, EventArgs e)
        {
            ClinicarItem entity = this.GetCurrentRowData();
            if (entity == null)
            {
                this.dgrdViewDetail.DataSource = null;
                return;
            }
            detailGridSearch(entity);
        }

        private void DgrdViewDetail_Click(object sender, EventArgs e)
        {
            f_intIdext = 2;
        }

        #endregion

        #region + 刷新子表
        /// <summary>
        /// 刷新子表
        /// </summary>
        private void detailGridSearch(ClinicarItem entity)
        {
            if (entity == null) return;
            SPagintion<ClinicarItemDetail> page = clinicarItemDetailBiz.FindByPagination(1, 9999, entity.Id);
            IList<ClinicarItemDetail> list = page != null ? page.Data : new List<ClinicarItemDetail>();
            SGridViewUtil.BindingData<ClinicarItemDetail>(list, this.ucdgv_itemDetail.UcDataGridViewControl, displayPropertiesDetail);
        }
        #endregion
    }
}
