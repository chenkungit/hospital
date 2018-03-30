using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.sys
{
    /// <summary>
    /// 转向管理
    /// </summary>
    [ActiveRecord("t_sys_dict")]
    public class SysDic : SCommon.SBase.SBaseModel<SysDic>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Property("code")]
        [SCommon.SAttribute.SModelProperty("code", Display = "代码")]
        public String Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Property("name")]
        [SCommon.SAttribute.SModelProperty("name", Display = "名称")]
        public String Name { get; set; }

        /// <summary>
        /// 上级代码
        /// </summary>
        [Property("pcode")]
        [SCommon.SAttribute.SModelProperty("pcode", Display = "上级代码")]
        public String Pcode { get; set; }

        /// <summary>
        /// 字典类型（1：字典大类 2：字典数据）
        /// </summary>
        [Property("sort")]
        [SCommon.SAttribute.SModelProperty("sort", Display = "字典类型")]
        public String Sort { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Property("enabled")]
        [SCommon.SAttribute.SModelProperty("enabled", Display = "有效标志")]
        public String Enabled { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [Property("display_order")]
        [SCommon.SAttribute.SModelProperty("display_order", Display = "显示顺序")]
        public String DisplayOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }
    }
}
