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
    public class SysUserBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(SysUser sysUser)
        {
            SResult rst = new SResult();
            //验证用户名是否重复
            if (this.CheckIsExist(sysUser.Username, null))
            {
                rst.success = false;
                rst.message = "[" + sysUser.Username + "]已存在！";
            }
            else
            {
                SysUserDao.Insert(sysUser);
                rst.success = true;
                rst.data = sysUser;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sysUser"></param>
        [STransactionMethod]
        public SResult Update(SysUser sysUser)
        {
            SResult rst = new SResult();
            //验证用户名是否重复
            if (this.CheckIsExist(sysUser.Username, sysUser.Id))
            {
                rst.success = false;
                rst.message = "[" + sysUser.Username + "]已存在！";
            }
            else
            {
                SysUserDao.Update(sysUser);
                rst.success = true;
                rst.data = sysUser;
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
            SysUserDao.DeleteById(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<SysUser> FindByPagination(int pageNum, int pageSize, string username, string fullName)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            if (username != null && username.Length>0)
            {
                whereSql += " and username like ? ";
                listParam.Add("%" + username + "%");
            }
            if (fullName != null && fullName.Length > 0)
            {
                whereSql += " and fullName like ? ";
                listParam.Add("%" + fullName + "%");
            }

            SPagintion<SysUser> page = SysUserDao.FindByPagintion(whereSql, listParam.ToArray(), "id desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SysUser FindById(int Id)
        {
            return SysUserDao.FindById(Id);
        }

        /// <summary>
        /// 按用户名查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public SysUser FindByUsername(string username)
        {
            IList<SysUser> list = SysUserDao.FindByHql(" and username=?", new Object[] { username }, "id desc");
            SysUser user = null;
            if (list.Count() > 0)
            {
                user = list[0];
            }
            return user;
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIsExist(string username, Int32? id)
        {
            List<object> _listParam = new List<object>();
            String _sql = " and username=?";
            _listParam.Add(username);
            if (id != null)
            {
                _sql += " and id<>?";
                _listParam.Add(id);
            }

            int count = SysUserDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
