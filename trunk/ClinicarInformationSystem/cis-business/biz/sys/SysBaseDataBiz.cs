using cis_business.dao.sys;
using cis_model.sys;
using SCommon.SAttribute;
using SCommon.SBase;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cis_business.biz.sys
{
    public class SysBaseDataBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="SysBaseData"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(SysBaseData SysBaseData)
        {
            SResult rst = new SResult();

            SysBaseDataDao.Insert(SysBaseData);
            rst.success = true;
            rst.data = SysBaseData;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="SysBaseData"></param>
        [STransactionMethod]
        public SResult Update(SysBaseData SysBaseData)
        {
            SResult rst = new SResult();

            SysBaseDataDao.Update(SysBaseData);
            rst.success = true;
            rst.data = SysBaseData;
            rst.message = "修改成功！";
            return rst;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void Delete(string Id)
        {
            SysBaseDataDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<SysBaseData> FindByPagination(int pageNum, int pageSize, string code)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (code != null && code.Length > 0)
            {
                whereSql += " and code like ? ";
                listParam.Add("%" + code + "%");
            }
            SPagintion<SysBaseData> page = SysBaseDataDao.FindByPagintion(whereSql, listParam.ToArray(), "code asc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按code查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SysBaseData FindByCode(string Code)
        {
            return SysBaseDataDao.FindAllByProperty("code",Code)[0];
        }
        /// <summary>
        /// 按字典类型进行查询
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <returns></returns>
        public System.Collections.IList FindByType(string TypeCode)
        {
            return SysBaseDataDao.FindBySql("select code,name from t_sys_dict where enabled = 1 and sort = ? order by code",new string[] { TypeCode });
        }

    }
}
