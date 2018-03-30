namespace cis_client.ui.sys
{
    partial class FrmSysUserManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysUserManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucCbo_userType = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.ucTxt_password = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_remark = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_tel = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_full_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_username = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 47);
            this.panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(347, 10);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(65, 28);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_save
            // 
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Location = new System.Drawing.Point(270, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(65, 28);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ucCbo_userType);
            this.panel2.Controls.Add(this.ucTxt_password);
            this.panel2.Controls.Add(this.ucTxt_remark);
            this.panel2.Controls.Add(this.ucTxt_tel);
            this.panel2.Controls.Add(this.ucTxt_full_name);
            this.panel2.Controls.Add(this.ucTxt_username);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 304);
            this.panel2.TabIndex = 1;
            // 
            // ucCbo_userType
            // 
            this.ucCbo_userType.BackColor = System.Drawing.Color.White;
            this.ucCbo_userType.FormattingEnabled = true;
            this.ucCbo_userType.Location = new System.Drawing.Point(111, 76);
            this.ucCbo_userType.Name = "ucCbo_userType";
            this.ucCbo_userType.Size = new System.Drawing.Size(207, 20);
            this.ucCbo_userType.TabIndex = 2;
            this.ucCbo_userType.UcEmptyMessage = null;
            this.ucCbo_userType.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucCbo_userType.UcErrorIcon")));
            this.ucCbo_userType.UcErrorMessage = null;
            // 
            // ucTxt_password
            // 
            this.ucTxt_password.BackColor = System.Drawing.Color.White;
            this.ucTxt_password.Location = new System.Drawing.Point(111, 49);
            this.ucTxt_password.Name = "ucTxt_password";
            this.ucTxt_password.PasswordChar = '*';
            this.ucTxt_password.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_password.TabIndex = 1;
            this.ucTxt_password.UcEmptyMessage = null;
            this.ucTxt_password.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_password.UcErrorIcon")));
            this.ucTxt_password.UcErrorMessage = null;
            this.ucTxt_password.UcRegexExpression = null;
            // 
            // ucTxt_remark
            // 
            this.ucTxt_remark.BackColor = System.Drawing.Color.White;
            this.ucTxt_remark.Location = new System.Drawing.Point(111, 156);
            this.ucTxt_remark.Name = "ucTxt_remark";
            this.ucTxt_remark.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_remark.TabIndex = 1;
            this.ucTxt_remark.UcEmptyMessage = null;
            this.ucTxt_remark.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_remark.UcErrorIcon")));
            this.ucTxt_remark.UcErrorMessage = null;
            this.ucTxt_remark.UcRegexExpression = null;
            // 
            // ucTxt_tel
            // 
            this.ucTxt_tel.BackColor = System.Drawing.Color.White;
            this.ucTxt_tel.Location = new System.Drawing.Point(111, 129);
            this.ucTxt_tel.Name = "ucTxt_tel";
            this.ucTxt_tel.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_tel.TabIndex = 1;
            this.ucTxt_tel.UcEmptyMessage = null;
            this.ucTxt_tel.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_tel.UcErrorIcon")));
            this.ucTxt_tel.UcErrorMessage = null;
            this.ucTxt_tel.UcRegexExpression = null;
            // 
            // ucTxt_full_name
            // 
            this.ucTxt_full_name.BackColor = System.Drawing.Color.White;
            this.ucTxt_full_name.Location = new System.Drawing.Point(111, 102);
            this.ucTxt_full_name.Name = "ucTxt_full_name";
            this.ucTxt_full_name.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_full_name.TabIndex = 1;
            this.ucTxt_full_name.UcEmptyMessage = null;
            this.ucTxt_full_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_full_name.UcErrorIcon")));
            this.ucTxt_full_name.UcErrorMessage = null;
            this.ucTxt_full_name.UcRegexExpression = null;
            // 
            // ucTxt_username
            // 
            this.ucTxt_username.BackColor = System.Drawing.Color.White;
            this.ucTxt_username.Location = new System.Drawing.Point(111, 21);
            this.ucTxt_username.Name = "ucTxt_username";
            this.ucTxt_username.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_username.TabIndex = 1;
            this.ucTxt_username.UcEmptyMessage = null;
            this.ucTxt_username.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_username.UcErrorIcon")));
            this.ucTxt_username.UcErrorMessage = null;
            this.ucTxt_username.UcRegexExpression = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "手机号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // FrmSysUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 351);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSysUserManage";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmSysUserManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_password;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcComboBox ucCbo_userType;
        private System.Windows.Forms.Label label3;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_full_name;
        private System.Windows.Forms.Label label4;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_tel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_remark;
    }
}