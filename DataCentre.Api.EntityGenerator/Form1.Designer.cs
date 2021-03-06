namespace DataCentre.Api.EntityGenerator
{
    partial class frmEntityCodeGrenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxDB = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cboDBType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.grpModelSection = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerateModel = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnSelectOutPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radSystemAnno = new System.Windows.Forms.RadioButton();
            this.radDapper = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnListTable = new System.Windows.Forms.Button();
            this.clbTableList = new System.Windows.Forms.CheckedListBox();
            this.groupBoxDB.SuspendLayout();
            this.grpModelSection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDB
            // 
            this.groupBoxDB.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBoxDB.Controls.Add(this.label6);
            this.groupBoxDB.Controls.Add(this.txtDBName);
            this.groupBoxDB.Controls.Add(this.btnTestConnection);
            this.groupBoxDB.Controls.Add(this.cboDBType);
            this.groupBoxDB.Controls.Add(this.label5);
            this.groupBoxDB.Controls.Add(this.btnSaveSetting);
            this.groupBoxDB.Controls.Add(this.label4);
            this.groupBoxDB.Controls.Add(this.txtPassword);
            this.groupBoxDB.Controls.Add(this.label3);
            this.groupBoxDB.Controls.Add(this.txtUserName);
            this.groupBoxDB.Controls.Add(this.label2);
            this.groupBoxDB.Controls.Add(this.txtPort);
            this.groupBoxDB.Controls.Add(this.label1);
            this.groupBoxDB.Controls.Add(this.txtIP);
            this.groupBoxDB.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDB.Name = "groupBoxDB";
            this.groupBoxDB.Size = new System.Drawing.Size(864, 96);
            this.groupBoxDB.TabIndex = 2;
            this.groupBoxDB.TabStop = false;
            this.groupBoxDB.Text = "資料庫連線";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "資料庫名稱";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(94, 64);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(100, 23);
            this.txtDBName.TabIndex = 14;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(610, 67);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 13;
            this.btnTestConnection.Text = "測試連線";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cboDBType
            // 
            this.cboDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDBType.FormattingEnabled = true;
            this.cboDBType.Items.AddRange(new object[] {
            "MySQL",
            "MSSQL"});
            this.cboDBType.Location = new System.Drawing.Point(285, 64);
            this.cboDBType.Name = "cboDBType";
            this.cboDBType.Size = new System.Drawing.Size(95, 24);
            this.cboDBType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "資料庫類型";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(691, 67);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSetting.TabIndex = 10;
            this.btnSaveSetting.Text = "儲存設定";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "資料庫密碼";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(666, 28);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "資料庫帳號";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(476, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 23);
            this.txtUserName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "資料庫阜號";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(285, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "3306";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "資料庫IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(94, 28);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 23);
            this.txtIP.TabIndex = 2;
            // 
            // grpModelSection
            // 
            this.grpModelSection.BackColor = System.Drawing.Color.LightSalmon;
            this.grpModelSection.Controls.Add(this.groupBox2);
            this.grpModelSection.Controls.Add(this.groupBox1);
            this.grpModelSection.Controls.Add(this.btnListTable);
            this.grpModelSection.Controls.Add(this.clbTableList);
            this.grpModelSection.Location = new System.Drawing.Point(12, 132);
            this.grpModelSection.Name = "grpModelSection";
            this.grpModelSection.Size = new System.Drawing.Size(865, 403);
            this.grpModelSection.TabIndex = 17;
            this.grpModelSection.TabStop = false;
            this.grpModelSection.Text = "產生Entity";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnGenerateModel);
            this.groupBox2.Controls.Add(this.txtOutputPath);
            this.groupBox2.Controls.Add(this.btnSelectOutPath);
            this.groupBox2.Location = new System.Drawing.Point(213, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 216);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "輸出程式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(8, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(622, 62);
            this.label7.TabIndex = 26;
            this.label7.Text = "※此程式會依據上面的資料庫設定，抓取Table、Column定義並產出C#的程式碼\r\n※將產生的程式碼，放到Model的專案後替換原有的檔案便可以產出最新的Mod" +
    "el dll檔\r\n※此程式碼僅提供.NET或.NET Core程式使用\r\n";
            // 
            // btnGenerateModel
            // 
            this.btnGenerateModel.Location = new System.Drawing.Point(365, 51);
            this.btnGenerateModel.Name = "btnGenerateModel";
            this.btnGenerateModel.Size = new System.Drawing.Size(103, 23);
            this.btnGenerateModel.TabIndex = 25;
            this.btnGenerateModel.Text = "產出Model程式";
            this.btnGenerateModel.UseVisualStyleBackColor = true;
            this.btnGenerateModel.Click += new System.EventHandler(this.btnGenerateModel_Click_1);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(7, 51);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(352, 23);
            this.txtOutputPath.TabIndex = 24;
            // 
            // btnSelectOutPath
            // 
            this.btnSelectOutPath.Location = new System.Drawing.Point(7, 22);
            this.btnSelectOutPath.Name = "btnSelectOutPath";
            this.btnSelectOutPath.Size = new System.Drawing.Size(110, 23);
            this.btnSelectOutPath.TabIndex = 23;
            this.btnSelectOutPath.Text = "選擇輸出路徑";
            this.btnSelectOutPath.UseVisualStyleBackColor = true;
            this.btnSelectOutPath.Click += new System.EventHandler(this.btnSelectOutPath_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.txtNamespace);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.radSystemAnno);
            this.groupBox1.Controls.Add(this.radDapper);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(213, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 144);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "程式碼設定";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(7, 107);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(352, 23);
            this.txtNamespace.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "命名空間";
            // 
            // radSystemAnno
            // 
            this.radSystemAnno.AutoSize = true;
            this.radSystemAnno.Location = new System.Drawing.Point(138, 55);
            this.radSystemAnno.Name = "radSystemAnno";
            this.radSystemAnno.Size = new System.Drawing.Size(272, 20);
            this.radSystemAnno.TabIndex = 30;
            this.radSystemAnno.TabStop = true;
            this.radSystemAnno.Text = "System.ComponentModel.DataAnnotations";
            this.radSystemAnno.UseVisualStyleBackColor = true;
            // 
            // radDapper
            // 
            this.radDapper.AutoSize = true;
            this.radDapper.Location = new System.Drawing.Point(6, 55);
            this.radDapper.Name = "radDapper";
            this.radDapper.Size = new System.Drawing.Size(68, 20);
            this.radDapper.TabIndex = 29;
            this.radDapper.TabStop = true;
            this.radDapper.Text = "Dapper";
            this.radDapper.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "資料標記選項";
            // 
            // btnListTable
            // 
            this.btnListTable.Location = new System.Drawing.Point(13, 22);
            this.btnListTable.Name = "btnListTable";
            this.btnListTable.Size = new System.Drawing.Size(75, 23);
            this.btnListTable.TabIndex = 18;
            this.btnListTable.Text = "列出Table";
            this.btnListTable.UseVisualStyleBackColor = true;
            this.btnListTable.Click += new System.EventHandler(this.btnListTable_Click);
            // 
            // clbTableList
            // 
            this.clbTableList.FormattingEnabled = true;
            this.clbTableList.Location = new System.Drawing.Point(13, 51);
            this.clbTableList.Name = "clbTableList";
            this.clbTableList.Size = new System.Drawing.Size(181, 346);
            this.clbTableList.TabIndex = 17;
            // 
            // frmEntityCodeGrenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 547);
            this.Controls.Add(this.grpModelSection);
            this.Controls.Add(this.groupBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEntityCodeGrenerator";
            this.Text = "C# DB Model程式產生器";
            this.groupBoxDB.ResumeLayout(false);
            this.groupBoxDB.PerformLayout();
            this.grpModelSection.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxDB;
        private Label label2;
        private TextBox txtPort;
        private Label label1;
        private TextBox txtIP;
        private Label label3;
        private TextBox txtUserName;
        private Label label4;
        private TextBox txtPassword;
        private Button btnSaveSetting;
        private Label label5;
        private ComboBox cboDBType;
        private Button btnTestConnection;
        private Label label6;
        private TextBox txtDBName;
        private GroupBox grpModelSection;
        private Button btnListTable;
        private CheckedListBox clbTableList;
        private GroupBox groupBox1;
        private TextBox txtNamespace;
        private Label label9;
        private RadioButton radSystemAnno;
        private RadioButton radDapper;
        private Label label8;
        private GroupBox groupBox2;
        private Label label7;
        private Button btnGenerateModel;
        private TextBox txtOutputPath;
        private Button btnSelectOutPath;
    }
}