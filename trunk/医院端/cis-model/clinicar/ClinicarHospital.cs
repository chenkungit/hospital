using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.clinicar
{
    /// <summary>
    /// 医院信息
    /// </summary>
    [ActiveRecord("t_clinicar_hospital")]
    public class ClinicarHospital : SCommon.SBase.SBaseModel<ClinicarHospital>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// 
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>
        [Property("hospitalcode")]
        [SCommon.SAttribute.SModelProperty("hospitalcode", Display = "医院编码")]
        public string HospitalCode { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        [Property("hospitalname")]
        [SCommon.SAttribute.SModelProperty("hospitalname", Display = "医院名称")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public string Remark { get; set; }
    }
}
