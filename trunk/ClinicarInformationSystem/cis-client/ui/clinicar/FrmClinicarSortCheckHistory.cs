using AxAcroPDFLib;
using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_business.util;
using cis_model.clinicar;
using cis_model.sys;
using cis_util;
using SCommon.SUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarSortCheckHistory : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayPropertiesLeft =
        {
            "Name", "CheckDate","CheckNumber"
        };

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayPropertiesCenter =
        {
            "DptName"
        };

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayPropertiesRight =
        {
            "DetailName","Result","Unit","Conclusion"
        };

        /// <summary>
        /// 登记表
        /// </summary>
        private readonly DataGridView dgrdViewLeft;

        /// <summary>
        /// 检查科室列表
        /// </summary>
        private readonly DataGridView dgrdViewCenter;

        /// <summary>
        /// 检查科室列表
        /// </summary>
        private readonly DataGridView dgrdViewRight;

        /// <summary>
        /// 检查结果表业务层
        /// </summary>
        private ClinicarCheckResultBiz clinicarCheckResultBiz = new ClinicarCheckResultBiz();

        /// <summary>
        /// 检查结果实体类
        /// </summary>
        public ClinicarCheckResult DataEntityClinicarCheckResult { get; set; }

        /// <summary>
        /// 登记表业务层
        /// </summary>
        public ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();

        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();

        /// <summary>
        /// 登记表实体类（来自分检界面）
        /// </summary>
        public ClinicarCheck entityCheckTransmit { get; set; }

        /// <summary>
        /// 检查项目实体类（数据来自分检界面）
        /// </summary>
        public ClinicarCheckItem entityTransmit { get; set; }

        /// <summary>
        /// 缓存结果表（来自分检界面，用于回填历史数据）
        /// </summary>
        public DataGridView F_dgViewTransmit;

        /// <summary>
        /// 科室名称
        /// </summary>
        private String f_strAttachmentPath;
        [Category("User-Defined"), Description("获取 科室名称")]
        public String F_strAttachmentPath
        {
            get { return f_strAttachmentPath; }
        }

        /// <summary>
        /// 类型（图片或者pdf）
        /// </summary>
        public string type = string.Empty;

        #endregion

        #region + 构造方法
        public FrmClinicarSortCheckHistory()
        {
            InitializeComponent();
            this.dgrdViewLeft = this.ucDgv_listLeft.UcDataGridViewControl;
            this.dgrdViewLeft.SelectionChanged += dgrdViewLeft_SelectionChanged;
            this.dgrdViewCenter = this.dataGridView_Dtp.UcDataGridViewControl;
            this.dgrdViewCenter.SelectionChanged += dgrdViewCenter_SelectionChanged;
            this.dgrdViewRight = this.dataGridView_result.UcDataGridViewControl;
            this.dgrdViewRight.DoubleClick += DgrdViewRight_DoubleClick;
        }

        #endregion

        #region + 事件

        private void FrmClinicarSortCheckHistory_Load(object sender, EventArgs e)
        {
            //移除所有标签页，根据不同科室选择添加不同标签页
            removeTabpages();
            this.ucDgv_listLeft.Search(1);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.ucDgv_listLeft.Search(1);
        }

        #endregion

        #region + 判断行是否有数据

        /// <summary>
        /// 判断检查结果列表
        /// </summary>
        /// <returns></returns>
        private ClinicarCheckResult GetRightCurrentRowData()
        {
            ClinicarCheckResult entity = null;
            if (this.dgrdViewRight.CurrentRow != null && this.dgrdViewRight.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheckResult>)this.dgrdViewRight.DataSource)[this.dgrdViewRight.CurrentRow.Index];
            }
            return entity;
        }
        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            //检查科室表格绑定数据 
            SPagintion<ClinicarCheck> page = clinicarCheckBiz.FindByPagination(1, 999, uTxt_checkNumber.Text.Trim(), "", entityCheckTransmit.CertificateNumber==null?"": entityCheckTransmit.CertificateNumber);
            IList<ClinicarCheck> list = page != null ? page.Data : new List<ClinicarCheck>();
            SGridViewUtil.BindingData<ClinicarCheck>(list, this.ucDgv_listLeft.UcDataGridViewControl, displayPropertiesLeft);
            if (list==null || Convert.IsDBNull(list) || list.Count <= 0)
            {
                dgrdViewCenter.DataSource = null;
                dgrdViewRight.DataSource = null;
            }
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        #region + 回填数据相关方法

        /// <summary>
        /// </summary>回填数据按钮事件
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fillBack_Click(object sender, EventArgs e)
        {
            dataFillBack();
        }

        /// <summary>
        /// 右侧结果表双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrdViewRight_DoubleClick(object sender, EventArgs e)
        {
            dataFillBack();
        }

        /// <summary>
        /// 历史数据回填
        /// </summary>
        private void dataFillBack()
        {
            //check表
            ClinicarCheck entityCheck = this.GetCurrentRowData();
            if (entityCheck == null || Convert.IsDBNull(entityCheck))
            {
                return;
            }
            //项目表
            ClinicarCheckItem entityItem = this.GetCenterCurrentRowData();
            if (entityItem == null || Convert.IsDBNull(entityItem))
            {
                return;
            }

            //表格
            if (Util.showType(entityItem.DptName).Equals(Util.data))
            {
                //结果表
                ClinicarCheckResult entity = this.GetRightCurrentRowData();
                if (entity == null || Convert.IsDBNull(entity))
                {
                    return;
                }
                if (!this.type.Equals(Util.data))
                {
                    return;
                }
                for (int i = 0; i < this.F_dgViewTransmit.RowCount; i++)
                {
                    //如果项目名称一致则回填
                    string itemName = this.F_dgViewTransmit.Rows[i].Cells[0].Value == null ? "" : this.F_dgViewTransmit.Rows[i].Cells[0].Value.ToString();
                    if (itemName == entity.DetailName)
                    {
                        f_strAttachmentPath = string.Empty;
                        this.F_dgViewTransmit.Rows[i].Cells[1].Value = entity.Result;
                        this.F_dgViewTransmit.Rows[i].Cells[4].Value = entity.Conclusion;
                        UcMessageBox.Information("【" + entity.DetailName + "】项目结果、结论回填成功.", "历史数据回填");
                    }
                }
            }
            //图片
            else if (Util.showType(entityItem.DptName).Equals(Util.image))
            {
                //检查科室表格绑定数据 
                SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 100, entityCheck.CheckNumber, entityItem.ItemCode);
                IList<ClinicarCheckResult> list = page != null ? page.Data : new List<ClinicarCheckResult>();
                if (list == null || Convert.IsDBNull(list) || list.Count <= 0)
                {
                    return;
                }
                if (!this.type.Equals(Util.image))
                {
                    return;
                }
                f_strAttachmentPath = list[0].AttachmentPath;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            //pdf
            else if (Util.showType(entityItem.DptName).Equals(Util.pdf))
            {
                //检查科室表格绑定数据 
                SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 100, entityCheck.CheckNumber, entityItem.ItemCode);
                IList<ClinicarCheckResult> list = page != null ? page.Data : new List<ClinicarCheckResult>();
                if (list == null || Convert.IsDBNull(list) || list.Count <= 0)
                {
                    return;
                }
                if (!this.type.Equals(Util.pdf))
                {
                    return;
                }
                f_strAttachmentPath = list[0].AttachmentPath;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        #region + 左边分检列表相关方法

        /// <summary>
        /// 行改变监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrdViewLeft_SelectionChanged(object sender, EventArgs e)
        {
            ClinicarCheck entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity))
            {
                return;
            }
            //检查科室表格绑定数据 
            SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindByPagination(1, 100, Convert.ToInt32(entity.Id));
            IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
            SGridViewUtil.BindingData<ClinicarCheckItem>(list, this.dataGridView_Dtp.UcDataGridViewControl, displayPropertiesCenter);
        }

        #region + 判断行是否有数据
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ClinicarCheck GetCurrentRowData()
        {
            ClinicarCheck entity = null;
            if (this.dgrdViewLeft.CurrentRow != null && this.dgrdViewLeft.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheck>)this.dgrdViewLeft.DataSource)[this.dgrdViewLeft.CurrentRow.Index];
            }
            else
            {
                //UcMessageBox.Warning("请先选择行数据", "提示");
            }
            return entity;
        }
        #endregion

        #endregion

        #region + 中间科室表相关方法

        /// <summary>
        /// 行改变监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrdViewCenter_SelectionChanged(object sender, EventArgs e)
        {
            //移除所有标签页，根据不同科室选择添加不同标签页
            removeTabpages();
            //check表
            ClinicarCheck entityCheck = this.GetCurrentRowData();
            if (entityCheck == null || Convert.IsDBNull(entityCheck))
            {
                dgrdViewCenter.DataSource = null;
                dgrdViewRight.DataSource = null;
                return;
            }
            //项目表
            ClinicarCheckItem entity = this.GetCenterCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity))
            {
                dgrdViewRight.DataSource = null;
                return;
            }
            //展示结果
            showResult(entityCheck,entity);
        }

        #region + 判断行是否有数据

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private ClinicarCheckItem GetCenterCurrentRowData()
        {
            ClinicarCheckItem entity = null;
            if (this.dgrdViewCenter.CurrentRow != null && this.dgrdViewCenter.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheckItem>)this.dgrdViewCenter.DataSource)[this.dgrdViewCenter.CurrentRow.Index];
            }
            else
            {
                //UcMessageBox.Warning("请先选择行数据", "提示");
            }
            return entity;
        }
        #endregion

        #endregion

        #region + 表格/图片/pdf展示
        /// <summary>
        /// 
        /// </summary>
        private void showResult(ClinicarCheck entityCheck,ClinicarCheckItem entity)
        {
            //检查科室表格绑定数据 
            SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 100, entityCheck.CheckNumber, entity.ItemCode);
            IList<ClinicarCheckResult> list = page != null ? page.Data : new List<ClinicarCheckResult>();

            //数据类展示(表格)
            if (Util.showType(entity.DptName).Equals(Util.data))
            {
                //添加数据标签页
                tabControl1.TabPages.Insert(0, tabPage1);
                //结果表有数据则查询结果表，没有数据则查询项目表
                if (list != null && Convert.IsDBNull(list) == false && list.Count > 0)
                {
                    SGridViewUtil.BindingData<ClinicarCheckResult>(list, this.dataGridView_result.UcDataGridViewControl, displayPropertiesRight);
                }
            }
            //图片类展示
            else if (Util.showType(entity.DptName).Equals(Util.image))
            {
                //添加图片类标签页
                tabControl1.TabPages.Insert(0, tabPage2);
                //加载图片
                if (list != null && Convert.IsDBNull(list) == false && list.Count > 0)
                {
                    if (list[0].AttachmentPath != null && !list[0].AttachmentPath.Equals(""))
                    {
                        this.label9.Visible = false;
                        try
                        {
                            pictureBox1.Image = Image.FromFile(Util.basePath + list[0].AttachmentPath);
                        }
                        catch
                        {
                            pictureBox1.Image = null;
                            this.label9.Visible = true;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        this.label9.Visible = true;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    this.label9.Visible = true;
                }
            }
            //pdf类展示
            else if (Util.showType(entity.DptName).Equals(Util.pdf))
            {
                //添加pdf类标签页
                tabControl1.TabPages.Insert(0, tabPage3);
                //加载pdf
                if (list != null && Convert.IsDBNull(list) == false && list.Count > 0)
                {
                    if (list[0].AttachmentPath != null && !list[0].AttachmentPath.Equals(""))
                    {
                        this.label10.Visible = false;
                        try
                        {
                            if (list[0].AttachmentPath.ToString().ToLower().EndsWith(".pdf"))
                            {
                                axAcroPDF1.LoadFile(Util.basePath + list[0].AttachmentPath);
                            }
                            else
                            {
                                axAcroPDF1.LoadFile("");
                                this.label10.Visible = true;
                            }
                        }
                        catch
                        {
                            axAcroPDF1.LoadFile("");
                            this.label10.Visible = true;
                        }
                    }
                    else
                    {
                        axAcroPDF1.LoadFile("");
                        this.label10.Visible = true;
                    }
                }
                else
                {
                    axAcroPDF1.LoadFile("");
                    this.label10.Visible = true;
                }
            }
        }
        #endregion

        #region + 移除标签页
        /// <summary>
        /// 
        /// </summary>
        private void removeTabpages()
        {
            //移除所有标签页，后期根据选择的科室进行添加
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
        }
        #endregion
    }
}
