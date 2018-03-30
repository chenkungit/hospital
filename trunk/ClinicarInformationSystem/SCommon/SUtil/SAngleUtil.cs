using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SAngleUtil
    {
        /// <summary>
        /// 返回true表示从fromPoint顺时针旋转到toPoint, 反之则逆时针
        /// </summary>
        /// <param name="fromPoint"></param>
        /// <param name="toPoint"></param>
        /// <param name="centerPoint">中心点</param>
        /// <returns></returns>
        public static bool GetTurnDirection(Point fromPoint, Point toPoint, Point centerPoint)
        {
            Point a = new Point(fromPoint.X - centerPoint.X, fromPoint.Y - centerPoint.Y);
            Point b = new Point(toPoint.X - centerPoint.X, toPoint.Y - centerPoint.Y);
            return b.Y * a.X - b.X * a.Y >= 0;
        }

        /// <summary>
        /// 返回true表示从fromPoint顺时针旋转到toPoint, 反之则逆时针
        /// </summary>
        /// <param name="fromPoint"></param>
        /// <param name="toPoint"></param>
        /// <returns></returns>
        public static bool GetTurnDirection(Point fromPoint, Point toPoint)
        {
            return GetTurnDirection(fromPoint, toPoint, Point.Empty);
        }

        /// <summary>
        /// 获取基于center点的a点的对称点
        /// </summary>
        /// <param name="a"></param>
        /// <param name="center"></param>
        /// <returns></returns>
        public static Point GetSymmetryPoint(Point a, Point center)
        {
            return new Point(2 * center.X - a.X, 2 * center.Y - a.Y);
        }

        /// <summary>
        /// 基于笛卡尔坐标系，从 X 轴正向逆时针旋转到向量ab时经过的角度
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetAngleOfLine(Point a, Point b)
        {
            double angleOfLine = Math.Atan2((b.Y - a.Y), (b.X - a.X));
            return angleOfLine * 180 / System.Math.PI;
        }

        /// <summary>
        /// 计算∠AOB(内角)
        /// </summary>
        /// <param name="O"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double GetAngleOfAOB(Point A, Point O, Point B)
        {
            float dx1, dx2, dy1, dy2;
            double angle;
            dx1 = A.X - O.X;
            dy1 = A.Y - O.Y;
            dx2 = B.X - O.X;
            dy2 = B.Y - O.Y;
            double c = Math.Sqrt(dx1 * dx1 + dy1 * dy1) * Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            if (c == 0)
            {
                return -1;
            }
            else
            {
                // 按照余弦定理得到公式：
                angle = Math.Acos((dx1 * dx2 + dy1 * dy2) / c);
                return angle * 180 / System.Math.PI;
            }
        }

        /// <summary>
        /// 计算点P(x,y)与X轴正方向的夹角
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <returns>夹角弧度</returns>
        private static double RadPOX(double x, double y)
        {
            //P在(0,0)的情况
            if (x == 0 && y == 0) return 0;

            //P在四个坐标轴上的情况：x正、x负、y正、y负
            if (y == 0 && x > 0) return 0;
            if (y == 0 && x < 0) return Math.PI;
            if (x == 0 && y > 0) return Math.PI / 2;
            if (x == 0 && y < 0) return Math.PI / 2 * 3;

            //点在第一、二、三、四象限时的情况
            if (x > 0 && y > 0) return Math.Atan(y / x);
            if (x < 0 && y > 0) return Math.PI - Math.Atan(y / -x);
            if (x < 0 && y < 0) return Math.PI + Math.Atan(-y / -x);
            if (x > 0 && y < 0) return Math.PI * 2 - Math.Atan(-y / x);

            return 0;
        }

        /// <summary>
        /// 两点间距离
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetDistance(Point a, Point b)
        {
            double d = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            return d;
        }

        /// <summary>
        /// 【基于直角坐标系】已知圆上两点坐标和凸度，求圆心坐标
        /// </summary>
        /// <param name="BeginPoint"></param>
        /// <param name="EndPoint"></param>
        /// <param name="centerAngle">从BeginPoint到EndPoint夹角【弧度】；顺时针为正，逆时针为负</param>
        /// <returns></returns>
        public static Point GetCenterPoint(Point BeginPoint, Point EndPoint, double centerAngle)
        {
            double x1, x2, y1, y2;//圆弧起始点和终止点
            x1 = BeginPoint.X;
            y1 = BeginPoint.Y;
            x2 = EndPoint.X;
            y2 = EndPoint.Y;

            double L; //弦长
            L = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

            double R = L / 2;//圆弧半径
            if (Math.Abs(centerAngle) != Math.PI)
            {
                R = 0.5 * L / Math.Sin(0.5 * centerAngle);
            }

            double h;//圆心到弦的距离
            h = Math.Sqrt(R * R - L * L / 4);

            //double k;//起始点和终止点连线的中垂线斜率
            double xc, yc;//圆心坐标
            double xa, ya; //起始点和终止点连线的中点横纵坐标
            xa = 0.5 * (x1 + x2);
            ya = 0.5 * (y1 + y2);

            //弦的方向角（0-2PI之）
            double angle;//起点到终点的弦向量与x正方向之间的倾斜角
            angle = Math.Acos((x2 - x1) / Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))); // acos返回值范围是 0~ pi

            double amass; //弦向量与X轴正向单位向量的叉积
            amass = y1 - y2;//由（由(x2-x1)*0-1*(y2-y1)）得到

            // 若 P × Q > 0 , 则P在Q的顺时针方向。 若 P × Q < 0 , 则P在Q的逆时针方向。
            if (amass < 0)
            {
                angle = -angle;
                angle = 2 * Math.PI + angle;
            }


            double DirectionAngle = 0;//弦中点到圆心的直线向量的方向角（0-2PI之间）
            //if ((u > 0 && centerAngle < Math.PI) || (u < 0 && centerAngle > Math.PI))
            //    DirectionAngle = angle + Math.PI / 2;
            //if ((u < 0 && centerAngle < Math.PI) || (u > 0 && centerAngle > Math.PI))
            //    DirectionAngle = angle - Math.PI / 2;

            if ((centerAngle < 0 && Math.Abs(centerAngle) < Math.PI) || (centerAngle > Math.PI))
                DirectionAngle = angle + Math.PI / 2;
            if ((centerAngle > 0 && centerAngle < Math.PI) || (centerAngle < 0 && Math.Abs(centerAngle) > Math.PI))
                DirectionAngle = angle - Math.PI / 2;

            if (DirectionAngle > 2 * Math.PI)
                DirectionAngle = DirectionAngle - 2 * Math.PI;

            double d;//圆心到弦的距离
            d = Math.Sqrt(R * R - L * L / 4);
            if (DirectionAngle == 0)
            {
                xc = xa + d;
                yc = ya;
            }
            else if (DirectionAngle == Math.PI / 2)
            {
                xc = xa;
                yc = ya + d;
            }
            else if (DirectionAngle == Math.PI)
            {
                xc = xa - d;
                yc = ya;
            }
            else if (DirectionAngle == Math.PI + Math.PI / 2)
            {
                xc = xa;
                yc = ya - d;
            }
            else
            {
                double nslope, k;//nslope 为弦的斜率，K为弦中垂线的斜率
                double nAngle;//中垂线的倾斜角；
                double X, Y; //圆心相对于弦中心点的坐标偏移量

                nslope = (y2 - y1) / (x2 - x1);
                k = -1 / nslope;
                nAngle = Math.Atan(k);
                X = Math.Cos(nAngle) * d;
                Y = Math.Sin(nAngle) * d;

                if (DirectionAngle > Math.PI / 2 && DirectionAngle < Math.PI)
                {
                    X = -X;
                    Y = -Y;
                }
                if (DirectionAngle > Math.PI && DirectionAngle < (Math.PI + Math.PI / 2))
                {
                    X = -X;
                    Y = -Y;
                }

                xc = xa + X;
                yc = ya + Y;
            }

            Point centerPoint = new Point(
                (int)Math.Round(xc, 0, MidpointRounding.AwayFromZero),
                (int)Math.Round(yc, 0, MidpointRounding.AwayFromZero)
            );

            return centerPoint;
        }

        /// <summary>
        /// 【基于直角坐标系】返回点P围绕点A旋转弧度rad后的坐标
        /// </summary>
        /// <param name="P">待旋转点坐标</param>
        /// <param name="o">旋转中心坐标</param>
        /// <param name="rad">旋转弧度</param>
        /// <param name="isClockwise">true:顺时针/false:逆时针</param>
        /// <returns>旋转后坐标</returns>
        public static Point RotatePoint(Point P, Point o, double rad, bool isClockwise = true)
        {
            //点Temp1
            Point Temp1 = new Point(P.X - o.X, P.Y - o.Y);
            //点Temp1到原点的长度
            double lenO2Temp1 = SAngleUtil.GetDistance(Temp1, new Point(0, 0));
            //∠T1OX弧度
            double angT1OX = SAngleUtil.RadPOX(Temp1.X, Temp1.Y);
            //∠T2OX弧度（T2为T1以O为圆心旋转弧度rad）
            double angT2OX = angT1OX - (isClockwise ? 1 : -1) * rad;

            //点Temp2
            Point Temp2 = new Point(
                (int)Math.Round(lenO2Temp1 * Math.Cos(angT2OX), 0, MidpointRounding.AwayFromZero),
                (int)Math.Round(lenO2Temp1 * Math.Sin(angT2OX), 0, MidpointRounding.AwayFromZero));
            //点Q
            return new Point(Temp2.X + o.X, Temp2.Y + o.Y);
        }
    }
}
