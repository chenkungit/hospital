using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_business.util;
using cis_model.clinicar;
using cis_model.sys;
using cis_util;
using SCommon.SQL;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarConsultationManage : SCommon.SControl.SBaseForm
    {
        /// <summary>
        /// 申请会诊业务层
        /// </summary>
        private ClinicarConsultationBiz clinicarConsultationBiz = new ClinicarConsultationBiz();
        /// <summary>
        /// 申请会诊实体类
        /// </summary>
        public ClinicarConsultation DataEntity { get; set; }
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
        /// 检查结果集
        /// </summary>
        private IList<ClinicarCheckResult> F_checkResultList;
        /// <summary>
        /// 图片浏览
        /// </summary>
        private FrmPView fp;
        /// <summary>
        /// B超报告预览
        /// </summary>
        private FrmBView fb;
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
        // <summary>
        /// 定义TabControl的index
        /// </summary>
        private int TabIndex = 0;

        /// <summary>
        /// 医院端（我的会诊）界面进入
        /// </summary>
        public bool hospitalConsultation = false;

        /// <summary>
        /// FTP服务器地址
        /// </summary>
        private string ftpUristring = null;

        /// <summary>
        /// 需要上传的本地文件固定路径前缀
        /// </summary>
        private string strLocalFilePath = "D:\\uploadFolder\\";

        public FrmClinicarConsultationManage()
        {
            InitializeComponent();
            this.ucDgvlistdetail = ucDgv_listdetail.UcDataGridViewControl;
            //图片点击放大
            this.pictureBox1.Click += pictureBox_Click;
            this.pictureBox3.Click += pictureBox_Click;

        }
        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
            downLoadFiles();
            // 性别
            this.ucCbo_sex.DataSource = Constant.GetGenderCodeData(DicSort.GenderCode).ToList();
            this.ucCbo_sex.DisplayMember = "Value";
            this.ucCbo_sex.ValueMember = "Key";
            // 婚否
            this.ucCbo_married.DataSource = Constant.GetMaritalStatusCodeData(DicSort.MaritalStatusCode).ToList();
            this.ucCbo_married.DisplayMember = "Value";
            this.ucCbo_married.ValueMember = "Key";
            if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
            {
                if (hospitalConsultation)
                {
                    this.btn_search.Enabled = false;
                    this.btn_save.Visible = false;
                    this.Fill2Win();
                    //根据检查号获取checkId
                    ClinicarCheck clinicarcheck = clinicarCheckBiz.FindByCheckNum(DataEntity.CheckNumber);
                    if (clinicarcheck != null)
                    {
                        //根据检查号获取总检信息
                        FineAllCheckInfo(Convert.ToInt32(clinicarcheck.Id), DataEntity.CheckNumber);
                    }

                }
            }
            else
            {
                //回填已有的数据
                uTxt_hospitalname.Text = DataEntity.HospitalName;
                uTxt_deptname.Text = DataEntity.DeptName;
                uDtp_consultationdate.Value = DataEntity.ConsultationDate;
            }

            //加载时标签只显示既往病史和初步诊断
            //tabControl1.TabPages.Remove(tabPage1);
            //tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Remove(tabPage3);
            //tabControl1.TabPages.Remove(tabPage4);
            //tabControl1.TabPages.Remove(tabPage7);
            //tabControl1.TabPages.Remove(tabPage8);
            //tabControl1.TabPages.Remove(tabPage9);
            //tabControl1.TabPages.Remove(tabPage10);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
            else if (sender == this.btn_save)
            {
                if (this.Save())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (this.CheckBeforeSave())//保存前的校验
            {
                SResult rst = new SResult();
                if (this.DialogStatus == UBaseLib.Enums.DialogStatus.New) //新增
                {
                    this.Fill2Entity();
                    rst = clinicarConsultationBiz.Insert(this.DataEntity);
                    if (rst.success)
                    {
                        dataUpload(rst);
                    }
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = clinicarConsultationBiz.Update(this.DataEntity);
                }
                if (rst.success)
                {
                    this.DialogResult = DialogResult.OK;
                    UcMessageBox.Information(rst.message, "提示");
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    UcMessageBox.Error(rst.message, "提示");
                }
                return rst.success;
            }
            return false;
        }

        /// <summary>
        /// 保存前的校验方法
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            if (this.uTxt_name.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入患者姓名！", "提示");
                this.uTxt_name.Focus();
                return false;
            }

            if (this.uTxt_checknumber.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入检查号！", "提示");
                this.uTxt_checknumber.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.ApplyHospitalCode = uTxt_applyhospitalcode.Text;
            this.DataEntity.ApplyHospitalName = uTxt_applyhospitalname.Text;
            this.DataEntity.ApplyHospitalTel = uTxt_applyhospitaltel.Text;
            this.DataEntity.ApplyHospitalDate = uDtp_applyhospitaldate.Value;
            this.DataEntity.Name = uTxt_name.Text;
            this.DataEntity.CheckNumber = uTxt_checknumber.Text;
            this.DataEntity.Sex = ucCbo_sex.SelectedValue.ToString();
            this.DataEntity.Married = ucCbo_married.SelectedValue.ToString();
            this.DataEntity.Tel = uTxt_tel.Text;
            this.DataEntity.Cardnumber = uTxt_cardnumber.Text;
            this.DataEntity.Diagnosis = ric_diagnosis.Text;
            this.DataEntity.Medicalhistory = ric_medicalhistory.Text;
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            uTxt_hospitalname.Text = DataEntity.HospitalName;
            uTxt_deptname.Text = DataEntity.DeptName;
            uDtp_consultationdate.Text = DataEntity.ConsultationDate.ToString();
            uTxt_name.Text = DataEntity.Name;
            uTxt_checknumber.Text = DataEntity.CheckNumber;
            ucCbo_sex.SelectedValue = DataEntity.Sex;
            ucCbo_married.SelectedValue = DataEntity.Married;
            uTxt_age.Text = DataEntity.Age;
            uTxt_tel.Text = DataEntity.Tel;
            uTxt_cardnumber.Text = DataEntity.Cardnumber;
            ric_diagnosis.Text = DataEntity.Diagnosis;
            ric_medicalhistory.Text = DataEntity.Medicalhistory;
        }

        private void uTxt_applyhospitalcode_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarHospital frmClinicarHospital = new FrmClinicarHospital();
            frmClinicarHospital.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarHospital.operationPower = false;
            frmClinicarHospital.ShowDialog();
            if (frmClinicarHospital.DialogResult == DialogResult.OK)
            {
                uTxt_applyhospitalcode.Text = frmClinicarHospital.F_StringCode;
                uTxt_applyhospitalname.Text = frmClinicarHospital.F_StringName;
            }
        }

        /// <summary>
        /// 图片点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
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
                uTxt_checknumber.Text = DataEntity.CheckNumber;
                uTxt_name.Text = DataEntity.Name;
                uTxt_age.Text = DataEntity.Age == null ? "" : DataEntity.Age.ToString();
                ucCbo_sex.SelectedValue = DataEntity.GenderCode;
                ucCbo_married.SelectedValue = DataEntity.MaritalStatusCode;
                uTxt_tel.Text = DataEntity.Tel;
                uTxt_cardnumber.Text = DataEntity.CertificateNumber;

                //根据检查号获取总检信息
                FineAllCheckInfo(Convert.ToInt32(DataEntity.Id), DataEntity.CheckNumber);
            }
        }
        /// <summary>
        /// 获取总检数据
        /// </summary>
        /// <param name="checkNumber"></param>
        private void FineAllCheckInfo(int DataEntityId, string checkNumber)
        {
            TabIndex = -1;
            //移除所有标签
            removeTabpages();
            //所有完成的项目结果
            IList<ClinicarCheckResult> listdetail = new List<ClinicarCheckResult>();
            F_checkResultList = new List<ClinicarCheckResult>();
            //查询已完成的项目表
            IList<ClinicarCheckItem> completedItemList = clinicarCheckItemBiz.FindCompletedItem(DataEntityId);
            if (completedItemList != null && completedItemList.Count > 0)
            {
                foreach (ClinicarCheckItem item in completedItemList)
                {
                    IList<ClinicarCheckResult> resutlList = clinicarCheckResultBiz.FindEntity(checkNumber, item.ItemCode);
                    //已完成项目的结果添加到listdetail中
                    if (resutlList != null && resutlList.Count > 0)
                    {
                        foreach (ClinicarCheckResult r in resutlList)
                        {
                            if (r.DetailName == null || r.DetailName == "" || (r.DetailName != null && !r.DetailName.Equals("Take Mode") && !r.DetailName.Equals("Blood Mode") && !r.DetailName.Equals("Ref Group")))
                            {
                                r.DptCode = item.DptCode;
                                r.DptName = item.DptName;
                                listdetail.Add(r);
                                F_checkResultList.Add(r);
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
            //绑定数据
            //SGridViewUtil.BindingData<ClinicarCheckResult>(dataList, ucDgvlistdetail, displayPropertiesdetail);
            //tabControl1.TabPages.Insert(0, tabPage1);
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
                tabControl1.TabPages.Insert(TabIndex, tabPage8);
                SGridViewUtil.BindingData<ClinicarCheckResult>(xxbList, ucDataGridView1.UcDataGridViewControl, displayPropertiesdetail);
            }
            if (nfxList != null && nfxList.Count > 0)
            {
                TabIndex = TabIndex + 1;
                tabControl1.TabPages.Insert(TabIndex, tabPage9);
                SGridViewUtil.BindingData<ClinicarCheckResult>(nfxList, ucDataGridView2.UcDataGridViewControl, displayPropertiesdetail);
            }
            if (shfxList != null && shfxList.Count > 0)
            {
                TabIndex = TabIndex + 1;
                tabControl1.TabPages.Insert(TabIndex, tabPage10);
                SGridViewUtil.BindingData<ClinicarCheckResult>(shfxList, ucDataGridView3.UcDataGridViewControl, displayPropertiesdetail);
            }
            #endregion
            #region 加载图片
            viewReport.Visible = false;
            button1.Visible = false;
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
                                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + picEntity.AttachmentPath);
                                button1.Visible = true;
                            } 
                            else if ("B超".Equals(picEntity.DptName.ToUpper()))
                            {
                                TabIndex = TabIndex + 1;
                                tabControl1.TabPages.Insert(TabIndex, tabPage7);
                                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\" + picEntity.AttachmentPath);
                                viewReport.Visible = true;
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
                                    axAcroPDF1.LoadFile(Application.StartupPath + "\\" + pdfEntity.AttachmentPath);
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
                        else if ("电子阴道镜".Equals(pdfEntity.DptName))
                        {
                            TabIndex = TabIndex + 1;
                            tabControl1.TabPages.Insert(TabIndex, tabPage3);
                            if (pdfEntity.AttachmentPath != null && !pdfEntity.AttachmentPath.Equals("") && pdfEntity.AttachmentPath.ToString().ToLower().EndsWith(".pdf"))
                            {
                                try
                                {
                                    axAcroPDF2.LoadFile(Application.StartupPath +"\\" + pdfEntity.AttachmentPath);
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

            //添加初步诊断和既往病史
            TabIndex = TabIndex + 1;
            tabControl1.TabPages.Insert(TabIndex, tabPage5);
            tabControl1.TabPages.Insert(TabIndex + 1, tabPage6);
        }
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
            tabControl1.TabPages.Remove(tabPage9);
            tabControl1.TabPages.Remove(tabPage10);
        }

        /// <summary>
        /// 将本地指定数据同步到公网
        /// </summary>
        private void dataUpload(SResult rst)
        {
            #region + 会诊记录表

            DataTable _dtHz = MySQLHelper.ExecuteDataTable(SqlUtil.F_OutsideConnectionString, CommandType.Text, "select id from t_clinicar_consultation where id in (" + ((ClinicarConsultation)rst.data).Id + ")");
            if (_dtHz == null || Convert.IsDBNull(_dtHz) || _dtHz.Rows.Count <= 0)
            {
                try
                {
                    string sql = "insert into t_clinicar_consultation values ("
                                + "'" + ((ClinicarConsultation)rst.data).Id + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ApplyHospitalCode + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ApplyHospitalName + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ApplyHospitalTel + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ApplyHospitalDate + "',"
                                + "'" + ((ClinicarConsultation)rst.data).HospitalCode + "',"
                                + "'" + ((ClinicarConsultation)rst.data).HospitalName + "',"
                                + "'" + ((ClinicarConsultation)rst.data).DeptCode + "',"
                                + "'" + ((ClinicarConsultation)rst.data).DeptName + "',"
                                + "'" + ((ClinicarConsultation)rst.data).UserName + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ConsultationDate + "',"
                                + "'" + ((ClinicarConsultation)rst.data).ConsultationType + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Name + "',"
                                + "'" + ((ClinicarConsultation)rst.data).CheckNumber + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Sex + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Age + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Married + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Cardnumber + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Tel + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Diagnosis + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Medicalhistory + "',"
                                + "'" + ((ClinicarConsultation)rst.data).Results + "'"
                                + " )";
                    MySQLHelper.ExecuteNonQuery(SqlUtil.F_OutsideConnectionString, CommandType.Text, sql);
                }
                catch (Exception exception)
                {
                    UcMessageBox.Error("申请会诊数据上传失败 -- ", exception.Message + "\r\n" + exception.StackTrace + "\r\n" + exception.Source);
                }
            }
            #endregion

            #region + 检查结果表

            if (F_checkResultList != null && F_checkResultList.Count > 0)
            {
                StringBuilder strId = new StringBuilder();
                foreach (ClinicarCheckResult r in F_checkResultList)
                {
                    DataTable _dtJg = MySQLHelper.ExecuteDataTable(SqlUtil.F_OutsideConnectionString, CommandType.Text, "select id from t_clinicar_check_result where id in (" + r.Id + ")");
                    if (_dtJg == null || Convert.IsDBNull(_dtJg) || _dtJg.Rows.Count <= 0)
                    {
                        strId.Append(r.Id);
                        strId.Append(",");
                    }
                }
                if (strId.Length > 0)
                {
                    strId.Remove(strId.Length - 1, 1);
                }
                else
                {
                    strId.Append("0");
                }
                //获取本地数据，并过滤掉服务器已有的数据
                DataTable _dt = MySQLHelper.ExecuteDataTable(SqlUtil.F_LocalConnectionString, CommandType.Text, "select * from t_clinicar_check_result where id in (" + strId + ")");
                if (_dt != null && Convert.IsDBNull(_dt) == false && _dt.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            string sql = "insert into t_clinicar_check_result values ("
                                       + "'" + _dt.Rows[i][0] + "',"
                                       + _dt.Rows[i][1] + ","
                                       + "'" + _dt.Rows[i][2] + "',"
                                       + "'" + _dt.Rows[i][3] + "',"
                                       + "'" + _dt.Rows[i][4] + "',"
                                       + "'" + _dt.Rows[i][5] + "',"
                                       + "'" + _dt.Rows[i][6] + "',"
                                       + "'" + _dt.Rows[i][7] + "',"
                                       + "'" + _dt.Rows[i][8] + "',"
                                       + "'" + _dt.Rows[i][9] + "',"
                                       + "'" + _dt.Rows[i][10] + "',"
                                       + "'" + _dt.Rows[i][11].ToString().Replace(@"\", @"\\") + "',"
                                       + "'" + _dt.Rows[i][12] + "',"
                                       + "'" + _dt.Rows[i][13] + "',"
                                       + "'" + _dt.Rows[i][14] + "'"
                                       + " )";

                            this.uploadFile(_dt.Rows[i][11].ToString(), _dt.Rows[i][3].ToString());     //上传文件
                            MySQLHelper.ExecuteNonQuery(SqlUtil.F_OutsideConnectionString, CommandType.Text, sql);
                        }
                    }
                    catch (Exception exception)
                    {
                        UcMessageBox.Error("检查结果表数据上传失败 -- " + exception.Message + "\r\n" + exception.StackTrace + "\r\n" + exception.Source);
                    }

                }
            }

            #endregion
        }

        #region + 文件类上传相关
        /// <summary>
        /// 上传文件方法
        /// relativePath ：数据库中文件的相对路径
        /// </summary>
        private void uploadFile(string relativePath, string checkNumber)
        {
            string strFilePath = strLocalFilePath;          //需要上传的本地文件固定路径前缀
            strFilePath = strFilePath + relativePath;           //拼接路径
            if (!File.Exists(strFilePath)) return;
            //获取外网ftp地址
            int indexStart = SqlUtil.F_OutsideConnectionString.IndexOf("=") + 1;
            int indexEnd = SqlUtil.F_OutsideConnectionString.IndexOf(";");
            ftpUristring = "ftp://" + SqlUtil.F_OutsideConnectionString.Substring(indexStart, indexEnd - indexStart);

            //B超报告同步
            string bcPath = strLocalFilePath + @"bc\data\" + checkNumber + @"\";
            DirectoryInfo bcDir = new DirectoryInfo(bcPath);
            if (bcDir.Exists)
            {
                FileInfo[] files = bcDir.GetFiles("*.html");
                if (files != null && files.Length > 0)
                {
                    try
                    {
                        string uri = GetUriString(@"bc\data\" + checkNumber + @"\" + files[0].Name);
                        //检查目录是否存在，不存在创建
                        FtpCheckDirectoryExist(@"bc\data\" + checkNumber + @"\" + files[0].Name);
                        FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.UploadFile);
                        request.ContentLength = files[0].Length;
                        int buflength = 8196;
                        byte[] buffer = new byte[buflength];
                        FileStream filestream = files[0].OpenRead();
                        Stream responseStream = request.GetRequestStream();
                        //lstbxFtpState.Items.Add("打开上传流，文件上传中...");
                        int contenlength = filestream.Read(buffer, 0, buflength);
                        while (contenlength != 0)
                        {
                            responseStream.Write(buffer, 0, contenlength);
                            contenlength = filestream.Read(buffer, 0, buflength);
                        }
                        responseStream.Close();
                        filestream.Close();
                        FtpWebResponse response = GetFtpResponse(request);
                        if (response == null)
                        {
                            UcMessageBox.Warning("服务器未响应...", "提示");
                        }
                    }
                    catch (WebException ex)
                    {
                        UcMessageBox.Error("上传发生错误，返回信息为：" + ex.Status, "提示");
                    }
                }
            }


            FileInfo fileinfo = new FileInfo(strFilePath);
            try
            {
                string uri = GetUriString(relativePath.Replace("\\", "/"));
                //检查目录是否存在，不存在创建
                FtpCheckDirectoryExist(relativePath);
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.UploadFile);
                request.ContentLength = fileinfo.Length;
                int buflength = 8196;
                byte[] buffer = new byte[buflength];
                FileStream filestream = fileinfo.OpenRead();
                Stream responseStream = request.GetRequestStream();
                //lstbxFtpState.Items.Add("打开上传流，文件上传中...");
                int contenlength = filestream.Read(buffer, 0, buflength);
                while (contenlength != 0)
                {
                    responseStream.Write(buffer, 0, contenlength);
                    contenlength = filestream.Read(buffer, 0, buflength);
                }

                responseStream.Close();
                filestream.Close();
                FtpWebResponse response = GetFtpResponse(request);
                if (response == null)
                {
                    UcMessageBox.Warning("服务器未响应...", "提示");
                }
            }
            catch (WebException ex)
            {
                UcMessageBox.Error("上传发生错误，返回信息为：" + ex.Status, "提示");
            }
        }

        private string GetUriString(string relativePath)
        {
            string uri = string.Empty;
            string currentDir = "/";
            uri = ftpUristring + currentDir + relativePath;
            return uri;
        }

        #region 与服务器的交互

        // 创建FTP连接
        private FtpWebRequest CreateFtpWebRequest(string uri, string requestMethod)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            string _ftpUser = System.Configuration.ConfigurationManager.AppSettings["ftp-user"];
            string _ftpPwd = System.Configuration.ConfigurationManager.AppSettings["ftp-pwd"];
            //指定用户登陆
            NetworkCredential networkCredential = new NetworkCredential(_ftpUser, _ftpPwd);
            request.Credentials = networkCredential;
            request.KeepAlive = false;
            request.Method = requestMethod;
            request.UseBinary = true;
            return request;
        }

        // 获取服务器返回的响应体
        private FtpWebResponse GetFtpResponse(FtpWebRequest request)
        {
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
                return response;
            }
            catch (WebException ex)
            {
                UcMessageBox.Error("发送错误，返回信息为：" + ex.Status, "提示");
                return null;
            }
        }
        #endregion

        #region + 创建目录相关
        //判断文件的目录是否存,不存则创建
        public void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath.Replace(@"\", @"/"));
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空  
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        //创建目录
        public Boolean FtpMakeDir(string localFile)
        {
            string _ftpUser = System.Configuration.ConfigurationManager.AppSettings["ftp-user"];
            string _ftpPwd = System.Configuration.ConfigurationManager.AppSettings["ftp-pwd"];
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpUristring + localFile);
            req.Credentials = new NetworkCredential(_ftpUser, _ftpPwd);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }
        #endregion

        #region + 预览报告
        private void viewReport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uTxt_checknumber.Text))
            {
                string filePath = Application.StartupPath;
                DirectoryInfo newFolder = new DirectoryInfo(filePath + @"\bc\data\" + uTxt_checknumber.Text);
                FileInfo[] htmlFiles = newFolder.GetFiles("*.html");
                if (htmlFiles.Length > 0)
                {
                    string url = filePath + @"\bc\data\" + uTxt_checknumber.Text + @"\" + htmlFiles[0].Name;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uTxt_checknumber.Text))
            {
                string filePath = Application.StartupPath;
                DirectoryInfo newFolder = new DirectoryInfo(filePath + @"\xRayFolder\data\" + uTxt_checknumber.Text);
                if (newFolder != null && newFolder.Exists)
                {
                    FileInfo[] bmpFiles = newFolder.GetFiles("*.bmp");
                    if (bmpFiles.Length > 0)
                    {
                        string url = filePath+@"\xRayFolder\data\" + uTxt_checknumber.Text + @"\" + bmpFiles[0].Name;
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

            //if (pictureBox1.Image != null)
            //{
            //    if (fp == null || fp.IsDisposed)
            //        fp = new FrmPView();
            //    fp.image = pictureBox1.Image;
            //    fp.Show();
            //}
        }
        #endregion
        #region + 从FTP下载文件
        /// <summary>
        /// 医院端专用，从服务器下载本次明细的相关附件
        /// </summary>
        private void downLoadFiles()
        {
            if (DataEntity != null)
            {
                //根据检查号查询所有检查结果
                IList<ClinicarCheckResult> list = clinicarCheckResultBiz.FindEntity(DataEntity.CheckNumber);
                if (list.Count > 0)
                {
                    foreach (ClinicarCheckResult cr in list)
                    {
                        if (cr.AttachmentPath != null && !"".Equals(cr.AttachmentPath))
                            downLoadFromFTP(cr.AttachmentPath);
                        if (cr.ReportPath != null && !"".Equals(cr.ReportPath))
                        {
                            downLoadFromFTP(cr.ReportPath);
                            downLoadFromFTP(@"bc\ReportLOGO.bmp");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 从FTP服务器下载文件
        /// </summary>
        /// <param name="relativePath">文件相对地址</param>
        private void downLoadFromFTP(string relativePath)
        {
            //获取外网ftp地址
            int indexStart = SqlUtil.F_OutsideConnectionString.IndexOf("=") + 1;
            int indexEnd = SqlUtil.F_OutsideConnectionString.IndexOf(";");
            ftpUristring = "ftp://" + SqlUtil.F_OutsideConnectionString.Substring(indexStart, indexEnd - indexStart);
            string _ftpUser = System.Configuration.ConfigurationManager.AppSettings["ftp-user"];
            string _ftpPwd = System.Configuration.ConfigurationManager.AppSettings["ftp-pwd"];
            FtpWebRequest reqFTP;
            try
            {
                string filePath = Application.StartupPath;
                string fullDir = FtpParseDirectory((filePath + "\\" + relativePath).Replace(@"\", @"/"));
                //如果文件存在则不下载
                if (!System.IO.File.Exists(filePath + "\\" + relativePath))
                {
                    if (!System.IO.Directory.Exists(fullDir))
                    {
                        System.IO.Directory.CreateDirectory(fullDir);
                    }
                    FileStream outputStream = new FileStream(filePath + "\\" + relativePath, FileMode.Create);
                    string uri = GetUriString(relativePath.Replace("\\", "/"));
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(_ftpUser, _ftpPwd);
                    reqFTP.UsePassive = false;
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    long cl = response.ContentLength;
                    int bufferSize = 8196;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }
                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #endregion

        
    }
}
