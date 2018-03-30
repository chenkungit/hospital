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
    public partial class FrmClinihospitalMyConsultationManage : SCommon.SControl.SBaseForm
    {
        private ClinicarConsultationBiz clinicarConsultationBiz = new ClinicarConsultationBiz();
        public ClinicarConsultation DataEntity { get; set; }

        public FrmClinihospitalMyConsultationManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarDptManage_Load(object sender, EventArgs e)
        {
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
                this.Fill2Win();
            }
            else
            {
                //回填已有的数据
                uTxt_hospitalname.Text = DataEntity.HospitalName;
                uTxt_deptname.Text = DataEntity.DeptName;
                uDtp_consultationdate.Value = DataEntity.ConsultationDate;
            }
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
                    
                }
                else if (this.DialogStatus == UBaseLib.Enums.DialogStatus.Modify) //修改
                {
                    this.Fill2Entity();
                    rst = clinicarConsultationBiz.Update(this.DataEntity);
                }
                if (rst.success)
                {
                    this.DialogResult = DialogResult.OK;
                    UcMessageBox.Information("保存成功.", "提示");
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    UcMessageBox.Error("保存失败", "提示");
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
                UcMessageBox.Warning("请输入患者姓名！","提示");
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
            this.DataEntity.Results = ric_results.Text;
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
            ric_results.Text = DataEntity.Results;
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
    }
}
