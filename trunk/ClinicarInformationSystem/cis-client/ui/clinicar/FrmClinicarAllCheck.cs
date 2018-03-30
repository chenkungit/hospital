using cis_business.biz.clinicar;
using cis_business.biz.sys;
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
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarAllCheck : SCommon.SControl.SBaseDockForm
    {
        #region + 属性
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
        /// 检查结果列表
        /// </summary>
        private readonly DataGridView ucDgvlistdetail;
        /// <summary>
        /// 检查结果需要显示的列表
        /// </summary>
        private String[] displayPropertiesdetail =
        {
            "ItemName", "DetailName","Result","Unit","Conclusion"
        };
        /// <summary>
        /// 图片浏览
        /// </summary>
        private FrmPView fp;
        /// <summary>
        /// 报告预览
        /// </summary>
        private FrmBView fb;
        /// <summary>
        /// 主表ID
        /// </summary>
        private int DataEntityId = 0;
        /// <summary>
        /// 审核状态
        /// </summary>
        private bool AuditStatus = false;
        /// <summary>
        /// 定义TabControl的index
        /// </summary>
        private int TabIndex = 0;
        public ClinicarAllCheck AllCheckDataEntity { get; set; }
        #endregion
        #region + 构造方法
        public FrmClinicarAllCheck()
        {
            InitializeComponent();
            this.ucDgvlistdetail = ucDgv_listdetail.UcDataGridViewControl;
            //图片点击放大
            this.pictureBox1.Click += pictureBox_Click;
            this.pictureBox3.Click += pictureBox_Click;
        }

        #endregion
        #region + 移除标签页
        /// <summary>
        /// 
        /// </summary>
        private void removeTabpages()
        {
            //移除所有标签页，后期根据查询数据进行添加
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
        }
        #endregion
        /// <summary>
        /// 根据检查号获取病种和建议
        /// </summary>
        /// <param name="checkNumber"></param>
        /// <returns></returns>
        private ClinicarAllCheck getAllCheckData(string checkNumber)
        {
            return clinicarAllCheckBiz.FindByCheckNumber(checkNumber);
        }
        /// <summary>
        /// 设置审核状态行为
        /// </summary>
        private void setAuditStatusbehavior(bool flag)
        {
            if (flag)
            {
                this.btn_disease.Enabled = false;
                this.btn_audit.Enabled = false;
                this.btn_audit.Text = "已审核";
                this.btn_ad.Enabled = false;
                this.btn_cancel.Enabled = true;
            }
            else
            {
                this.btn_disease.Enabled = true;
                this.btn_audit.Enabled = true;
                this.btn_audit.Text = "审核";
                this.btn_cancel.Enabled = false;
                this.btn_ad.Enabled = true;
            }
        }
        /// <summary>
        /// 检查号查询方法
        /// </summary>
        private void queryCheckNumber()
        {
            //查询检查号信息
            if (!string.IsNullOrEmpty(ucTxt_code.Text.Trim()))
            {
                TabIndex = -1;

                ClinicarCheck clinicarcheck = new ClinicarCheck();
                clinicarcheck = clinicarCheckBiz.FindByCheckNumberBar(ucTxt_code.Text.Trim());
                uTxt_age.Text = clinicarcheck.Age.ToString();
                uTxt_birthday.Text = clinicarcheck.Birthday;
                uTxt_gender.Text = clinicarcheck.GenderName;
                uTxt_ID.Text = clinicarcheck.CertificateNumber;
                uTxt_IDType.Text = clinicarcheck.CertificateTypeName;
                uTxt_married.Text = clinicarcheck.MaritalStatusName;
                uTxt_name.Text = clinicarcheck.Name;
                uTxt_nation.Text = clinicarcheck.NationalityName;
                ucTxt_tel.Text = clinicarcheck.Tel;
                AuditStatus = clinicarcheck.AllcheckCompleted;
                uRic_ad.Text = clinicarcheck.Advice;
                uRic_disease.Text = clinicarcheck.Disease;
                DataEntityId = Convert.ToInt32(clinicarcheck.Id);
                //判断当前是否存在未完成科目
                if (clinicarCheckItemBiz.ExistUnCompletedItem(DataEntityId))
                {
                    //弹出弃检窗口
                    FrmClinicarAllCheckCancel cancelwindow = new FrmClinicarAllCheckCancel();
                    cancelwindow.check_id = DataEntityId;
                    cancelwindow.ShowDialog();
                }
                //移除所有标签
                removeTabpages();
                //所有完成的项目结果
                IList<ClinicarCheckResult> listdetail = new List<ClinicarCheckResult>();
                //查询已完成的项目表
                IList<ClinicarCheckItem> completedItemList = clinicarCheckItemBiz.FindCompletedItem(DataEntityId);
                if (completedItemList != null && completedItemList.Count > 0)
                {
                    foreach (ClinicarCheckItem item in completedItemList)
                    {
                        IList<ClinicarCheckResult> resutlList = clinicarCheckResultBiz.FindEntity(ucTxt_code.Text, item.ItemCode);
                        //已完成项目的结果添加到listdetail中
                        if (resutlList != null && resutlList.Count > 0)
                        {
                            foreach (ClinicarCheckResult r in resutlList)
                            {
                                if (r.DetailName == null || r.DetailName =="" || (r.DetailName != null && !r.DetailName.Equals("Take Mode") && !r.DetailName.Equals("Blood Mode") && !r.DetailName.Equals("Ref Group")))
                                {
                                    r.DptCode = item.DptCode;
                                    r.DptName = item.DptName;
                                    listdetail.Add(r);
                                }
                            }
                        }
                    }
                }
                //检查结果表格绑定数据 
                //SPagintion<ClinicarCheckResult> page = clinicarCheckResultBiz.FindByPagination(1, 10000, ucTxt_code.Text);
                //IList<ClinicarCheckResult> listdetail = page != null ? page.Data : new List<ClinicarCheckResult>();
                IList<ClinicarCheckResult> dataList = new List<ClinicarCheckResult>();
                IList<ClinicarCheckResult> picList = new List<ClinicarCheckResult>();
                IList<ClinicarCheckResult> pdfList = new List<ClinicarCheckResult>();
                foreach (ClinicarCheckResult ccr in listdetail)
                {
                    //数据类展示(表格)
                    if (Util.showType(ccr.DptName).Equals(Util.data))
                    {
                        dataList.Add(ccr);
                    }
                    else if (Util.showType(ccr.DptName).Equals(Util.image))
                    {
                        picList.Add(ccr);
                    }
                    else if (Util.showType(ccr.DptName).Equals(Util.pdf))
                    {
                        pdfList.Add(ccr);
                    }
                }
                #region 加载数据
                //定义各个标签List
                IList<ClinicarCheckResult> ybjcList = new List<ClinicarCheckResult>();//一般检查
                IList<ClinicarCheckResult> xxbList = new List<ClinicarCheckResult>();//血细胞分析仪
                IList<ClinicarCheckResult> nfxList = new List<ClinicarCheckResult>();//尿分析仪
                IList<ClinicarCheckResult> shfxList = new List<ClinicarCheckResult>();//生化分析仪
                if (dataList != null && dataList.Count > 0)
                {
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        ClinicarCheckResult dataEntity = dataList[i];
                        if (dataEntity != null)
                        {
                            if (dataEntity.DptCode == "526")
                            {
                                ybjcList.Add(dataEntity);
                            }
                            else if (dataEntity.DptCode == "603")
                            {
                                xxbList.Add(dataEntity);
                            }
                            else if (dataEntity.DptCode == "605")
                            {
                                nfxList.Add(dataEntity);
                            }
                            else if (dataEntity.DptCode == "604")
                            {
                                shfxList.Add(dataEntity);
                            }
                        }
                    }
                }
                if (ybjcList != null && ybjcList.Count > 0)
                {
                    TabIndex = TabIndex + 1;
                    tabControl1.TabPages.Insert(TabIndex, tabPage1);
                    SGridViewUtil.BindingData<ClinicarCheckResult>(ybjcList, ucDgvlistdetail, displayPropertiesdetail);
                }
                if (xxbList != null && xxbList.Count > 0)
                {
                    TabIndex = TabIndex + 1;
                    tabControl1.TabPages.Insert(TabIndex, tabPage6);
                    SGridViewUtil.BindingData<ClinicarCheckResult>(xxbList, ucDataGridView1.UcDataGridViewControl, displayPropertiesdetail);
                }
                if (nfxList != null && nfxList.Count > 0)
                {
                    TabIndex = TabIndex + 1;
                    tabControl1.TabPages.Insert(TabIndex, tabPage7);
                    SGridViewUtil.BindingData<ClinicarCheckResult>(nfxList, ucDataGridView2.UcDataGridViewControl, displayPropertiesdetail);
                }
                if (shfxList != null && shfxList.Count > 0)
                {
                    TabIndex = TabIndex + 1;
                    tabControl1.TabPages.Insert(TabIndex, tabPage8);
                    SGridViewUtil.BindingData<ClinicarCheckResult>(shfxList, ucDataGridView3.UcDataGridViewControl, displayPropertiesdetail);
                }
                #endregion
                #region 加载图片
                this.viewReport.Visible = false;
                this.button1.Visible = false;
                if (picList != null && picList.Count > 0)
                {
                    for (int i = 0; i < picList.Count; i++)
                    {
                        ClinicarCheckResult picEntity = picList[i];
                        if (picEntity != null)
                        {


                            try
                            {
                                if ("X光".Equals(picEntity.DptName.ToUpper()))
                                {
                                    TabIndex = TabIndex + 1;
                                    tabControl1.TabPages.Insert(TabIndex, tabPage2);
                                    pictureBox1.Image = Image.FromFile(Util.basePath + picEntity.AttachmentPath);
                                    this.button1.Visible = true;
                                }
                                else if ("B超".Equals(picEntity.DptName.ToUpper()))
                                {
                                    TabIndex = TabIndex + 1;
                                    tabControl1.TabPages.Insert(TabIndex, tabPage5);
                                    pictureBox3.Image = Image.FromFile(Util.basePath + picEntity.AttachmentPath);
                                    this.viewReport.Visible = true;
                                }
                            }
                            catch
                            {
                                pictureBox1.Image = null;
                                pictureBox3.Image = null;
                            }

                        }
                    }
                }
                #endregion
                #region 加载PDF
                if (pdfList != null && pdfList.Count > 0)
                {
                    for (int i = 0; i < pdfList.Count; i++)
                    {
                        ClinicarCheckResult pdfEntity = pdfList[i];
                        if (pdfEntity != null)
                        {
                            if ("心电图".Equals(pdfEntity.DptName.ToUpper()))
                            {
                                TabIndex = TabIndex + 1;
                                tabControl1.TabPages.Insert(TabIndex, tabPage4);
                                if (pdfEntity.AttachmentPath != null && !pdfEntity.AttachmentPath.Equals("") && pdfEntity.AttachmentPath.ToString().ToLower().EndsWith(".pdf"))
                                {
                                    try
                                    {
                                        axAcroPDF1.LoadFile(Util.basePath + pdfEntity.AttachmentPath);
                                    }
                                    catch
                                    {
                                        axAcroPDF1.LoadFile("");
                                    }
                                }
                                else
                                {
                                    axAcroPDF1.LoadFile("");
                                }
                            }
                            else if ("电子阴道镜".Equals(pdfEntity.DptName.ToUpper()))
                            {
                                TabIndex = TabIndex + 1;
                                tabControl1.TabPages.Insert(TabIndex, tabPage3);
                                if (pdfEntity.AttachmentPath != null && !pdfEntity.AttachmentPath.Equals("") && pdfEntity.AttachmentPath.ToString().ToLower().EndsWith(".pdf"))
                                {
                                    try
                                    {
                                        axAcroPDF2.LoadFile(Util.basePath + pdfEntity.AttachmentPath);
                                    }
                                    catch
                                    {
                                        axAcroPDF2.LoadFile("");
                                    }
                                }
                                else
                                {
                                    axAcroPDF2.LoadFile("");
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 加载项目小结
                //获取项目小结
                //IList<ClinicarCheckResult> list = clinicarCheckResultBiz.FindEntity(ucTxt_code.Text);
                //if (completedItemList != null && completedItemList.Count > 0)
                //{
                //    string _disease = string.Empty;
                //    string _advice = string.Empty;
                //    for (int i = 0; i < completedItemList.Count; i++)
                //    {
                //        if (i == 0)
                //        {
                //            if (completedItemList[i].Summary != null && !string.IsNullOrEmpty(completedItemList[i].Summary.Trim()))
                //                _disease =  completedItemList[i].Summary;
                //            //_disease = ((object[])list[i])[5].ToString();
                //            //_advice = ((object[])list[i])[5].ToString();
                //        }
                //        else
                //        {
                //            if (completedItemList[i].Summary != null && !string.IsNullOrEmpty(completedItemList[i].Summary.Trim()))
                //                _disease = _disease + "\r\n" + completedItemList[i].Summary;
                //            //_advice = _advice + "\r\n" + ((object[])list[i])[5].ToString();
                //        }
                //    }
                //    //uRic_ad.Text = _advice;
                //    uRic_disease.Text = _disease;
                //}
                //else
                //{
                //    uRic_disease.Text = string.Empty;
                //}
                #endregion
                #region 判断审核状态
                //判断审核状态
                if (AuditStatus)
                {
                    btn_audit.Enabled = false;
                    uRic_ad.Enabled = false;
                    uRic_disease.Enabled = false;
                    btn_audit.Text = "已审核";
                    btn_cancel.Enabled = true;
                }
                else
                {
                    btn_audit.Enabled = true;
                    uRic_ad.Enabled = true;
                    uRic_disease.Enabled = true;
                    btn_audit.Text = "审核";
                    btn_cancel.Enabled = false;
                }
                #endregion
            }
            else
            {
                MessageBox.Show("请填写检查号！");
                return;
            }
        }
        #region + 事件
        private void FrmClinicarAllCheck_Load(object sender, EventArgs e)
        {
            removeTabpages();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            //患者查找
            FrmClinicarCheckPatient frmClinicarCheckPatient = new FrmClinicarCheckPatient();
            frmClinicarCheckPatient.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarCheckPatient.ShowDialog();
            if (frmClinicarCheckPatient.DialogResult == DialogResult.OK)
            {
                ClinicarCheck DataEntity = new ClinicarCheck();
                DataEntity = frmClinicarCheckPatient.F_DataEntityTransmit;
                ucTxt_code.Text = DataEntity.CheckNumber;
            }
            queryCheckNumber();
        }
        /// <summary>
        /// 检查项目行改变监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDgv_list_SelectionChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 诊断建议设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ad_Click(object sender, EventArgs e)
        {
            //FrmClinicarAllCheckAdviceManage frmAdvice = new FrmClinicarAllCheckAdviceManage();
            //if (isAdd)
            //{
            //    frmAdvice.DialogStatus = DialogStatus.New;
            //    frmAdvice.strAdvice = uRic_ad.Text;
            //    frmAdvice.strDisease = uRic_disease.Text;
            //}
            //else
            //{
            //    frmAdvice.DialogStatus = DialogStatus.Modify;
            //    frmAdvice.DataEntity = DataEntity;
            //}
            //frmAdvice.checkNumber = ucTxt_code.Text;
            //frmAdvice.ShowDialog();
            //queryCheckNumber();
        }
        /// <summary>
        /// 病种设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_disease_Click(object sender, EventArgs e)
        {
            //FrmClinicarAllCheckDiseaseManage frmAdvice = new FrmClinicarAllCheckDiseaseManage();
            //if (isAdd)
            //{
            //    frmAdvice.DialogStatus = DialogStatus.New;
            //    frmAdvice.strAdvice = uRic_ad.Text;
            //    frmAdvice.strDisease = uRic_disease.Text;
            //}
            //else
            //{
            //    frmAdvice.DialogStatus = DialogStatus.Modify;
            //    frmAdvice.DataEntity = DataEntity;
            //}
            //frmAdvice.checkNumber = ucTxt_code.Text;
            //frmAdvice.ShowDialog();
            //queryCheckNumber();
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_audit_Click(object sender, EventArgs e)
        {
            ClinicarCheck cc = new ClinicarCheck();
            cc = clinicarCheckBiz.FindByCheckNum(ucTxt_code.Text);
            cc.AllcheckCompleted = true;
            cc.Advice = uRic_ad.Text;
            cc.Disease = uRic_disease.Text;
            clinicarCheckBiz.Update(cc);
            
            MessageBox.Show("审核成功！");
            queryCheckNumber();
        }
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClinicarCheck cc = new ClinicarCheck();
            cc = clinicarCheckBiz.FindByCheckNum(ucTxt_code.Text);
            cc.AllcheckCompleted = false;
            clinicarCheckBiz.Update(cc);
            MessageBox.Show("取消审核成功！");
            queryCheckNumber();
        }
        /// <summary>
        /// 图片点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender,EventArgs e)
        {
            PictureBox pictureBox1 = sender as PictureBox;
            if (pictureBox1.Image != null)
            {
                if (fp == null || fp.IsDisposed)
                    fp = new FrmPView();
                fp.image = pictureBox1.Image;
                fp.Show();
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_print_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(MyPrintDoc_PrintPage);
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                printPreviewDialog1.ShowDialog();
                //printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("请安装打印机", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 预览B超报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewReport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucTxt_code.Text))
            {
                DirectoryInfo newFolder = new DirectoryInfo(@"D:\uploadFolder\bc\data\" + ucTxt_code.Text);
                FileInfo[] htmlFiles = newFolder.GetFiles("*.html");
                if (htmlFiles.Length > 0)
                {
                    string url = @"D:\uploadFolder\bc\data\" + ucTxt_code.Text + @"\" + htmlFiles[0].Name;
                    if (fb == null || fb.IsDisposed)
                        fb = new FrmBView();
                    fb.Show();
                    fb.browser.Navigate(url.ToString());
                    fb.browser.GetMarkupDocumentViewer().SetFullZoomAttribute(1.2f);
                }
                else
                {
                    MessageBox.Show("暂无报告！");
                }

            }
        }

        /// <summary>
        /// 预览X光报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucTxt_code.Text))
            {
                DirectoryInfo newFolder = new DirectoryInfo(@"D:\uploadFolder\xRayFolder\data\" + ucTxt_code.Text);
                if (newFolder != null)
                {
                    FileInfo[] bmpFiles = newFolder.GetFiles("*.bmp");
                    if (bmpFiles.Length > 0)
                    {
                        string url = @"D:\uploadFolder\xRayFolder\data\" + ucTxt_code.Text + @"\" + bmpFiles[0].Name;
                        if (fp == null || fp.IsDisposed)
                            fp = new FrmPView();
                        fp.image = Image.FromFile(url);
                        fp.Show();
                    }
                    else
                    {
                        MessageBox.Show("暂无报告！");
                    }
                }
                else
                {
                    MessageBox.Show("暂无报告！");
                }

            }

            if (pictureBox1.Image != null)
            {
                if (fp == null || fp.IsDisposed)
                    fp = new FrmPView();
                fp.image = pictureBox1.Image;
                fp.Show();
            }
        }
        /// <summary>
        /// 绘制打印表格（指引单）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyPrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //字体 颜色 格式 坐标
            Font drawFont = null;
            SolidBrush drawBrush = null;
            float x = 0F;
            float y = 0F;
            StringFormat drawFormat = new StringFormat();

            drawFont = new Font("Arial", 12);
            drawBrush = new SolidBrush(Color.Black);
            x = 0F;
            y = 0F;
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;
            //表格行数
            int num = 6;
            //int num = listDraw.Count() + 1;
            //if (num < 6)
            //{
            //    num = 6;
            //}
            //标题
            //标题第一行
            string BillCode = "检查号：" + ucTxt_code.Text;
            //string ClassType = "姓名：" + uTxt_name.Text;
            //string type1 = "日期：" + uDat_checkDate.Value.ToString("yyyy-MM-dd");
            ////标题第二行
            //string ArriveStation = "性别：" + uTxt_genderName.Text;
            //string SpLine = "年龄：" + uNum_age.Text;
            //string SaleNo = "证件号：" + uTxt_certificateNumber.Text;
            //线条长度
            Pen line = new Pen(drawBrush, 1);
            //绘图--字的位置
            //绘图--总标题
            e.Graphics.DrawString(BillCode, new Font("黑体", 18), drawBrush, 350, 45, drawFormat);
            //绘图--标题--第一行
            //吊号
            e.Graphics.DrawString(BillCode, drawFont, drawBrush, 125, 83, drawFormat);
            ////班别
            //e.Graphics.DrawString(ClassType, drawFont, drawBrush, 370, 83, drawFormat);
            ////类型
            //e.Graphics.DrawString(type1, drawFont, drawBrush, 520, 83, drawFormat);
            ////记录单号
            ////绘图--标题--第二行
            ////到站
            //e.Graphics.DrawString(ArriveStation, drawFont, drawBrush, 125, 106, drawFormat);
            ////专用线
            //e.Graphics.DrawString(SpLine, drawFont, drawBrush, 370, 106, drawFormat);
            ////销售订单号
            //e.Graphics.DrawString(SaleNo, drawFont, drawBrush, 520, 106, drawFormat);

            //绘图 表格
            float leftbianJu = 60;
            float topbianJu = 152;
            float tableWidth = 720;
            float tableHeight = 40 * num;
            float cellwidth = 55;
            float cellwidth1 = 55;
            float cellheigh = 0F;
            //绘图--线的位置 外边矩形
            //横
            e.Graphics.DrawLine(line, leftbianJu, topbianJu, leftbianJu + tableWidth, topbianJu);
            e.Graphics.DrawLine(line, leftbianJu, topbianJu + tableHeight, leftbianJu + tableWidth, topbianJu + tableHeight);
            //竖
            e.Graphics.DrawLine(line, leftbianJu, topbianJu, leftbianJu, topbianJu + tableHeight);
            e.Graphics.DrawLine(line, leftbianJu + tableWidth, topbianJu, leftbianJu + tableWidth, topbianJu + tableHeight);
            //e.Graphics.DrawLine(line, 15, 0, 15, 614);
            //绘图--内部竖线的位置
            y = topbianJu + tableHeight;
            x = leftbianJu + cellwidth;
            e.Graphics.DrawLine(line, tableWidth / 2 + leftbianJu, topbianJu, tableWidth / 2 + leftbianJu, y);
            //绘图--内部横线的位置
            //根据块数计算表格高度
            if (num != 0)
                //cellheigh = tableHeight / (float)num;
                cellheigh = 40;
            else
                cellheigh = 0;
            //绘图--内部横线的位置
            for (int i = 1; i <= num; i++)
            {
                //if (i == 1)
                //{
                //    //表头
                //    string str = "";
                //    str = "检查项目";
                //    x = leftbianJu + cellwidth / 5;
                //    y = topbianJu + cellheigh / 3;
                //    e.Graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
                //    str = "科室";
                //    x = leftbianJu + tableWidth / 2 + cellwidth1 / 5;
                //    e.Graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
                //}
                //else
                //{
                //    //如果检查项目不够五条时，则添加空行
                //    if (i - 1 > listDraw.Count)
                //    {
                //        //检查项目
                //        string str = "";
                //        x = leftbianJu + cellwidth / 5;
                //        y = topbianJu + cellheigh * (i - 1) + cellheigh / 3;
                //        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);

                //        //科室
                //        str = "";
                //        x = leftbianJu + cellwidth1 / 5 + tableWidth / 2;
                //        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);
                //    }
                //    else
                //    {
                //        //检查项目
                //        string str = listDraw[i - 2].ItemName;
                //        x = leftbianJu + cellwidth / 5;
                //        y = topbianJu + cellheigh * (i - 1) + cellheigh / 3;
                //        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);

                //        //科室
                //        str = listDraw[i - 2].DptName;
                //        x = leftbianJu + cellwidth1 / 5 + tableWidth / 2;
                //        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);
                //    }
                //}

                ////横线
                //y = topbianJu + cellheigh * i;
                //e.Graphics.DrawLine(line, leftbianJu, y, leftbianJu + tableWidth, y);
                ////打印条码
                //e.Graphics.DrawImage(picb_left.Image, 20, 35, 100, 50);
            }
            e.HasMorePages = false;
        }
        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {

        }
        /// <summary>
        /// 重新生成总检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSczj_Click(object sender, EventArgs e)
        {
            queryCheckNumber();
        }

        #endregion

    }
}
