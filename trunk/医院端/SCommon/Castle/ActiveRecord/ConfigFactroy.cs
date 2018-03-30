using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SCommon.CARecord
{

    public class ConfigFactroy
    {
        public static void InitConnection(SCommon.SUtil.SConstants.S_DbType type, string connection_string, Assembly assembly)
        {
            switch (type)
            {
                case SCommon.SUtil.SConstants.S_DbType.MSSQL:
                    break;

                case SCommon.SUtil.SConstants.S_DbType.MySQL:

                    InPlaceConfigurationSource source = new InPlaceConfigurationSource();
                    IDictionary<string, string> properties = new Dictionary<string, string>();
                    properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");

                    properties.Add("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
                    properties.Add("dialect", "NHibernate.Dialect.MySQLDialect");
                    properties.Add("connection.connection_string", connection_string);

                    // 数据库连接配置  
                    source.Add(typeof(ActiveRecordBase), properties);

                    // 载入程序集中所有 ActiveRecord 类。  
                    ActiveRecordStarter.Initialize(assembly, source);

                    // 自主载入指定类型  
                    //ActiveRecordStarter.Initialize(source, typeof(ActiveRecordBase), typeof(User), typeof(Base));  

                    // 删除数据库架构  
                    //ActiveRecordStarter.DropSchema();  

                    // 创建数据库架构(该方法会删除同名表后再创建)  
                    //ActiveRecordStarter.CreateSchema();
                    break;
            }
        }
    }
}
