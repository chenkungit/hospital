namespace cis_client.ui.clinicar
{
    partial class FrmClinicarHospital
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarHospital));
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_fullName = new System.Windows.Forms.Label();
            this.ucTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_mod = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_username = new System.Windows.Forms.Label();
            this.ucTxt_code = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.lbl_fullName);
            this.pnl_top.Controls.Add(this.ucTxt_name);
            this.pnl_top.Controls.Add(this.btn_del);
            this.pnl_top.Controls.Add(this.btn_mod);
            this.pnl_top.Controls.Add(this.btn_new);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Controls.Add(this.lbl_username);
            this.pnl_top.Controls.Add(this.ucTxt_code);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(784, 57);
            this.pnl_top.TabIndex = 0;
            // 
            // lbl_fullName
            // 
            this.lbl_fullName.AutoSize = true;
            this.lbl_fullName.Location = new System.Drawing.Point(197, 23);
            this.lbl_fullName.Name = "lbl_fullName";
            this.lbl_fullName.Size = new System.Drawing.Size(65, 12);
            this.lbl_fullName.TabIndex = 4;
            this.lbl_fullName.Text = "医院名称：";
            // 
            // ucTxt_name
            // 
            this.ucTxt_name.BackColor = System.Drawing.Color.White;
            this.ucTxt_name.Location = new System.Drawing.Point(262, 19);
            this.ucTxt_name.Name = "ucTxt_name";
            this.ucTxt_name.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_name.TabIndex = 3;
            this.ucTxt_name.UcEmptyMessage = null;
            this.ucTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_name.UcErrorIcon")));
            this.ucTxt_name.UcErrorMessage = null;
            this.ucTxt_name.UcRegexExpression = null;
            // 
            // btn_del
            // 
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Location = new System.Drawing.Point(617, 18);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 2;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_mod
            // 
            this.btn_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod.Location = new System.Drawing.Point(536, 18);
            this.btn_mod.Name = "btn_mod";
            this.btn_mod.Size = new System.Drawing.Size(75, 23);
            this.btn_mod.TabIndex = 2;
            this.btn_mod.Text = "修改";
            this.btn_mod.UseVisualStyleBackColor = true;
            this.btn_mod.Click += new System.EventHandler(this.btn_mod_Click);
            // 
            // btn_new
            // 
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Location = new System.Drawing.Point(455, 18);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 2;
            this.btn_new.Text = "新增";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(374, 18);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(20, 23);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(65, 12);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "医院编号：";
            // 
            // ucTxt_code
            // 
            this.ucTxt_code.BackColor = System.Drawing.Color.White;
            this.ucTxt_code.Location = new System.Drawing.Point(87, 19);
            this.ucTxt_code.Name = "ucTxt_code";
            this.ucTxt_code.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_code.TabIndex = 0;
            this.ucTxt_code.UcEmptyMessage = null;
            this.ucTxt_code.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_code.UcErrorIcon")));
            this.ucTxt_code.UcErrorMessage = null;
            this.ucTxt_code.UcRegexExpression = null;
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 57);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(784, 330);
            this.ucDgv_list.TabIndex = 1;
            this.ucDgv_list.UcFooterVisible = true;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // FrmClinicarHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 387);
            this.Controls.Add(this.ucDgv_list);
            this.Controls.Add(this.pnl_top);
            this.Name = "FrmClinicarHospital";
            this.Text = "医院管理";
            this.Load += new System.EventHandler(this.FrmClinicarHospital_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private System.Windows.Forms.Label lbl_username;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_code;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_mod;
        private System.Windows.Forms.Label lbl_fullName;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_name;
    }
}