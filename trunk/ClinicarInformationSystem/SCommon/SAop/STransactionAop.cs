using Castle.ActiveRecord;
using SCommon.SAttribute;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace SCommon.SAop
{
    public sealed class STransactionAop : IMessageSink
    {
        private IMessageSink nextSink; //保存下一个接收器

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next">接收器</param>
        public STransactionAop(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }

        /// <summary>
        ///  IMessageSink接口方法，用于异步处理，我们不实现异步处理，所以简单返回null,
        ///  不管是同步还是异步，这个方法都需要定义
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="replySink"></param>
        /// <returns></returns>
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        /// <summary>
        /// 下一个接收器
        /// </summary>
        public IMessageSink NextSink
        {
            get { return nextSink; }
        }

        /// <summary>
        /// 同步处理方法 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;
            //方法调用消息接口 
            IMethodCallMessage call = msg as IMethodCallMessage;

            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(STransactionMethodAttribute))) == null)
            {
                retMsg = nextSink.SyncProcessMessage(msg);
            }
            //如果打了STransactionMethodAttribute标签 
            else
            {
                if (SConstants.DEFAULT_ORM_TYPE == SConstants.S_ORM_TYPE.CastleActiveRecord)
                {
                    TransactionScope trans = new TransactionScope(Castle.ActiveRecord.TransactionMode.Inherits);
                    try
                    {
                        // 讲存储存储在上下文
                        CallContext.SetData(STransactionAop.ContextName, trans);
                        // 传递消息给下一个接收器 - > 就是指执行你自己的方法
                        retMsg = nextSink.SyncProcessMessage(msg);

                        ReturnMessage tmpMsg = retMsg as ReturnMessage;
                        if (tmpMsg != null && tmpMsg.Exception != null)
                        {
                            throw tmpMsg.Exception;
                        }
                        else
                        {
                            trans.VoteCommit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.VoteRollBack();
                        throw ex;
                    }
                    finally
                    {
                        trans.Dispose();
                    }
                }
                else if (SConstants.DEFAULT_ORM_TYPE == SConstants.S_ORM_TYPE.Custom)
                {
                    //此处换成自己的数据库连接
                    using (SqlConnection Connect = new SqlConnection(SConstants.DEFAULT_DB_CONN_STRING))
                    {
                        Connect.Open();
                        SqlTransaction SqlTrans = Connect.BeginTransaction();
                        // 讲存储存储在上下文
                        CallContext.SetData(STransactionAop.ContextName, SqlTrans);

                        // 传递消息给下一个接收器 - > 就是指执行你自己的方法
                        retMsg = nextSink.SyncProcessMessage(msg);

                        if (SqlTrans != null)
                        {
                            IMethodReturnMessage methodReturn = retMsg as IMethodReturnMessage;
                            Exception except = methodReturn.Exception;

                            if (except != null)
                            {
                                SqlTrans.Rollback();
                                //可以做日志及其他处理
                            }
                            else
                            {
                                SqlTrans.Commit();
                            }
                            SqlTrans.Dispose();
                            SqlTrans = null;
                        }
                    }
                }
            }
            return retMsg;
        }

        /// <summary>
        /// 用于提取、存储SqlTransaction
        /// </summary>
        public static string ContextName
        {
            get { return "TransactionAop"; }
        }
    }
}
