using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SBase
{
    public class SBaseDao<T, PK> : SCommon.CARecord.CARBaseDao<T, PK> where T : class
    {
    }
}
