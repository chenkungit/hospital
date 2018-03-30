using cis_business.biz.sys;
using cis_business.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cis_client.ui.sys
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private SysUserBiz sysUserBiz = new SysUserBiz();
        //用户类型用户权限控制
        public string userType = string.Empty;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if(string.IsNullOrEmpty(passWord.Text))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            cis_model.sys.SysUser UserEntity = sysUserBiz.FindByUsername(userName.Text.Trim());
            if (UserEntity != null && UserEntity.Password.Equals(passWord.Text))//验证
            {
                UserInfo.Username = userName.Text.Trim();
                userType = UserEntity.UserType;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                //return;
            }

    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (sender == this.btnCancel)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
        }
    }
}
