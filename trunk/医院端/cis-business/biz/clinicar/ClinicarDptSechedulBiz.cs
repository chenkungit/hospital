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
    public class ClinicarHospitalBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarHospital ClinicarHospital)
        {
            SResult rst = new SResult();
            ClinicarHospitalDao.Insert(ClinicarHospital);
            rst.success = true;
            rst.data = ClinicarHospital;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ClinicarHospital"></param>
        [STransactionMethod]
        public SResult Update(ClinicarHospital ClinicarHospital)
        {
            SResult rst = new SResult();
            ClinicarHospitalDao.Update(ClinicarHospital);
            rst.success = true;
            rst.data = ClinicarHospital;
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
            ClinicarHospitalDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarHospital> FindByPagination(int pageNum, int pageSize, string hospitalCode,string hospitalName)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (hospitalCode != null && hospitalCode.Length > 0)
            {
                whereSql += " and hospitalcode like ? ";
                listParam.Add("%" + hospitalCode + "%");
            }
            if (hospitalName != null && hospitalName.Length > 0)
            {
                whereSql += " and hospitalname like ? ";
                listParam.Add("%" + hospitalName + "%");
            }
            SPagintion<ClinicarHospital> page = ClinicarHospitalDao.FindByPagintion(whereSql, listParam.ToArray(), "hospitalcode desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarHospital FindById(Int32 Id)
        {
            return ClinicarHospitalDao.FindById(Id);
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
            String _sql = " and hospital=?";
            _listParam.Add(code);
            if (id != null)
            {
                _sql += " and id<>?";
                _listParam.Add(id);
            }

            int count = ClinicarHospitalDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
