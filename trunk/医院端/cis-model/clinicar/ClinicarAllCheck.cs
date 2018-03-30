using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 总检
    /// </summary>
    [ActiveRecord("t_clinicar_allcheck")]
    public class ClinicarAllCheck : SCommon.SBase.SBaseModel<ClinicarAllCheck>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// 
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 检查码
        /// </summary>
        [Property("check_number")]
        [SCommon.SAttribute.SModelProperty("check_number", Display = "检查码")]
        public string CheckNumber { get; set; }

        /// <summary>
        /// 诊断建议
        /// </summary>
        [Property("advice")]
        [SCommon.SAttribute.SModelProperty("advice", Display = "诊断建议")]
        public String Advice { get; set; }

        /// <summary>
        /// 病种
        /// </summary>
        [Property("disease")]
        [SCommon.SAttribute.SModelProperty("disease", Display = "用户名")]
        public string Disease { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [Property("aduitStatus")]
        [SCommon.SAttribute.SModelProperty("aduitStatus", Display = "审核状态")]
        public bool AduitStatus { get; set; }
    }
}
