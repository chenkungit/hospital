using SCommon.SAop;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace SCommon.SAttribute
{
    /// <summary>
    /// 标注类某方法内所有数据库操作加入事务控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class STransactionAttribute : ContextAttribute, IContributeObjectSink
    {
        /// <summary>
        /// 标注类某方法内所有数据库操作加入事务控制，请使用TransactionMethodAttribute同时标注
        /// </summary>
        public STransactionAttribute() : base("Transaction")
        { }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new STransactionAop(next);
        }
    }

    /// <summary>
    /// 标示方法内所有数据库操作加入事务控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class STransactionMethodAttribute : Attribute
    {
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
        public STransactionMethodAttribute()
        {
        }
    }
}
