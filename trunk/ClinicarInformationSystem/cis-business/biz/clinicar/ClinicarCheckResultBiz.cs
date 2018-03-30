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
    public class ClinicarCheckResultBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_check"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarCheckResult clinicarCheckResult)
        {
            SResult rst = new SResult();
            ClinicarCheckResultDao.Insert(clinicarCheckResult);
            rst.success = true;
            rst.data = clinicarCheckResult;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarCheckResult clinicarCheckResult)
        {
            SResult rst = new SResult();
            ClinicarCheckResultDao.Update(clinicarCheckResult);
            rst.success = true;
            rst.data = clinicarCheckResult;
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
            ClinicarCheckResultDao.DeleteById(Id);
        }

        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void FakeDelete(int Id)
        {
            ClinicarCheckResultDao.FakeDeleteById(Id);
        }

        /// <summary>
        /// 子表数据分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheckResult> FindByPagination(int pageNum, int pageSize, string checkNum,string itemCode)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";
           
            whereSql += " and IFNULL(item_detail_name,'') not in ('Ref Group','Blood Mode','Take Mode') and deleted=0 and check_number = ?  and item_code = ?   ";
            listParam.Add(checkNum);
            listParam.Add(itemCode);

            SPagintion<ClinicarCheckResult> page = ClinicarCheckResultDao.FindByPagintion(whereSql, listParam.ToArray(), "create_time desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 子表数据分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheckResult> FindByPagination(int pageNum, int pageSize, string checkNum)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            whereSql += " and deleted=0 and check_number = ? ";
            listParam.Add(checkNum);
            SPagintion<ClinicarCheckResult> page = ClinicarCheckResultDao.FindByPagintion(whereSql, listParam.ToArray(), "item_code asc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 根据检查号和项目编号分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarCheckResult> FindByNumAndItem(int pageNum, int pageSize, string checkNum,string itemCode)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (!string.IsNullOrWhiteSpace(checkNum))
            {
                whereSql += " and check_number = ? ";
                listParam.Add(checkNum);
            }

            whereSql += " and deleted=0 and item_code = ? ";
            listParam.Add(itemCode);

            SPagintion<ClinicarCheckResult> page = ClinicarCheckResultDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarCheckResult FindById(int Id)
        {
            return ClinicarCheckResultDao.FindById(Id);
        }

        /// <summary>
        /// 按日期对检查号查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarCheckResult FindByCheckNumber(string checkDate)
        {
            IList<ClinicarCheckResult> list = ClinicarCheckResultDao.FindByHql(" and check_date >= ?", new Object[] { checkDate }, "check_date,check_number desc limit 1");
            ClinicarCheckResult clinicarCheck = null;
            if (list.Count() > 0)
            {
                clinicarCheck = list[0];
            }
            return clinicarCheck;
        }

        /// <summary>
        /// 根据检查号获取检查结果
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public IList<ClinicarCheckResult> FindEntity(string checkNumber)
        {
            IList<ClinicarCheckResult> list = ClinicarCheckResultDao.FindByHql(" and deleted = 0 and check_number = ?", new Object[] { checkNumber }, "");
            
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

            int count = ClinicarCheckResultDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
        /// <summary>
        /// 查询项目数
        /// </summary>
        /// <returns></returns>
        public IList FindItemCount(string checkNumber)
        {
            string _sql = string.Format("select distinct item_code,item_name from t_clinicar_check_result where ifnull(deleted,0) =0 and check_number = ? ");
            return ClinicarCheckResultDao.FindBySql(_sql, new object[] { checkNumber });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkNumber"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public IList<ClinicarCheckResult> FindEntity(string checkNumber,string itemCode)
        {
            IList<ClinicarCheckResult> list = ClinicarCheckResultDao.FindByHql(" and deleted = 0 and check_number = ? and item_code = ? order by create_time desc", new Object[] { checkNumber,itemCode }, "");
            return list;
        }

        
    }
}
