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
    public class ClinicarCheckBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_check"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarCheck clinicarCheck)
        {
            SResult rst = new SResult();
            ClinicarCheckDao.Insert(clinicarCheck);
            rst.success = true;
            rst.data = clinicarCheck;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarCheck clinicarCheck)
        {
            SResult rst = new SResult();
            ClinicarCheckDao.Update(clinicarCheck);
            rst.success = true;
            rst.data = clinicarCheck;
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
            ClinicarCheckDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheck> FindByPagination(int pageNum, int pageSize, string checkNum, string name,string cardNum)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (checkNum != null && checkNum.Length > 0)
            {
                whereSql += " and check_number like ? ";
                listParam.Add("%" + checkNum + "%");
            }
            if (name != null && name.Length > 0)
            {
                whereSql += " and name like ? ";
                listParam.Add("%" + name + "%");
            }
            if (cardNum != null && cardNum.Length > 0)
            {
                whereSql += " and certificate_number like ? ";
                listParam.Add("%" + cardNum + "%");
            }

            SPagintion<ClinicarCheck> page = ClinicarCheckDao.FindByPagintion(whereSql, listParam.ToArray(), "check_number desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarCheck FindById(int Id)
        {
            return ClinicarCheckDao.FindById(Id);
        }

        /// <summary>
        /// 按日期对检查号查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarCheck FindByCheckNumber(string checkDate)
        {
            IList<ClinicarCheck> list = ClinicarCheckDao.FindByHql(" and deleted = 0 and check_date = ?", new Object[] { checkDate }, "check_date,check_number desc limit 1");
            ClinicarCheck clinicarCheck = null;
            if (list.Count() > 0)
            {
                clinicarCheck = list[0];
            }
            return clinicarCheck;
        }

        /// <summary>
        /// 根据'检查号'查询t_clinicar_check返回实体类
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ClinicarCheck FindByCheckNum(string checkNum)
        {
            IList<ClinicarCheck> list = ClinicarCheckDao.FindByHql(" and deleted = 0 and check_number = ?", new Object[] { checkNum }, " check_number desc limit 1");
            ClinicarCheck clinicarCheck = null;
            if (list.Count() > 0)
            {
                clinicarCheck = list[0];
            }
            return clinicarCheck;
        }

        /// <summary>
        /// 根据'证件号'查询检查历史记录
        /// </summary>
        /// <param name="personNumber"></param>
        /// <returns></returns>
        public IList FindByPersonNumber(string personNumber)
        {
            string str = " Select * From t_clinicar_check Where deleted=0 and certificate_number = ?  Order by check_date desc ";
            IList list = ClinicarCheckDao.FindBySql(str, new Object[] { personNumber });
            return list;
        }


        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIsExist(string code, Int32? id)
        {
            List<object> _listParam = new List<object>();
            String _sql = " and name=?";
            _listParam.Add(code);
            if (id != null)
            {
                _sql += " and id<>?";
                _listParam.Add(id);
            }

            int count = ClinicarItemDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
        /// <summary>
        /// 按检查号进行查询
        /// ADD BY CHENKUN 2017-04-09
        /// </summary>
        /// <param name="checkNumber"></param>
        /// <returns></returns>
        public ClinicarCheck FindByCheckNumberBar(string checkNumber)
        {
            IList<ClinicarCheck> list = ClinicarCheckDao.FindByHql(" and deleted = 0 and check_number = ?", new Object[] { checkNumber }, "check_date,check_number desc limit 1");
            ClinicarCheck clinicarCheck = null;
            if (list.Count() > 0)
            {
                clinicarCheck = list[0];
            }
            return clinicarCheck;
        }
        
    }
}
