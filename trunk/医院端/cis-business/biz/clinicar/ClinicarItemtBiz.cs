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
    public class ClinicarItemBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarItem clinicarItem)
        {
            SResult rst = new SResult();
            //验证项目代码是否重复
            if (this.CheckIsExist(clinicarItem.Id, null))
            {
                rst.success = false;
                rst.message = "[" + clinicarItem.Id + "]已存在！";
            }
            else
            {
                ClinicarItemDao.Insert(clinicarItem);
                rst.success = true;
                rst.data = clinicarItem;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarItem clinicarItem)
        {
            SResult rst = new SResult();
            ClinicarItemDao.Update(clinicarItem);
            rst.success = true;
            rst.data = clinicarItem;
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
            ClinicarItemDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// isEnabled 为 true 时，过滤掉未启用的记录
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarItem> FindByPagination(int pageNum, int pageSize, string code, string name,string dtpCode,string dtpName,bool isEnabled)
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
            if (dtpCode != null && dtpCode.Length > 0)
            {
                whereSql += " and dpt_code like ? ";
                listParam.Add("%" + dtpCode + "%");
            }
            if (dtpName != null && dtpName.Length > 0)
            {
                whereSql += " and dpt_name like ? ";
                listParam.Add("%" + dtpName + "%");
            }
            
            if (isEnabled)
            {
                whereSql += " and enabled = 1 ";
            }

            SPagintion<ClinicarItem> page = ClinicarItemDao.FindByPagintion(whereSql, listParam.ToArray(), "code desc", pageSize, pageNum);
            return page;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarItem FindById(String Id)
        {
            return ClinicarItemDao.FindById(Id);
        }

        /// <summary>
        /// 按用户名查询
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public ClinicarItem FindByUsername(string name)
        {
            IList<ClinicarItem> list = ClinicarItemDao.FindByHql(" and name=?", new Object[] { name }, "code desc");
            ClinicarItem clinicarItem = null;
            if (list.Count() > 0)
            {
                clinicarItem = list[0];
            }
            return clinicarItem;
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

            int count = ClinicarItemDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 验证设备编号是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIsExistForDeviceCode(string deviceCode,string code)
        {
            List<object> _listParam = new List<object>();
            String whereSql = " and device_code =? and enabled = 1 ";
            _listParam.Add(deviceCode);

            if (!string.IsNullOrWhiteSpace(code))
            {
                whereSql += " and code <> ?";
                _listParam.Add(code);
            }

            int count = ClinicarItemDao.FindCountByHql(whereSql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
