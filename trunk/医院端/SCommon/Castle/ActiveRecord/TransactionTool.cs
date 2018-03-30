using Castle.ActiveRecord;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.CARecord
{
    public class CastleActiveRecordTool
    {
        /// <summary>
        /// 通过委托，加事务
        /// </summary>
        /// <param name="delegateMethod"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static SResult TransactionAction(Delegate delegateMethod, params object[] args)
        {
            SResult sResult = new SResult();
            TransactionScope scope = new TransactionScope(Castle.ActiveRecord.TransactionMode.Inherits);
            try
            {
                //数据库操作
                object rstData = delegateMethod.DynamicInvoke(args);
                scope.VoteCommit();
                sResult.success = true;
                sResult.data = rstData;
            }
            catch
            {
                scope.VoteRollBack();
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return sResult;
        }
    }
}
