namespace cis_client.ui.clinicar
{
    partial class FrmClinicarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarItem));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_fullName = new System.Windows.Forms.Label();
            this.ucTxt_DtpName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_mod = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.ucTxt_DtpCode = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_code = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucdgv_itemDetail = new UComponentLib.Component.Composite.UcDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucDgv_list);
            this.splitContainer1.Panel1.Controls.Add(this.pnl_top);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucdgv_itemDetail);
            this.splitContainer1.Size = new System.Drawing.Size(743, 425);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 57);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(743, 212);
            this.ucDgv_list.TabIndex = 2;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.label2);
            this.pnl_top.Controls.Add(this.lbl_fullName);
            this.pnl_top.Controls.Add(this.ucTxt_DtpName);
            this.pnl_top.Controls.Add(this.ucTxt_name);
            this.pnl_top.Controls.Add(this.btn_del);
            this.pnl_top.Controls.Add(this.btn_mod);
            this.pnl_top.Controls.Add(this.btn_new);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Controls.Add(this.label1);
            this.pnl_top.Controls.Add(this.lbl_username);
            this.pnl_top.Controls.Add(this.ucTxt_DtpCode);
            this.pnl_top.Controls.Add(this.ucTxt_code);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(743, 57);
            this.pnl_top.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "科室名称";
            // 
            // lbl_fullName
            // 
            this.lbl_fullName.AutoSize = true;
            this.lbl_fullName.Location = new System.Drawing.Point(175, 23);
            this.lbl_fullName.Name = "lbl_fullName";
            this.lbl_fullName.Size = new System.Drawing.Size(53, 12);
            this.lbl_fullName.TabIndex = 4;
            this.lbl_fullName.Text = "项目名称";
            // 
            // ucTxt_DtpName
            // 
            this.ucTxt_DtpName.BackColor = System.Drawing.Color.White;
            this.ucTxt_DtpName.Enabled = false;
            this.ucTxt_DtpName.Location = new System.Drawing.Point(379, 79);
            this.ucTxt_DtpName.Name = "ucTxt_DtpName";
            this.ucTxt_DtpName.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_DtpName.TabIndex = 4;
            this.ucTxt_DtpName.UcEmptyMessage = null;
            this.ucTxt_DtpName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_DtpName.UcErrorIcon")));
            this.ucTxt_DtpName.UcErrorMessage = null;
            this.ucTxt_DtpName.UcRegexExpression = null;
            // 
            // ucTxt_name
            // 
            this.ucTxt_name.BackColor = System.Drawing.Color.White;
            this.ucTxt_name.Location = new System.Drawing.Point(231, 19);
            this.ucTxt_name.Name = "ucTxt_name";
            this.ucTxt_name.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_name.TabIndex = 1;
            this.ucTxt_name.UcEmptyMessage = null;
            this.ucTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_name.UcErrorIcon")));
            this.ucTxt_name.UcErrorMessage = null;
            this.ucTxt_name.UcRegexExpression = null;
            // 
            // btn_del
            // 
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Location = new System.Drawing.Point(588, 17);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 5;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_mod
            // 
            this.btn_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod.Location = new System.Drawing.Point(507, 17);
            this.btn_mod.Name = "btn_mod";
            this.btn_mod.Size = new System.Drawing.Size(75, 23);
            this.btn_mod.TabIndex = 4;
            this.btn_mod.Text = "修改";
            this.btn_mod.UseVisualStyleBackColor = true;
            this.btn_mod.Click += new System.EventHandler(this.btn_mod_Click);
            // 
            // btn_new
            // 
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Location = new System.Drawing.Point(426, 17);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 3;
            this.btn_new.Text = "新增";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(345, 17);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室编号";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(8, 23);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(53, 12);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "项目编号";
            // 
            // ucTxt_DtpCode
            // 
            this.ucTxt_DtpCode.BackColor = System.Drawing.Color.White;
            this.ucTxt_DtpCode.Enabled = false;
            this.ucTxt_DtpCode.Location = new System.Drawing.Point(365, 78);
            this.ucTxt_DtpCode.Name = "ucTxt_DtpCode";
            this.ucTxt_DtpCode.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_DtpCode.TabIndex = 3;
            this.ucTxt_DtpCode.UcEmptyMessage = null;
            this.ucTxt_DtpCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_DtpCode.UcErrorIcon")));
            this.ucTxt_DtpCode.UcErrorMessage = null;
            this.ucTxt_DtpCode.UcRegexExpression = null;
            // 
            // ucTxt_code
            // 
            this.ucTxt_code.BackColor = System.Drawing.Color.White;
            this.ucTxt_code.Location = new System.Drawing.Point(64, 19);
            this.ucTxt_code.Name = "ucTxt_code";
            this.ucTxt_code.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_code.TabIndex = 0;
            this.ucTxt_code.UcEmptyMessage = null;
            this.ucTxt_code.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_code.UcErrorIcon")));
            this.ucTxt_code.UcErrorMessage = null;
            this.ucTxt_code.UcRegexExpression = null;
            // 
            // ucdgv_itemDetail
            // 
            this.ucdgv_itemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucdgv_itemDetail.Location = new System.Drawing.Point(0, 0);
            this.ucdgv_itemDetail.Name = "ucdgv_itemDetail";
            this.ucdgv_itemDetail.Size = new System.Drawing.Size(743, 152);
            this.ucdgv_itemDetail.TabIndex = 3;
            this.ucdgv_itemDetail.UcIsPagintion = true;
            this.ucdgv_itemDetail.UcPageSize = 20;
            // 
            // FrmClinicarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 425);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmClinicarItem";
            this.Text = "项目管理";
            this.Load += new System.EventHandler(this.FrmClinicarItem_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private UComponentLib.Component.Composite.UcDataGridView ucdgv_itemDetail;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_fullName;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_DtpName;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_name;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_mod;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_username;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_DtpCode;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_code;
    }
}