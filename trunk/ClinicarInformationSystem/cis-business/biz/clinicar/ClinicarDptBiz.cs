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
    public class ClinicarDptBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarDpt clinicarDpt)
        {
            SResult rst = new SResult();
            //验证项目代码是否重复
            if (this.CheckIsExist(clinicarDpt.Id, null))
            {
                rst.success = false;
                rst.message = "[" + clinicarDpt.Id + "]已存在！";
            }
            else
            {
                ClinicarDptDao.Insert(clinicarDpt);
                rst.success = true;
                rst.data = clinicarDpt;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarDpt clinicarDpt)
        {
            SResult rst = new SResult();
            ClinicarDptDao.Update(clinicarDpt);
            rst.success = true;
            rst.data = clinicarDpt;
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
            ClinicarDptDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarDpt> FindByPagination(int pageNum, int pageSize, string code, string name,string hospitalcode)
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

            SPagintion<ClinicarDpt> page = ClinicarDptDao.FindByPagintion(whereSql, listParam.ToArray(), "code desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarDpt FindById(String Id)
        {
            return ClinicarDptDao.FindById(Id);
        }

        /// <summary>
        /// 按用户名查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarDpt FindByUsername(string name)
        {
            IList<ClinicarDpt> list = ClinicarDptDao.FindByHql(" and name=?", new Object[] { name }, "code desc");
            ClinicarDpt clinicarDpt = null;
            if (list.Count() > 0)
            {
                clinicarDpt = list[0];
            }
            return clinicarDpt;
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

            int count = ClinicarDptDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
