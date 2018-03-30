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
    public partial class FrmClinicarAllCheckCancel : SCommon.SControl.SBaseForm
    {
        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();
        /// <summary>
        /// 检查结果表业务层
        /// </summary>
        private ClinicarCheckResultBiz clinicarCheckResultBiz = new ClinicarCheckResultBiz();
        /// <summary>
        /// 总检表业务层
        /// </summary>
        private ClinicarAllCheckBiz clinicarAllCheckBiz = new ClinicarAllCheckBiz();
        /// <summary>
        /// 检查表业务层
        /// </summary>
        ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();
        /// <summary>
        /// 检查项目列表
        /// </summary>
        private DataGridView ucDgvlist;
        /// <summary>
        /// 检查项目需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "ItemCode", "ItemName","DptName"
        };
        /// <summary>
        /// 检查表编号
        /// </summary>
        public int check_id;
        public FrmClinicarAllCheckCancel()
        {
            InitializeComponent();
            this.ucDgvlist = ucDgv_list.UcDataGridViewControl;
        }

        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
            this.ucDgv_list.Search(1);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
            else if (sender == this.btn_save)
            {
                IList<ClinicarCheckItem> list = clinicarCheckItemBiz.FindUnCompletedItem(check_id);
                if (list != null && list.Count > 0)
                {
                    foreach (ClinicarCheckItem ccItem in list)
                    {
                        ccItem.Canceled = true;
                        clinicarCheckItemBiz.Update(ccItem);
                    }
                }
                MessageBox.Show("弃检成功！");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            SResult rst = new SResult();
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New) //新增
            {
            }
            else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
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



        private int FindResult(int pageNum, int pageSize)
        {
            SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindUnCompletedPagination(pageNum, pageSize, check_id);
            IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
            SGridViewUtil.BindingData<ClinicarCheckItem>(list, ucDgvlist, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }


    }
}
