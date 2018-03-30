using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 科室管理
    /// </summary>
    [ActiveRecord("t_clinicar_dpt")]
    public class ClinicarDpt : SCommon.SBase.SBaseModel<ClinicarDpt>
    {
        /// <summary>
        /// 主键(项目代码)
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Assigned, "code")]
        [SCommon.SAttribute.SModelProperty("code", Display = "科室编号")]
        public String Id { get; set; }

        /// <summary>
        /// 医院代码
        /// </summary>
        [Property("hospitalcode")]
        [SCommon.SAttribute.SModelProperty("hospitalcode", Display = "医院代码")]
        public String Hospitalcode { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Property("hospitalname")]
        [SCommon.SAttribute.SModelProperty("hospitalname", Display = "医院名称")]
        public String Hospitalname { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Property("name")]
        [SCommon.SAttribute.SModelProperty("name", Display = "科室名称")]
        public String Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Property("enabled")]
        [SCommon.SAttribute.SModelProperty("enabled", Display = "启用")]
        public Boolean Enabled { get; set; }
    }
}
