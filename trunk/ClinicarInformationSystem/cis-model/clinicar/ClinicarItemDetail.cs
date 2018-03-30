using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 项目管理--具体检查项目
    /// </summary>
    [ActiveRecord("t_clinicar_item_detail")]
    public class ClinicarItemDetail : SCommon.SBase.SBaseModel<ClinicarItemDetail>
    {
        /// <summary>
        /// 主键(项目代码)
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Assigned, "code")]
        [SCommon.SAttribute.SModelProperty("code", Display = "项目编号")]
        public String Id { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Property("name")]
        [SCommon.SAttribute.SModelProperty("name", Display = "项目名称")]
        public String DetailName { get; set; }

        /// <summary>
        /// item_code
        /// </summary>
        [Property("item_code")]
        [SCommon.SAttribute.SModelProperty("item_code", Display = "检查项目代码")]
        public String ItemCode { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Property("unit")]
        [SCommon.SAttribute.SModelProperty("unit", Display = "单位")]
        public String Unit { get; set; }
    }
}
