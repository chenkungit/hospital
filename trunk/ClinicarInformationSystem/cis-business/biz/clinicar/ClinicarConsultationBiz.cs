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
    public class ClinicarConsultationBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarConsultation ClinicarConsultation)
        {
            SResult rst = new SResult();
            ClinicarConsultationDao.Insert(ClinicarConsultation);
            rst.success = true;
            rst.data = ClinicarConsultation;
            rst.message = "新增成功！";
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ClinicarConsultation"></param>
        [STransactionMethod]
        public SResult Update(ClinicarConsultation ClinicarConsultation)
        {
            SResult rst = new SResult();
            ClinicarConsultationDao.Update(ClinicarConsultation);
            rst.success = true;
            rst.data = ClinicarConsultation;
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
            ClinicarConsultationDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarConsultation> FindByPagination(int pageNum, int pageSize, string beginDate,string endDate)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            //if (beginDate != null && beginDate.Length > 0 && endDate != null && endDate.Length > 0)
            //{
            //    whereSql += " and sechedulDate between ? and ? ";
            //    listParam.Add(beginDate);
            //    listParam.Add(endDate);
            //}

            whereSql += " and DATE_FORMAT(applyhospitaldate,'%Y-%m-%d') between ? and ? ";
            listParam.Add(beginDate);
            listParam.Add(endDate);

            SPagintion<ClinicarConsultation> page = ClinicarConsultationDao.FindByPagintion(whereSql, listParam.ToArray(), "applyhospitaldate desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarConsultation FindById(Int32 Id)
        {
            return ClinicarConsultationDao.FindById(Id);
        }

        /// <summary>
        /// 按部门编码查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarConsultation FindByDptCode(string dptCode)
        {
            IList<ClinicarConsultation> list = ClinicarConsultationDao.FindByHql(" and deptCode=?", new Object[] { dptCode }, "sechedulDate asc");
            ClinicarConsultation ClinicarConsultation = null;
            if (list.Count() > 0)
            {
                ClinicarConsultation = list[0];
            }
            return ClinicarConsultation;
        }
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IList<ClinicarConsultation> FindbyDate(string hospitalCode,string userName,string deptCode,string beginDate,string endDate,string dateType)
        {
            IList<ClinicarConsultation> list = ClinicarConsultationDao.FindByHql(" and hospitalcode = ? and consultationtype = ? and username = ? and deptCode = ? and consultationDate>=? and consultationDate<= ?", new Object[] { hospitalCode,dateType, userName, deptCode,beginDate,endDate }, "consultationDate asc");
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

        //    int count = ClinicarConsultationDao.FindCountByHql(_sql, _listParam.ToArray());
        //    return count > 0 ? true : false;
        //}
    }
}
