using System;
using System.Collections.Generic;
using System.Text;

namespace cis_util
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Util
    {
        #region + 属性

        /// <summary>
        /// 图片类型集合
        /// </summary>
        private enum imageType
        {
            X光,
            B超
        }

        /// <summary>
        /// PDF类型集合
        /// </summary>
        private enum PDFType
        {
            心电图,
            电子阴道镜
        }

        /// <summary>
        /// 图片类型
        /// </summary>
        public const string image = "image";

        /// <summary>
        /// pdf 类型
        /// </summary>
        public const string pdf = "pdf";

        /// <summary>
        /// 数据类型
        /// </summary>
        public const string data = "data";

        /// <summary>
        /// 图片、pdf基本路径
        /// </summary>
        public const string basePath = "D:\\uploadFolder\\";
        
        #endregion

        #region + 方法

        /// <summary>
        /// 根据选择的科室，判断需要展示的类型
        /// 类型：图片、pdf、表格
        /// </summary>
        /// <returns></returns>
        public static string showType(string dpt)
        {
            if (Enum.IsDefined(typeof(imageType), dpt))
            {
                return image;
            }
            else if (Enum.IsDefined(typeof(PDFType), dpt))
            {
                return pdf;
            }
            else
            {
                return data;
            }
        }

        #endregion
    }
}
