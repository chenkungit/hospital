using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SImageUtil
    {
        /// <summary>
        /// Converts an image into an icon.
        /// </summary>
        /// <param name="img">The image that shall become an icon</param>
        /// <param name="size">The width and height of the icon. Standard
        /// sizes are 16x16, 32x32, 48x48, 64x64.</param>
        /// <param name="keepAspectRatio">Whether the image should be squashed into a
        /// square or whether whitespace should be put around it.</param>
        /// <returns>An icon!!</returns>
        public static Icon MakeIcon(Image img, int size, bool keepAspectRatio)
        {
            Bitmap square = new Bitmap(size, size); // create new bitmap
            Graphics g = Graphics.FromImage(square); // allow drawing to it

            int x, y, w, h; // dimensions for new image

            if (!keepAspectRatio || img.Height == img.Width)
            {
                // just fill the square
                x = y = 0; // set x and y to 0
                w = h = size; // set width and height to size
            }
            else
            {
                // work out the aspect ratio
                float r = (float)img.Width / (float)img.Height;

                // set dimensions accordingly to fit inside size^2 square
                if (r > 1)
                { // w is bigger, so divide h by r
                    w = size;
                    h = (int)((float)size / r);
                    x = 0; y = (size - h) / 2; // center the image
                }
                else
                { // h is bigger, so multiply w by r
                    w = (int)((float)size * r);
                    h = size;
                    y = 0; x = (size - w) / 2; // center the image
                }
            }

            // make the image shrink nicely by using HighQualityBicubic mode
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, x, y, w, h); // draw image with specified dimensions
            g.Flush(); // make sure all drawing operations complete before we get the icon

            // following line would work directly on any image, but then
            // it wouldn't look as nice.
            return Icon.FromHandle(square.GetHicon());
        }

        /// <summary>
        /// 图像旋转。angle值为正，则逆时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Image GetRotateImage(Image img, float angle)
        {
            angle = angle % 360;//弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = img.Width;
            int h = img.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Image dsImage = new Bitmap(W, H, img.PixelFormat);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //计算偏移量
                Point Offset = new Point((W - w) / 2, (H - h) / 2);
                //构造图像显示区域：让图像的中心与窗口的中心点一致
                Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform(360 - angle);
                //恢复图像在水平和垂直方向的平移
                g.TranslateTransform(-center.X, -center.Y);
                g.DrawImage(img, rect);
                //重至绘图的所有变换
                g.ResetTransform();
                g.Save();
            }
            return dsImage;
        }


        /// <summary>
        /// 图像旋转。angle值为正，则逆时针旋转
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        public static Image GetRotateImage(Image img, float angle, int maxW, int maxH)
        {
            angle = angle % 360;//弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = img.Width;
            int h = img.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            if (W > maxW) W = maxW;
            if (H > maxH) H = maxH;
            //目标位图
            Image dsImage = new Bitmap(W, H, img.PixelFormat);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //计算偏移量
                Point Offset = new Point((W - w) / 2, (H - h) / 2);
                //构造图像显示区域：让图像的中心与窗口的中心点一致
                Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform(360 - angle);
                //恢复图像在水平和垂直方向的平移
                g.TranslateTransform(-center.X, -center.Y);
                g.DrawImage(img, rect);
                //重至绘图的所有变换
                g.ResetTransform();
                g.Save();
            }
            return dsImage;
        }

        /// <summary>
        /// 图像旋转。angle值为正，则顺时针旋转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Bitmap RotateImage(Image img, float angle)
        {
            Bitmap b = new Bitmap(img);
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }
    }
}
