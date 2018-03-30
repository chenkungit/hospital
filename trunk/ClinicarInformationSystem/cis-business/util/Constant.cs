using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cis_business.util
{
    public enum DicSort
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        UserType,

        /// <summary>
        /// 性别
        /// </summary>
        GenderCode,

        /// <summary>
        /// 民族
        /// </summary>
        NationalityCode,

        /// <summary>
        /// 婚姻
        /// </summary>
        MaritalStatusCode,

        /// <summary>
        /// 证件
        /// </summary>
        CertificateTypeCode,

        /// <summary>
        /// 字典类型
        /// </summary>
        DataType,

        /// <summary>
        /// 设备编号
        /// </summary>
        DeviceCode,

        /// <summary>
        /// 上传项目
        /// </summary>
        UploadItem

    }

    public class Constant
    {
        //数据存放
        private static Dictionary<DicSort, Dictionary<String, String>> dicData;
        public static Dictionary<String, String> GetDicData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String , String>();
            dict.Add("11", "系统管理员");
            dict.Add("21", "医生");
            dicData.Add(DicSort.UserType, dict);
            return dicData[ds];
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetDataType(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("01", "字典类型");
            dict.Add("02", "字典数据");
            dicData.Add(DicSort.DataType, dict);
            return dicData[ds];
        }

        public static String GetDicDataValue(DicSort ds, string key)
        {
            if (GetDicData(ds).ContainsKey(key))
            {
                return GetDicData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///性别
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetGenderCodeData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("1", "男");
            dict.Add("2", "女");
            dicData.Add(DicSort.GenderCode, dict);
            return dicData[ds];
        }

        /// <summary>
        /// 根据编号返回性别名称
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetGenderCodeDataValue(DicSort ds, string key)
        {
            if (GetGenderCodeData(ds).ContainsKey(key))
            {
                return GetGenderCodeData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///民族
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetNationalityCodeData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("1", "汉族");
            dict.Add("2", "其他");
            dicData.Add(DicSort.NationalityCode, dict);
            return dicData[ds];
        }

        /// <summary>
        /// 根据编号返回民族名称
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetNationalityCodeDataValue(DicSort ds, string key)
        {
            if (GetNationalityCodeData(ds).ContainsKey(key))
            {
                return GetNationalityCodeData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///婚姻
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetMaritalStatusCodeData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("1", "保密");
            dict.Add("2", "未婚");
            dict.Add("3", "已婚");
            dicData.Add(DicSort.MaritalStatusCode, dict);
            return dicData[ds];
        }

        /// <summary>
        /// 根据编号返回婚姻名称
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetMaritalStatusCodeDataValue(DicSort ds, string key)
        {
            if (GetMaritalStatusCodeData(ds).ContainsKey(key))
            {
                return GetMaritalStatusCodeData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///证件
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetCertificateTypeCodeData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("1", "身份证");
            dict.Add("2", "军官证");
            dict.Add("3", "其他");
            dicData.Add(DicSort.CertificateTypeCode, dict);
            return dicData[ds];
        }

        /// <summary>
        /// 根据编号返回证件名称
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetCertificateTypeCodeDataValue(DicSort ds, string key)
        {
            if (GetCertificateTypeCodeData(ds).ContainsKey(key))
            {
                return GetCertificateTypeCodeData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///设备编号
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetDeviceCodeData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("01", "X光");
            dict.Add("02", "心电图");
            dict.Add("03", "B超");
            dict.Add("04", "阴道镜");
            dict.Add("05", "尿分析仪");
            dict.Add("06", "血分析仪");
            dict.Add("07", "生化分析仪");
            dicData.Add(DicSort.DeviceCode, dict);
            return dicData[ds];
        }

        /// <summary>
        /// 根据编号返回性别名称
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetDeviceCodeDataValue(DicSort ds, string key)
        {
            if (GetDeviceCodeData(ds).ContainsKey(key))
            {
                return GetDeviceCodeData(ds)[key];
            }
            return "";
        }

        /// <summary>
        ///上传项目
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GetUploadItemData(DicSort ds)
        {
            dicData = new Dictionary<DicSort, Dictionary<String, String>>();
            Dictionary<String, String> dict;
            dict = new Dictionary<String, String>();
            dict.Add("t_clinicar_consultation", "会诊记录");
            dict.Add("t_clinicar_check_result", "检查结果");
            dicData.Add(DicSort.UploadItem, dict);
            return dicData[ds];
        }
    }
}
