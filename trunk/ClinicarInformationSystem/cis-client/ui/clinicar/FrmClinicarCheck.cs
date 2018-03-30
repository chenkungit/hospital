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
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UBaseLib.Enums;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarCheck : SCommon.SControl.SBaseDockForm
    {
        #region + 属性

        /// <summary>
        /// 需要显示的列表
        /// </summary>
        private String[] displayProperties =
        {
            "ItemCode", "ItemName","DptName","completed"
        };

        /// <summary>
        /// 列表
        /// </summary>
        private readonly DataGridView dgrdView;

        /// <summary>
        /// 登记表主表业务层
        /// </summary>
        private ClinicarCheckBiz clinicarCheckBiz = new ClinicarCheckBiz();

        /// <summary>
        /// 登记表子表业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();

        /// <summary>
        /// 实体类
        /// </summary>
        public ClinicarCheck DataEntity { get; set; }

        /// <summary>
        /// 实体类（用于传值）
        /// </summary>
        public ClinicarCheck DataEntityTransmit { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        private int DataEntityId = 0;

        #endregion

        #region + 构造方法
        public FrmClinicarCheck()
        {
            InitializeComponent();
            this.dgrdView = this.ucDgv_list.UcDataGridViewControl;
            this.dgrdView.BackgroundColor = Color.White;
            this.ucDgv_list.UcDataGridViewControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        #region + 事件
        private void FrmClinicarCheck_Load(object sender, EventArgs e)
        {
            #region + 初始化控件

            //性别
            uCbo_genderCode.DataSource = Constant.GetGenderCodeData(DicSort.GenderCode).ToList();
            uCbo_genderCode.DisplayMember = "Value";
            uCbo_genderCode.ValueMember = "Key";
            uCbo_genderCode.SelectedIndex = -1;
            //民族
            uCbo_nationalityCode.DataSource = Constant.GetNationalityCodeData(DicSort.NationalityCode).ToList();
            uCbo_nationalityCode.DisplayMember = "Value";
            uCbo_nationalityCode.ValueMember = "Key";
            uCbo_nationalityCode.SelectedIndex = -1;
            //婚姻
            uCbo_maritalStatusCode.DataSource = Constant.GetMaritalStatusCodeData(DicSort.MaritalStatusCode).ToList();
            uCbo_maritalStatusCode.DisplayMember = "Value";
            uCbo_maritalStatusCode.ValueMember = "Key";
            uCbo_maritalStatusCode.SelectedIndex = -1;
            //证件类型
            uCbo_certificateTypeCode.DataSource = Constant.GetCertificateTypeCodeData(DicSort.CertificateTypeCode).ToList();
            uCbo_certificateTypeCode.DisplayMember = "Value";
            uCbo_certificateTypeCode.ValueMember = "Key";
            uCbo_certificateTypeCode.SelectedIndex = -1;

            #endregion

            //开单医生
            uTxt_checkDoctor.Text = UserInfo.Username;

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
            SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindByPagination(pageNum, pageSize, DataEntityId);
            IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
            SGridViewUtil.BindingData<ClinicarCheckItem>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);
            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        #region + 判断行是否有数据
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ClinicarCheckItem GetCurrentRowData()
        {
            ClinicarCheckItem entity = null;
            if (this.dgrdView.CurrentRow != null && this.dgrdView.CurrentRow.Index >= 0)
            {
                entity = ((BindingList<ClinicarCheckItem>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
            }
            else
            {
                UcMessageBox.Warning("请先选择要删除的数据", "提示");
            }
            return entity;
        }
        #endregion

        #region + 重填

        /// <summary>
        /// 重填按钮 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_override_Click(object sender, EventArgs e)
        {
            if (DataEntityId != 0)
            {
                UcMessageBox.Warning("人员信息已保存，重填失败！", "提示");
                return;
            }
            cleanInformation();
        }

        /// <summary>
        /// 重填方法
        /// </summary>
        private void cleanInformation()
        {
            uTxt_name.Text = string.Empty;
            uCbo_genderCode.SelectedIndex = -1;
            uCbo_nationalityCode.SelectedIndex = -1;
            uDat_birthday.Value = DateTime.Now;
            uNum_age.Text = string.Empty;
            uCbo_maritalStatusCode.SelectedIndex = -1;
            uCbo_certificateTypeCode.SelectedIndex = -1;
            uTxt_certificateNumber.Text = string.Empty;
            uTxt_address.Text = string.Empty;
            uNum_tel.Text = string.Empty;
            uRic_remark.Text = string.Empty;
            uTxt_checkNumber.Text = string.Empty;
            this.groupBox1.Enabled = true;
            this.groupBox2.Enabled = true;
            DataEntityId = 0;       //缓存的主表Id
        }

        #endregion

        #region + 完成登记
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_finishRegister_Click(object sender, EventArgs e)
        {
            if (this.dgrdView.CurrentRow != null)
            {
                cleanInformation();
                this.ucDgv_list.Search(1);
                UcMessageBox.Information("已完成登记！", "提示");
            }
            else
            {
                UcMessageBox.Warning("请添加检查项目信息！", "提示");
            }

        }
        #endregion

        #region + 下拉框值改变事件

        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCbo_genderCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (uCbo_genderCode.SelectedIndex >= 0)
            {
                uTxt_genderName.Text = Constant.GetGenderCodeDataValue(DicSort.GenderCode, uCbo_genderCode.SelectedValue.ToString());
            }
            else
            {
                uTxt_genderName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 民族
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCbo_nationalityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uCbo_nationalityCode.SelectedIndex >= 0)
            {
                uTxt_nationalityName.Text = Constant.GetNationalityCodeDataValue(DicSort.NationalityCode, uCbo_nationalityCode.SelectedValue.ToString());
            }
            else
            {
                uTxt_nationalityName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 婚姻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCbo_maritalStatusCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uCbo_maritalStatusCode.SelectedIndex >= 0)
            {
                uTxt_maritalStatusName.Text = Constant.GetMaritalStatusCodeDataValue(DicSort.MaritalStatusCode, uCbo_maritalStatusCode.SelectedValue.ToString());
            }
            else
            {
                uTxt_maritalStatusName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 证件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCbo_certificateTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uCbo_certificateTypeCode.SelectedIndex >= 0)
            {
                uTxt_certificateTypeName.Text = Constant.GetCertificateTypeCodeDataValue(DicSort.CertificateTypeCode, uCbo_certificateTypeCode.SelectedValue.ToString());
            }
            else
            {
                uTxt_certificateTypeName.Text = string.Empty;
            }
        }

        #endregion

        #region + 保存主表方法

        private bool saveMaster()
        {
            if (this.CheckBeforeSave())//保存前的校验
            {
                SResult rst = new SResult();
                this.DataEntity = new ClinicarCheck();
                this.DataEntityTransmit = new ClinicarCheck();
                this.Fill2Entity();
                rst = clinicarCheckBiz.Insert(this.DataEntity);
                if (rst.success)
                {
                    DataEntityId = Convert.ToInt32(((cis_model.clinicar.ClinicarCheck)rst.data).Id);
                    this.DataEntityTransmit = (cis_model.clinicar.ClinicarCheck)rst.data;
                    UcMessageBox.Information("人员信息保存成功，请添加项目信息。", "提示！");
                }
                else
                {
                    DataEntityId = 0;
                    UcMessageBox.Error(rst.message);
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
                UcMessageBox.Warning("请输入姓名！", "提示");
                this.uTxt_name.Focus();
                return false;
            }

            if (this.uCbo_genderCode.SelectedIndex < 0)
            {
                UcMessageBox.Warning("请选择性别！", "提示");
                this.uCbo_genderCode.Focus();
                return false;
            }

            if (this.uNum_age.TextLength == 0 || this.uNum_age.UcValue == 0)
            {
                UcMessageBox.Warning("请输入年龄！", "提示");
                this.uNum_age.Focus();
                return false;
            }

            if (this.uCbo_maritalStatusCode.SelectedIndex < 0)
            {
                UcMessageBox.Warning("请选择婚姻状况！", "提示");
                this.uCbo_maritalStatusCode.Focus();
                return false;
            }

            if (this.uTxt_checkDoctor.Text.Trim().Length == 0)
            {
                UcMessageBox.Warning("请输入开单医生！", "提示");
                this.uTxt_checkDoctor.Focus();
                return false;
            }
            

            //生成检查号
            createCheckNumber();
            if (uTxt_checkNumber.TextLength == 0)
            {
                UcMessageBox.Warning("检查号生成失败！", "提示");
                this.uCbo_maritalStatusCode.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            this.DataEntity.Name = this.uTxt_name.Text;
            this.DataEntity.GenderCode = this.uCbo_genderCode.SelectedValue.ToString();
            this.DataEntity.GenderName = this.uTxt_genderName.Text;
            this.DataEntity.NationalityCode = (this.uCbo_nationalityCode.SelectedValue) == null ? "" : (this.uCbo_nationalityCode.SelectedValue.ToString());
            this.DataEntity.NationalityName = this.uTxt_nationalityName.Text;
            this.DataEntity.MaritalStatusCode = this.uCbo_maritalStatusCode.SelectedValue.ToString();
            this.DataEntity.MaritalStatusName = this.uTxt_maritalStatusName.Text;
            this.DataEntity.CertificateTypeCode = (this.uCbo_certificateTypeCode.SelectedValue) == null ? "" : (this.uCbo_certificateTypeCode.SelectedValue.ToString());
            this.DataEntity.CertificateTypeName = this.uTxt_certificateTypeName.Text;
            this.DataEntity.Birthday = this.uDat_birthday.Value.ToString("yyyy-MM-dd");
            this.DataEntity.Age = Convert.ToInt32(this.uNum_age.UcValue);
            this.DataEntity.CertificateNumber = this.uTxt_certificateNumber.Text;
            this.DataEntity.Address = this.uTxt_address.Text;
            this.DataEntity.Tel = (uNum_tel.TextLength==0 || uNum_tel.UcValue.ToString().Equals(""))==true ? "0" : uNum_tel.UcValue.ToString();
            this.DataEntity.Remark = this.uRic_remark.Text;
            this.DataEntity.CheckDoctor = this.uTxt_checkDoctor.Text;
            this.DataEntity.CheckDate = this.uDat_checkDate.Value.ToString("yyyy-MM-dd");
            this.DataEntity.Deleted = false;
            this.DataEntity.CheckNumber = this.uTxt_checkNumber.Text;
        }

        #endregion

        #region + 生成检查号

        /// <summary>
        /// 年月日+四位流水号
        /// </summary>
        private void createCheckNumber()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(uDat_checkDate.Value.Year.ToString().Substring(2));
            stringBuilder.Append(uDat_checkDate.Value.Month.ToString("00"));
            stringBuilder.Append(uDat_checkDate.Value.Day.ToString("00"));

            ClinicarCheck DataEntity = new ClinicarCheck();
            DataEntity = clinicarCheckBiz.FindByCheckNumber(uDat_checkDate.Value.ToString("yyyy-MM-dd"));

            string num = string.Empty;
            if (DataEntity != null && DataEntity.CheckNumber != null)
            {
                num = DataEntity.CheckNumber.ToString().Substring(6, 3);
                stringBuilder.Append((Convert.ToInt32(num) + 1).ToString("000"));
            }
            else
            {
                num = "001";
                stringBuilder.Append(num);
            }

            uTxt_checkNumber.Text = stringBuilder.ToString();
        }

        #endregion

        #region  + 保存人员信息按钮

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_saveMaster_Click(object sender, EventArgs e)
        {
            if (DataEntityId != 0)
            {
                UcMessageBox.Warning("未完成登记！", "提示");
                return;
            }

            if (saveMaster())
            {
                this.DialogResult = DialogResult.OK;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
            }
        }

        #endregion

        #region + 添加项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addItem_Click(object sender, EventArgs e)
        {
            if (DataEntityId == 0)
            {
                UcMessageBox.Warning("请先完成人员信息保存！", "提示");
                return;
            }
            //检查项目选择窗体
            FrmClinicarCheckItemChoose choose = new FrmClinicarCheckItemChoose(DataEntityId);
            choose.dataGridViewTranmit = this.ucDgv_list.UcDataGridViewControl;
            choose.StartPosition = FormStartPosition.CenterScreen;
            choose.ShowDialog();
            this.ucDgv_list.Search(1);
        }

        #endregion

        #region  + 删除项目

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click_1(object sender, EventArgs e)
        {
            ClinicarCheckItem entity = this.GetCurrentRowData();
            if (entity != null && UcMessageBox.Confirm("确定删除?", "提示"))
            {
                //int[] index = this.dgrdView.SelectedRows
                //    .OfType<DataGridViewRow>()
                //    .Select(x => x.Index)
                //    .OrderBy(x => x)
                //    .ToArray();
                //foreach (int i in index)
                //{
                //    entity = ((BindingList<ClinicarCheckItem>)this.dgrdView.DataSource)[i];
                //    clinicarCheckItemBiz.FakeDelete(entity.Id);
                //}

                entity = ((BindingList<ClinicarCheckItem>)this.dgrdView.DataSource)[this.dgrdView.CurrentRow.Index];
                clinicarCheckItemBiz.FakeDelete(entity.Id);
                this.ucDgv_list.Search(1);
            }
        }

        #endregion

        #region + 职员双击选择
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTxt_name_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarCheckPatient frmClinicarCheckPatient = new FrmClinicarCheckPatient();
            frmClinicarCheckPatient.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarCheckPatient.ShowDialog();
            if (frmClinicarCheckPatient.DialogResult == DialogResult.OK)
            {
                uTxt_name.Text = frmClinicarCheckPatient.F_DataEntityTransmit.Name;
                uCbo_genderCode.SelectedValue = frmClinicarCheckPatient.F_DataEntityTransmit.GenderCode;
                uTxt_genderName.Text = frmClinicarCheckPatient.F_DataEntityTransmit.GenderName;
                uCbo_nationalityCode.SelectedValue = frmClinicarCheckPatient.F_DataEntityTransmit.NationalityCode;
                uTxt_nationalityName.Text = frmClinicarCheckPatient.F_DataEntityTransmit.NationalityName;
                uDat_birthday.Value = Convert.ToDateTime(frmClinicarCheckPatient.F_DataEntityTransmit.Birthday);
                uNum_age.Text = frmClinicarCheckPatient.F_DataEntityTransmit.Age.ToString();
                uCbo_maritalStatusCode.SelectedValue = frmClinicarCheckPatient.F_DataEntityTransmit.MaritalStatusCode;
                uTxt_maritalStatusName.Text = frmClinicarCheckPatient.F_DataEntityTransmit.MaritalStatusName;
                uCbo_certificateTypeCode.SelectedValue = frmClinicarCheckPatient.F_DataEntityTransmit.CertificateTypeCode;
                uTxt_certificateTypeName.Text = frmClinicarCheckPatient.F_DataEntityTransmit.CertificateTypeName;
                uTxt_certificateNumber.Text = frmClinicarCheckPatient.F_DataEntityTransmit.CertificateNumber;
                uTxt_address.Text = frmClinicarCheckPatient.F_DataEntityTransmit.Address;
                uNum_tel.Text = frmClinicarCheckPatient.F_DataEntityTransmit.Tel;
                uRic_remark.Text = frmClinicarCheckPatient.F_DataEntityTransmit.Remark;
            }
        }
        #endregion

        #region + 指引单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_guide_Click(object sender, EventArgs e)
        {
            FrmClinicarCheckGuideOrder order = new FrmClinicarCheckGuideOrder(this.DataEntityTransmit);
            order.ShowDialog();
        }
        #endregion
    }
}
