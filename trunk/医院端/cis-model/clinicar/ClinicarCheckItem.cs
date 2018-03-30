using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 登记检查项目
    /// </summary>
    [ActiveRecord("t_clinicar_check_item")]
    public class ClinicarCheckItem : SCommon.SBase.SBaseModel<ClinicarCheckItem>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 检查ID（外键）
        /// </summary>
        [Property("check_id")]
        [SCommon.SAttribute.SModelProperty("check_id", Display = "检查ID")]
        public Int32 CheckId { get; set; }

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
        /// 科室编号
        /// </summary>
        [Property("dpt_code")]
        [SCommon.SAttribute.SModelProperty("dpt_code", Display = "科室编号")]
        public String DptCode { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [Property("dpt_name")]
        [SCommon.SAttribute.SModelProperty("dpt_name", Display = "科室")]
        public String DptName { get; set; }

        /// <summary>
        /// 该项检查是否完成
        /// </summary>
        [Property("completed")]
        [SCommon.SAttribute.SModelProperty("completed", Display = "检查状态")]
        public Boolean Completed { get; set; }

        /// <summary>
        /// 小结
        /// </summary>
        [Property("summary")]
        [SCommon.SAttribute.SModelProperty("summary", Display = "小结")]
        public String Summary { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Property("deleted")]
        [SCommon.SAttribute.SModelProperty("deleted", Display = "删除标记")]
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 该项检查是否弃检
        /// </summary>
        [Property("canceled")]
        [SCommon.SAttribute.SModelProperty("canceled", Display = "选中")]
        public Boolean Canceled { get; set; }
    }
}
