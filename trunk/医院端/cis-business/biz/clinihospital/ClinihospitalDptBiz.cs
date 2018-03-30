using cis_business.dao.clinihospital;
using cis_model.clinihospital;
using SCommon.SAttribute;
using SCommon.SBase;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cis_business.biz.Clinihospital
{
    public class ClinihospitalDptBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_Clinihospital_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinihospitalDpt ClinihospitalDpt)
        {
            SResult rst = new SResult();
            //验证项目代码是否重复
            if (this.CheckIsExist(ClinihospitalDpt.Id, null))
            {
                rst.success = false;
                rst.message = "[" + ClinihospitalDpt.Id + "]已存在！";
            }
            else
            {
                ClinihospitalDptDao.Insert(ClinihospitalDpt);
                rst.success = true;
                rst.data = ClinihospitalDpt;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ClinihospitalDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinihospitalDpt ClinihospitalDpt)
        {
            SResult rst = new SResult();
            ClinihospitalDptDao.Update(ClinihospitalDpt);
            rst.success = true;
            rst.data = ClinihospitalDpt;
            rst.message = "修改成功！";
            return rst;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void Delete(String Id)
        {
            ClinihospitalDptDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinihospitalDpt> FindByPagination(int pageNum, int pageSize, string code, string name,string hospitalcode)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (code != null && code.Length > 0)
            {
                whereSql += " and code like ? ";
                listParam.Add("%" + code + "%");
            }
            if (name != null && name.Length > 0)
            {
                whereSql += " and name like ? ";
                listParam.Add("%" + name + "%");
            }
            if (hospitalcode != null && hospitalcode.Length > 0)
            {
                whereSql += " and hospitalcode = ? ";
                listParam.Add(hospitalcode);
            }

            SPagintion<ClinihospitalDpt> page = ClinihospitalDptDao.FindByPagintion(whereSql, listParam.ToArray(), "code desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinihospitalDpt FindById(String Id)
        {
            return ClinihospitalDptDao.FindById(Id);
        }

        /// <summary>
        /// 按用户名查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinihospitalDpt FindByUsername(string name)
        {
            IList<ClinihospitalDpt> list = ClinihospitalDptDao.FindByHql(" and name=?", new Object[] { name }, "code desc");
            ClinihospitalDpt ClinihospitalDpt = null;
            if (list.Count() > 0)
            {
                ClinihospitalDpt = list[0];
            }
            return ClinihospitalDpt;
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
            String _sql = " and code=?";
            _listParam.Add(code);
            if (id != null)
            {
                _sql += " and id<>?";
                _listParam.Add(id);
            }

            int count = ClinihospitalDptDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
