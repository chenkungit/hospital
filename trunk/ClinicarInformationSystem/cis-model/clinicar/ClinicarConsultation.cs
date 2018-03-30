using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 申请会诊
    /// </summary>
    [ActiveRecord("t_clinicar_consultation")]
    public class ClinicarConsultation : SCommon.SBase.SBaseModel<ClinicarConsultation>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// 
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 申请医院编码
        /// </summary>
        [Property("applyhospitalcode")]
        [SCommon.SAttribute.SModelProperty("applyhospitalcode", Display = "申请医院编码")]
        public string ApplyHospitalCode { get; set; }
        /// <summary>
        /// 申请医院名称
        /// </summary>
        [Property("applyhospitalname")]
        [SCommon.SAttribute.SModelProperty("applyhospitalname", Display = "申请医院名称")]
        public string ApplyHospitalName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Property("applyhospitaltel")]
        [SCommon.SAttribute.SModelProperty("applyhospitaltel", Display = "申请医院联系电话")]
        public string ApplyHospitalTel { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        [Property("applyhospitaldate")]
        [SCommon.SAttribute.SModelProperty("applyhospitaldate", Display = "申请日期")]
        public DateTime ApplyHospitalDate { get; set; }
        /// <summary>
        /// 会诊医院编码
        /// </summary>
        [Property("hospitalcode")]
        [SCommon.SAttribute.SModelProperty("hospitalcode", Display = "会诊医院编码")]
        public string HospitalCode { get; set; }
        /// <summary>
        /// 会诊医院名称
        /// </summary>
        [Property("hospitalname")]
        [SCommon.SAttribute.SModelProperty("hospitalname", Display = "会诊医院名称")]
        public string HospitalName { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
        [Property("deptcode")]
        [SCommon.SAttribute.SModelProperty("deptcode", Display = "科室编码")]
        public String DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [Property("deptname")]
        [SCommon.SAttribute.SModelProperty("deptname", Display = "科室名称")]
        public String DeptName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Property("username")]
        [SCommon.SAttribute.SModelProperty("username", Display = "用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        [Property("name")]
        [SCommon.SAttribute.SModelProperty("name", Display = "患者姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 检查号
        /// </summary>
        [Property("check_number")]
        [SCommon.SAttribute.SModelProperty("check_number", Display = "检查号")]
        public string CheckNumber { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Property("sex")]
        [SCommon.SAttribute.SModelProperty("sex", Display = "性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Property("age")]
        [SCommon.SAttribute.SModelProperty("age", Display = "年龄")]
        public string Age { get; set; }
        /// <summary>
        /// 婚否
        /// </summary>
        [Property("married")]
        [SCommon.SAttribute.SModelProperty("married", Display = "婚否")]
        public string Married { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Property("cardnumber")]
        [SCommon.SAttribute.SModelProperty("cardnumber", Display = "身份证号")]
        public string Cardnumber { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Property("tel")]
        [SCommon.SAttribute.SModelProperty("tel", Display = "联系电话")]
        public string Tel { get; set; }
        /// <summary>
        /// 申请会诊日期
        /// </summary>
        [Property("consultationdate")]
        [SCommon.SAttribute.SModelProperty("consultationdate", Display = "申请会诊日期")]
        public DateTime ConsultationDate { get; set; }
        /// <summary>
        /// 申请会诊日期类型
        /// </summary>
        [Property("consultationtype")]
        [SCommon.SAttribute.SModelProperty("consultationtype", Display = "申请会诊日期类型")]
        public string ConsultationType { get; set; }
        /// <summary>
        /// 初步诊断
        /// </summary>
        [Property("diagnosis")]
        [SCommon.SAttribute.SModelProperty("diagnosis", Display = "初步诊断")]
        public string Diagnosis { get; set; }
        /// <summary>
        /// 申请会诊日期类型
        /// </summary>
        [Property("medicalhistory")]
        [SCommon.SAttribute.SModelProperty("medicalhistory", Display = "病史")]
        public string Medicalhistory { get; set; }

        /// <summary>
        /// 会诊结果
        /// </summary>
        [Property("results")]
        [SCommon.SAttribute.SModelProperty("results", Display = "会诊结果")]
        public string Results { get; set; }
        
    }
}
