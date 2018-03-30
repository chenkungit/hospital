using cis_business.biz.clinicar;
using cis_business.biz.sys;
using cis_business.util;
using cis_model.clinicar;
using cis_model.sys;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UComponentLib.Component.Extension;
using ZXing;
using ZXing.Common;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarCheckGuideOrder : SCommon.SControl.SBaseForm
    {
        #region + 属性

        /// <summary>
        ///  CheckItem 业务层
        /// </summary>
        private ClinicarCheckItemBiz clinicarCheckItemBiz = new ClinicarCheckItemBiz();

        /// <summary>
        /// ClinicarCheck 实体类
        /// </summary>
        private ClinicarCheck DataEntityClinicarCheck = new ClinicarCheck();

        /// <summary>
        /// 表格显示的列
        /// </summary>
        private String[] displayProperties = { "DptName", "ItemName" };

        /// <summary>
        /// 每次查询缓存子表，目的是打印的时候绘制表格
        /// </summary>
        private IList<ClinicarCheckItem> listDraw = null;

        /// <summary>
        /// 打印条码相关（panel滚动条相关）
        /// </summary>
        private static Bitmap mBitmap = null;
        private static System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

        #endregion

        #region + 构造方法
        public FrmClinicarCheckGuideOrder(ClinicarCheck DataEntityTransmit)
        {
            InitializeComponent();
            DataEntityClinicarCheck = DataEntityTransmit;
            ucDgv_list.UcDataGridViewControl.BackgroundColor = Color.White;
        }
        #endregion

        #region + 事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinicarCheckGuideOrder_Load(object sender, EventArgs e)
        {
            //初始化（回填数据和生成条码）
            fillBack();
        }

        /// <summary>
        /// 检查号双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTxt_checkNum_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarCheckPatient frmClinicarCheckPatient = new FrmClinicarCheckPatient();
            frmClinicarCheckPatient.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarCheckPatient.ShowDialog();
            if (frmClinicarCheckPatient.DialogResult == DialogResult.OK)
            {
                DataEntityClinicarCheck = frmClinicarCheckPatient.F_DataEntityTransmit;
                fillBack();
            }
        }

        /// <summary>
        /// 打印指引单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_printOrder_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(MyPrintDoc_PrintPage);
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                printPreviewDialog1.ShowDialog();
                //printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("请安装打印机", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_barCode_Click(object sender, EventArgs e)
        {
            PrintPanel(this.panel3);
        }

        /// <summary>
        /// “打印所有” 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_printAll_Click(object sender, EventArgs e)
        {
            btn_printOrder_Click(null,null);
            PrintPanel(this.panel3);
        }

        #endregion

        #region + 分页控件实现
        private int FindResult(int pageNum, int pageSize)
        {
            int check_id = 0;
            if (DataEntityClinicarCheck != null && !string.IsNullOrEmpty(DataEntityClinicarCheck.Id))
            {
                check_id = Convert.ToInt32(DataEntityClinicarCheck.Id);
            }
            SPagintion<ClinicarCheckItem> page = clinicarCheckItemBiz.FindByPagination(pageNum, pageSize, check_id);
            IList<ClinicarCheckItem> list = page != null ? page.Data : new List<ClinicarCheckItem>();
            SGridViewUtil.BindingData<ClinicarCheckItem>(list, this.ucDgv_list.UcDataGridViewControl, displayProperties);

            //移除控件
            this.picb_left.Controls.Clear();
            this.panel3.Controls.Clear();
            if (list != null && !Convert.IsDBNull(list) && list.Count > 0)
            {
                listDraw = list;
                for (int i = 0; i < list.Count; i++)
                {
                    //右边条码
                    createBarCode(uTxt_checkNum.Text.Trim(), list[i].ItemCode, 27, 6 + i * 88);
                }
            }
            //左上角条码
            createLeftBarCode(uTxt_checkNum.Text.Trim());

            return page.TotalRecordCount;
        }

        private void ucDgv_list_UcCustomPagintion(object sender, UComponentLib.Component.Composite.CustomPagintionEventArgs e)
        {
            int count = FindResult(e.PageNum, e.PageSize);
            e.SetResult(true, count);
        }
        #endregion

        #region + 自定义方法
        /// <summary>
        /// 生成条码（检查号+项目编号）
        /// </summary>
        private void createBarCode(string checkNum, string itemCode, int x, int y)
        {
            try
            {
                // 1.设置条形码规格
                EncodingOptions encodeOption = new EncodingOptions();
                encodeOption.Height = 82; // 必须制定高度、宽度
                encodeOption.Width = 179;

                // 2.生成条形码图片
                ZXing.BarcodeWriter wr = new BarcodeWriter();
                wr.Options = encodeOption;
                //条形码规格：CODE_128,能包含数字字母特殊字符；
                wr.Format = BarcodeFormat.CODE_128;
                //生成图片
                Bitmap bitmap = wr.Write(checkNum + itemCode);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(x, y);
                pictureBox.Height = 82;
                pictureBox.Width = 179;
                pictureBox.Image = new Bitmap(bitmap);
                panel3.Controls.Add(pictureBox);
            }
            catch
            {
                UcMessageBox.Warning("检查号或项目编号含有特殊字符，条码生成失败.", "提示！");
            }
        }

        /// <summary>
        /// 生成条码（检查号）
        /// </summary>
        private void createLeftBarCode(string checkNum)
        {
            if (string.IsNullOrEmpty(checkNum)) return;

            try
            {
                // 1.设置条形码规格
                EncodingOptions encodeOption = new EncodingOptions();
                encodeOption.Height = 44; // 必须制定高度、宽度
                encodeOption.Width = 98;

                // 2.生成条形码图片
                ZXing.BarcodeWriter wr = new BarcodeWriter();
                wr.Options = encodeOption;
                //条形码规格：CODE_128,能包含数字字母特殊字符；
                wr.Format = BarcodeFormat.CODE_128;
                //生成图片
                Bitmap bitmap = wr.Write(checkNum);
                picb_left.Image = new Bitmap(bitmap);
            }
            catch
            {
                UcMessageBox.Warning("检查号含有特殊字符，条码生成失败.", "提示！");
            }
        }

        /// <summary>
        /// 回填数据
        /// </summary>
        private void fillBack()
        {
            if (DataEntityClinicarCheck != null)
            {
                uTxt_checkNum.Text = DataEntityClinicarCheck.CheckNumber;
                uTxt_name.Text = DataEntityClinicarCheck.Name;
                uDat_checkDate.Value = Convert.ToDateTime(DataEntityClinicarCheck.CheckDate);
                uTxt_genderName.Text = DataEntityClinicarCheck.GenderName;
                uNum_age.Text = DataEntityClinicarCheck.Age.ToString();
                uTxt_certificateNumber.Text = DataEntityClinicarCheck.CertificateNumber;
                this.ucDgv_list.Search(1);
            }
            else
            {
                //清空
                uTxt_checkNum.Text = string.Empty;
                uTxt_name.Text = string.Empty;
                uDat_checkDate.Value = DateTime.Now;
                uTxt_genderName.Text = string.Empty;
                uNum_age.Text = string.Empty;
                uTxt_certificateNumber.Text = string.Empty;
                this.ucDgv_list.Search(1);
            }
        }
        #endregion

        #region + 绘制打印表格（指引单）

        /// <summary>
        /// 绘制打印表格（指引单）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyPrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (listDraw == null || Convert.IsDBNull(listDraw) || listDraw.Count <= 0)
            {
                return;
            }
            //字体 颜色 格式 坐标
            Font drawFont = null;
            SolidBrush drawBrush = null;
            float x = 0F;
            float y = 0F;
            StringFormat drawFormat = new StringFormat();

            drawFont = new Font("Arial", 12);
            drawBrush = new SolidBrush(Color.Black);
            x = 0F;
            y = 0F;
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;
            //表格行数
            int num = listDraw.Count() + 1;
            if (num < 6)
            {
                num = 6;
            }
            //标题
            //标题第一行
            string title = "检查通知单";
            string BillCode = "检查号：" + uTxt_checkNum.Text;
            string ClassType = "姓名：" + uTxt_name.Text;
            string type1 = "日期：" + uDat_checkDate.Value.ToString("yyyy-MM-dd");
            //标题第二行
            string ArriveStation = "性别：" + uTxt_genderName.Text;
            string SpLine = "年龄：" + uNum_age.Text;
            string SaleNo = "证件号：" + uTxt_certificateNumber.Text;
            //线条长度
            Pen line = new Pen(drawBrush, 1);
            //绘图--字的位置
            //绘图--总标题
            e.Graphics.DrawString(title, new Font("黑体", 16), drawBrush, 350, 45, drawFormat);
            //绘图--标题--第一行
            //吊号
            e.Graphics.DrawString(BillCode, drawFont, drawBrush, 125, 83, drawFormat);
            //班别
            e.Graphics.DrawString(ClassType, drawFont, drawBrush, 370, 83, drawFormat);
            //类型
            e.Graphics.DrawString(type1, drawFont, drawBrush, 520, 83, drawFormat);
            //记录单号
            //绘图--标题--第二行
            //到站
            e.Graphics.DrawString(ArriveStation, drawFont, drawBrush, 125, 106, drawFormat);
            //专用线
            e.Graphics.DrawString(SpLine, drawFont, drawBrush, 370, 106, drawFormat);
            //销售订单号
            e.Graphics.DrawString(SaleNo, drawFont, drawBrush, 520, 106, drawFormat);

            //绘图 表格
            float leftbianJu = 60;
            float topbianJu = 152;
            float tableWidth = 720;
            float tableHeight = 40 * num;
            float cellwidth = 55;
            float cellwidth1 = 55;
            float cellheigh = 0F;
            //绘图--线的位置 外边矩形
            //横
            e.Graphics.DrawLine(line, leftbianJu, topbianJu, leftbianJu + tableWidth, topbianJu);
            e.Graphics.DrawLine(line, leftbianJu, topbianJu + tableHeight, leftbianJu + tableWidth, topbianJu + tableHeight);
            //竖
            e.Graphics.DrawLine(line, leftbianJu, topbianJu, leftbianJu, topbianJu + tableHeight);
            e.Graphics.DrawLine(line, leftbianJu + tableWidth, topbianJu, leftbianJu + tableWidth, topbianJu + tableHeight);
            //e.Graphics.DrawLine(line, 15, 0, 15, 614);
            //绘图--内部竖线的位置
            y = topbianJu + tableHeight;
            x = leftbianJu + cellwidth;
            e.Graphics.DrawLine(line, tableWidth / 2 + leftbianJu, topbianJu, tableWidth / 2 + leftbianJu, y);
            //绘图--内部横线的位置
            //根据块数计算表格高度
            if (num != 0)
                //cellheigh = tableHeight / (float)num;
                cellheigh = 40;
            else
                cellheigh = 0;
            //绘图--内部横线的位置
            for (int i = 1; i <= num; i++)
            {
                if (i == 1)
                {
                    //表头
                    string str = "";
                    str = "检查项目";
                    x = leftbianJu + cellwidth / 5;
                    y = topbianJu + cellheigh / 3;
                    e.Graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
                    str = "科室";
                    x = leftbianJu + tableWidth / 2 + cellwidth1 / 5;
                    e.Graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
                }
                else
                {
                    //如果检查项目不够五条时，则添加空行
                    if (i - 1 > listDraw.Count)
                    {
                        //检查项目
                        string str = "";
                        x = leftbianJu + cellwidth / 5;
                        y = topbianJu + cellheigh * (i - 1) + cellheigh / 3;
                        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);

                        //科室
                        str = "";
                        x = leftbianJu + cellwidth1 / 5 + tableWidth / 2;
                        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);
                    }
                    else
                    {
                        //检查项目
                        string str = listDraw[i - 2].ItemName;
                        x = leftbianJu + cellwidth / 5;
                        y = topbianJu + cellheigh * (i - 1) + cellheigh / 3;
                        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);

                        //科室
                        str = listDraw[i - 2].DptName;
                        x = leftbianJu + cellwidth1 / 5 + tableWidth / 2;
                        e.Graphics.DrawString(str, new Font("Arial", 10), drawBrush, x, y, drawFormat);
                    }
                }

                //横线
                y = topbianJu + cellheigh * i;
                e.Graphics.DrawLine(line, leftbianJu, y, leftbianJu + tableWidth, y);
                //打印条码
                e.Graphics.DrawImage(picb_left.Image, 20, 35, 100, 50);
            }
            e.HasMorePages = false;
        }
        #endregion

        #region + 打印Panel滚动条内容相关
        #region + 处理打印Panel时 跨越滚动条 API

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        public enum ScrollBarInfoFlags
        {
            SIF_RANGE = 0x0001,
            SIF_PAGE = 0x0002,
            SIF_POS = 0x0004,
            SIF_DISABLENOSCROLL = 0x0008,
            SIF_TRACKPOS = 0x0010,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS)
        }
        public enum ScrollBarRequests
        {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);
        [DllImport("user32")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool Rush);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        #endregion
        #region + 将内容转换成图片形式返回
        public static Bitmap GetPanel(Panel p_Panel)
        {
            bool _PanelAotu = p_Panel.AutoScroll;
            Size _PanelSize = p_Panel.Size;
            p_Panel.Visible = false;
            p_Panel.AutoScroll = true;
            MoveBar(0, 0, p_Panel);
            MoveBar(1, 0, p_Panel);
            Point _Point = GetScrollPoint(p_Panel);
            p_Panel.Width += _Point.X + 5;
            p_Panel.Height += _Point.Y + 5;
            Bitmap _BitMap = new Bitmap(p_Panel.Width, p_Panel.Height);
            p_Panel.DrawToBitmap(_BitMap, new Rectangle(0, 0, _BitMap.Width, _BitMap.Height));
            p_Panel.AutoScroll = _PanelAotu;
            p_Panel.Size = _PanelSize;
            p_Panel.Visible = true;

            return _BitMap;
        }
        #endregion
        #region + 获取滚动条数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MyControl"></param>
        /// <param name="ScrollSize"></param>
        /// <returns></returns>
        private static Point GetScrollPoint(Control MyControl)
        {
            Point MaxScroll = new Point();
            SCROLLINFO ScrollInfo = new SCROLLINFO();
            ScrollInfo.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(ScrollInfo);
            ScrollInfo.fMask = (uint)ScrollBarInfoFlags.SIF_ALL;
            GetScrollInfo(MyControl.Handle, 1, ref ScrollInfo);
            MaxScroll.Y = ScrollInfo.nMax - (int)ScrollInfo.nPage;
            if ((int)ScrollInfo.nPage == 0) MaxScroll.Y = 0;
            GetScrollInfo(MyControl.Handle, 0, ref ScrollInfo);
            MaxScroll.X = ScrollInfo.nMax - (int)ScrollInfo.nPage;
            if ((int)ScrollInfo.nPage == 0) MaxScroll.X = 0;
            return MaxScroll;
        }
        #endregion
        #region + 移动控件滚动条位置
        /// <summary>
        /// 移动控件滚动条位置
        /// </summary>
        /// <param name="Bar"></param>
        /// <param name="Point"></param>
        /// <param name="MyControl"></param>
        private static void MoveBar(int Bar, int Point, Control MyControl)
        {
            if (Bar == 0)
            {
                SetScrollPos(MyControl.Handle, 0, Point, true);
                SendMessage(MyControl.Handle, (int)0x0114, (int)ScrollBarRequests.SB_THUMBPOSITION, 0);
            }
            else
            {
                SetScrollPos(MyControl.Handle, 1, Point, true);
                SendMessage(MyControl.Handle, (int)0x0115, (int)ScrollBarRequests.SB_THUMBPOSITION, 0);
            }
        }
        #endregion
        #region + 打印方法
        public void PrintPanel(Panel p)
        {
            PrintPreviewDialog ppvw;
            Graphics mygraphics = p.CreateGraphics();
            
            mBitmap = GetPanel(panel3);                 //调用方法

            ppvw = new PrintPreviewDialog();
            ppvw.Width = 800;
            ppvw.Height = 600;
            ppvw.Document = printDoc;
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
            if (ppvw.ShowDialog() != DialogResult.OK)
            {
                printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
                return;
            }
            printDoc.Print();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr HDest, int nXDest, int nYDest, int nWidth, int hHeight, IntPtr HSrc, int nXSrc, int nYSrc, int DwRop);

        /// <summary>
        /// 打印每页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(mBitmap, 0, 0);
        }
        #endregion

        #endregion + 打印Panel滚动条内容相关
    }
}
