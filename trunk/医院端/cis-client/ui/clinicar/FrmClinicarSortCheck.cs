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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarSortCheck : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayPropertiesLeft =
        {
            "DptName", "Completed"
        };

        /// <summary>
        /// 检查科室列表
        /// </summary>
        private readonly DataGridView dgrdViewLeft;

        /// <summary>
        /// 登记表主表业务层
        /// </summary>
        private ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();

        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();

        /// <summary>
        /// 项目表业务层
        /// </summary>
        private ClinicarItemBiz clinicarItemBiz = new ClinicarItemBiz();

        /// <summary>
        /// 项目子表业务层
        /// </summary>
        private ClinicarItemtDetailBiz clinicarItemDetailBiz = new ClinicarItemtDetailBiz();

        /// <summary>
        /// 检查结果表业务层
        /// </summary>
        private ClinicarCheckResultBiz clinicarCheckResultBiz = new ClinicarCheckResultBiz();

        /// <summary>
        /// 实体类
        /// </summary>
        public ClinicarCheck DataEntity { get; set; }

        /// <summary>
        /// 实体类（用于传值）
        /// </summary>
        public ClinicarCheck DataEntityTransmit { get; set; }

        /// <summary>
        /// 检查结果实体类
        /// </summary>
        public ClinicarCheckResult DataEntityClinicarCheckResult { get; set; }

        /// <summary>
        /// 修改标记
        /// </summary>
        private bool f_blEdit = true;

        /// <summary>
        /// 图片或pdf相对路径
        /// </summary>
        private string imageOrPdfPath = string.Empty;

        #endregion

        #region + 构造方法
        public FrmClinicarSortCheck()
        {
            InitializeComponent();
            this.dgrdViewLeft = this.ucDgv_listLeft.UcDataGridViewControl;
            this.dgrdViewLeft.SelectionChanged += DgrdViewLeft_SelectionChanged;
        }

        #endregion

        #region + 事件

        private void FrmClinicarSortCheck_Load(object sender, EventArgs e)
        {
            //不允许手动添加行
            this.dataGridView_Result.AllowUserToAddRows = false;
            //移除所有标签页，根据不同科室选择添加不同标签页
            removeTabpages();
        }

        #region + 检查号相关
        /// <summary>
        /// 判断是否按下enter键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTxt_checkNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(uTxt_checkNumber.Text))
            {
                UcMessageBox.Warning("请选择或填写相应的检查号.", "提示！");
                return;
            }
            else
            {
                DataEntity = new ClinicarCheck();
                DataEntity = clinicarCheckBiz.FindByCheckNum(uTxt_checkNumber.Text.Trim());
                fillByCheckNum();
            }
        }

        /// <summary>
        /// 根据检查号回填信息
        /// </summary>
        private void fillByCheckNum()
        {
            if (DataEntity != null && Convert.IsDBNull(DataEntity) == false)
            {
                label8.Text = DataEntity.CheckNumber;
                uTxt_name.Text = DataEntity.Name;
                uTxt_genderName.Text = DataEntity.GenderName;
                uNum_age.Text = DataEntity.Age.ToString();
                uTxt_maritalStatusName.Text = DataEntity.MaritalStatusName;
                uTxt_nationalityName.Text = DataEntity.NationalityName;
                uTxt_checkNumber.Text = DataEntity.CheckNumber;

                //检查科室表格绑定数据 
                SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindByPagination(1, 100, Convert.ToInt32(DataEntity.Id));
                IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
                SGridViewUtil.BindingData<ClinicarCheckItem>(list, this.ucDgv_listLeft.UcDataGridViewControl, displayPropertiesLeft);
            }
            else
            {
                UcMessageBox.Warning("所查询的检查号不存在.", "提示！");
            }
        }

        /// <summary>
        /// 检查号选择窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_guide_Click(object sender, EventArgs e)
        {
            //患者查找
            FrmClinicarCheckPatient frmClinicarCheckPatient = new FrmClinicarCheckPatient();
            frmClinicarCheckPatient.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarCheckPatient.ShowDialog();
            if (frmClinicarCheckPatient.DialogResult == DialogResult.OK)
            {
                DataEntity = new ClinicarCheck();
                DataEntity = frmClinicarCheckPatient.F_DataEntityTransmit;
                fillByCheckNum();
            }
        }

        #endregion

        #endregion

        #region + 判断行是否有数据
        /// <summary>
        /// 判断科室项目列表
        /// </summary>
        /// <returns></returns>
        private ClinicarCheckItem GetCurrentRowData()
        {
            ClinicarCheckItem entity = null;
            if (this.dgrdViewLeft.CurrentRow != null && this.dgrdViewLeft.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheckItem>)this.dgrdViewLeft.DataSource)[this.dgrdViewLeft.CurrentRow.Index];
            }
            return entity;
        }

        #endregion

        #region + 左边科室项目列表相关方法

        /// <summary>
        /// 行改变监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrdViewLeft_SelectionChanged(object sender, EventArgs e)
        {
            //移除所有标签页，根据不同科室选择添加不同标签页
            removeTabpages();
            ClinicarCheckItem entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity))
            {
                //当前科室
                lb_choseDpt.Text = string.Empty;
                this.dataGridView_Result.DataSource = null;
                return;
            }
            //根据科室不同，展示不同的结果
            showResult(entity);
            //结论和建议
            uRic_summary.Text = entity.Summary;
            //当前科室
            lb_choseDpt.Text = "当前科室：" + entity.DptName;
        }

        #endregion

        #region + 保存按钮相关方法
        /// <summary>
        /// 保存相关方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (this.CheckBeforeSave())//保存前的校验
            {
                //获取检查项目聚焦行数据
                ClinicarCheckItem entity = this.GetCurrentRowData();
                if (entity == null || Convert.IsDBNull(entity)) return;

                //图片类或pdf
                if (Util.showType(entity.DptName).Equals(Util.image) || Util.showType(entity.DptName).Equals(Util.pdf))
                {
                    SResult rst = new SResult();
                    this.DataEntityClinicarCheckResult = new ClinicarCheckResult();
                    this.DataEntityClinicarCheckResult.Deleted = false;
                    this.DataEntityClinicarCheckResult.CheckNumber = uTxt_checkNumber.Text.Trim();
                    this.DataEntityClinicarCheckResult.AttachmentPath = this.imageOrPdfPath;
                    this.DataEntityClinicarCheckResult.ItemCode = entity.ItemCode;
                    this.DataEntityClinicarCheckResult.ItemName = entity.ItemName;
                    //检查结果表格绑定数据 
                    SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 100, uTxt_checkNumber.Text.Trim(), entity.ItemCode);
                    IList<ClinicarCheckResult> list = page != null ? page.Data : new List<ClinicarCheckResult>();
                    if (list != null && Convert.IsDBNull(list) == false && list.Count > 0)
                    {
                        this.DataEntityClinicarCheckResult.Id = list[0].Id;
                        rst = clinicarCheckResultBiz.Update(DataEntityClinicarCheckResult);
                    }
                    else
                    {
                        rst = clinicarCheckResultBiz.Insert(DataEntityClinicarCheckResult);
                    }
                    if (rst.success)
                    {
                        UcMessageBox.Information("保存成功.", "提示");
                        entity.Summary = uRic_summary.Text;
                        entity.Completed = true;
                        rst = clinicarCheckItemBiz.Update(entity);
                    }
                    else
                    {
                        UcMessageBox.Error("保存失败.", "提示");
                    }
                }
                //数据类
                else if (Util.showType(entity.DptName).Equals(Util.data))
                {
                    SResult rst = new SResult();
                    if (dataGridView_Result != null && !Convert.IsDBNull(dataGridView_Result) && dataGridView_Result.RowCount > 0)
                    {
                        try
                        {
                            for (int i = 0; i < dataGridView_Result.RowCount; i++)
                            {
                                this.DataEntityClinicarCheckResult = new ClinicarCheckResult();

                                this.DataEntityClinicarCheckResult.DetailName = dataGridView_Result.Rows[i].Cells[0].Value == null ? "" : dataGridView_Result.Rows[i].Cells[0].Value.ToString();
                                this.DataEntityClinicarCheckResult.Result = dataGridView_Result.Rows[i].Cells[1].Value == null ? "" : dataGridView_Result.Rows[i].Cells[1].Value.ToString();
                                this.DataEntityClinicarCheckResult.Unit = dataGridView_Result.Rows[i].Cells[3].Value == null ? "" : dataGridView_Result.Rows[i].Cells[3].Value.ToString();
                                this.DataEntityClinicarCheckResult.Conclusion = dataGridView_Result.Rows[i].Cells[4].Value == null ? "" : dataGridView_Result.Rows[i].Cells[4].Value.ToString();
                                this.DataEntityClinicarCheckResult.Deleted = false;
                                this.DataEntityClinicarCheckResult.CheckNumber = uTxt_checkNumber.Text.Trim();
                                this.DataEntityClinicarCheckResult.AttachmentPath = "";
                                this.DataEntityClinicarCheckResult.ItemCode = entity.ItemCode;
                                this.DataEntityClinicarCheckResult.ItemName = entity.ItemName;

                                if (!f_blEdit) //新增
                                {
                                    this.DataEntityClinicarCheckResult.DetailCode = dataGridView_Result.Rows[i].Cells[5].Value == null ? "" : dataGridView_Result.Rows[i].Cells[5].Value.ToString();
                                    rst = clinicarCheckResultBiz.Insert(DataEntityClinicarCheckResult);
                                }
                                else if (f_blEdit)  //修改
                                {
                                    this.DataEntityClinicarCheckResult.DetailCode = dataGridView_Result.Rows[i].Cells[6].Value == null ? "" : dataGridView_Result.Rows[i].Cells[6].Value.ToString();
                                    this.DataEntityClinicarCheckResult.Id = dataGridView_Result.Rows[i].Cells[5].Value == null ? 0 : Convert.ToInt32(dataGridView_Result.Rows[i].Cells[5].Value);
                                    rst = clinicarCheckResultBiz.Update(DataEntityClinicarCheckResult);
                                }
                            }
                        }
                        catch
                        { }
                        finally
                        {
                            if (rst.success)
                            {
                                UcMessageBox.Information("保存成功.", "提示");
                                entity.Summary = uRic_summary.Text;
                                entity.Completed = true;
                                rst = clinicarCheckItemBiz.Update(entity);
                            }
                            else
                            {
                                UcMessageBox.Error("保存失败.", "提示");
                            }
                        }
                    }
                }

                //重新查询科室表
                DataEntity = new ClinicarCheck();
                DataEntity = clinicarCheckBiz.FindByCheckNum(uTxt_checkNumber.Text.Trim());
                fillByCheckNum();
            }
        }

        /// <summary>
        /// 保存前的校验方法
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            //获取检查项目聚焦行数据
            ClinicarCheckItem entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region + 检查结果表相关方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgrdViewRight_SelectionChanged(object sender, EventArgs e)
        {
            //获取检查项目聚焦行数据
            ClinicarCheckItem entityLeft = this.GetCurrentRowData();
            if (entityLeft == null || Convert.IsDBNull(entityLeft))
            {
                return;
            }
            ////获取检查结果聚焦行数据
            //ClinicarCheckResult entityRight = this.GetRightCurrentRowData();
            //if (entityRight == null || Convert.IsDBNull(entityRight))
            //{
            //    clean();
            //    return;
            //}

            //uTxt_itemName.Text = entityRight.Name;
            //uTxt_itemResult.Text = entityRight.Result;
            //uTxt_itemUtil.Text = entityRight.Unit;
            //uTxt_itemConlusion.Text = entityRight.Conclusion;
        }

        #endregion

        #region + 小结、保存
        /// <summary>
        /// </summary>小结
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_summary_Click(object sender, EventArgs e)
        {
            if (dataGridView_Result!=null && Convert.IsDBNull(dataGridView_Result)==false && dataGridView_Result.RowCount > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dataGridView_Result.RowCount; i++)
                {
                    sb.Append(i + 1 + "、" + dataGridView_Result.Rows[i].Cells[4].Value + "\n");
                }

                uRic_summary.Text = sb.ToString();
            }
        }

        #endregion

        #region + 历史数据
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_history_Click(object sender, EventArgs e)
        {
            //获取检查项目聚焦行数据
            ClinicarCheckItem entityItem = this.GetCurrentRowData();
            if (entityItem == null || Convert.IsDBNull(entityItem))
            {
                return;
            }
            FrmClinicarSortCheckHistory history = new FrmClinicarSortCheckHistory();
            history.StartPosition = FormStartPosition.CenterScreen;
            //检查项目（科室）实体类
            history.entityTransmit = entityItem;
            //登记表实体类
            history.entityCheckTransmit = DataEntity;
            //结果表控件
            history.F_dgViewTransmit = dataGridView_Result;
            //回填类型（图片/pdf/表格）
            if (Util.showType(entityItem.DptName).Equals(Util.image))
            {
                history.type = Util.image;
            }
            else if (Util.showType(entityItem.DptName).Equals(Util.pdf))
            {
                history.type = Util.pdf;
            }
            else
            {
                history.type = Util.data;
            }
            history.ShowDialog();

            if (history.DialogResult == DialogResult.OK)
            {
                imageOrPdfPath = history.F_strAttachmentPath;
                if (!string.IsNullOrEmpty(imageOrPdfPath))
                {
                    if (imageOrPdfPath.ToLower().EndsWith(".pdf"))
                    {
                        axAcroPDF1.LoadFile(Util.basePath + imageOrPdfPath);
                        this.label10.Visible = false;
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile(Util.basePath + imageOrPdfPath);
                    }
                }
            }
        }
        #endregion

        #region + 取消按钮事件
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            SResult rst = new SResult();
            ClinicarCheckItem entity = this.GetCurrentRowData();
            if (entity == null || Convert.IsDBNull(entity)) return;
            entity.Completed = false;
            rst = clinicarCheckItemBiz.Update(entity);

            if (rst.success)
            {
                UcMessageBox.Information("取消成功.", "提示");
            }
            else
            {
                UcMessageBox.Information("取消失败.", "提示");
            }

            //重新查询科室表
            DataEntity = new ClinicarCheck();
            DataEntity = clinicarCheckBiz.FindByCheckNum(uTxt_checkNumber.Text.Trim());
            fillByCheckNum();
        }
        #endregion

        #region + 图片相关方法
        /// <summary>
        /// 双击选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            //openDialog();
        }

        /// <summary>
        /// label 双击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label9_DoubleClick(object sender, EventArgs e)
        {
            //openDialog();
        }

        /// <summary>
        /// 选择图片
        /// </summary>
        private void openDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult dr = openFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string image = openFile.FileName;
                pictureBox1.Image = Image.FromFile(image);
                this.label9.Visible = false;
            }
        }

        /// <summary>
        /// 上传方法
        /// </summary>
        /// <param name="prePath"></param>
        /// <returns></returns>
        private string upLoad(string prePath)
        {
            if (string.IsNullOrEmpty(prePath))
            {
                return string.Empty;
            }

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"ClinicarIamge\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"ClinicarIamge\");
            }
            string tempFileName = AppDomain.CurrentDomain.BaseDirectory + @"ClinicarIamge\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(prePath, tempFileName);
            return tempFileName;
        }

        /// <summary>
        /// 图片右键方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
            this.label9.Visible = true;
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

        #region + 表格/图片/pdf展示
        /// <summary>
        /// 
        /// </summary>
        private void showResult(ClinicarCheckItem entity)
        {
            //检查结果表格绑定数据 
            SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 100, uTxt_checkNumber.Text.Trim(), entity.ItemCode);
            IList<ClinicarCheckResult> list = page != null ? page.Data : new List<ClinicarCheckResult>();
            this.imageOrPdfPath = string.Empty;

            //数据类展示(表格)
            if (Util.showType(entity.DptName).Equals(Util.data))
            {
                //添加数据标签页
                tabControl1.TabPages.Insert(0, tabPage1);
                //结果表有数据则查询结果表，没有数据则查询项目表
                if (list != null && Convert.IsDBNull(list) == false && list.Count > 0)
                {
                    //不自动生成列
                    this.dataGridView_Result.AutoGenerateColumns = false;
                    this.dataGridView_Result.DataSource = list;
                    this.f_blEdit = true;
                }
                else
                {
                    SPagintion<ClinicarItemDetail> pageItem = clinicarItemDetailBiz.FindByPagination(1, 100, entity.ItemCode);
                    IList<ClinicarItemDetail> listItem = pageItem != null ? pageItem.Data : new List<ClinicarItemDetail>();
                    //不自动生成列
                    this.dataGridView_Result.AutoGenerateColumns = false;
                    this.dataGridView_Result.DataSource = listItem;
                    this.f_blEdit = false;
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
                            this.imageOrPdfPath = list[0].AttachmentPath;
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
                                this.imageOrPdfPath = list[0].AttachmentPath;
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

        #region + 选择pdf文件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label10_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF文档(*.pdf)|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                axAcroPDF1.LoadFile(ofd.FileName);
                this.label10.Visible = false;
            }
            else
            {
                axAcroPDF1.LoadFile("");
                this.label10.Visible = true;
            }
        }
        #endregion
    }
}
