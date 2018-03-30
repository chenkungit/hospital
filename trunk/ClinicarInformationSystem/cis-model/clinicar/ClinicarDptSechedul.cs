using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 科室排班
    /// </summary>
    [ActiveRecord("t_clinicar_dpt_sechedul")]
    public class ClinicarDptSechedul : SCommon.SBase.SBaseModel<ClinicarDptSechedul>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// 
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 排班日期
        /// </summary>
        [Property("sechedulDate")]
        [SCommon.SAttribute.SModelProperty("sechedulDate", Display = "排班日期")]
        public DateTime SechedulDate { get; set; }

        /// <summary>
        /// 排班类型
        /// </summary>
        [Property("sechedulType")]
        [SCommon.SAttribute.SModelProperty("sechedulType", Display = "排班类型")]
        public String SechedulType { get; set; }

        /// <summary>
        /// 科室编码
        /// </summary>
        [Property("deptCode")]
        [SCommon.SAttribute.SModelProperty("deptCode", Display = "科室编码")]
        public string DeptCode { get; set; }
    }
}
