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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarConsultation : SCommon.SControl.SBaseDockForm
    {
        private ClinicarDptSechedulBiz clinicarDptSechedulBiz = new ClinicarDptSechedulBiz();
        public ClinicarDptSechedul DataEntity { get; set; }
        private ClinicarConsultationBiz clinicarConsultationBiz = new ClinicarConsultationBiz();



        public FrmClinicarConsultation()
        {
            InitializeComponent();
        }

        private void FrmClinicarConsultationManage_Load(object sender, EventArgs e)
        {
            this.radio_xz.Checked = true;
            createDate("xz");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 保存前的校验方法
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            return true;
        }

        /// <summary>
        /// 将界面控件中的数据，回填到实体类对象中
        /// </summary>
        private void Fill2Entity()
        {
            
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win()
        {
            
        }
        private void radio_bz_Click(object sender, EventArgs e)
        {
            if (radio_bz.Checked)
            {
                createDate("bz");
            }
        }
        private void radio_xz_Click(object sender, EventArgs e)
        {
            if (radio_xz.Checked)
            {
                createDate("xz");
            }
        }
        private void uTxt_deptCode_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uTxt_hospitalcode.Text) && !"双击选择医院".Equals(uTxt_hospitalcode.Text))
            {
                FrmClinicarDpt frmClinicarDpt = new FrmClinicarDpt();
                frmClinicarDpt.StartPosition = FormStartPosition.CenterScreen;
                frmClinicarDpt.hospitalcod = uTxt_hospitalcode.Text;
                frmClinicarDpt.operationPower = false;
                frmClinicarDpt.ShowDialog();
                if (frmClinicarDpt.DialogResult == DialogResult.OK)
                {
                    uTxt_deptCode.Text = frmClinicarDpt.F_StringCode;
                    uTxt_deptName.Text = frmClinicarDpt.F_StringName;
                }
            }else
            {
                MessageBox.Show("请先选择医院！");
                return;
            }
        }

        /// <summary>
        /// 设置日期
        /// </summary>
        /// <param name="type">本周、下周</param>
        private void createDate(string type)
        {
            if ("bz".Equals(type))
            {
                //获取当前星期
                string d = DateTime.Now.DayOfWeek.ToString("d");

                //获取当前日期
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                this.lbl_date1.Text = "星期一 ";// + Convert.ToDateTime(now).AddDays(1 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date2.Text = "星期二 ";// + Convert.ToDateTime(now).AddDays(2 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date3.Text = "星期三 ";// + Convert.ToDateTime(now).AddDays(3 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date4.Text = "星期四 ";// + Convert.ToDateTime(now).AddDays(4 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date5.Text = "星期五 ";// + Convert.ToDateTime(now).AddDays(5 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date6.Text = "星期六 ";// + Convert.ToDateTime(now).AddDays(6 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date7.Text = "星期日 ";// + Convert.ToDateTime(now).AddDays(7 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d1.Text = Convert.ToDateTime(now).AddDays(1 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d2.Text = Convert.ToDateTime(now).AddDays(2 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d3.Text = Convert.ToDateTime(now).AddDays(3 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d4.Text = Convert.ToDateTime(now).AddDays(4 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d5.Text = Convert.ToDateTime(now).AddDays(5 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d6.Text = Convert.ToDateTime(now).AddDays(6 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d7.Text = Convert.ToDateTime(now).AddDays(7 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                //查询数据库中数据
                //list = ClinicarDptSechedulBiz.FindbyDate(f_stringCode, this.lbl_date1, this.lbl_date7);
                lbl_datefrom.Text = Convert.ToDateTime(now).AddDays(1 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                lbl_dateto.Text = Convert.ToDateTime(now).AddDays(7 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
            }
            else if ("xz".Equals(type))
            {
                //获取当前星期
                string d = DateTime.Now.DayOfWeek.ToString("d");
                //获取当前日期
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                this.lbl_date1.Text = "星期一 "; //+ Convert.ToDateTime(now).AddDays(8 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date2.Text = "星期二 "; //+ Convert.ToDateTime(now).AddDays(9 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date3.Text = "星期三 "; //+ Convert.ToDateTime(now).AddDays(10 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date4.Text = "星期四 "; //+ Convert.ToDateTime(now).AddDays(11 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date5.Text = "星期五 "; //+ Convert.ToDateTime(now).AddDays(12 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date6.Text = "星期六 "; //+ Convert.ToDateTime(now).AddDays(13 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date7.Text = "星期日 "; //+ Convert.ToDateTime(now).AddDays(14 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d1.Text = Convert.ToDateTime(now).AddDays(8 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d2.Text = Convert.ToDateTime(now).AddDays(9 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d3.Text = Convert.ToDateTime(now).AddDays(10 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d4.Text = Convert.ToDateTime(now).AddDays(11 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d5.Text = Convert.ToDateTime(now).AddDays(12 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d6.Text = Convert.ToDateTime(now).AddDays(13 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_d7.Text = Convert.ToDateTime(now).AddDays(14 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                //查询数据库中数据
                //list = ClinicarDptSechedulBiz.FindbyDate(f_stringCode, this.lbl_date1, this.lbl_date7);
                lbl_datefrom.Text = Convert.ToDateTime(now).AddDays(8 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                lbl_dateto.Text = Convert.ToDateTime(now).AddDays(14 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
            }

            lbl_swdate1.Visible = false;
            lbl_swdate2.Visible = false;
            lbl_swdate3.Visible = false;
            lbl_swdate4.Visible = false;
            lbl_swdate5.Visible = false;
            lbl_swdate6.Visible = false;
            lbl_swdate7.Visible = false;

            lbl_xwdate1.Visible = false;
            lbl_xwdate2.Visible = false;
            lbl_xwdate3.Visible = false;
            lbl_xwdate4.Visible = false;
            lbl_xwdate5.Visible = false;
            lbl_xwdate6.Visible = false;
            lbl_xwdate7.Visible = false;
            if (!string.IsNullOrEmpty(uTxt_deptCode.Text))
            {
                IList<ClinicarDptSechedul> swlist = clinicarDptSechedulBiz.FindbyDateAndType(uTxt_deptCode.Text, lbl_datefrom.Text, lbl_dateto.Text, "上午");
                if (swlist != null && swlist.Count > 0)
                {
                    foreach (ClinicarDptSechedul cds in swlist)
                    {
                        string weekStr = Convert.ToDateTime(cds.SechedulDate).DayOfWeek.ToString();
                        switch (weekStr)
                        {
                            case "Monday":
                                lbl_swdate1.Text = "可申请";
                                lbl_swdate1.Visible = true;
                                break;
                            case "Tuesday":
                                lbl_swdate2.Text = "可申请";
                                lbl_swdate2.Visible = true;
                                break;
                            case "Wednesday":
                                lbl_swdate3.Text = "可申请";
                                lbl_swdate3.Visible = true;
                                break;
                            case "Thursday":
                                lbl_swdate4.Text = "可申请";
                                lbl_swdate4.Visible = true;
                                break;
                            case "Friday":
                                lbl_swdate5.Text = "可申请";
                                lbl_swdate5.Visible = true;
                                break;
                            case "Saturday":
                                lbl_swdate6.Text = "可申请";
                                lbl_swdate6.Visible = true;
                                break;
                            case "Sunday":
                                lbl_swdate7.Text = "可申请";
                                lbl_swdate7.Visible = true;
                                break;
                        }

                    }
                }
                IList<ClinicarDptSechedul> xwlist = clinicarDptSechedulBiz.FindbyDateAndType(uTxt_deptCode.Text, lbl_datefrom.Text, lbl_dateto.Text, "下午");
                if (xwlist != null && xwlist.Count > 0)
                {
                    foreach (ClinicarDptSechedul cds in xwlist)
                    {
                        string weekStr = Convert.ToDateTime(cds.SechedulDate).DayOfWeek.ToString();
                        switch (weekStr)
                        {
                            case "Monday":
                                lbl_xwdate1.Text = "可申请";
                                lbl_xwdate1.Visible = true;
                                break;
                            case "Tuesday":
                                lbl_xwdate2.Text = "可申请";
                                lbl_xwdate2.Visible = true;
                                break;
                            case "Wednesday":
                                lbl_xwdate3.Text = "可申请";
                                lbl_xwdate3.Visible = true;
                                break;
                            case "Thursday":
                                lbl_xwdate4.Text = "可申请";
                                lbl_xwdate4.Visible = true;
                                break;
                            case "Friday":
                                lbl_xwdate5.Text = "可申请";
                                lbl_xwdate5.Visible = true;
                                break;
                            case "Saturday":
                                lbl_xwdate6.Text = "可申请";
                                lbl_xwdate6.Visible = true;
                                break;
                            case "Sunday":
                                lbl_xwdate7.Text = "可申请";
                                lbl_xwdate7.Visible = true;
                                break;
                        }

                    }
                }

                // 查询已申请的会诊信息 ====上午
                IList<ClinicarConsultation> swConsultationlist = clinicarConsultationBiz.FindbyDate(uTxt_hospitalcode.Text,UserInfo.Username,uTxt_deptCode.Text, lbl_datefrom.Text, lbl_dateto.Text,"上午");
                if (swConsultationlist != null && swConsultationlist.Count > 0)
                {
                    foreach (ClinicarConsultation cc in swConsultationlist)
                    {
                        string weekStr = Convert.ToDateTime(cc.ConsultationDate).DayOfWeek.ToString();
                        switch (weekStr)
                        {
                            case "Monday":
                                lbl_swdate1.Text = "已申请";
                                lbl_swdate1.Visible = true;
                                lbl_swdate1.LinkColor = Color.Red;
                                break;
                            case "Tuesday":
                                lbl_swdate2.Text = "已申请";
                                lbl_swdate2.Visible = true;
                                lbl_swdate2.LinkColor = Color.Red;
                                break;
                            case "Wednesday":
                                lbl_swdate3.Text = "已申请";
                                lbl_swdate3.Visible = true;
                                lbl_swdate3.LinkColor = Color.Red;
                                break;
                            case "Thursday":
                                lbl_swdate4.Text = "已申请";
                                lbl_swdate4.Visible = true;
                                lbl_swdate4.LinkColor = Color.Red;
                                break;
                            case "Friday":
                                lbl_swdate5.Text = "已申请";
                                lbl_swdate5.Visible = true;
                                lbl_swdate5.LinkColor = Color.Red;
                                break;
                            case "Saturday":
                                lbl_swdate6.Text = "已申请";
                                lbl_swdate6.Visible = true;
                                lbl_swdate6.LinkColor = Color.Red;
                                break;
                            case "Sunday":
                                lbl_swdate7.Text = "已申请";
                                lbl_swdate7.Visible = true;
                                lbl_swdate7.LinkColor = Color.Red;
                                break;
                        }

                    }
                }
                // 查询已申请的会诊信息 ===下午
                IList<ClinicarConsultation> xwConsultationlist = clinicarConsultationBiz.FindbyDate(uTxt_hospitalcode.Text,UserInfo.Username, uTxt_deptCode.Text, lbl_datefrom.Text, lbl_dateto.Text, "下午");
                if (xwConsultationlist != null && xwConsultationlist.Count > 0)
                {
                    foreach (ClinicarConsultation cc in xwConsultationlist)
                    {
                        string weekStr = Convert.ToDateTime(cc.ConsultationDate).DayOfWeek.ToString();
                        switch (weekStr)
                        {
                            case "Monday":
                                lbl_xwdate1.Text = "已申请";
                                lbl_xwdate1.Visible = true;
                                lbl_xwdate1.LinkColor = Color.Red;
                                break;
                            case "Tuesday":
                                lbl_xwdate2.Text = "已申请";
                                lbl_xwdate2.Visible = true;
                                lbl_xwdate2.LinkColor = Color.Red;
                                break;
                            case "Wednesday":
                                lbl_xwdate3.Text = "已申请";
                                lbl_xwdate3.Visible = true;
                                lbl_xwdate3.LinkColor = Color.Red;
                                break;
                            case "Thursday":
                                lbl_xwdate4.Text = "已申请";
                                lbl_xwdate4.Visible = true;
                                lbl_xwdate4.LinkColor = Color.Red;
                                break;
                            case "Friday":
                                lbl_xwdate5.Text = "已申请";
                                lbl_xwdate5.Visible = true;
                                lbl_xwdate5.LinkColor = Color.Red;
                                break;
                            case "Saturday":
                                lbl_xwdate6.Text = "已申请";
                                lbl_xwdate6.Visible = true;
                                lbl_xwdate6.LinkColor = Color.Red;
                                break;
                            case "Sunday":
                                lbl_xwdate7.Text = "已申请";
                                lbl_xwdate7.Visible = true;
                                lbl_xwdate7.LinkColor = Color.Red;
                                break;
                        }
                    }
                }
            }
        }

        private void uTxt_deptCode_TextChanged(object sender, EventArgs e)
        {
                if (radio_bz.Checked)
                    createDate("bz");
                else if (radio_xz.Checked)
                    createDate("xz");
        }

        private void uTxt_hospitalcode_DoubleClick(object sender, EventArgs e)
        {
            FrmClinicarHospital frmClinicarHospital = new FrmClinicarHospital();
            frmClinicarHospital.StartPosition = FormStartPosition.CenterScreen;
            frmClinicarHospital.operationPower = false;
            frmClinicarHospital.ShowDialog();
            if (frmClinicarHospital.DialogResult == DialogResult.OK)
            {
                uTxt_hospitalcode.Text = frmClinicarHospital.F_StringCode;
                uTxt_hospitalname.Text = frmClinicarHospital.F_StringName;
            }
        }

        /// <summary>
        /// 设置可否申请
        /// </summary>
        /// <param name="lbl_date"></param>
        /// <param name="lbl_d"></param>
        private void setLinkText(LinkLabel linklab,Label lbl_d)
        {
            if ("可申请".Equals(linklab.Text))
            {
                ClinicarConsultation cc = new ClinicarConsultation();
                cc.DeptCode = uTxt_deptCode.Text;
                cc.DeptName = uTxt_deptName.Text;
                cc.UserName = UserInfo.Username;
                cc.ConsultationDate = Convert.ToDateTime(lbl_d.Text);
                cc.ConsultationType = "上午";
                cc.HospitalCode = uTxt_hospitalcode.Text;//暂留医院代码
                cc.HospitalName = uTxt_hospitalname.Text;//医院名称
                FrmClinicarConsultationManage consultationMangage = new FrmClinicarConsultationManage();
                consultationMangage.DialogStatus = UBaseLib.Enums.DialogStatus.New;
                consultationMangage.DataEntity = cc;
                consultationMangage.ShowDialog();
                //SResult st = clinicarConsultationBiz.Insert(cc);
                if (consultationMangage.DialogResult == DialogResult.OK)
                {
                    linklab.Text = "已申请";
                    linklab.LinkColor = Color.Red;
                }
            }
            else if ("已申请".Equals(linklab.Text))
            {
                //执行删除？
            }
        }

        private void lbl_swdate1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate1, lbl_d1);
        }

        private void lbl_swdate2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate2, lbl_d2);
        }

        private void lbl_swdate3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate3, lbl_d3);
        }

        private void lbl_swdate4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate4, lbl_d4);
        }

        private void lbl_swdate5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate5, lbl_d5);
        }

        private void lbl_swdate6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate6, lbl_d6);
        }

        private void lbl_swdate7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_swdate7, lbl_d7);
        }

        private void lbl_xwdate1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate1, lbl_d1);
        }
        private void lbl_xwdate2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate2, lbl_d2);
        }
        private void lbl_xwdate3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate3, lbl_d3);
        }
        private void lbl_xwdate4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate4, lbl_d4);
        }
        private void lbl_xwdate5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate5, lbl_d5);
        }
        private void lbl_xwdate6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate6, lbl_d6);
        }
        private void lbl_xwdate7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLinkText(lbl_xwdate7, lbl_d7);
        }
    }
}
