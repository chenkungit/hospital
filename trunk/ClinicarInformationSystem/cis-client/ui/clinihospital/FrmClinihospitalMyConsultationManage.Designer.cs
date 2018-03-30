namespace cis_client.ui.clinicar
{
    partial class FrmClinihospitalMyConsultationManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinihospitalMyConsultationManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ric_medicalhistory = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ric_diagnosis = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ucCbo_married = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.uTxt_cardnumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_tel = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.ucCbo_sex = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.uTxt_checknumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uTxt_age = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uDtp_consultationdate = new System.Windows.Forms.DateTimePicker();
            this.uTxt_deptname = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uTxt_hospitalname = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uDtp_applyhospitaldate = new System.Windows.Forms.DateTimePicker();
            this.uTxt_applyhospitaltel = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uTxt_applyhospitalcode = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_applyhospitalname = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ric_results = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 47);
            this.panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(496, 10);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(65, 25);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_save
            // 
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Location = new System.Drawing.Point(419, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(65, 25);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 449);
            this.panel2.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ric_medicalhistory);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 239);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "既往病史";
            // 
            // ric_medicalhistory
            // 
            this.ric_medicalhistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ric_medicalhistory.Location = new System.Drawing.Point(3, 17);
            this.ric_medicalhistory.Name = "ric_medicalhistory";
            this.ric_medicalhistory.Size = new System.Drawing.Size(229, 219);
            this.ric_medicalhistory.TabIndex = 0;
            this.ric_medicalhistory.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ric_diagnosis);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 239);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "初步诊断";
            // 
            // ric_diagnosis
            // 
            this.ric_diagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ric_diagnosis.Location = new System.Drawing.Point(3, 17);
            this.ric_diagnosis.Name = "ric_diagnosis";
            this.ric_diagnosis.Size = new System.Drawing.Size(234, 219);
            this.ric_diagnosis.TabIndex = 0;
            this.ric_diagnosis.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucCbo_married);
            this.groupBox3.Controls.Add(this.uTxt_cardnumber);
            this.groupBox3.Controls.Add(this.uTxt_tel);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.ucCbo_sex);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.uTxt_checknumber);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.uTxt_age);
            this.groupBox3.Controls.Add(this.uTxt_name);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 177);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "患者信息";
            // 
            // ucCbo_married
            // 
            this.ucCbo_married.BackColor = System.Drawing.Color.White;
            this.ucCbo_married.FormattingEnabled = true;
            this.ucCbo_married.Location = new System.Drawing.Point(226, 58);
            this.ucCbo_married.Name = "ucCbo_married";
            this.ucCbo_married.Size = new System.Drawing.Size(93, 20);
            this.ucCbo_married.TabIndex = 4;
            this.ucCbo_married.UcEmptyMessage = null;
            this.ucCbo_married.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucCbo_married.UcErrorIcon")));
            this.ucCbo_married.UcErrorMessage = null;
            // 
            // uTxt_cardnumber
            // 
            this.uTxt_cardnumber.BackColor = System.Drawing.Color.White;
            this.uTxt_cardnumber.Location = new System.Drawing.Point(77, 149);
            this.uTxt_cardnumber.Name = "uTxt_cardnumber";
            this.uTxt_cardnumber.Size = new System.Drawing.Size(242, 21);
            this.uTxt_cardnumber.TabIndex = 2;
            this.uTxt_cardnumber.UcEmptyMessage = null;
            this.uTxt_cardnumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_cardnumber.UcErrorIcon")));
            this.uTxt_cardnumber.UcErrorMessage = null;
            this.uTxt_cardnumber.UcRegexExpression = null;
            // 
            // uTxt_tel
            // 
            this.uTxt_tel.BackColor = System.Drawing.Color.White;
            this.uTxt_tel.Location = new System.Drawing.Point(77, 122);
            this.uTxt_tel.Name = "uTxt_tel";
            this.uTxt_tel.Size = new System.Drawing.Size(242, 21);
            this.uTxt_tel.TabIndex = 2;
            this.uTxt_tel.UcEmptyMessage = null;
            this.uTxt_tel.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_tel.UcErrorIcon")));
            this.uTxt_tel.UcErrorMessage = null;
            this.uTxt_tel.UcRegexExpression = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "证件号码：";
            // 
            // ucCbo_sex
            // 
            this.ucCbo_sex.BackColor = System.Drawing.Color.White;
            this.ucCbo_sex.FormattingEnabled = true;
            this.ucCbo_sex.Location = new System.Drawing.Point(77, 58);
            this.ucCbo_sex.Name = "ucCbo_sex";
            this.ucCbo_sex.Size = new System.Drawing.Size(93, 20);
            this.ucCbo_sex.TabIndex = 4;
            this.ucCbo_sex.UcEmptyMessage = null;
            this.ucCbo_sex.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("ucCbo_sex.UcErrorIcon")));
            this.ucCbo_sex.UcErrorMessage = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "联系电话：";
            // 
            // uTxt_checknumber
            // 
            this.uTxt_checknumber.BackColor = System.Drawing.Color.White;
            this.uTxt_checknumber.Location = new System.Drawing.Point(226, 21);
            this.uTxt_checknumber.Name = "uTxt_checknumber";
            this.uTxt_checknumber.Size = new System.Drawing.Size(93, 21);
            this.uTxt_checknumber.TabIndex = 2;
            this.uTxt_checknumber.UcEmptyMessage = null;
            this.uTxt_checknumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_checknumber.UcErrorIcon")));
            this.uTxt_checknumber.UcErrorMessage = null;
            this.uTxt_checknumber.UcRegexExpression = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "检查号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(182, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "婚否：";
            // 
            // uTxt_age
            // 
            this.uTxt_age.BackColor = System.Drawing.Color.White;
            this.uTxt_age.Location = new System.Drawing.Point(77, 90);
            this.uTxt_age.Name = "uTxt_age";
            this.uTxt_age.Size = new System.Drawing.Size(93, 21);
            this.uTxt_age.TabIndex = 2;
            this.uTxt_age.UcEmptyMessage = null;
            this.uTxt_age.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_age.UcErrorIcon")));
            this.uTxt_age.UcErrorMessage = null;
            this.uTxt_age.UcRegexExpression = null;
            // 
            // uTxt_name
            // 
            this.uTxt_name.BackColor = System.Drawing.Color.White;
            this.uTxt_name.Location = new System.Drawing.Point(77, 20);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(93, 21);
            this.uTxt_name.TabIndex = 2;
            this.uTxt_name.UcEmptyMessage = null;
            this.uTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_name.UcErrorIcon")));
            this.uTxt_name.UcErrorMessage = null;
            this.uTxt_name.UcRegexExpression = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "年龄：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "性别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uDtp_consultationdate);
            this.groupBox2.Controls.Add(this.uTxt_deptname);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.uTxt_hospitalname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 115);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会诊医院信息";
            // 
            // uDtp_consultationdate
            // 
            this.uDtp_consultationdate.Enabled = false;
            this.uDtp_consultationdate.Location = new System.Drawing.Point(77, 77);
            this.uDtp_consultationdate.Name = "uDtp_consultationdate";
            this.uDtp_consultationdate.Size = new System.Drawing.Size(212, 21);
            this.uDtp_consultationdate.TabIndex = 3;
            // 
            // uTxt_deptname
            // 
            this.uTxt_deptname.BackColor = System.Drawing.Color.White;
            this.uTxt_deptname.Enabled = false;
            this.uTxt_deptname.Location = new System.Drawing.Point(77, 50);
            this.uTxt_deptname.Name = "uTxt_deptname";
            this.uTxt_deptname.Size = new System.Drawing.Size(212, 21);
            this.uTxt_deptname.TabIndex = 2;
            this.uTxt_deptname.UcEmptyMessage = null;
            this.uTxt_deptname.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_deptname.UcErrorIcon")));
            this.uTxt_deptname.UcErrorMessage = null;
            this.uTxt_deptname.UcRegexExpression = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "会诊时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会诊医院：";
            // 
            // uTxt_hospitalname
            // 
            this.uTxt_hospitalname.BackColor = System.Drawing.Color.White;
            this.uTxt_hospitalname.Enabled = false;
            this.uTxt_hospitalname.Location = new System.Drawing.Point(77, 23);
            this.uTxt_hospitalname.Name = "uTxt_hospitalname";
            this.uTxt_hospitalname.Size = new System.Drawing.Size(212, 21);
            this.uTxt_hospitalname.TabIndex = 2;
            this.uTxt_hospitalname.UcEmptyMessage = null;
            this.uTxt_hospitalname.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_hospitalname.UcErrorIcon")));
            this.uTxt_hospitalname.UcErrorMessage = null;
            this.uTxt_hospitalname.UcRegexExpression = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "会诊科室：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uDtp_applyhospitaldate);
            this.groupBox1.Controls.Add(this.uTxt_applyhospitaltel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.uTxt_applyhospitalcode);
            this.groupBox1.Controls.Add(this.uTxt_applyhospitalname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(78, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 118);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请医院信息";
            // 
            // uDtp_applyhospitaldate
            // 
            this.uDtp_applyhospitaldate.Location = new System.Drawing.Point(77, 74);
            this.uDtp_applyhospitaldate.Name = "uDtp_applyhospitaldate";
            this.uDtp_applyhospitaldate.Size = new System.Drawing.Size(212, 21);
            this.uDtp_applyhospitaldate.TabIndex = 3;
            // 
            // uTxt_applyhospitaltel
            // 
            this.uTxt_applyhospitaltel.BackColor = System.Drawing.Color.White;
            this.uTxt_applyhospitaltel.Location = new System.Drawing.Point(77, 47);
            this.uTxt_applyhospitaltel.Name = "uTxt_applyhospitaltel";
            this.uTxt_applyhospitaltel.Size = new System.Drawing.Size(212, 21);
            this.uTxt_applyhospitaltel.TabIndex = 2;
            this.uTxt_applyhospitaltel.UcEmptyMessage = null;
            this.uTxt_applyhospitaltel.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_applyhospitaltel.UcErrorIcon")));
            this.uTxt_applyhospitaltel.UcErrorMessage = null;
            this.uTxt_applyhospitaltel.UcRegexExpression = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "申请日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "联系电话：";
            // 
            // uTxt_applyhospitalcode
            // 
            this.uTxt_applyhospitalcode.BackColor = System.Drawing.Color.White;
            this.uTxt_applyhospitalcode.Location = new System.Drawing.Point(77, 20);
            this.uTxt_applyhospitalcode.Name = "uTxt_applyhospitalcode";
            this.uTxt_applyhospitalcode.Size = new System.Drawing.Size(101, 21);
            this.uTxt_applyhospitalcode.TabIndex = 2;
            this.uTxt_applyhospitalcode.Text = "双击选择";
            this.uTxt_applyhospitalcode.UcEmptyMessage = null;
            this.uTxt_applyhospitalcode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_applyhospitalcode.UcErrorIcon")));
            this.uTxt_applyhospitalcode.UcErrorMessage = null;
            this.uTxt_applyhospitalcode.UcRegexExpression = null;
            this.uTxt_applyhospitalcode.DoubleClick += new System.EventHandler(this.uTxt_applyhospitalcode_DoubleClick);
            // 
            // uTxt_applyhospitalname
            // 
            this.uTxt_applyhospitalname.BackColor = System.Drawing.Color.White;
            this.uTxt_applyhospitalname.Enabled = false;
            this.uTxt_applyhospitalname.Location = new System.Drawing.Point(184, 20);
            this.uTxt_applyhospitalname.Name = "uTxt_applyhospitalname";
            this.uTxt_applyhospitalname.Size = new System.Drawing.Size(105, 21);
            this.uTxt_applyhospitalname.TabIndex = 2;
            this.uTxt_applyhospitalname.UcEmptyMessage = null;
            this.uTxt_applyhospitalname.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_applyhospitalname.UcErrorIcon")));
            this.uTxt_applyhospitalname.UcErrorMessage = null;
            this.uTxt_applyhospitalname.UcRegexExpression = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "申请医院：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(393, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Size = new System.Drawing.Size(479, 239);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ric_results);
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Location = new System.Drawing.Point(393, 257);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(479, 178);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "检查结果";
            // 
            // ric_results
            // 
            this.ric_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ric_results.Location = new System.Drawing.Point(3, 17);
            this.ric_results.Name = "ric_results";
            this.ric_results.Size = new System.Drawing.Size(473, 158);
            this.ric_results.TabIndex = 0;
            this.ric_results.Text = "";
            // 
            // FrmClinihospitalMyConsultationManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 496);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClinihospitalMyConsultationManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分时会诊";
            this.Load += new System.EventHandler(this.FrmClinicarDptManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private UComponentLib.Component.Extension.UcTextBox uTxt_applyhospitalname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private UComponentLib.Component.Extension.UcTextBox uTxt_applyhospitaltel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker uDtp_applyhospitaldate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private UComponentLib.Component.Extension.UcTextBox uTxt_deptname;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcTextBox uTxt_hospitalname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker uDtp_consultationdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private UComponentLib.Component.Extension.UcTextBox uTxt_checknumber;
        private System.Windows.Forms.Label label8;
        private UComponentLib.Component.Extension.UcTextBox uTxt_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private UComponentLib.Component.Extension.UcComboBox ucCbo_sex;
        private UComponentLib.Component.Extension.UcComboBox ucCbo_married;
        private System.Windows.Forms.Label label11;
        private UComponentLib.Component.Extension.UcTextBox uTxt_age;
        private System.Windows.Forms.Label label10;
        private UComponentLib.Component.Extension.UcTextBox uTxt_cardnumber;
        private UComponentLib.Component.Extension.UcTextBox uTxt_tel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox ric_medicalhistory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox ric_diagnosis;
        private UComponentLib.Component.Extension.UcTextBox uTxt_applyhospitalcode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox ric_results;
    }
}