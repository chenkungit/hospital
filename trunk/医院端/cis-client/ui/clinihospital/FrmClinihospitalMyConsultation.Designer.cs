namespace cis_client.ui.clinicar
{
    partial class FrmClinihospitalMyConsultation
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
            this.pnl_top = new System.Windows.Forms.Panel();
            this.uDat_End = new System.Windows.Forms.DateTimePicker();
            this.uDat_Start = new System.Windows.Forms.DateTimePicker();
            this.btn_deltail = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.uDat_End);
            this.pnl_top.Controls.Add(this.uDat_Start);
            this.pnl_top.Controls.Add(this.btn_deltail);
            this.pnl_top.Controls.Add(this.btn_new);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Controls.Add(this.label1);
            this.pnl_top.Controls.Add(this.lbl_username);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(784, 51);
            this.pnl_top.TabIndex = 0;
            // 
            // uDat_End
            // 
            this.uDat_End.Location = new System.Drawing.Point(227, 18);
            this.uDat_End.Name = "uDat_End";
            this.uDat_End.Size = new System.Drawing.Size(113, 21);
            this.uDat_End.TabIndex = 1;
            // 
            // uDat_Start
            // 
            this.uDat_Start.Location = new System.Drawing.Point(85, 17);
            this.uDat_Start.Name = "uDat_Start";
            this.uDat_Start.Size = new System.Drawing.Size(113, 21);
            this.uDat_Start.TabIndex = 0;
            // 
            // btn_deltail
            // 
            this.btn_deltail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deltail.Location = new System.Drawing.Point(536, 18);
            this.btn_deltail.Name = "btn_deltail";
            this.btn_deltail.Size = new System.Drawing.Size(90, 23);
            this.btn_deltail.TabIndex = 4;
            this.btn_deltail.Text = "会诊申请明细";
            this.btn_deltail.UseVisualStyleBackColor = true;
            this.btn_deltail.Click += new System.EventHandler(this.btn_deltail_Click);
            // 
            // btn_new
            // 
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Location = new System.Drawing.Point(455, 18);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 3;
            this.btn_new.Text = "分时会诊";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "至";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(19, 21);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(65, 12);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "申请日期：";
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(0, 51);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(784, 336);
            this.ucDgv_list.TabIndex = 1;
            this.ucDgv_list.UcFooterVisible = true;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 20;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // FrmClinihospitalMyConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 387);
            this.Controls.Add(this.ucDgv_list);
            this.Controls.Add(this.pnl_top);
            this.Name = "FrmClinihospitalMyConsultation";
            this.Text = "我的会诊";
            this.Load += new System.EventHandler(this.FrmClinihospitalMyConsultation_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker uDat_Start;
        private System.Windows.Forms.DateTimePicker uDat_End;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_deltail;
    }
}