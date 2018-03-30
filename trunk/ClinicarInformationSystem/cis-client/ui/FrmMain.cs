using cis_client.ui.clinicar;
using cis_client.ui.clinihospital;
using cis_client.ui.sys;
using SCommon.SControl;
using SCommon.SQL;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace cis_client.ui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string _strWeek = string.Empty;
            switch (DateTime.Now.DayOfWeek.ToString("d"))
            {
                case "0":
                    _strWeek = "星期日";
                    break;
                case "1":
                    _strWeek = "星期一";
                    break;
                case "2":
                    _strWeek = "星期二";
                    break;
                case "3":
                    _strWeek = "星期三";
                    break;
                case "4":
                    _strWeek = "星期四";
                    break;
                case "5":
                    _strWeek = "星期五";
                    break;
                case "6":
                    _strWeek = "星期六";
                    break;
            }

            this.lbl_date.Text = "今天是" + DateTime.Now.ToString("D") + _strWeek;
            FrmLogin formLogin = new FrmLogin();
            formLogin.StartPosition = FormStartPosition.CenterScreen;
            formLogin.ShowDialog();
            if (formLogin.DialogResult == DialogResult.OK)//如果登录框返回DialogResult.OK
            {
                InitButton(formLogin.userType);
            }
            else
            {
                this.Close();
                return;
            }

            //this.WindowState = FormWindowState.Maximized;       //窗口最大化
            //窗口最大化且不遮挡任务栏
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            //注册事件
            this.pnl_top.MouseDown += this.MouseDown4MoveWin;
            this.lbl_title.MouseDown += this.MouseDown4MoveWin;
            this.pb_logo.MouseDown += this.MouseDown4MoveWin;

            System.Windows.Forms.ContextMenuStrip cms = new System.Windows.Forms.ContextMenuStrip();
            cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{
                new System.Windows.Forms.ToolStripMenuItem("关闭", null, tsmiClose_Click, "tsmiClose")
            });

            //将右键菜单绑定到DockContent的TabPage上
            this.wDpnl_Main.ContextMenuStrip = cms;
        }

        #region + 移动窗体
        //定义无边框窗体Form
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void MouseDown4MoveWin(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }
        #endregion

        #region + 选项卡打开窗体
        public bool IsOpendForm(string text)
        {
            bool rBool = false;
            if (!string.IsNullOrEmpty(text))
            {
                foreach (IDockContent content in this.wDpnl_Main.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        content.DockHandler.Activate();
                        rBool = true;
                        content.DockHandler.Show();
                        break;
                    }
                }
            }
            return rBool;
        }

        /// <summary>
        /// 打卡选项卡
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        private void OpenTab(string title, Image icon)
        {
            //验证是否存在
            Boolean _IsExtst = IsOpendForm(title);
            if (!_IsExtst)
            {
                //循环判断显示哪个页面
                SBaseDockForm frm = new SBaseDockForm();
                switch (title)
                {
                    case "用户管理":
                        frm = new FrmSysUser();
                        break;
                    case "基础数据管理":
                        frm = new FrmBaseData();
                        break;
                    case "医院管理":
                        frm = new FrmClinicarHospital();
                        break;
                    case "科室管理":
                        frm = new FrmClinicarDpt();
                        break;
                    case "项目管理":
                        frm = new FrmClinicarItem();
                        break;
                    case "登记":
                        frm = new FrmClinicarCheck();
                        break;
                    case "分检":
                        frm = new FrmClinicarSortCheck();
                        break;
                    case "总检":
                        frm = new FrmClinicarAllCheck();
                        break;
                    case "申请会诊":
                        frm = new FrmClinicarConsultation();
                        break;

                    case "我的会诊":
                        frm = new FrmClinihospitalMyConsultation();
                        break;

                    case "我的科室":
                        frm = new FrmClinihospitalDpt();
                        break;

                    case "视频通信":
                        frm = new FrmCliniWebBrowser();
                        break;
                    //case "就诊统计":
                    //    frm = new FrmClinicarCheckTotal();
                    //    break;

                    default:
                        break;
                }

                frm.Text = title;
                if (icon != null)
                    frm.Icon = SImageUtil.MakeIcon(icon, 32, true);
                frm.Show(wDpnl_Main);
            }
        }
        #endregion

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            string title = "";
            Image icon = null;
            if (sender as Button != null)
            {
                title = (sender as Button).Text;
                icon = (sender as Button).Image;
            }

            if (title == "退出")
            {
                this.Close();
            }
            else
            {
                this.OpenTab(title, icon);
            }
        }

        /// <summary>
        /// 动态添加按钮，方便以后权限控制
        /// </summary>
        private void InitButton(string userType)
        {
            int btnHeight = 40;
            if (userType.Equals("11"))//管理员
            {
                Button btnSysUser = new Button();
                btnSysUser.Text = "用户管理";
                btnSysUser.Size = new Size(this.flp_left.Width, btnHeight);
                btnSysUser.FlatStyle = FlatStyle.Flat;
                btnSysUser.Margin = new Padding(0);
                btnSysUser.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnSysUser);
                btnSysUser.Click += this.btn_Click;

                Button btnSysDict = new Button();
                btnSysDict.Text = "基础数据管理";
                btnSysDict.Size = new Size(this.flp_left.Width, btnHeight);
                btnSysDict.FlatStyle = FlatStyle.Flat;
                btnSysDict.Margin = new Padding(0);
                btnSysDict.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnSysDict);
                btnSysDict.Click += this.btn_Click;
            }
            else if (userType.Equals("21"))//医生
            {
                Button btnClinicarHos = new Button();
                btnClinicarHos.Text = "医院管理";
                btnClinicarHos.Size = new Size(this.flp_left.Width, btnHeight);
                btnClinicarHos.FlatStyle = FlatStyle.Flat;
                btnClinicarHos.Margin = new Padding(0);
                btnClinicarHos.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnClinicarHos);
                btnClinicarHos.Click += this.btn_Click;

                Button btnClinicarDtp = new Button();
                btnClinicarDtp.Text = "科室管理";
                btnClinicarDtp.Size = new Size(this.flp_left.Width, btnHeight);
                btnClinicarDtp.FlatStyle = FlatStyle.Flat;
                btnClinicarDtp.Margin = new Padding(0);
                btnClinicarDtp.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnClinicarDtp);
                btnClinicarDtp.Click += this.btn_Click;


                Button btnClinicarItem = new Button();
                btnClinicarItem.Text = "项目管理";
                btnClinicarItem.Size = new Size(this.flp_left.Width, btnHeight);
                btnClinicarItem.FlatStyle = FlatStyle.Flat;
                btnClinicarItem.Margin = new Padding(0);
                btnClinicarItem.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnClinicarItem);
                btnClinicarItem.Click += this.btn_Click;

                Button btnCheck = new Button();
                btnCheck.Text = "登记";
                btnCheck.Size = new Size(this.flp_left.Width, btnHeight);
                btnCheck.FlatStyle = FlatStyle.Flat;
                btnCheck.Margin = new Padding(0);
                btnCheck.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnCheck);
                btnCheck.Click += this.btn_Click;

                Button btnSortCheck = new Button();
                btnSortCheck.Text = "分检";
                btnSortCheck.Size = new Size(this.flp_left.Width, btnHeight);
                btnSortCheck.FlatStyle = FlatStyle.Flat;
                btnSortCheck.Margin = new Padding(0);
                btnSortCheck.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnSortCheck);
                btnSortCheck.Click += this.btn_Click;

                Button btnAllCheck = new Button();
                btnAllCheck.Text = "总检";
                btnAllCheck.Size = new Size(this.flp_left.Width, btnHeight);
                btnAllCheck.FlatStyle = FlatStyle.Flat;
                btnAllCheck.Margin = new Padding(0);
                btnAllCheck.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnAllCheck);
                btnAllCheck.Click += this.btn_Click;

                Button btnConsultation = new Button();
                btnConsultation.Text = "申请会诊";
                btnConsultation.Size = new Size(this.flp_left.Width, btnHeight);
                btnConsultation.FlatStyle = FlatStyle.Flat;
                btnConsultation.Margin = new Padding(0);
                btnConsultation.FlatAppearance.BorderSize = 0;
                this.flp_left.Controls.Add(btnConsultation);
                btnConsultation.Click += this.btn_Click;


                Button btnMyConsultation = new Button();
                btnMyConsultation.Text = "我的会诊";
                btnMyConsultation.Size = new Size(this.flp_left.Width, btnHeight);
                btnMyConsultation.FlatStyle = FlatStyle.Flat;
                btnMyConsultation.Margin = new Padding(0);
                btnMyConsultation.FlatAppearance.BorderSize = 0;
                //this.flp_left.Controls.Add(btnMyConsultation);
                btnMyConsultation.Click += this.btn_Click;

                Button btnhospitalDpt = new Button();
                btnhospitalDpt.Text = "我的科室";
                btnhospitalDpt.Size = new Size(this.flp_left.Width, btnHeight);
                btnhospitalDpt.FlatStyle = FlatStyle.Flat;
                btnhospitalDpt.Margin = new Padding(0);
                btnhospitalDpt.FlatAppearance.BorderSize = 0;
                //this.flp_left.Controls.Add(btnhospitalDpt);
                btnhospitalDpt.Click += this.btn_Click;

                Button btnUploadData = new Button();
                btnUploadData.Text = "数据上传";
                btnUploadData.Size = new Size(this.flp_left.Width, btnHeight);
                btnUploadData.FlatStyle = FlatStyle.Flat;
                btnUploadData.Margin = new Padding(0);
                btnUploadData.FlatAppearance.BorderSize = 0;
                //this.flp_left.Controls.Add(btnUploadData);
                btnUploadData.Click += this.btn_DataUploadClick;

                Button btnWebBrowser = new Button();
                btnWebBrowser.Text = "视频通信";
                btnWebBrowser.Size = new Size(this.flp_left.Width, btnHeight);
                btnWebBrowser.FlatStyle = FlatStyle.Flat;
                btnWebBrowser.Margin = new Padding(0);
                btnWebBrowser.FlatAppearance.BorderSize = 0;
                //this.flp_left.Controls.Add(btnWebBrowser);
                btnWebBrowser.Click += this.btn_Click;

                Button btnCheckTotal = new Button();
                btnCheckTotal.Text = "就诊统计";
                btnCheckTotal.Size = new Size(this.flp_left.Width, btnHeight);
                btnCheckTotal.FlatStyle = FlatStyle.Flat;
                btnCheckTotal.Margin = new Padding(0);
                btnCheckTotal.FlatAppearance.BorderSize = 0;
                //this.flp_left.Controls.Add(btnCheckTotal);
                btnCheckTotal.Click += this.btn_Click;
            }
            Button btnExit = new Button();
            btnExit.Text = "退出";
            btnExit.Size = new Size(this.flp_left.Width, btnHeight);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Margin = new Padding(0);
            btnExit.FlatAppearance.BorderSize = 0;
            this.flp_left.Controls.Add(btnExit);
            btnExit.Click += this.btn_Click;
        }

        /// <summary>
        /// 数据上传事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DataUploadClick(object sender, EventArgs e)
        {
            FrmClinicarDataUpload dataUpload = new FrmClinicarDataUpload();
            dataUpload.ShowDialog();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem _tsmt = sender as System.Windows.Forms.ToolStripMenuItem;
            if (_tsmt == null) return;
            DockContentCollection contents = this.wDpnl_Main.Contents;
            if (contents == null || Convert.IsDBNull(contents) || contents.Count <= 0) return;
            //关闭
            wDpnl_Main.ActiveContent.DockHandler.Close();
        }
    }
}
