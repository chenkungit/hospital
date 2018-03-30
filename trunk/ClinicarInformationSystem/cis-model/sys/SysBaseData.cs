﻿using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.sys
{
    /// <summary>
    /// 基础数据
    /// </summary>
    [ActiveRecord("t_sys_dict")]
    public class SysBaseData : SCommon.SBase.SBaseModel<SysBaseData>
    {
        /// <summary>
        /// 代码
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Assigned, "code")]
        [SCommon.SAttribute.SModelProperty("code", Display = "代码")]
        public String Id { get; set; }

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
        /// 数据类型
        /// </summary>
        [Property("sort")]
        [SCommon.SAttribute.SModelProperty("sort", Display = "数据类型")]
        public String Sort { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        [Property("enabled")]
        [SCommon.SAttribute.SModelProperty("enabled", Display = "启用")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [Property("display_order")]
        [SCommon.SAttribute.SModelProperty("display_order", Display = "显示顺序")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }
    }
}