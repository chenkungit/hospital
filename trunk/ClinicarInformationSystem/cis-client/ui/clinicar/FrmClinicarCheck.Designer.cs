namespace cis_client.ui.clinicar
{
    partial class FrmClinicarCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClinicarCheck));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uTxt_checkDoctor = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.uDat_checkDate = new UComponentLib.Component.Extension.UcDateTimePicker(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uRic_remark = new System.Windows.Forms.RichTextBox();
            this.uNum_tel = new UComponentLib.Component.Extension.UcNumberBox();
            this.uNum_age = new UComponentLib.Component.Extension.UcNumberBox();
            this.uDat_birthday = new UComponentLib.Component.Extension.UcDateTimePicker(this.components);
            this.uCbo_certificateTypeCode = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.uCbo_maritalStatusCode = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.uCbo_nationalityCode = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.uCbo_genderCode = new UComponentLib.Component.Extension.UcComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.uTxt_address = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_certificateNumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uTxt_name = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uTxt_checkNumber = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_certificateTypeName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_maritalStatusName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_nationalityName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.uTxt_genderName = new UComponentLib.Component.Extension.UcTextBox(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ucDgv_list = new UComponentLib.Component.Composite.UcDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_guide = new System.Windows.Forms.Button();
            this.btn_override = new System.Windows.Forms.Button();
            this.btn_finishRegister = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_saveMaster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(916, 484);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.uTxt_checkDoctor);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.uDat_checkDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检查信息";
            // 
            // uTxt_checkDoctor
            // 
            this.uTxt_checkDoctor.BackColor = System.Drawing.Color.White;
            this.uTxt_checkDoctor.Location = new System.Drawing.Point(73, 29);
            this.uTxt_checkDoctor.Name = "uTxt_checkDoctor";
            this.uTxt_checkDoctor.Size = new System.Drawing.Size(110, 21);
            this.uTxt_checkDoctor.TabIndex = 0;
            this.uTxt_checkDoctor.UcEmptyMessage = null;
            this.uTxt_checkDoctor.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_checkDoctor.UcErrorIcon")));
            this.uTxt_checkDoctor.UcErrorMessage = null;
            this.uTxt_checkDoctor.UcRegexExpression = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "开单医生";
            // 
            // uDat_checkDate
            // 
            this.uDat_checkDate.Location = new System.Drawing.Point(248, 29);
            this.uDat_checkDate.Name = "uDat_checkDate";
            this.uDat_checkDate.Size = new System.Drawing.Size(110, 21);
            this.uDat_checkDate.TabIndex = 1;
            this.uDat_checkDate.UcEmptyMessage = null;
            this.uDat_checkDate.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uDat_checkDate.UcErrorIcon")));
            this.uDat_checkDate.UcErrorMessage = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "检查日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.uRic_remark);
            this.groupBox1.Controls.Add(this.uNum_tel);
            this.groupBox1.Controls.Add(this.uNum_age);
            this.groupBox1.Controls.Add(this.uDat_birthday);
            this.groupBox1.Controls.Add(this.uCbo_certificateTypeCode);
            this.groupBox1.Controls.Add(this.uCbo_maritalStatusCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.uCbo_nationalityCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.uCbo_genderCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uTxt_address);
            this.groupBox1.Controls.Add(this.uTxt_certificateNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.uTxt_name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.uTxt_checkNumber);
            this.groupBox1.Controls.Add(this.uTxt_certificateTypeName);
            this.groupBox1.Controls.Add(this.uTxt_maritalStatusName);
            this.groupBox1.Controls.Add(this.uTxt_nationalityName);
            this.groupBox1.Controls.Add(this.uTxt_genderName);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员基本信息";
            // 
            // uRic_remark
            // 
            this.uRic_remark.BackColor = System.Drawing.SystemColors.Window;
            this.uRic_remark.Location = new System.Drawing.Point(73, 219);
            this.uRic_remark.Name = "uRic_remark";
            this.uRic_remark.Size = new System.Drawing.Size(413, 70);
            this.uRic_remark.TabIndex = 10;
            this.uRic_remark.Text = "";
            // 
            // uNum_tel
            // 
            this.uNum_tel.BackColor = System.Drawing.Color.White;
            this.uNum_tel.Location = new System.Drawing.Point(73, 180);
            this.uNum_tel.Name = "uNum_tel";
            this.uNum_tel.Size = new System.Drawing.Size(413, 21);
            this.uNum_tel.TabIndex = 9;
            this.uNum_tel.Text = "0";
            this.uNum_tel.UcEmptyMessage = null;
            this.uNum_tel.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uNum_tel.UcErrorIcon")));
            this.uNum_tel.UcErrorMessage = null;
            this.uNum_tel.UcNumberType = UComponentLib.Enum.NumberType.PositiveNumber;
            this.uNum_tel.UcRegexExpression = null;
            this.uNum_tel.UcRegexOnTextChanged = true;
            this.uNum_tel.UcValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // uNum_age
            // 
            this.uNum_age.BackColor = System.Drawing.Color.White;
            this.uNum_age.Location = new System.Drawing.Point(248, 67);
            this.uNum_age.Name = "uNum_age";
            this.uNum_age.Size = new System.Drawing.Size(88, 21);
            this.uNum_age.TabIndex = 4;
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
            // uDat_birthday
            // 
            this.uDat_birthday.Location = new System.Drawing.Point(73, 68);
            this.uDat_birthday.Name = "uDat_birthday";
            this.uDat_birthday.Size = new System.Drawing.Size(110, 21);
            this.uDat_birthday.TabIndex = 3;
            this.uDat_birthday.UcEmptyMessage = null;
            this.uDat_birthday.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uDat_birthday.UcErrorIcon")));
            this.uDat_birthday.UcErrorMessage = null;
            // 
            // uCbo_certificateTypeCode
            // 
            this.uCbo_certificateTypeCode.BackColor = System.Drawing.Color.White;
            this.uCbo_certificateTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uCbo_certificateTypeCode.FormattingEnabled = true;
            this.uCbo_certificateTypeCode.Location = new System.Drawing.Point(73, 106);
            this.uCbo_certificateTypeCode.Name = "uCbo_certificateTypeCode";
            this.uCbo_certificateTypeCode.Size = new System.Drawing.Size(110, 20);
            this.uCbo_certificateTypeCode.TabIndex = 6;
            this.uCbo_certificateTypeCode.UcEmptyMessage = null;
            this.uCbo_certificateTypeCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uCbo_certificateTypeCode.UcErrorIcon")));
            this.uCbo_certificateTypeCode.UcErrorMessage = null;
            this.uCbo_certificateTypeCode.SelectedIndexChanged += new System.EventHandler(this.uCbo_certificateTypeCode_SelectedIndexChanged);
            // 
            // uCbo_maritalStatusCode
            // 
            this.uCbo_maritalStatusCode.BackColor = System.Drawing.Color.White;
            this.uCbo_maritalStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uCbo_maritalStatusCode.FormattingEnabled = true;
            this.uCbo_maritalStatusCode.Location = new System.Drawing.Point(398, 68);
            this.uCbo_maritalStatusCode.Name = "uCbo_maritalStatusCode";
            this.uCbo_maritalStatusCode.Size = new System.Drawing.Size(88, 20);
            this.uCbo_maritalStatusCode.TabIndex = 5;
            this.uCbo_maritalStatusCode.UcEmptyMessage = null;
            this.uCbo_maritalStatusCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uCbo_maritalStatusCode.UcErrorIcon")));
            this.uCbo_maritalStatusCode.UcErrorMessage = null;
            this.uCbo_maritalStatusCode.SelectedIndexChanged += new System.EventHandler(this.uCbo_maritalStatusCode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "证件类型";
            // 
            // uCbo_nationalityCode
            // 
            this.uCbo_nationalityCode.BackColor = System.Drawing.Color.White;
            this.uCbo_nationalityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uCbo_nationalityCode.FormattingEnabled = true;
            this.uCbo_nationalityCode.Location = new System.Drawing.Point(398, 31);
            this.uCbo_nationalityCode.Name = "uCbo_nationalityCode";
            this.uCbo_nationalityCode.Size = new System.Drawing.Size(88, 20);
            this.uCbo_nationalityCode.TabIndex = 2;
            this.uCbo_nationalityCode.UcEmptyMessage = null;
            this.uCbo_nationalityCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uCbo_nationalityCode.UcErrorIcon")));
            this.uCbo_nationalityCode.UcErrorMessage = null;
            this.uCbo_nationalityCode.SelectedIndexChanged += new System.EventHandler(this.uCbo_nationalityCode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "婚姻";
            // 
            // uCbo_genderCode
            // 
            this.uCbo_genderCode.BackColor = System.Drawing.Color.White;
            this.uCbo_genderCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uCbo_genderCode.FormattingEnabled = true;
            this.uCbo_genderCode.Location = new System.Drawing.Point(248, 31);
            this.uCbo_genderCode.Name = "uCbo_genderCode";
            this.uCbo_genderCode.Size = new System.Drawing.Size(88, 20);
            this.uCbo_genderCode.TabIndex = 1;
            this.uCbo_genderCode.UcEmptyMessage = null;
            this.uCbo_genderCode.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uCbo_genderCode.UcErrorIcon")));
            this.uCbo_genderCode.UcErrorMessage = null;
            this.uCbo_genderCode.SelectedValueChanged += new System.EventHandler(this.uCbo_genderCode_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "民族";
            // 
            // uTxt_address
            // 
            this.uTxt_address.BackColor = System.Drawing.Color.White;
            this.uTxt_address.Location = new System.Drawing.Point(73, 142);
            this.uTxt_address.Name = "uTxt_address";
            this.uTxt_address.Size = new System.Drawing.Size(413, 21);
            this.uTxt_address.TabIndex = 8;
            this.uTxt_address.UcEmptyMessage = null;
            this.uTxt_address.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_address.UcErrorIcon")));
            this.uTxt_address.UcErrorMessage = null;
            this.uTxt_address.UcRegexExpression = null;
            // 
            // uTxt_certificateNumber
            // 
            this.uTxt_certificateNumber.BackColor = System.Drawing.Color.White;
            this.uTxt_certificateNumber.Location = new System.Drawing.Point(248, 106);
            this.uTxt_certificateNumber.Name = "uTxt_certificateNumber";
            this.uTxt_certificateNumber.Size = new System.Drawing.Size(238, 21);
            this.uTxt_certificateNumber.TabIndex = 7;
            this.uTxt_certificateNumber.UcEmptyMessage = null;
            this.uTxt_certificateNumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_certificateNumber.UcErrorIcon")));
            this.uTxt_certificateNumber.UcErrorMessage = null;
            this.uTxt_certificateNumber.UcRegexExpression = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "备注";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "联系电话";
            // 
            // uTxt_name
            // 
            this.uTxt_name.AccessibleName = "";
            this.uTxt_name.BackColor = System.Drawing.Color.White;
            this.uTxt_name.Location = new System.Drawing.Point(73, 31);
            this.uTxt_name.Name = "uTxt_name";
            this.uTxt_name.Size = new System.Drawing.Size(110, 21);
            this.uTxt_name.TabIndex = 0;
            this.uTxt_name.UcEmptyMessage = null;
            this.uTxt_name.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_name.UcErrorIcon")));
            this.uTxt_name.UcErrorMessage = null;
            this.uTxt_name.UcRegexExpression = null;
            this.uTxt_name.DoubleClick += new System.EventHandler(this.uTxt_name_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "年龄";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "性别";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "证件号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "出生日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // uTxt_checkNumber
            // 
            this.uTxt_checkNumber.BackColor = System.Drawing.Color.White;
            this.uTxt_checkNumber.Enabled = false;
            this.uTxt_checkNumber.Location = new System.Drawing.Point(112, 240);
            this.uTxt_checkNumber.Name = "uTxt_checkNumber";
            this.uTxt_checkNumber.Size = new System.Drawing.Size(110, 21);
            this.uTxt_checkNumber.TabIndex = 0;
            this.uTxt_checkNumber.UcEmptyMessage = null;
            this.uTxt_checkNumber.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_checkNumber.UcErrorIcon")));
            this.uTxt_checkNumber.UcErrorMessage = null;
            this.uTxt_checkNumber.UcRegexExpression = null;
            // 
            // uTxt_certificateTypeName
            // 
            this.uTxt_certificateTypeName.BackColor = System.Drawing.Color.White;
            this.uTxt_certificateTypeName.Enabled = false;
            this.uTxt_certificateTypeName.Location = new System.Drawing.Point(399, 240);
            this.uTxt_certificateTypeName.Name = "uTxt_certificateTypeName";
            this.uTxt_certificateTypeName.Size = new System.Drawing.Size(51, 21);
            this.uTxt_certificateTypeName.TabIndex = 0;
            this.uTxt_certificateTypeName.UcEmptyMessage = null;
            this.uTxt_certificateTypeName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_certificateTypeName.UcErrorIcon")));
            this.uTxt_certificateTypeName.UcErrorMessage = null;
            this.uTxt_certificateTypeName.UcRegexExpression = null;
            // 
            // uTxt_maritalStatusName
            // 
            this.uTxt_maritalStatusName.BackColor = System.Drawing.Color.White;
            this.uTxt_maritalStatusName.Enabled = false;
            this.uTxt_maritalStatusName.Location = new System.Drawing.Point(342, 240);
            this.uTxt_maritalStatusName.Name = "uTxt_maritalStatusName";
            this.uTxt_maritalStatusName.Size = new System.Drawing.Size(51, 21);
            this.uTxt_maritalStatusName.TabIndex = 0;
            this.uTxt_maritalStatusName.UcEmptyMessage = null;
            this.uTxt_maritalStatusName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_maritalStatusName.UcErrorIcon")));
            this.uTxt_maritalStatusName.UcErrorMessage = null;
            this.uTxt_maritalStatusName.UcRegexExpression = null;
            // 
            // uTxt_nationalityName
            // 
            this.uTxt_nationalityName.BackColor = System.Drawing.Color.White;
            this.uTxt_nationalityName.Enabled = false;
            this.uTxt_nationalityName.Location = new System.Drawing.Point(285, 240);
            this.uTxt_nationalityName.Name = "uTxt_nationalityName";
            this.uTxt_nationalityName.Size = new System.Drawing.Size(51, 21);
            this.uTxt_nationalityName.TabIndex = 0;
            this.uTxt_nationalityName.UcEmptyMessage = null;
            this.uTxt_nationalityName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_nationalityName.UcErrorIcon")));
            this.uTxt_nationalityName.UcErrorMessage = null;
            this.uTxt_nationalityName.UcRegexExpression = null;
            // 
            // uTxt_genderName
            // 
            this.uTxt_genderName.BackColor = System.Drawing.Color.White;
            this.uTxt_genderName.Enabled = false;
            this.uTxt_genderName.Location = new System.Drawing.Point(228, 240);
            this.uTxt_genderName.Name = "uTxt_genderName";
            this.uTxt_genderName.Size = new System.Drawing.Size(51, 21);
            this.uTxt_genderName.TabIndex = 0;
            this.uTxt_genderName.UcEmptyMessage = null;
            this.uTxt_genderName.UcErrorIcon = ((System.Drawing.Icon)(resources.GetObject("uTxt_genderName.UcErrorIcon")));
            this.uTxt_genderName.UcErrorMessage = null;
            this.uTxt_genderName.UcRegexExpression = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucDgv_list);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 484);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // ucDgv_list
            // 
            this.ucDgv_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDgv_list.Location = new System.Drawing.Point(3, 17);
            this.ucDgv_list.Name = "ucDgv_list";
            this.ucDgv_list.Size = new System.Drawing.Size(392, 464);
            this.ucDgv_list.TabIndex = 2;
            this.ucDgv_list.UcIsPagintion = true;
            this.ucDgv_list.UcPageSize = 100;
            this.ucDgv_list.UcCustomPagintion += new UComponentLib.Component.Composite.CustomPagintionHandler(this.ucDgv_list_UcCustomPagintion);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_guide);
            this.panel2.Controls.Add(this.btn_override);
            this.panel2.Controls.Add(this.btn_finishRegister);
            this.panel2.Controls.Add(this.btn_del);
            this.panel2.Controls.Add(this.btn_addItem);
            this.panel2.Controls.Add(this.btn_saveMaster);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 43);
            this.panel2.TabIndex = 0;
            // 
            // btn_guide
            // 
            this.btn_guide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guide.Location = new System.Drawing.Point(829, 10);
            this.btn_guide.Name = "btn_guide";
            this.btn_guide.Size = new System.Drawing.Size(75, 23);
            this.btn_guide.TabIndex = 5;
            this.btn_guide.Text = "指引单";
            this.btn_guide.UseVisualStyleBackColor = true;
            this.btn_guide.Click += new System.EventHandler(this.btn_guide_Click);
            // 
            // btn_override
            // 
            this.btn_override.Location = new System.Drawing.Point(113, 10);
            this.btn_override.Name = "btn_override";
            this.btn_override.Size = new System.Drawing.Size(75, 23);
            this.btn_override.TabIndex = 3;
            this.btn_override.Text = "重填";
            this.btn_override.UseVisualStyleBackColor = true;
            this.btn_override.Click += new System.EventHandler(this.btn_override_Click);
            // 
            // btn_finishRegister
            // 
            this.btn_finishRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_finishRegister.Location = new System.Drawing.Point(667, 10);
            this.btn_finishRegister.Name = "btn_finishRegister";
            this.btn_finishRegister.Size = new System.Drawing.Size(75, 23);
            this.btn_finishRegister.TabIndex = 2;
            this.btn_finishRegister.Text = "完成登记";
            this.btn_finishRegister.UseVisualStyleBackColor = true;
            this.btn_finishRegister.Click += new System.EventHandler(this.btn_finishRegister_Click);
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.Location = new System.Drawing.Point(748, 10);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 4;
            this.btn_del.Text = "删除项目";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click_1);
            // 
            // btn_addItem
            // 
            this.btn_addItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addItem.Location = new System.Drawing.Point(586, 10);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(75, 23);
            this.btn_addItem.TabIndex = 1;
            this.btn_addItem.Text = "添加项目";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // btn_saveMaster
            // 
            this.btn_saveMaster.Location = new System.Drawing.Point(12, 10);
            this.btn_saveMaster.Name = "btn_saveMaster";
            this.btn_saveMaster.Size = new System.Drawing.Size(94, 23);
            this.btn_saveMaster.TabIndex = 0;
            this.btn_saveMaster.Text = "保存人员信息";
            this.btn_saveMaster.UseVisualStyleBackColor = true;
            this.btn_saveMaster.Click += new System.EventHandler(this.btn_saveMaster_Click);
            // 
            // FrmClinicarCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 484);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmClinicarCheck";
            this.Text = "登记";
            this.Load += new System.EventHandler(this.FrmClinicarCheck_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private UComponentLib.Component.Extension.UcTextBox uTxt_name;
        private UComponentLib.Component.Extension.UcComboBox uCbo_genderCode;
        private System.Windows.Forms.Label label2;
        private UComponentLib.Component.Extension.UcComboBox uCbo_nationalityCode;
        private System.Windows.Forms.Label label3;
        private UComponentLib.Component.Extension.UcDateTimePicker uDat_birthday;
        private System.Windows.Forms.Label label4;
        private UComponentLib.Component.Extension.UcNumberBox uNum_age;
        private System.Windows.Forms.Label label5;
        private UComponentLib.Component.Extension.UcComboBox uCbo_maritalStatusCode;
        private System.Windows.Forms.Label label6;
        private UComponentLib.Component.Extension.UcComboBox uCbo_certificateTypeCode;
        private System.Windows.Forms.Label label7;
        private UComponentLib.Component.Extension.UcTextBox uTxt_certificateNumber;
        private System.Windows.Forms.Label label8;
        private UComponentLib.Component.Extension.UcTextBox uTxt_address;
        private System.Windows.Forms.Label label9;
        private UComponentLib.Component.Extension.UcNumberBox uNum_tel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox uRic_remark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private UComponentLib.Component.Extension.UcTextBox uTxt_checkDoctor;
        private System.Windows.Forms.Label label12;
        private UComponentLib.Component.Extension.UcDateTimePicker uDat_checkDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_guide;
        private System.Windows.Forms.Button btn_override;
        private System.Windows.Forms.Button btn_finishRegister;
        private UComponentLib.Component.Extension.UcTextBox uTxt_checkNumber;
        private UComponentLib.Component.Extension.UcTextBox uTxt_genderName;
        private UComponentLib.Component.Extension.UcTextBox uTxt_nationalityName;
        private UComponentLib.Component.Extension.UcTextBox uTxt_maritalStatusName;
        private UComponentLib.Component.Extension.UcTextBox uTxt_certificateTypeName;
        private System.Windows.Forms.Button btn_saveMaster;
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Button btn_del;
        private UComponentLib.Component.Composite.UcDataGridView ucDgv_list;
    }
}