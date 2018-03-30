using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SCommon
{
    public class SInit
    {
        public static void InitDataBase(SConstants.S_DbType dbType, String strConn, SConstants.S_ORM_TYPE ormType,Assembly _assembly)
        {
            SConstants.DEFAULT_DB_TYPE = dbType;
            SConstants.DEFAULT_DB_CONN_STRING = strConn;
            SConstants.DEFAULT_ORM_TYPE = ormType;

            switch (SConstants.DEFAULT_ORM_TYPE)
            {
                case SConstants.S_ORM_TYPE.Custom:
                    break;

                case SConstants.S_ORM_TYPE.NHibernate:
                    break;

                case SConstants.S_ORM_TYPE.CastleActiveRecord:
                    SCommon.CARecord.ConfigFactroy.InitConnection(SConstants.DEFAULT_DB_TYPE, SConstants.DEFAULT_DB_CONN_STRING, _assembly);
                    break;
            }
        }
    }
}
