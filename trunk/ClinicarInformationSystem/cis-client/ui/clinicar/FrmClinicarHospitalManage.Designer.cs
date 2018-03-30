namespace cis_client.ui.clinicar
{
    partial class FrmClinicarHospitalManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarHospitalManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucRic_remark = new System.Windows.Forms.RichTextBox();
            this.uTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_code = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.btn_close.TabIndex = 6;
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
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ucRic_remark);
            this.panel2.Controls.Add(this.uTxt_name);
            this.panel2.Controls.Add(this.uTxt_code);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 304);
            this.panel2.TabIndex = 1;
            // 
            // ucRic_remark
            // 
            this.ucRic_remark.Location = new System.Drawing.Point(84, 107);
            this.ucRic_remark.Name = "ucRic_remark";
            this.ucRic_remark.Size = new System.Drawing.Size(321, 136);
            this.ucRic_remark.TabIndex = 3;
            this.ucRic_remark.Text = "";
            // 
            // uTxt_name
            // 
            this.uTxt_name.BackColor = System.Drawing.Color.White;
            this.uTxt_name.Location = new System.Drawing.Point(84, 63);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(321, 21);
            this.uTxt_name.TabIndex = 2;
            this.uTxt_name.UcEmptyMessage = null;
            this.uTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_name.UcErrorIcon")));
            this.uTxt_name.UcErrorMessage = null;
            this.uTxt_name.UcRegexExpression = null;
            // 
            // uTxt_code
            // 
            this.uTxt_code.BackColor = System.Drawing.Color.White;
            this.uTxt_code.Location = new System.Drawing.Point(84, 24);
            this.uTxt_code.Name = "uTxt_code";
            this.uTxt_code.Size = new System.Drawing.Size(321, 21);
            this.uTxt_code.TabIndex = 1;
            this.uTxt_code.UcEmptyMessage = null;
            this.uTxt_code.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_code.UcErrorIcon")));
            this.uTxt_code.UcErrorMessage = null;
            this.uTxt_code.UcRegexExpression = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "医院名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "医院编码：";
            // 
            // FrmClinicarHospitalManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 351);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClinicarHospitalManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医院管理";
            this.Load += new System.EventHandler(this.FrmClinicarHospitalManage_Load);
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
        private UComponentLib.Component.Extension.UcTextBox uTxt_code;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcTextBox uTxt_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox ucRic_remark;
    }
}