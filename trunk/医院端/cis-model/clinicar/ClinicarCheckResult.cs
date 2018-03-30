using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 检查项目结果
    /// </summary>
    [ActiveRecord("t_clinicar_check_result")]
    public class ClinicarCheckResult : SCommon.SBase.SBaseModel<ClinicarCheckResult>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        ///// <summary>
        ///// 检查ID（外键）
        ///// </summary>
        //[Property("check_id")]
        //[SCommon.SAttribute.SModelProperty("check_id", Display = "检查ID")]
        //public Int32 CheckId { get; set; }

        /// <summary>
        /// 检查号
        /// </summary>
        [Property("check_number")]
        [SCommon.SAttribute.SModelProperty("check_number", Display = "检查号")]
        public String CheckNumber { get; set; }

        ///// <summary>
        ///// 检查项目ID
        ///// </summary>
        //[Property("check_item_id")]
        //[SCommon.SAttribute.SModelProperty("check_item_id", Display = "检查项目ID")]
        //public Int32 CheckItemId { get; set; }

        /// <summary>
        /// 检查项目编号
        /// </summary>
        [Property("item_code")]
        [SCommon.SAttribute.SModelProperty("item_code", Display = "项目编号")]
        public String ItemCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Property("item_name")]
        [SCommon.SAttribute.SModelProperty("item_name", Display = "项目名称")]
        public String ItemName { get; set; }

        /// <summary>
        /// 明细项代码
        /// </summary>
        [Property("item_detail_code")]
        [SCommon.SAttribute.SModelProperty("item_detail_code", Display = "项目代码")]
        public String DetailCode { get; set; }

        /// <summary>
        /// 明细项名称
        /// </summary>
        [Property("item_detail_name")]
        [SCommon.SAttribute.SModelProperty("item_detail_name", Display = "详细项目")]
        public String DetailName { get; set; }

        /// <summary>
        /// 项目检查结果
        /// </summary>
        [Property("result")]
        [SCommon.SAttribute.SModelProperty("result", Display = "项目结果")]
        public String Result { get; set; }

        /// <summary>
        /// 项目单位
        /// </summary>
        [Property("unit")]
        [SCommon.SAttribute.SModelProperty("unit", Display = "项目单位")]
        public String Unit { get; set; }

        /// <summary>
        /// 结论
        /// </summary>
        [Property("conclusion")]
        [SCommon.SAttribute.SModelProperty("conclusion", Display = "结论")]
        public String Conclusion { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        [Property("attachment_path")]
        [SCommon.SAttribute.SModelProperty("attachment_path", Display = "附件地址")]
        public String AttachmentPath { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Property("deleted")]
        [SCommon.SAttribute.SModelProperty("deleted", Display = "删除标记")]
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
        [Property("dpt_code")]
        [SCommon.SAttribute.SModelProperty("dpt_code", Display = "科室编码")]
        public String DptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [Property("dpt_name")]
        [SCommon.SAttribute.SModelProperty("dpt_name", Display = "科室名称")]
        public String DptName { get; set; }

        /// <summary>
        /// B超报告地址
        /// </summary>
        [Property("report_path")]
        [SCommon.SAttribute.SModelProperty("report_path", Display = "报告地址")]
        public String ReportPath { get; set; }


    }
}
