namespace CodeGenerator.Forms {
	partial class FormGenerator {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerator));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.MaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnConnectDisconnect = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtIp = new System.Windows.Forms.TextBox();
			this.cmbDatabase = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dgvTables = new System.Windows.Forms.DataGridView();
			this.ColChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSelect = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dgvTable = new System.Windows.Forms.DataGridView();
			this.ColConstructor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.grpTables = new System.Windows.Forms.GroupBox();
			this.txtFilterTables = new System.Windows.Forms.TextBox();
			this.grpTable = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkInterfaces = new System.Windows.Forms.CheckBox();
			this.chkPersistence = new System.Windows.Forms.CheckBox();
			this.chkService = new System.Windows.Forms.CheckBox();
			this.chkConstructor = new System.Windows.Forms.CheckBox();
			this.chkModel = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
			this.grpTables.SuspendLayout();
			this.grpTable.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(213, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(201, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port: ";
			// 
			// txtPort
			// 
			this.txtPort.ForeColor = System.Drawing.Color.Black;
			this.txtPort.Location = new System.Drawing.Point(233, 55);
			this.txtPort.Mask = "00000";
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(101, 23);
			this.txtPort.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(39, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "User: ";
			// 
			// txtUser
			// 
			this.txtUser.ForeColor = System.Drawing.Color.Black;
			this.txtUser.Location = new System.Drawing.Point(73, 52);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(100, 23);
			this.txtUser.TabIndex = 2;
			// 
			// txtPassword
			// 
			this.txtPassword.ForeColor = System.Drawing.Color.Black;
			this.txtPassword.Location = new System.Drawing.Point(73, 81);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(100, 23);
			this.txtPassword.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(12, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "Password: ";
			// 
			// txtName
			// 
			this.txtName.ForeColor = System.Drawing.Color.Black;
			this.txtName.Location = new System.Drawing.Point(233, 81);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(101, 23);
			this.txtName.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(173, 85);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "DB Name: ";
			// 
			// btnConnectDisconnect
			// 
			this.btnConnectDisconnect.ForeColor = System.Drawing.Color.Black;
			this.btnConnectDisconnect.Location = new System.Drawing.Point(6, 110);
			this.btnConnectDisconnect.Name = "btnConnectDisconnect";
			this.btnConnectDisconnect.Size = new System.Drawing.Size(328, 27);
			this.btnConnectDisconnect.TabIndex = 6;
			this.btnConnectDisconnect.Text = "Connect Database";
			this.btnConnectDisconnect.UseVisualStyleBackColor = true;
			this.btnConnectDisconnect.Click += new System.EventHandler(this.BtnConnectDisconnect_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.txtIp);
			this.groupBox1.Controls.Add(this.cmbDatabase);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btnConnectDisconnect);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUser);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.ForeColor = System.Drawing.Color.Navy;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(340, 146);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection";
			// 
			// txtIp
			// 
			this.txtIp.ForeColor = System.Drawing.Color.Black;
			this.txtIp.Location = new System.Drawing.Point(233, 26);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(101, 23);
			this.txtIp.TabIndex = 1;
			// 
			// cmbDatabase
			// 
			this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDatabase.FormattingEnabled = true;
			this.cmbDatabase.Location = new System.Drawing.Point(73, 23);
			this.cmbDatabase.Name = "cmbDatabase";
			this.cmbDatabase.Size = new System.Drawing.Size(100, 23);
			this.cmbDatabase.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(14, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 15);
			this.label6.TabIndex = 11;
			this.label6.Text = "Database: ";
			// 
			// dgvTables
			// 
			this.dgvTables.AllowUserToAddRows = false;
			this.dgvTables.AllowUserToDeleteRows = false;
			this.dgvTables.AllowUserToResizeRows = false;
			this.dgvTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChecked,
            this.ColTable,
            this.ColClassName,
            this.ColSelect});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvTables.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvTables.Location = new System.Drawing.Point(6, 51);
			this.dgvTables.Name = "dgvTables";
			this.dgvTables.RowHeadersVisible = false;
			this.dgvTables.RowHeadersWidth = 62;
			this.dgvTables.RowTemplate.Height = 25;
			this.dgvTables.Size = new System.Drawing.Size(328, 495);
			this.dgvTables.TabIndex = 12;
			this.dgvTables.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTables_CellEndEdit);
			this.dgvTables.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTables_CellMouseClick);
			// 
			// ColChecked
			// 
			this.ColChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColChecked.HeaderText = "Generate?";
			this.ColChecked.MinimumWidth = 8;
			this.ColChecked.Name = "ColChecked";
			this.ColChecked.Width = 65;
			// 
			// ColTable
			// 
			this.ColTable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.ColTable.DefaultCellStyle = dataGridViewCellStyle1;
			this.ColTable.HeaderText = "Table";
			this.ColTable.MinimumWidth = 8;
			this.ColTable.Name = "ColTable";
			this.ColTable.ReadOnly = true;
			// 
			// ColClassName
			// 
			this.ColClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			this.ColClassName.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColClassName.HeaderText = "Class Name";
			this.ColClassName.MinimumWidth = 8;
			this.ColClassName.Name = "ColClassName";
			// 
			// ColSelect
			// 
			this.ColSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColSelect.HeaderText = "";
			this.ColSelect.MinimumWidth = 8;
			this.ColSelect.Name = "ColSelect";
			this.ColSelect.Text = "Open";
			this.ColSelect.ToolTipText = "Open";
			this.ColSelect.UseColumnTextForButtonValue = true;
			this.ColSelect.Width = 8;
			// 
			// dgvTable
			// 
			this.dgvTable.AllowUserToAddRows = false;
			this.dgvTable.AllowUserToDeleteRows = false;
			this.dgvTable.AllowUserToResizeRows = false;
			this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColConstructor,
            this.ColName,
            this.ColType,
            this.ColPropertyName});
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvTable.DefaultCellStyle = dataGridViewCellStyle7;
			this.dgvTable.Location = new System.Drawing.Point(6, 22);
			this.dgvTable.Name = "dgvTable";
			this.dgvTable.RowHeadersVisible = false;
			this.dgvTable.RowHeadersWidth = 62;
			this.dgvTable.RowTemplate.Height = 25;
			this.dgvTable.Size = new System.Drawing.Size(430, 516);
			this.dgvTable.TabIndex = 13;
			this.dgvTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTable_CellEndEdit);
			// 
			// ColConstructor
			// 
			this.ColConstructor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColConstructor.HeaderText = ".Constructor?";
			this.ColConstructor.MinimumWidth = 8;
			this.ColConstructor.Name = "ColConstructor";
			this.ColConstructor.Width = 84;
			// 
			// ColName
			// 
			this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			this.ColName.DefaultCellStyle = dataGridViewCellStyle4;
			this.ColName.HeaderText = "Column Name";
			this.ColName.MinimumWidth = 8;
			this.ColName.Name = "ColName";
			this.ColName.ReadOnly = true;
			// 
			// ColType
			// 
			this.ColType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			this.ColType.DefaultCellStyle = dataGridViewCellStyle5;
			this.ColType.HeaderText = "Type";
			this.ColType.MinimumWidth = 8;
			this.ColType.Name = "ColType";
			this.ColType.ReadOnly = true;
			this.ColType.Width = 56;
			// 
			// ColPropertyName
			// 
			this.ColPropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			this.ColPropertyName.DefaultCellStyle = dataGridViewCellStyle6;
			this.ColPropertyName.HeaderText = "Property Name";
			this.ColPropertyName.MinimumWidth = 8;
			this.ColPropertyName.Name = "ColPropertyName";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerate.Location = new System.Drawing.Point(361, 672);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(439, 44);
			this.btnGenerate.TabIndex = 3;
			this.btnGenerate.Text = "Generate Code";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
			// 
			// grpTables
			// 
			this.grpTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpTables.Controls.Add(this.txtFilterTables);
			this.grpTables.Controls.Add(this.dgvTables);
			this.grpTables.ForeColor = System.Drawing.Color.Navy;
			this.grpTables.Location = new System.Drawing.Point(12, 164);
			this.grpTables.Name = "grpTables";
			this.grpTables.Size = new System.Drawing.Size(340, 552);
			this.grpTables.TabIndex = 1;
			this.grpTables.TabStop = false;
			this.grpTables.Text = "Tables";
			// 
			// txtFilterTables
			// 
			this.txtFilterTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilterTables.Location = new System.Drawing.Point(6, 22);
			this.txtFilterTables.Name = "txtFilterTables";
			this.txtFilterTables.Size = new System.Drawing.Size(328, 23);
			this.txtFilterTables.TabIndex = 13;
			this.txtFilterTables.TextChanged += new System.EventHandler(this.TxtFilterTables_TextChanged);
			// 
			// grpTable
			// 
			this.grpTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTable.Controls.Add(this.dgvTable);
			this.grpTable.ForeColor = System.Drawing.Color.Navy;
			this.grpTable.Location = new System.Drawing.Point(358, 12);
			this.grpTable.Name = "grpTable";
			this.grpTable.Size = new System.Drawing.Size(442, 544);
			this.grpTable.TabIndex = 2;
			this.grpTable.TabStop = false;
			this.grpTable.Text = "Table";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.chkInterfaces);
			this.groupBox2.Controls.Add(this.chkPersistence);
			this.groupBox2.Controls.Add(this.chkService);
			this.groupBox2.Controls.Add(this.chkConstructor);
			this.groupBox2.Controls.Add(this.chkModel);
			this.groupBox2.ForeColor = System.Drawing.Color.Navy;
			this.groupBox2.Location = new System.Drawing.Point(361, 619);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(439, 47);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Files";
			// 
			// chkInterfaces
			// 
			this.chkInterfaces.AutoSize = true;
			this.chkInterfaces.ForeColor = System.Drawing.Color.Black;
			this.chkInterfaces.Location = new System.Drawing.Point(336, 22);
			this.chkInterfaces.Name = "chkInterfaces";
			this.chkInterfaces.Size = new System.Drawing.Size(77, 19);
			this.chkInterfaces.TabIndex = 4;
			this.chkInterfaces.Text = "Interfaces";
			this.chkInterfaces.UseVisualStyleBackColor = true;
			// 
			// chkPersistence
			// 
			this.chkPersistence.AutoSize = true;
			this.chkPersistence.Checked = true;
			this.chkPersistence.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPersistence.ForeColor = System.Drawing.Color.Black;
			this.chkPersistence.Location = new System.Drawing.Point(245, 22);
			this.chkPersistence.Name = "chkPersistence";
			this.chkPersistence.Size = new System.Drawing.Size(85, 19);
			this.chkPersistence.TabIndex = 3;
			this.chkPersistence.Text = "Persistence";
			this.chkPersistence.UseVisualStyleBackColor = true;
			// 
			// chkService
			// 
			this.chkService.AutoSize = true;
			this.chkService.Checked = true;
			this.chkService.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkService.ForeColor = System.Drawing.Color.Black;
			this.chkService.Location = new System.Drawing.Point(176, 22);
			this.chkService.Name = "chkService";
			this.chkService.Size = new System.Drawing.Size(63, 19);
			this.chkService.TabIndex = 2;
			this.chkService.Text = "Service";
			this.chkService.UseVisualStyleBackColor = true;
			// 
			// chkConstructor
			// 
			this.chkConstructor.AutoSize = true;
			this.chkConstructor.Checked = true;
			this.chkConstructor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkConstructor.ForeColor = System.Drawing.Color.Black;
			this.chkConstructor.Location = new System.Drawing.Point(81, 22);
			this.chkConstructor.Name = "chkConstructor";
			this.chkConstructor.Size = new System.Drawing.Size(89, 19);
			this.chkConstructor.TabIndex = 1;
			this.chkConstructor.Text = "Constructor";
			this.chkConstructor.UseVisualStyleBackColor = true;
			// 
			// chkModel
			// 
			this.chkModel.AutoSize = true;
			this.chkModel.Checked = true;
			this.chkModel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkModel.ForeColor = System.Drawing.Color.Black;
			this.chkModel.Location = new System.Drawing.Point(15, 22);
			this.chkModel.Name = "chkModel";
			this.chkModel.Size = new System.Drawing.Size(60, 19);
			this.chkModel.TabIndex = 0;
			this.chkModel.Text = "Model";
			this.chkModel.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtProjectName);
			this.groupBox3.ForeColor = System.Drawing.Color.Navy;
			this.groupBox3.Location = new System.Drawing.Point(358, 562);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(442, 51);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Project Name";
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(6, 22);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(430, 23);
			this.txtProjectName.TabIndex = 0;
			// 
			// FormGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 728);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grpTable);
			this.Controls.Add(this.grpTables);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(828, 767);
			this.Name = "FormGenerator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Code Generator";
			this.Load += new System.EventHandler(this.FormGenerator_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
			this.grpTables.ResumeLayout(false);
			this.grpTables.PerformLayout();
			this.grpTable.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private Label label1;
		private Label label2;
		private MaskedTextBox txtPort;
		private Label label3;
		private TextBox txtUser;
		private TextBox txtPassword;
		private Label label4;
		private TextBox txtName;
		private Label label5;
		private Button btnConnectDisconnect;
		private GroupBox groupBox1;
		private DataGridView dgvTables;
		private DataGridView dgvTable;
		private Button btnGenerate;
		private ComboBox cmbDatabase;
		private Label label6;
		private GroupBox grpTables;
		private GroupBox grpTable;
		private TextBox txtIp;
		private DataGridViewCheckBoxColumn ColChecked;
		private DataGridViewTextBoxColumn ColTable;
		private DataGridViewTextBoxColumn ColClassName;
		private DataGridViewButtonColumn ColSelect;
		private DataGridViewCheckBoxColumn ColConstructor;
		private DataGridViewTextBoxColumn ColName;
		private DataGridViewTextBoxColumn ColType;
		private DataGridViewTextBoxColumn ColPropertyName;
		private GroupBox groupBox2;
		private CheckBox chkModel;
		private CheckBox chkConstructor;
		private CheckBox chkService;
		private CheckBox chkPersistence;
		private CheckBox chkInterfaces;
		private TextBox txtFilterTables;
		private GroupBox groupBox3;
		private TextBox txtProjectName;
	}
}