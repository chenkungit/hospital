using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 项目管理
    /// </summary>
    [ActiveRecord("t_clinicar_item")]
    public class ClinicarItem : SCommon.SBase.SBaseModel<ClinicarItem>
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
        public String Name { get; set; }

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
        /// 检查设备编号，用于接口对接
        /// </summary>
        [Property("device_code")]
        [SCommon.SAttribute.SModelProperty("device_code", Display = "检查设备编号")]
        public String DeviceCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }

        /// <summary>
        /// 已启用
        /// </summary>
        [Property("enabled")]
        [SCommon.SAttribute.SModelProperty("enabled", Display = "启用")]
        public Boolean Enabled { get; set; }
    }
}
