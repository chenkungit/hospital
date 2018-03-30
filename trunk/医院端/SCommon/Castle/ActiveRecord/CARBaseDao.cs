using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using SCommon.SUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCommon.CARecord
{
    public class CARBaseDao<T, PK> : ActiveRecordBase<T> where T : class
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Insert(T entity)
        {
            ActiveRecordBase.Create(entity);
            return entity;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void Update(T entity)
        {
            ActiveRecordBase.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteById(PK id)
        {
            T entity = System.Activator.CreateInstance<T>();
            PropertyInfo property = typeof(T).GetProperty("Id");
            property.SetValue(entity, id, null);
            ActiveRecordBase.Delete(entity);
        }

        /// <summary>
        /// 伪删除
        /// </summary>
        /// <returns></returns>
        public static Int32 FakeDeleteById(PK id)
        {
            Type tt = typeof(T);
            string hql = "Update " + tt.Name + " Set deleted=1 Where id=?";
            object count = ActiveRecordBase<T>.Execute(
                delegate(NHibernate.ISession session, object instance)
                {
                    NHibernate.IQuery iQuery = session.CreateQuery(hql);
                    iQuery.SetParameter(0, id);
                    return iQuery.ExecuteUpdate();
                }, null);

            return (int)count;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T FindById(PK id)
        {
            return ActiveRecordBase<T>.FindByPrimaryKey(id);
        }

        /// <summary>
        /// 按属性查询
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Array FindByProperty(string property, object value)
        {
            return ActiveRecordBase<T>.FindAllByProperty(property, value);
        }

        /// <summary>
        /// 按属性查询
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Array FindByProperty(string orderByColumn, string property, object value)
        {
            return ActiveRecordBase<T>.FindAllByProperty(orderByColumn, property, value);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereHql">以and开始，例如"and name=?"</param>
        /// <param name="whereParams">对应whereHql的参数(?)</param>
        /// <param name="orderSql">排序sql，例如"name desc, id desc"</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageNo">要查询的页数</param>
        /// <returns></returns>
        public static SPagintion<T> FindByPagintion(string _whereHql, object[] _whereParams, string _orderSql, int _pageSize, int _pageNo)
        {
            try
            {
                if (_pageNo < 1)
                {
                    _pageNo = 1;
                }
                Type tt = typeof(T);

                SPagintion<T> page = new SPagintion<T>();
                page.WhereSql = _whereHql;
                page.WhereParams = _whereParams;
                page.OrderSql = _orderSql;
                page.PageSize = _pageSize;
                page.CurrentPageNum = _pageNo;

                string filter = "1=1 " + page.WhereSql;
                page.TotalRecordCount = ActiveRecordBase.Count(tt, filter, page.WhereParams);//获得总条数

                if (page.TotalRecordCount > 0)
                {
                    string hql = "FROM " + tt.Name + " WHERE " + filter;
                    if (page.OrderSql != null && page.OrderSql.Trim().Length > 0)
                    {
                        hql += " ORDER BY " + page.OrderSql;
                    }
                    SimpleQuery<T> sq = new SimpleQuery<T>(hql, page.WhereParams);
                    int startRecordNum = (page.CurrentPageNum - 1) * page.PageSize;
                    sq.SetQueryRange(startRecordNum, page.PageSize);// Mysql是分页语句
                    page.Data = (IList<T>)ActiveRecordBase.ExecuteQuery(sq);
                }

                return page;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 按HQL查询数量
        /// </summary>
        /// <param name="_whereHql"></param>
        /// <param name="_whereParams"></param>
        /// <returns></returns>
        public static Int32 FindCountByHql(string _whereHql, object[] _whereParams)
        {
            Type tt = typeof(T);
            string filter = "1=1 " + _whereHql;
            int count = ActiveRecordBase.Count(tt, filter, _whereParams);//获得总条数
            return count;
        }

        /// <summary>
        /// 按HQL查询
        /// </summary>
        /// <param name="_whereHql"></param>
        /// <param name="_whereParams"></param>
        /// <param name="_orderSql"></param>
        /// <returns></returns>
        public static IList<T> FindByHql(string _whereHql, object[] _whereParams, string _orderSql)
        {
            Type tt = typeof(T);
            string hql = "From " + tt.Name + " Where 1=1 " + _whereHql;
            if (_orderSql != null && _orderSql.Trim().Length > 0)
            {
                hql += " Order By " + _orderSql;
            }
            SimpleQuery<T> sq = new SimpleQuery<T>(hql, _whereParams);
            IList<T> result = (IList<T>)ActiveRecordBase.ExecuteQuery(sq);
            return result;
        }

        /// <summary>
        /// 按SQL查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="_sqlParams"></param>
        /// <returns></returns>
        public static IList FindBySql(string sql, object[] _sqlParams)
        {
            IList rst = (IList)ActiveRecordBase<T>.Execute(
                delegate(NHibernate.ISession session, object instance)
                {
                    NHibernate.ISQLQuery iSQLQuery = session.CreateSQLQuery(sql);
                    if (_sqlParams != null && _sqlParams.Length > 0)
                    {
                        for (int i = 0; i < _sqlParams.Length; i++)
                        {
                            iSQLQuery.SetParameter(i, _sqlParams[i]);
                        }
                    }
                    return iSQLQuery.List();
                }, null);

            return rst;
        }
    }
}
