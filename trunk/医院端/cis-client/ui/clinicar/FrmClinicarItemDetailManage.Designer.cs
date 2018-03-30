namespace cis_client.ui.clinicar
{
    partial class FrmClinicarItemDetailManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarItemDetailManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uTxt_itemCode = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_code = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uTxt_unit = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 139);
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
            this.btn_close.TabIndex = 9;
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
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.uTxt_itemCode);
            this.panel2.Controls.Add(this.uTxt_unit);
            this.panel2.Controls.Add(this.uTxt_name);
            this.panel2.Controls.Add(this.uTxt_code);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 139);
            this.panel2.TabIndex = 0;
            // 
            // uTxt_itemCode
            // 
            this.uTxt_itemCode.BackColor = System.Drawing.Color.White;
            this.uTxt_itemCode.Enabled = false;
            this.uTxt_itemCode.Location = new System.Drawing.Point(84, 140);
            this.uTxt_itemCode.Name = "uTxt_itemCode";
            this.uTxt_itemCode.Size = new System.Drawing.Size(321, 21);
            this.uTxt_itemCode.TabIndex = 3;
            this.uTxt_itemCode.UcEmptyMessage = null;
            this.uTxt_itemCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_itemCode.UcErrorIcon")));
            this.uTxt_itemCode.UcErrorMessage = null;
            this.uTxt_itemCode.UcRegexExpression = null;
            // 
            // uTxt_name
            // 
            this.uTxt_name.BackColor = System.Drawing.Color.White;
            this.uTxt_name.Location = new System.Drawing.Point(84, 63);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(321, 21);
            this.uTxt_name.TabIndex = 1;
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
            this.uTxt_code.TabIndex = 0;
            this.uTxt_code.UcEmptyMessage = null;
            this.uTxt_code.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_code.UcErrorIcon")));
            this.uTxt_code.UcErrorMessage = null;
            this.uTxt_code.UcRegexExpression = "^[0-9]*$";
            this.uTxt_code.UcRegexOnTextChanged = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "主表编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "单位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "项目名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目编号：";
            // 
            // uTxt_unit
            // 
            this.uTxt_unit.BackColor = System.Drawing.Color.White;
            this.uTxt_unit.Location = new System.Drawing.Point(84, 101);
            this.uTxt_unit.Name = "uTxt_unit";
            this.uTxt_unit.Size = new System.Drawing.Size(321, 21);
            this.uTxt_unit.TabIndex = 2;
            this.uTxt_unit.UcEmptyMessage = null;
            this.uTxt_unit.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_unit.UcErrorIcon")));
            this.uTxt_unit.UcErrorMessage = null;
            this.uTxt_unit.UcRegexExpression = null;
            // 
            // FrmClinicarItemDetailManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 186);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClinicarItemDetailManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查明细";
            this.Load += new System.EventHandler(this.FrmClinicarItemDetailManage_Load);
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
        private UComponentLib.Component.Extension.UcTextBox uTxt_itemCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UComponentLib.Component.Extension.UcTextBox uTxt_unit;
    }
}