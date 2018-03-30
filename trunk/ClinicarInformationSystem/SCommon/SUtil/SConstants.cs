using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SConstants
    {
        public enum S_ORM_TYPE {
            Custom, NHibernate, CastleActiveRecord
        }

        public enum S_DbType
        {
            MSSQL, MySQL, Oracle
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static S_DbType DEFAULT_DB_TYPE { get; set; }

        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string DEFAULT_DB_CONN_STRING { get; set; }

        /// <summary>
        /// 底层框架
        /// </summary>
        public static S_ORM_TYPE DEFAULT_ORM_TYPE { get; set; }
    }
}
