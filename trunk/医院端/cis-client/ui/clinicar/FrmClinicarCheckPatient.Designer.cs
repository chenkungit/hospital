namespace cis_client.ui.clinicar
{
    partial class FrmClinicarCheckPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarCheckPatient));
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_fullName = new System.Windows.Forms.Label();
            this.ucTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_username = new System.Windows.Forms.Label();
            this.ucTxt_checkNumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.ucTxt_cre = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.label1);
            this.pnl_top.Controls.Add(this.lbl_fullName);
            this.pnl_top.Controls.Add(this.ucTxt_cre);
            this.pnl_top.Controls.Add(this.ucTxt_name);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Controls.Add(this.lbl_username);
            this.pnl_top.Controls.Add(this.ucTxt_checkNumber);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(765, 57);
            this.pnl_top.TabIndex = 0;
            // 
            // lbl_fullName
            // 
            this.lbl_fullName.AutoSize = true;
            this.lbl_fullName.Location = new System.Drawing.Point(181, 22);
            this.lbl_fullName.Name = "lbl_fullName";
            this.lbl_fullName.Size = new System.Drawing.Size(29, 12);
            this.lbl_fullName.TabIndex = 4;
            this.lbl_fullName.Text = "姓名";
            // 
            // ucTxt_name
            // 
            this.ucTxt_name.BackColor = System.Drawing.Color.White;
            this.ucTxt_name.Location = new System.Drawing.Point(216, 18);
            this.ucTxt_name.Name = "ucTxt_name";
            this.ucTxt_name.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_name.TabIndex = 1;
            this.ucTxt_name.UcEmptyMessage = null;
            this.ucTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_name.UcErrorIcon")));
            this.ucTxt_name.UcErrorMessage = null;
            this.ucTxt_name.UcRegexExpression = null;
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(490, 17);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(18, 23);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(41, 12);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "检查号";
            // 
            // ucTxt_checkNumber
            // 
            this.ucTxt_checkNumber.BackColor = System.Drawing.Color.White;
            this.ucTxt_checkNumber.Location = new System.Drawing.Point(65, 19);
            this.ucTxt_checkNumber.Name = "ucTxt_checkNumber";
            this.ucTxt_checkNumber.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_checkNumber.TabIndex = 0;
            this.ucTxt_checkNumber.UcEmptyMessage = null;
            this.ucTxt_checkNumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_checkNumber.UcErrorIcon")));
            this.ucTxt_checkNumber.UcErrorMessage = null;
            this.ucTxt_checkNumber.UcRegexExpression = null;
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 57);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(765, 330);
            this.ucDgv_list.TabIndex = 1;
            this.ucDgv_list.UcFooterVisible = true;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // ucTxt_cre
            // 
            this.ucTxt_cre.BackColor = System.Drawing.Color.White;
            this.ucTxt_cre.Location = new System.Drawing.Point(379, 18);
            this.ucTxt_cre.Name = "ucTxt_cre";
            this.ucTxt_cre.Size = new System.Drawing.Size(100, 21);
            this.ucTxt_cre.TabIndex = 2;
            this.ucTxt_cre.UcEmptyMessage = null;
            this.ucTxt_cre.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucTxt_cre.UcErrorIcon")));
            this.ucTxt_cre.UcErrorMessage = null;
            this.ucTxt_cre.UcRegexExpression = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "证件号";
            // 
            // FrmClinicarCheckPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 387);
            this.Controls.Add(this.ucDgv_list);
            this.Controls.Add(this.pnl_top);
            this.Name = "FrmClinicarCheckPatient";
            this.Text = "患者查询";
            this.Load += new System.EventHandler(this.FrmClinicarCheckPatient_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private System.Windows.Forms.Label lbl_username;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_checkNumber;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_fullName;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_name;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcTextBox ucTxt_cre;
    }
}