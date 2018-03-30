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
    public class ClinicarItemtDetailBiz : SBaseBiz
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t_clinicar_dpt"></param>
        /// <returns></returns>
        [STransactionMethod]
        public SResult Insert(ClinicarItemDetail clinicarItemDetail)
        {
            SResult rst = new SResult();
            //验证项目代码是否重复
            if (this.CheckIsExist(clinicarItemDetail.Id, null))
            {
                rst.success = false;
                rst.message = "[" + clinicarItemDetail.Id + "]已存在！";
            }
            else
            {
                ClinicarItemDetailDao.Insert(clinicarItemDetail);
                rst.success = true;
                rst.data = clinicarItemDetail;
                rst.message = "新增成功！";
            }
            return rst;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="clinicarDpt"></param>
        [STransactionMethod]
        public SResult Update(ClinicarItemDetail clinicarItemDetail)
        {
            SResult rst = new SResult();
            ClinicarItemDetailDao.Update(clinicarItemDetail);
            rst.success = true;
            rst.data = clinicarItemDetail;
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
            ClinicarItemDetailDao.DeleteById(Id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public SPagintion<ClinicarItemDetail> FindByPagination(int pageNum, int pageSize, string itemCode)
        {
            List<object> listParam = new List<object>();
            String whereSql = "";

            whereSql += " and name not in ('Ref Group','Blood Mode','Take Mode') and item_code = ? ";
            listParam.Add(itemCode);

            SPagintion<ClinicarItemDetail> page = ClinicarItemDetailDao.FindByPagintion(whereSql, listParam.ToArray(), "code asc", pageSize, pageNum);
            return page;
        }

        public IList<ClinicarItemDetail> FindEntity(string itemCode)
        {
            IList<ClinicarItemDetail> list = ClinicarItemDetailDao.FindByHql(" and name not in ('Ref Group','Blood Mode','Take Mode') and item_code = ? order by code asc", new Object[] { itemCode }, "");
            return list;
        }

        /// <summary>
        /// 按id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClinicarItemDetail FindById(String Id)
        {
            return ClinicarItemDetailDao.FindById(Id);
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

            int count = ClinicarItemDetailDao.FindCountByHql(_sql, _listParam.ToArray());
            return count > 0 ? true : false;
        }
    }
}
