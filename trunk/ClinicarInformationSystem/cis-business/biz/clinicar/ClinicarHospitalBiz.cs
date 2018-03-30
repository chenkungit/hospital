using cis_business.dao.clinicar;
using cis_model.clinicar;
using SCommon.SAttribute;
using SCommon.SBase;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cis_business.biz.clinicar
{
    public class ClinicarDptSechedulBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarDptSechedul ClinicarDptSechedul)
        {
            SResult rst = new SResult();
            ClinicarDptSechedulDao.Insert(ClinicarDptSechedul);
            rst.success = true;
            rst.data = ClinicarDptSechedul;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ClinicarDptSechedul"></param>
        [STransactionMethod]
        public SResult Update(ClinicarDptSechedul ClinicarDptSechedul)
        {
            SResult rst = new SResult();
            ClinicarDptSechedulDao.Update(ClinicarDptSechedul);
            rst.success = true;
            rst.data = ClinicarDptSechedul;
            rst.message = "修改成功！";
            return rst;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void Delete(Int32 Id)
        {
            ClinicarDptSechedulDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarDptSechedul> FindByPagination(int pageNum, int pageSize, string deptCode, string beginDate,string endDate)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (deptCode != null && deptCode.Length > 0)
            {
                whereSql += " and deptCode like ? ";
                listParam.Add("%" + deptCode + "%");
            }
            if (beginDate != null && beginDate.Length > 0 && endDate != null && endDate.Length > 0)
            {
                whereSql += " and sechedulDate between ? and ? ";
                listParam.Add(beginDate);
                listParam.Add(endDate);
            }

            SPagintion<ClinicarDptSechedul> page = ClinicarDptSechedulDao.FindByPagintion(whereSql, listParam.ToArray(), "code desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarDptSechedul FindById(Int32 Id)
        {
            return ClinicarDptSechedulDao.FindById(Id);
        }

        /// <summary>
        /// 按部门编码查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarDptSechedul FindByDptCode(string dptCode)
        {
            IList<ClinicarDptSechedul> list = ClinicarDptSechedulDao.FindByHql(" and deptCode=?", new Object[] { dptCode }, "sechedulDate asc");
            ClinicarDptSechedul ClinicarDptSechedul = null;
            if (list.Count() > 0)
            {
                ClinicarDptSechedul = list[0];
            }
            return ClinicarDptSechedul;
        }
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IList<ClinicarDptSechedul> FindbyDate(string deptCode,string beginDate,string endDate)
        {
            IList<ClinicarDptSechedul> list = ClinicarDptSechedulDao.FindByHql(" and deptCode = ? and sechedulDate>=? and sechedulDate<= ?", new Object[] { deptCode,beginDate,endDate }, "sechedulDate asc");
            return list;
        }
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IList<ClinicarDptSechedul> FindbyDateAndType(string deptCode, string beginDate, string endDate,string sechedulType)
        {
            IList<ClinicarDptSechedul> list = ClinicarDptSechedulDao.FindByHql(" and sechedulType = ? and deptCode = ? and sechedulDate>=? and sechedulDate<= ?", new Object[] { sechedulType,deptCode, beginDate, endDate }, "sechedulDate asc");
            return list;
        }
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        //public bool CheckIsExist(string code, Int32? id)
        //{
        //    List<object> _listParam = new List<object>();
        //    String _sql = " and code=?";
        //    _listParam.Add(code);
        //    if (id != null)
        //    {
        //        _sql += " and id<>?";
        //        _listParam.Add(id);
        //    }

        //    int count = ClinicarDptSechedulDao.FindCountByHql(_sql, _listParam.ToArray());
        //    return count > 0 ? true : false;
        //}
    }
}
