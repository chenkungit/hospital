namespace cis_client.ui.clinicar
{
    partial class FrmClinicarSortCheckHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarSortCheckHistory));
            this.btn_search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uTxt_checkNumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_fillBack = new System.Windows.Forms.Button();
            this.ucDgv_listLeft = new UComponentLib.Component.Composite.UcDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Dtp = new UComponentLib.Component.Composite.UcDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_result = new UComponentLib.Component.Composite.UcDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(228, 15);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(50, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "检查号";
            // 
            // uTxt_checkNumber
            // 
            this.uTxt_checkNumber.BackColor = System.Drawing.Color.White;
            this.uTxt_checkNumber.Location = new System.Drawing.Point(70, 16);
            this.uTxt_checkNumber.Name = "uTxt_checkNumber";
            this.uTxt_checkNumber.Size = new System.Drawing.Size(142, 21);
            this.uTxt_checkNumber.TabIndex = 0;
            this.uTxt_checkNumber.UcEmptyMessage = null;
            this.uTxt_checkNumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_checkNumber.UcErrorIcon")));
            this.uTxt_checkNumber.UcErrorMessage = null;
            this.uTxt_checkNumber.UcRegexExpression = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uTxt_checkNumber);
            this.panel1.Controls.Add(this.btn_fillBack);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 48);
            this.panel1.TabIndex = 0;
            // 
            // btn_fillBack
            // 
            this.btn_fillBack.Location = new System.Drawing.Point(297, 15);
            this.btn_fillBack.Name = "btn_fillBack";
            this.btn_fillBack.Size = new System.Drawing.Size(68, 23);
            this.btn_fillBack.TabIndex = 2;
            this.btn_fillBack.Text = "回填数据";
            this.btn_fillBack.UseVisualStyleBackColor = true;
            this.btn_fillBack.Click += new System.EventHandler(this.btn_fillBack_Click);
            // 
            // ucDgv_listLeft
            // 
            this.ucDgv_listLeft.BackColor = System.Drawing.Color.White;
            this.ucDgv_listLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_listLeft.Location = new System.Drawing.Point(0, 0);
            this.ucDgv_listLeft.Name = "ucDgv_listLeft";
            this.ucDgv_listLeft.Size = new System.Drawing.Size(433, 525);
            this.ucDgv_listLeft.TabIndex = 8;
            this.ucDgv_listLeft.UcIsPagintion = true;
            this.ucDgv_listLeft.UcPageSize = 20;
            this.ucDgv_listLeft.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucDgv_listLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Dtp);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 525);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 9;
            // 
            // dataGridView_Dtp
            // 
            this.dataGridView_Dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Dtp.Location = new System.Drawing.Point(2, 0);
            this.dataGridView_Dtp.Name = "dataGridView_Dtp";
            this.dataGridView_Dtp.Size = new System.Drawing.Size(188, 525);
            this.dataGridView_Dtp.TabIndex = 1;
            this.dataGridView_Dtp.UcIsPagintion = true;
            this.dataGridView_Dtp.UcPageSize = 100;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(190, 525);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(449, 499);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.axAcroPDF1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(449, 499);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PDF";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(449, 499);
            this.label10.TabIndex = 2;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(449, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图片";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(443, 493);
            this.label9.TabIndex = 1;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(449, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_result
            // 
            this.dataGridView_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_result.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_result.Name = "dataGridView_result";
            this.dataGridView_result.Size = new System.Drawing.Size(443, 493);
            this.dataGridView_result.TabIndex = 1;
            this.dataGridView_result.UcIsPagintion = true;
            this.dataGridView_result.UcPageSize = 100;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(190, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 525);
            this.tabControl1.TabIndex = 2;
            // 
            // FrmClinicarSortCheckHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClinicarSortCheckHistory";
            this.Text = "历史数据";
            this.Load += new System.EventHandler(this.FrmClinicarSortCheckHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_search;
        private UComponentLib.Component.Extension.UcTextBox uTxt_checkNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_fillBack;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_listLeft;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private UComponentLib.Component.Composite.UcDataGridView dataGridView_Dtp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UComponentLib.Component.Composite.UcDataGridView dataGridView_result;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}