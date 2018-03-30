namespace cis_client.ui.clinicar
{
    partial class FrmClinicarCheckItemChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarCheckItemChoose));
            this.pnl_top = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_fullName = new System.Windows.Forms.Label();
            this.ucTxt_DtpName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.label2);
            this.pnl_top.Controls.Add(this.lbl_fullName);
            this.pnl_top.Controls.Add(this.ucTxt_DtpName);
            this.pnl_top.Controls.Add(this.ucTxt_name);
            this.pnl_top.Controls.Add(this.btn_new);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(608, 57);
            this.pnl_top.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "科室名称";
            // 
            // lbl_fullName
            // 
            this.lbl_fullName.AutoSize = true;
            this.lbl_fullName.Location = new System.Drawing.Point(22, 21);
            this.lbl_fullName.Name = "lbl_fullName";
            this.lbl_fullName.Size = new System.Drawing.Size(53, 12);
            this.lbl_fullName.TabIndex = 4;
            this.lbl_fullName.Text = "项目名称";
            // 
            // ucTxt_DtpName
            // 
            this.ucTxt_DtpName.BackColor = System.Drawing.Color.White;
            this.ucTxt_DtpName.Location = new System.Drawing.Point(269, 18);
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
            this.ucTxt_name.Location = new System.Drawing.Point(82, 17);
            this.ucTxt_name.Name = "ucTxt_name";
            this.ucTxt_name.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_name.TabIndex = 2;
            this.ucTxt_name.UcEmptyMessage = null;
            this.ucTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_name.UcErrorIcon")));
            this.ucTxt_name.UcErrorMessage = null;
            this.ucTxt_name.UcRegexExpression = null;
            // 
            // btn_new
            // 
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Location = new System.Drawing.Point(482, 17);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 2;
            this.btn_new.Text = "添加";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(401, 17);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 57);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(608, 368);
            this.ucDgv_list.TabIndex = 1;
            this.ucDgv_list.UcFooterVisible = true;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            this.ucDgv_list.DoubleClick += new System.EventHandler(this.DgrdView_DoubleClick);
            // 
            // FrmClinicarCheckItemChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 425);
            this.Controls.Add(this.ucDgv_list);
            this.Controls.Add(this.pnl_top);
            this.Name = "FrmClinicarCheckItemChoose";
            this.Text = "项目管理";
            this.Load += new System.EventHandler(this.FrmClinicarCheckItemChoose_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_fullName;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_name;
        private System.Windows.Forms.Label label2;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_DtpName;
    }
}