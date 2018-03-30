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
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarDptSechedulManage : SCommon.SControl.SBaseForm
    {
        private ClinicarDptSechedulBiz ClinicarDptSechedulBiz = new ClinicarDptSechedulBiz();
        public ClinicarDptSechedul DataEntity { get; set; }
        /// <summary>
        /// 待保存数据
        /// </summary>
        private List<ClinicarDptSechedul> dptSechedulList = new List<ClinicarDptSechedul>();
        /// <summary>
        /// 回填数据
        /// </summary>
        private IList<ClinicarDptSechedul> list = null;
        //科室编码
        public string f_stringCode = string.Empty;
        //科室名称
        public string f_stringName = string.Empty;

        public FrmClinicarDptSechedulManage()
        {
            InitializeComponent();
        }

        private void FrmClinicarDptSechedulManage_Load(object sender, EventArgs e)
        {
            this.lbl_ksbm.Text = f_stringCode;
            this.lbl_ksmc.Text = f_stringName;
            this.radio_xz.Checked = true;
            createDate("xz");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
            else if (sender == this.btn_save)
            {
                if (this.Save())
                {
                    UcMessageBox.Information("排班成功！");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (this.CheckBeforeSave())//保存前的校验
            {
                SResult rst = new SResult();
                this.DataEntity = new ClinicarDptSechedul();
                this.Fill2Entity(DataEntity);
                //保存前删除数据库中存在的数据
                if(list != null && list.Count >0)
                {
                    foreach(ClinicarDptSechedul cds in list)
                    {
                        ClinicarDptSechedulBiz.Delete(cds.Id);
                    }
                }
                //循环插入数据库
                if (dptSechedulList != null && dptSechedulList.Count > 0)
                {
                    foreach (ClinicarDptSechedul cds in dptSechedulList)
                    {
                        ClinicarDptSechedulBiz.Insert(cds);
                    }
                }
                return true;
            }
            return false;
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
        private void Fill2Entity(ClinicarDptSechedul DataEntity)
        {
            for (int i = 1; i <= 7; i++)
            {
                if (i == 1)
                {
                    if (chk_sw1.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date1.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw1.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date1.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 2)
                {

                    if (chk_sw2.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date2.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw2.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date2.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 3)
                {
                    if (chk_sw3.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date3.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw3.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date3.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 4)
                {
                    if (chk_sw4.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date4.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw4.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date4.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 5)
                {
                    if (chk_sw5.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date5.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw5.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date5.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 6)
                {
                    if (chk_sw6.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date6.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw6.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date6.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
                else if (i == 7)
                {
                    if (chk_sw7.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date7.Text);
                        DataEntity.SechedulType = "上午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                    if (chk_xw7.Checked)
                    {
                        DataEntity = new ClinicarDptSechedul();
                        DataEntity.SechedulDate = Convert.ToDateTime(lbl_date7.Text);
                        DataEntity.SechedulType = "下午";
                        DataEntity.DeptCode = f_stringCode;
                        dptSechedulList.Add(DataEntity);
                    }
                }
            }
            
            
        }

        /// <summary>
        /// 将实体类对象中的数据，回填到界面控件中
        /// </summary>
        private void Fill2Win(IList<ClinicarDptSechedul> list)
        {
            //先清空所有勾选
            chk_sw1.Checked = false;
            chk_sw2.Checked = false;
            chk_sw3.Checked = false;
            chk_sw4.Checked = false;
            chk_sw5.Checked = false;
            chk_sw6.Checked = false;
            chk_sw7.Checked = false;
            chk_xw1.Checked = false;
            chk_xw2.Checked = false;
            chk_xw3.Checked = false;
            chk_xw4.Checked = false;
            chk_xw5.Checked = false;
            chk_xw6.Checked = false;
            chk_xw7.Checked = false;
            //回填已有排班
            if (list != null && list.Count > 0)
            {
                foreach (ClinicarDptSechedul cds in list)
                {
                    if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date1.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw1.Checked = true;
                        else
                            chk_sw1.Checked = false;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw1.Checked = true;
                        else
                            chk_xw1.Checked = false;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date2.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw2.Checked = true;
                        else
                            chk_sw2.Checked = false;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw2.Checked = true;
                        else
                            chk_xw2.Checked = false;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date3.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw3.Checked = true;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw3.Checked = true;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date4.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw4.Checked = true;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw4.Checked = true;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date5.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw5.Checked = true;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw5.Checked = true;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date6.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw6.Checked = true;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw6.Checked = true;
                    }
                    else if (cds.SechedulDate.ToString("yyyy-MM-dd").Equals(lbl_date7.Text))
                    {
                        if ("上午".Equals(cds.SechedulType))
                            chk_sw7.Checked = true;
                        if ("下午".Equals(cds.SechedulType))
                            chk_xw7.Checked = true;
                    }
                }
            }
            else
            {
                chk_sw1.Checked = false;
                chk_sw2.Checked = false;
                chk_sw3.Checked = false;
                chk_sw4.Checked = false;
                chk_sw5.Checked = false;
                chk_sw6.Checked = false;
                chk_sw7.Checked = false;
                chk_xw1.Checked = false;
                chk_xw2.Checked = false;
                chk_xw3.Checked = false;
                chk_xw4.Checked = false;
                chk_xw5.Checked = false;
                chk_xw6.Checked = false;
                chk_xw7.Checked = false;
            }
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
                this.lbl_date1.Text = Convert.ToDateTime(now).AddDays(1 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date2.Text = Convert.ToDateTime(now).AddDays(2 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date3.Text = Convert.ToDateTime(now).AddDays(3 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date4.Text = Convert.ToDateTime(now).AddDays(4 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date5.Text = Convert.ToDateTime(now).AddDays(5 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date6.Text = Convert.ToDateTime(now).AddDays(6 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date7.Text = Convert.ToDateTime(now).AddDays(7 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                //查询数据库中数据
                list = ClinicarDptSechedulBiz.FindbyDate(f_stringCode, this.lbl_date1.Text, this.lbl_date7.Text);
                Fill2Win(list);
            }
            else if ("xz".Equals(type))
            {
                //获取当前星期
                string d = DateTime.Now.DayOfWeek.ToString("d");
                //获取当前日期
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                this.lbl_date1.Text = Convert.ToDateTime(now).AddDays(8 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date2.Text = Convert.ToDateTime(now).AddDays(9 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date3.Text = Convert.ToDateTime(now).AddDays(10 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date4.Text = Convert.ToDateTime(now).AddDays(11 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date5.Text = Convert.ToDateTime(now).AddDays(12 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date6.Text = Convert.ToDateTime(now).AddDays(13 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                this.lbl_date7.Text = Convert.ToDateTime(now).AddDays(14 - Convert.ToInt16(d)).ToString("yyyy-MM-dd");
                //查询数据库中数据
                list = ClinicarDptSechedulBiz.FindbyDate(f_stringCode, this.lbl_date1.Text, this.lbl_date7.Text);
                Fill2Win(list);
            }

        }
    }
}
