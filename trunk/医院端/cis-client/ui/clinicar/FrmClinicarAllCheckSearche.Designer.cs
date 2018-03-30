namespace cis_client.ui.clinicar
{
    partial class FrmClinicarAllCheckSearch
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.uItem_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.uUser_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.uChk_zjwc = new System.Windows.Forms.CheckBox();
            this.uChk_fjwwc = new System.Windows.Forms.CheckBox();
            this.uChk_fjwc = new System.Windows.Forms.CheckBox();
            this.uDtp_to = new System.Windows.Forms.DateTimePicker();
            this.uDtp_from = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uTxt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.groupbox1);
            this.panel2.Controls.Add(this.uUser_list);
            this.panel2.Controls.Add(this.uChk_zjwc);
            this.panel2.Controls.Add(this.uChk_fjwwc);
            this.panel2.Controls.Add(this.uChk_fjwc);
            this.panel2.Controls.Add(this.uDtp_to);
            this.panel2.Controls.Add(this.uDtp_from);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.uTxt_name);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 416);
            this.panel2.TabIndex = 1;
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.uItem_list);
            this.groupbox1.Location = new System.Drawing.Point(443, 12);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(332, 393);
            this.groupbox1.TabIndex = 8;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "项目情况";
            // 
            // uItem_list
            // 
            this.uItem_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uItem_list.Location = new System.Drawing.Point(6, 16);
            this.uItem_list.Name = "uItem_list";
            this.uItem_list.Size = new System.Drawing.Size(320, 371);
            this.uItem_list.TabIndex = 7;
            this.uItem_list.UcIsPagintion = true;
            this.uItem_list.UcPageSize = 100;
            // 
            // uUser_list
            // 
            this.uUser_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uUser_list.Location = new System.Drawing.Point(12, 126);
            this.uUser_list.Name = "uUser_list";
            this.uUser_list.Size = new System.Drawing.Size(416, 279);
            this.uUser_list.TabIndex = 7;
            this.uUser_list.UcIsPagintion = true;
            this.uUser_list.UcPageSize = 100;
            // 
            // uChk_zjwc
            // 
            this.uChk_zjwc.AutoSize = true;
            this.uChk_zjwc.Location = new System.Drawing.Point(186, 87);
            this.uChk_zjwc.Name = "uChk_zjwc";
            this.uChk_zjwc.Size = new System.Drawing.Size(72, 16);
            this.uChk_zjwc.TabIndex = 6;
            this.uChk_zjwc.Text = "总检完成";
            this.uChk_zjwc.UseVisualStyleBackColor = true;
            // 
            // uChk_fjwwc
            // 
            this.uChk_fjwwc.AutoSize = true;
            this.uChk_fjwwc.Location = new System.Drawing.Point(90, 87);
            this.uChk_fjwwc.Name = "uChk_fjwwc";
            this.uChk_fjwwc.Size = new System.Drawing.Size(84, 16);
            this.uChk_fjwwc.TabIndex = 6;
            this.uChk_fjwwc.Text = "分检未完成";
            this.uChk_fjwwc.UseVisualStyleBackColor = true;
            // 
            // uChk_fjwc
            // 
            this.uChk_fjwc.AutoSize = true;
            this.uChk_fjwc.Location = new System.Drawing.Point(12, 87);
            this.uChk_fjwc.Name = "uChk_fjwc";
            this.uChk_fjwc.Size = new System.Drawing.Size(72, 16);
            this.uChk_fjwc.TabIndex = 6;
            this.uChk_fjwc.Text = "分检完成";
            this.uChk_fjwc.UseVisualStyleBackColor = true;
            // 
            // uDtp_to
            // 
            this.uDtp_to.Location = new System.Drawing.Point(281, 51);
            this.uDtp_to.Name = "uDtp_to";
            this.uDtp_to.Size = new System.Drawing.Size(130, 21);
            this.uDtp_to.TabIndex = 5;
            // 
            // uDtp_from
            // 
            this.uDtp_from.Location = new System.Drawing.Point(72, 51);
            this.uDtp_from.Name = "uDtp_from";
            this.uDtp_from.Size = new System.Drawing.Size(130, 21);
            this.uDtp_from.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(281, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 21);
            this.textBox1.TabIndex = 4;
            // 
            // uTxt_name
            // 
            this.uTxt_name.Location = new System.Drawing.Point(72, 24);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(130, 21);
            this.uTxt_name.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "体检号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "登记日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "姓名：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmClinicarAllCheckSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 416);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClinicarAllCheckSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浏览已完成列表";
            this.Load += new System.EventHandler(this.FrmClinicarDptManage_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupbox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uTxt_name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker uDtp_to;
        private System.Windows.Forms.DateTimePicker uDtp_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox uChk_zjwc;
        private System.Windows.Forms.CheckBox uChk_fjwwc;
        private System.Windows.Forms.CheckBox uChk_fjwc;
        private UComponentLib.Component.Composite.UcDataGridView uUser_list;
        private System.Windows.Forms.GroupBox groupbox1;
        private UComponentLib.Component.Composite.UcDataGridView uItem_list;
        private System.Windows.Forms.Button button1;
    }
}