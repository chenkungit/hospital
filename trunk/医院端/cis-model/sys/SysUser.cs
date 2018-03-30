using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace cis_model.sys
{
    /// <summary>
    /// 转向管理
    /// </summary>
    [ActiveRecord("t_sys_user")]
    public class SysUser : SCommon.SBase.SBaseModel<SysUser>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(PrimaryKeyType.Identity, "id")]
        [SCommon.SAttribute.SModelProperty("id", Display = "主键")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Property("username")]
        [SCommon.SAttribute.SModelProperty("username", Display = "用户名")]
        public String Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Property("password")]
        [SCommon.SAttribute.SModelProperty("password", Display = "密码")]
        public String Password { get; set; }

        /// <summary>
        /// 用户类型（01=管理员；11=运维人员；21=业务人员）
        /// </summary>
        [Property("user_type")]
        [SCommon.SAttribute.SModelProperty("user_type", Display = "用户类型")]
        public String UserType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Property("full_name")]
        [SCommon.SAttribute.SModelProperty("full_name", Display = "姓名")]
        public String FullName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Property("tel")]
        [SCommon.SAttribute.SModelProperty("tel", Display = "电话")]
        public String Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property("remark")]
        [SCommon.SAttribute.SModelProperty("remark", Display = "备注")]
        public String Remark { get; set; }
    }
}
