using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SCommon;

namespace SCommon.SQL
{
    public sealed class SqlUtil
    {
        /// <summary>
        /// 本地数据库连接串
        /// </summary>
        [Category("User-Defined"), Description("获取 本地数据库连接")]
        public static String F_LocalConnectionString
        { get { return System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString; } }

        /// <summary>
        /// 公网数据库连接串
        /// </summary>
        [Category("User-Defined"), Description("获取 公网数据库连接")]
        public static String F_OutsideConnectionString
        { get { return System.Configuration.ConfigurationManager.ConnectionStrings["outSidelConn"].ConnectionString; } }
    }
}
