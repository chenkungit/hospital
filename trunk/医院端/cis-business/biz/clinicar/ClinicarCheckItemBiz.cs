using cis_business.dao.clinicar;
using cis_model.clinicar;
using SCommon.SAttribute;
using SCommon.SBase;
using SCommon.SUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cis_business.biz.clinicar
{
    public class ClinicarCheckItemBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_check"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarCheckItem clinicarCheckItem)
        {
            SResult rst = new SResult();
            if (CheckIsExist(clinicarCheckItem.CheckId, clinicarCheckItem.ItemCode))
            {
                rst.success = false;
                rst.message = "[" + clinicarCheckItem.ItemName + "]已存在！";
            }
            else
            {
                ClinicarCheckItemDao.Insert(clinicarCheckItem);
                rst.success = true;
                rst.data = clinicarCheckItem;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarCheckItem clinicarCheckItem)
        {
            SResult rst = new SResult();
            ClinicarCheckItemDao.Update(clinicarCheckItem);
            rst.success = true;
            rst.data = clinicarCheckItem;
            rst.message = "修改成功！";
            return rst;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void Delete(int Id)
        {
            ClinicarCheckItemDao.DeleteById(Id);
        }

        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void FakeDelete(int Id)
        {
            ClinicarCheckItemDao.FakeDeleteById(Id);
        }

        /// <summary>
        /// 子表数据分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheckItem> FindByPagination(int pageNum, int pageSize, int checkId)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";
           
            whereSql += " and deleted=0 and check_id = ? ";
            listParam.Add(checkId);

            SPagintion<ClinicarCheckItem> page = ClinicarCheckItemDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }





        /// <summary>
        /// 查询分检检查项目表中涉及的科室
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList FindByCheckId(int checkId)
        {
            List<object> listParam = new List<object>();
            String sql = " Select distinct check_id,dpt_code,dpt_name,completed,summary,ifnull(conclusion,'') as conclusion,ifnull(advice,'') as advice From t_clinicar_check_item ";

            sql += " Where deleted=0 and check_id = ? ";
            listParam.Add(checkId);

            IList list = ClinicarCheckItemDao.FindBySql(sql, listParam.ToArray());
            return list;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarCheckItem FindById(int Id)
        {
            return ClinicarCheckItemDao.FindById(Id);
        }

        /// <summary>
        /// 按日期对检查号查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarCheckItem FindByCheckNumber(string checkDate)
        {
            IList<ClinicarCheckItem> list = ClinicarCheckItemDao.FindByHql(" and check_date >= ?", new Object[] { checkDate }, "check_date,check_number desc limit 1");
            ClinicarCheckItem clinicarCheck = null;
            if (list.Count() > 0)
            {
                clinicarCheck = list[0];
            }
            return clinicarCheck;
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIsExist(int checkId, string itemCode)
        {
            List<object> _listParam = new List<object>();
            String _sql = " and deleted=0 and check_id=? and item_code=? ";
            _listParam.Add(checkId);
            _listParam.Add(itemCode);

            int count = ClinicarCheckItemDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }


        /// <summary>
        /// 查询未完成的项目
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheckItem> FindUnCompletedPagination(int pageNum, int pageSize, int checkId)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            whereSql += "  and ifnull(completed,0) = 0 and ifnull(canceled,0) =0 and deleted=0 and check_id = ? ";
            listParam.Add(checkId);

            SPagintion<ClinicarCheckItem> page = ClinicarCheckItemDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 查询未完成的项目
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<ClinicarCheckItem> FindUnCompletedItem(int checkId)
        {
            IList<ClinicarCheckItem> list = ClinicarCheckItemDao.FindByHql(" and deleted = 0 and canceled = 0 and check_id = ? and completed=0", new Object[] { checkId }, "");
            return list;
        }

        /// <summary>
        /// 查询是否存在未完成的项目
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public bool ExistUnCompletedItem(int checkId)
        {
            IList<ClinicarCheckItem> list = ClinicarCheckItemDao.FindByHql(" and deleted = 0 and canceled = 0 and check_id = ? and completed=0", new Object[] { checkId }, "");
            if (list.Count() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 查询已完成的项目
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public IList<ClinicarCheckItem> FindCompletedItem(int checkId)
        {
            IList<ClinicarCheckItem> list = ClinicarCheckItemDao.FindByHql(" and deleted = 0  and check_id = ? and completed=1", new Object[] { checkId }, "");
            return list;
        }
    }
}
