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
    public class SysDicBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sysDic"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(SysDic sysDic)
        {
            SResult rst = new SResult();
            //验证用户名是否重复
            if (this.CheckIsExist(sysDic.Code, null))
            {
                rst.success = false;
                rst.message = "[" + sysDic.Code + "]已存在！";
            }
            else
            {
                SysDicDao.Insert(sysDic);
                rst.success = true;
                rst.data = sysDic;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sysDic"></param>
        [STransactionMethod]
        public SResult Update(SysDic sysDic)
        {
            SResult rst = new SResult();
            //验证用户名是否重复
            if (this.CheckIsExist(sysDic.Code, sysDic.Id))
            {
                rst.success = false;
                rst.message = "[" + sysDic.Code + "]已存在！";
            }
            else
            {
                SysDicDao.Update(sysDic);
                rst.success = true;
                rst.data = sysDic;
                rst.message = "修改成功！";
            }
            return rst;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [STransactionMethod]
        public void Delete(int id)
        {
            SysDicDao.DeleteById(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<SysUser> FindByPagination(int pageNum, int pageSize, string code, string name)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (code != null && code.Length>0)
            {
                whereSql += " and code like ? ";
                listParam.Add("%" + code + "%");
            }
            if (name != null && name.Length > 0)
            {
                whereSql += " and name like ? ";
                listParam.Add("%" + name + "%");
            }

            SPagintion<SysUser> page = SysUserDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SysDic FindById(int Id)
        {
            return SysDicDao.FindById(Id);
        }

        /// <summary>
        /// 按用户名查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public SysDic FindByCode(string code)
        {
            IList<SysDic> list = SysDicDao.FindByHql(" and code=?", new Object[] { code }, "id desc");
            SysDic dic = null;
            if (list.Count() > 0)
            {
                dic = list[0];
            }
            return dic;
        }

        /// <summary>
        /// 验证代码是否存在
        /// </summary>
        /// <param name="code"></param>
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

            int count = SysDicDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
