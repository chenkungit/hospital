namespace cis_client.ui.sys
{
    partial class FrmBaseDataManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseDataManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uChk_enabled = new System.Windows.Forms.CheckBox();
            this.ucCbo_pcode = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.ucCbo_sort = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.ucTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_remark = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucText_display_order = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_code = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel1.TabIndex = 1;
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
            this.panel2.Controls.Add(this.uChk_enabled);
            this.panel2.Controls.Add(this.ucCbo_pcode);
            this.panel2.Controls.Add(this.ucCbo_sort);
            this.panel2.Controls.Add(this.ucTxt_name);
            this.panel2.Controls.Add(this.ucTxt_remark);
            this.panel2.Controls.Add(this.ucText_display_order);
            this.panel2.Controls.Add(this.ucTxt_code);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 304);
            this.panel2.TabIndex = 0;
            // 
            // uChk_enabled
            // 
            this.uChk_enabled.AutoSize = true;
            this.uChk_enabled.Location = new System.Drawing.Point(111, 187);
            this.uChk_enabled.Name = "uChk_enabled";
            this.uChk_enabled.Size = new System.Drawing.Size(48, 16);
            this.uChk_enabled.TabIndex = 6;
            this.uChk_enabled.Text = "启用";
            this.uChk_enabled.UseVisualStyleBackColor = true;
            // 
            // ucCbo_pcode
            // 
            this.ucCbo_pcode.BackColor = System.Drawing.Color.White;
            this.ucCbo_pcode.FormattingEnabled = true;
            this.ucCbo_pcode.Location = new System.Drawing.Point(111, 102);
            this.ucCbo_pcode.Name = "ucCbo_pcode";
            this.ucCbo_pcode.Size = new System.Drawing.Size(207, 20);
            this.ucCbo_pcode.TabIndex = 3;
            this.ucCbo_pcode.UcEmptyMessage = null;
            this.ucCbo_pcode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucCbo_pcode.UcErrorIcon")));
            this.ucCbo_pcode.UcErrorMessage = null;
            // 
            // ucCbo_sort
            // 
            this.ucCbo_sort.BackColor = System.Drawing.Color.White;
            this.ucCbo_sort.FormattingEnabled = true;
            this.ucCbo_sort.Location = new System.Drawing.Point(111, 76);
            this.ucCbo_sort.Name = "ucCbo_sort";
            this.ucCbo_sort.Size = new System.Drawing.Size(207, 20);
            this.ucCbo_sort.TabIndex = 2;
            this.ucCbo_sort.UcEmptyMessage = null;
            this.ucCbo_sort.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucCbo_sort.UcErrorIcon")));
            this.ucCbo_sort.UcErrorMessage = null;
            // 
            // ucTxt_name
            // 
            this.ucTxt_name.BackColor = System.Drawing.Color.White;
            this.ucTxt_name.Location = new System.Drawing.Point(111, 49);
            this.ucTxt_name.Name = "ucTxt_name";
            this.ucTxt_name.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_name.TabIndex = 1;
            this.ucTxt_name.UcEmptyMessage = null;
            this.ucTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_name.UcErrorIcon")));
            this.ucTxt_name.UcErrorMessage = null;
            this.ucTxt_name.UcRegexExpression = null;
            // 
            // ucTxt_remark
            // 
            this.ucTxt_remark.BackColor = System.Drawing.Color.White;
            this.ucTxt_remark.Location = new System.Drawing.Point(111, 160);
            this.ucTxt_remark.Name = "ucTxt_remark";
            this.ucTxt_remark.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_remark.TabIndex = 5;
            this.ucTxt_remark.UcEmptyMessage = null;
            this.ucTxt_remark.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_remark.UcErrorIcon")));
            this.ucTxt_remark.UcErrorMessage = null;
            this.ucTxt_remark.UcRegexExpression = null;
            // 
            // ucText_display_order
            // 
            this.ucText_display_order.BackColor = System.Drawing.Color.White;
            this.ucText_display_order.Location = new System.Drawing.Point(111, 131);
            this.ucText_display_order.Name = "ucText_display_order";
            this.ucText_display_order.Size = new System.Drawing.Size(207, 21);
            this.ucText_display_order.TabIndex = 4;
            this.ucText_display_order.UcEmptyMessage = null;
            this.ucText_display_order.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucText_display_order.UcErrorIcon")));
            this.ucText_display_order.UcErrorMessage = null;
            this.ucText_display_order.UcRegexExpression = null;
            // 
            // ucTxt_code
            // 
            this.ucTxt_code.BackColor = System.Drawing.Color.White;
            this.ucTxt_code.Location = new System.Drawing.Point(111, 21);
            this.ucTxt_code.Name = "ucTxt_code";
            this.ucTxt_code.Size = new System.Drawing.Size(207, 21);
            this.ucTxt_code.TabIndex = 0;
            this.ucTxt_code.UcEmptyMessage = null;
            this.ucTxt_code.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_code.UcErrorIcon")));
            this.ucTxt_code.UcErrorMessage = null;
            this.ucTxt_code.UcRegexExpression = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "显示顺序：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "上级代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码：";
            // 
            // FrmBaseDataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 351);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmBaseDataManage";
            this.Text = "基础数据管理";
            this.Load += new System.EventHandler(this.FrmSysBaseDataManage_Load);
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
        private UComponentLib.Component.Extension.UcTextBox ucTxt_name;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcComboBox ucCbo_sort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_remark;
        private System.Windows.Forms.CheckBox uChk_enabled;
        private System.Windows.Forms.Label label7;
        private UComponentLib.Component.Extension.UcTextBox ucText_display_order;
        private UComponentLib.Component.Extension.UcComboBox ucCbo_pcode;
    }
}