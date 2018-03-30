using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SCommon.SUtil
{
    public class SPictureBoxUtil
    {
        /// <summary>
        /// 获取PictureBox在Zoom下显示的位置和大小
        /// </summary>        
        /// <param name="p_PictureBox">Picture 如果没有图形或则非ZOOM模式 返回的是PictureBox的大小</param>
        /// <returns>如果p_PictureBox为null 返回 Rectangle(0, 0, 0, 0)</returns>         
        public static Rectangle GetPictureBoxZoomSize(PictureBox p_PictureBox)
        {
            if (p_PictureBox != null)
            {
                PropertyInfo _ImageRectanglePropert = p_PictureBox.GetType().GetProperty("ImageRectangle",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                return (Rectangle)_ImageRectanglePropert.GetValue(p_PictureBox, null);

            } return new Rectangle(0, 0, 0, 0);
        }
    }
}
