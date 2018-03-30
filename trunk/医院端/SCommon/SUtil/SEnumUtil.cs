using SCommon.SAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public sealed class SEnumUtil
    {
        private static Dictionary<string, Dictionary<object, string>> _EnumList = new Dictionary<string, Dictionary<object, string>>(); //枚举缓存池


        /// <summary>
        /// 将枚举转换成Dictionary&lt;int, string&gt;
        /// Dictionary中，key为枚举项对应的int值；value为：若定义了EnumShowName属性，则取它，否则取name
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static Dictionary<object, string> EnumToDictionary(Type enumType)
        {
            string keyName = enumType.FullName;

            if (!_EnumList.ContainsKey(keyName))
            {
                Dictionary<object, string> list = new Dictionary<object, string>();

                foreach (object i in Enum.GetValues(enumType))
                {
                    string name = Enum.GetName(enumType, i);

                    //取显示名称
                    string showName = string.Empty;
                    object[] atts = enumType.GetField(name).GetCustomAttributes(typeof(UBaseLib.Attributes.EnumAttribute), false);
                    if (atts.Length > 0) showName = ((UBaseLib.Attributes.EnumAttribute)atts[0]).ShowName;

                    list.Add(i, string.IsNullOrEmpty(showName) ? name : showName);
                }

                object syncObj = new object();

                if (!_EnumList.ContainsKey(keyName))
                {
                    lock (syncObj)
                    {
                        if (!_EnumList.ContainsKey(keyName))
                        {
                            _EnumList.Add(keyName, list);
                        }
                    }
                }
            }

            return _EnumList[keyName];
        }

        /// <summary>
        /// 获取枚举值对应的显示名称
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="intValue">枚举项对应的int值</param>
        /// <returns></returns>
        public static string GetEnumShowName(Type enumType, object objValue)
        {
            return EnumToDictionary(enumType)[objValue];
        }
    }
}
