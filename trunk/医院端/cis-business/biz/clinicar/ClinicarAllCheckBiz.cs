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
    public class ClinicarAllCheckBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarAllCheck ClinicarAllCheck)
        {
            SResult rst = new SResult();
            ClinicarAllCheckDao.Insert(ClinicarAllCheck);
            rst.success = true;
            rst.data = ClinicarAllCheck;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ClinicarAllCheck"></param>
        [STransactionMethod]
        public SResult Update(ClinicarAllCheck ClinicarAllCheck)
        {
            SResult rst = new SResult();
            ClinicarAllCheckDao.Update(ClinicarAllCheck);
            rst.success = true;
            rst.data = ClinicarAllCheck;
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
            ClinicarAllCheckDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarAllCheck> FindByPagination(int pageNum, int pageSize, string checkNumber)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (checkNumber != null && checkNumber.Length > 0)
            {
                whereSql += " and check_number like ? ";
                listParam.Add("%" + checkNumber + "%");
            }
            SPagintion<ClinicarAllCheck> page = ClinicarAllCheckDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarAllCheck FindById(Int32 Id)
        {
            return ClinicarAllCheckDao.FindById(Id);
        }

        /// <summary>
        /// 按检查码查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarAllCheck FindByCheckNumber(string checkNumber)
        {
            IList<ClinicarAllCheck> list = ClinicarAllCheckDao.FindByHql(" and check_number=?", new Object[] { checkNumber }, "id asc");
            ClinicarAllCheck ClinicarAllCheck = null;
            if (list.Count() > 0)
            {
                ClinicarAllCheck = list[0];
            }
            return ClinicarAllCheck;
        }
    }
}
