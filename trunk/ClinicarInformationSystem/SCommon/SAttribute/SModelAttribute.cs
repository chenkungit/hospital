using System;

namespace SCommon.SAttribute
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SModelAttribute : Attribute
    {
        /// <summary>
        /// </summary>
        public SModelAttribute(string _table)
        {
            this.table = _table;
        }

        /// <summary>
        /// 数据库表名称
        /// </summary>
        private string table;
        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        /// <summary>
        /// 用于显示的名称
        /// </summary>
        private string display;
        public string Display
        {
            get { return display; }
            set { display = value; }
        }
    }

    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SModelPropertyAttribute : Attribute
    {
        /// <summary>
        /// </summary>
        public SModelPropertyAttribute(string _column)
        {
            this.column = _column;
        }

        /// <summary>
        /// 数据库字段名
        /// </summary>
        private string column;
        public string Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// 用于显示的名称
        /// </summary>
        private string display;
        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        /// <summary>
        /// 是否瞬时字段
        /// </summary>
        private bool transient;
        public bool Transient
        {
            get { return transient; }
            set { transient = value; }
        }
    }
}
