using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SAttribute
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class SEnumAttribute : Attribute
    {
        private string showName;

        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName
        {
            get
            {
                return this.showName;
            }
        }

        /// <summary>
        /// 构造枚举的显示名称
        /// </summary>
        /// <param name="showName">显示名称</param>
        public SEnumAttribute(string showName)
        {
            this.showName = showName;
        }
    }
}
