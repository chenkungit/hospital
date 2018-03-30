using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SPagintion<T>
    {
        /**
         * 每页显示的记录数
         */
        public int PageSize { get; set; }

        /**
         * 总页码数
         */
        public int TotalPageCount { get; set; }

        /**
         * 总记录数
         */
        private int totalRecordCount;
        public int TotalRecordCount
        {
            get
            {
                return totalRecordCount;
            }
            set
            {
                totalRecordCount = value;
                int tmp = totalRecordCount / this.PageSize;
                this.TotalPageCount = totalRecordCount % this.PageSize == 0 ? tmp : tmp + 1;
            }
        }

        /**
         * 当前页码
         */
        public int CurrentPageNum { get; set; }

        /**
         * 排序
         */
        public string OrderSql { get; set; }

        public string WhereSql { get; set; }

        public object[] WhereParams { get; set; }

        public IList<T> Data { get; set; }

        public SPagintion()
        {
            this.PageSize = 20;
            this.CurrentPageNum = 1;
            this.TotalPageCount = 1;
            this.TotalRecordCount = 0;
        }
    }
}
