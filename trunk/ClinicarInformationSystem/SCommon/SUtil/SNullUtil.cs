using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SNullUtil
    {
        public static String ChangeNullToString(Object obj) {
            if (obj == null)
                return "";
            return obj.ToString();
        }
        public static Double ChangeNullToSDouble(Object obj)
        {
            if (obj == null || obj.Equals(""))
                return Convert.ToDouble("0");
            else {
                return Convert.ToDouble(obj);
            }
        }
        public static Int32 ChangeNullToInt32(Object obj)
        {
            if (obj == null || obj.Equals(""))
                return Convert.ToInt32("0");
            else
            {
                try
                {
                    return Convert.ToInt32(obj);
                }
                catch {
                    return 0;
                }
            }
        }

        public static Int32? ChangeToInt32(Object obj)
        {
            if (obj == null || obj.ToString().Trim().Equals(""))
                return null;
            else
            {
                try
                {
                    return Convert.ToInt32(obj);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static Int16 ChangeNullToInt16(object obj)
        {
            Int16 rst = 0;
            if (obj != null && !obj.Equals(""))
            {
                try
                {
                    rst = Convert.ToInt16(obj);
                }
                catch
                {
                }
            }
            return rst;
        }

    }
}
