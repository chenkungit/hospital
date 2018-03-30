using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 登记（检查信息表）
    /// </summary>
    [ActiveRecord("t_clinicar_check")]
    public class ClinicarCheck : SCommon.SBase.SBaseModel<ClinicarCheck>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public String Id { get; set; }

        /// <summary>
        /// 检查号
        /// </summary>
        [Property("check_number")]
        [SCommon.SAttribute.SModelProperty("check_number", Display = "检查号")]
        public String CheckNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Property("name")]
        [SCommon.SAttribute.SModelProperty("name", Display = "姓名")]
        public String Name { get; set; }

        /// <summary>
        /// 性别编码
        /// </summary>
        [Property("gender_code")]
        [SCommon.SAttribute.SModelProperty("gender_code", Display = "性别编码")]
        public String GenderCode { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Property("gender_name")]
        [SCommon.SAttribute.SModelProperty("gender_name", Display = "性别")]
        public String GenderName { get; set; }

        /// <summary>
        /// 民族编号
        /// </summary>
        [Property("nationality_code")]
        [SCommon.SAttribute.SModelProperty("nationality_code", Display = "民族编号")]
        public String NationalityCode { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Property("nationality_name")]
        [SCommon.SAttribute.SModelProperty("nationality_name", Display = "民族")]
        public String NationalityName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Property("birthday")]
        [SCommon.SAttribute.SModelProperty("birthday", Display = "出生日期")]
        public String Birthday { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Property("age")]
        [SCommon.SAttribute.SModelProperty("age", Display = "年龄")]
        public Int32 Age { get; set; }

        /// <summary>
        /// 婚姻状况编码
        /// </summary>
        [Property("marital_status_code")]
        [SCommon.SAttribute.SModelProperty("marital_status_code", Display = "婚姻状况编码")]
        public String MaritalStatusCode { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        [Property("marital_status_name")]
        [SCommon.SAttribute.SModelProperty("marital_status_name", Display = "婚姻状况")]
        public String MaritalStatusName { get; set; }

        /// <summary>
        /// 证件类型编码
        /// </summary>
        [Property("certificate_type_code")]
        [SCommon.SAttribute.SModelProperty("certificate_type_code", Display = "证件类型编码")]
        public String CertificateTypeCode { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [Property("certificate_type_name")]
        [SCommon.SAttribute.SModelProperty("certificate_type_name", Display = "证件类型")]
        public String CertificateTypeName { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        [Property("certificate_number")]
        [SCommon.SAttribute.SModelProperty("certificate_number", Display = "证件号")]
        public String CertificateNumber { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Property("address")]
        [SCommon.SAttribute.SModelProperty("address", Display = "地址")]
        public String Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Property("tel")]
        [SCommon.SAttribute.SModelProperty("tel", Display = "联系电话")]
        public String Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }

        /// <summary>
        /// 开单医生
        /// </summary>
        [Property("check_doctor")]
        [SCommon.SAttribute.SModelProperty("check_doctor", Display = "开单医生")]
        public String CheckDoctor { get; set; }

        /// <summary>
        /// 检查日期（yyyy-MM-dd）
        /// </summary>
        [Property("check_date")]
        [SCommon.SAttribute.SModelProperty("check_date", Display = "检查日期")]
        public String CheckDate { get; set; }

        /// <summary>
        /// 结论
        /// </summary>
        [Property("conclusion")]
        [SCommon.SAttribute.SModelProperty("conclusion", Display = "结论")]
        public String Conclusion { get; set; }

        /// <summary>
        /// 建议
        /// </summary>
        [Property("advice")]
        [SCommon.SAttribute.SModelProperty("advice", Display = "建议")]
        public String Advice { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Property("deleted")]
        [SCommon.SAttribute.SModelProperty("enabled", Display = "删除标记")]
        public Boolean Deleted { get; set; }
        /// <summary>
        /// 总检完成标记
        /// </summary>
        [Property("allcheck_completed")]
        [SCommon.SAttribute.SModelProperty("allcheck_completed", Display = "总检完成")]
        public Boolean AllcheckCompleted { get; set; }

        /// <summary>
        /// 病种
        /// </summary>
        [Property("disease")]
        [SCommon.SAttribute.SModelProperty("disease", Display = "病种")]
        public String Disease { get; set; }
    }
}
