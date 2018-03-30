namespace cis_client.ui.clinicar
{
    partial class FrmClinicarCheckGuideOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarCheckGuideOrder));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picb_left = new System.Windows.Forms.PictureBox();
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uTxt_genderName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_certificateNumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_checkNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uTxt_name = new System.Windows.Forms.TextBox();
            this.uNum_age = new UComponentLib.Component.Extension.UcNumberBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uDat_checkDate = new UComponentLib.Component.Extension.UcDateTimePicker(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_printAll = new System.Windows.Forms.Button();
            this.btn_barCode = new System.Windows.Forms.Button();
            this.btn_printOrder = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_left)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 506);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.picb_left);
            this.splitContainer1.Panel1.Controls.Add(this.ucDgv_list);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(690, 506);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.TabIndex = 0;
            // 
            // picb_left
            // 
            this.picb_left.Location = new System.Drawing.Point(16, 11);
            this.picb_left.Name = "picb_left";
            this.picb_left.Size = new System.Drawing.Size(98, 44);
            this.picb_left.TabIndex = 12;
            this.picb_left.TabStop = false;
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.BackColor = System.Drawing.Color.White;
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 205);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(436, 301);
            this.ucDgv_list.TabIndex = 11;
            this.ucDgv_list.UcFooterVisible = true;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uTxt_genderName);
            this.groupBox1.Controls.Add(this.uTxt_certificateNumber);
            this.groupBox1.Controls.Add(this.uTxt_checkNum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.uTxt_name);
            this.groupBox1.Controls.Add(this.uNum_age);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uDat_checkDate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(8, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // uTxt_genderName
            // 
            this.uTxt_genderName.BackColor = System.Drawing.Color.White;
            this.uTxt_genderName.Enabled = false;
            this.uTxt_genderName.Location = new System.Drawing.Point(269, 62);
            this.uTxt_genderName.Name = "uTxt_genderName";
            this.uTxt_genderName.Size = new System.Drawing.Size(49, 21);
            this.uTxt_genderName.TabIndex = 4;
            this.uTxt_genderName.UcEmptyMessage = null;
            this.uTxt_genderName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_genderName.UcErrorIcon")));
            this.uTxt_genderName.UcErrorMessage = null;
            this.uTxt_genderName.UcRegexExpression = null;
            // 
            // uTxt_certificateNumber
            // 
            this.uTxt_certificateNumber.BackColor = System.Drawing.Color.White;
            this.uTxt_certificateNumber.Enabled = false;
            this.uTxt_certificateNumber.Location = new System.Drawing.Point(71, 99);
            this.uTxt_certificateNumber.Name = "uTxt_certificateNumber";
            this.uTxt_certificateNumber.Size = new System.Drawing.Size(338, 21);
            this.uTxt_certificateNumber.TabIndex = 9;
            this.uTxt_certificateNumber.UcEmptyMessage = null;
            this.uTxt_certificateNumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_certificateNumber.UcErrorIcon")));
            this.uTxt_certificateNumber.UcErrorMessage = null;
            this.uTxt_certificateNumber.UcRegexExpression = null;
            // 
            // uTxt_checkNum
            // 
            this.uTxt_checkNum.Location = new System.Drawing.Point(71, 24);
            this.uTxt_checkNum.Name = "uTxt_checkNum";
            this.uTxt_checkNum.ReadOnly = true;
            this.uTxt_checkNum.Size = new System.Drawing.Size(121, 21);
            this.uTxt_checkNum.TabIndex = 0;
            this.uTxt_checkNum.DoubleClick += new System.EventHandler(this.uTxt_checkNum_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "证件号";
            // 
            // uTxt_name
            // 
            this.uTxt_name.Enabled = false;
            this.uTxt_name.Location = new System.Drawing.Point(269, 25);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(140, 21);
            this.uTxt_name.TabIndex = 0;
            // 
            // uNum_age
            // 
            this.uNum_age.BackColor = System.Drawing.Color.White;
            this.uNum_age.Enabled = false;
            this.uNum_age.Location = new System.Drawing.Point(360, 63);
            this.uNum_age.Name = "uNum_age";
            this.uNum_age.Size = new System.Drawing.Size(49, 21);
            this.uNum_age.TabIndex = 6;
            this.uNum_age.Text = "0";
            this.uNum_age.UcEmptyMessage = null;
            this.uNum_age.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uNum_age.UcErrorIcon")));
            this.uNum_age.UcErrorMessage = null;
            this.uNum_age.UcNumberType = UComponentLib.Enum.NumberType.PositiveNumber;
            this.uNum_age.UcRegexExpression = null;
            this.uNum_age.UcRegexOnTextChanged = true;
            this.uNum_age.UcValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "检查号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "性别";
            // 
            // uDat_checkDate
            // 
            this.uDat_checkDate.Enabled = false;
            this.uDat_checkDate.Location = new System.Drawing.Point(71, 60);
            this.uDat_checkDate.Name = "uDat_checkDate";
            this.uDat_checkDate.Size = new System.Drawing.Size(121, 21);
            this.uDat_checkDate.TabIndex = 3;
            this.uDat_checkDate.UcEmptyMessage = null;
            this.uDat_checkDate.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uDat_checkDate.UcErrorIcon")));
            this.uDat_checkDate.UcErrorMessage = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "检查日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(158, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "检查通知单";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 382);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_printAll);
            this.panel1.Controls.Add(this.btn_barCode);
            this.panel1.Controls.Add(this.btn_printOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 382);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 124);
            this.panel1.TabIndex = 1;
            // 
            // btn_printAll
            // 
            this.btn_printAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printAll.Location = new System.Drawing.Point(77, 82);
            this.btn_printAll.Name = "btn_printAll";
            this.btn_printAll.Size = new System.Drawing.Size(77, 28);
            this.btn_printAll.TabIndex = 6;
            this.btn_printAll.Text = "打印所有";
            this.btn_printAll.UseVisualStyleBackColor = true;
            this.btn_printAll.Click += new System.EventHandler(this.btn_printAll_Click);
            // 
            // btn_barCode
            // 
            this.btn_barCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_barCode.Location = new System.Drawing.Point(77, 48);
            this.btn_barCode.Name = "btn_barCode";
            this.btn_barCode.Size = new System.Drawing.Size(77, 28);
            this.btn_barCode.TabIndex = 6;
            this.btn_barCode.Text = "打印条码";
            this.btn_barCode.UseVisualStyleBackColor = true;
            this.btn_barCode.Click += new System.EventHandler(this.btn_barCode_Click);
            // 
            // btn_printOrder
            // 
            this.btn_printOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printOrder.Location = new System.Drawing.Point(77, 14);
            this.btn_printOrder.Name = "btn_printOrder";
            this.btn_printOrder.Size = new System.Drawing.Size(77, 28);
            this.btn_printOrder.TabIndex = 5;
            this.btn_printOrder.Text = "打印指引单";
            this.btn_printOrder.UseVisualStyleBackColor = true;
            this.btn_printOrder.Click += new System.EventHandler(this.btn_printOrder_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FrmClinicarCheckGuideOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 506);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmClinicarCheckGuideOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指引单";
            this.Load += new System.EventHandler(this.FrmClinicarCheckGuideOrder_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picb_left)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_barCode;
        private System.Windows.Forms.Button btn_printOrder;
        private System.Windows.Forms.Button btn_printAll;
        private System.Windows.Forms.TextBox uTxt_checkNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uTxt_name;
        private UComponentLib.Component.Extension.UcDateTimePicker uDat_checkDate;
        private System.Windows.Forms.Label label13;
        private UComponentLib.Component.Extension.UcTextBox uTxt_genderName;
        private System.Windows.Forms.Label label3;
        private UComponentLib.Component.Extension.UcNumberBox uNum_age;
        private System.Windows.Forms.Label label5;
        private UComponentLib.Component.Extension.UcTextBox uTxt_certificateNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private System.Windows.Forms.Panel panel3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PictureBox picb_left;
    }
}