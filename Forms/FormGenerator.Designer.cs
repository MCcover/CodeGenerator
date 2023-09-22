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
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			label1 = new Label();
			label2 = new Label();
			txtPort = new MaskedTextBox();
			label3 = new Label();
			txtUser = new TextBox();
			txtPassword = new TextBox();
			label4 = new Label();
			txtName = new TextBox();
			label5 = new Label();
			btnConnectDisconnect = new Button();
			groupBox1 = new GroupBox();
			txtIp = new TextBox();
			cmbDatabase = new ComboBox();
			label6 = new Label();
			dgvTables = new DataGridView();
			ColChecked = new DataGridViewCheckBoxColumn();
			ColTable = new DataGridViewTextBoxColumn();
			ColClassName = new DataGridViewTextBoxColumn();
			ColSelect = new DataGridViewButtonColumn();
			dgvTable = new DataGridView();
			ColConstructor = new DataGridViewCheckBoxColumn();
			ColName = new DataGridViewTextBoxColumn();
			ColType = new DataGridViewTextBoxColumn();
			ColPropertyName = new DataGridViewTextBoxColumn();
			btnGenerate = new Button();
			grpTables = new GroupBox();
			grpTable = new GroupBox();
			groupBox2 = new GroupBox();
			chkInterfaces = new CheckBox();
			chkPersistence = new CheckBox();
			chkService = new CheckBox();
			chkConstructor = new CheckBox();
			chkModel = new CheckBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
			grpTables.SuspendLayout();
			grpTable.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Black;
			label1.Location = new Point(304, 48);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(36, 25);
			label1.TabIndex = 1;
			label1.Text = "IP: ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.Black;
			label2.Location = new Point(287, 97);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(53, 25);
			label2.TabIndex = 2;
			label2.Text = "Port: ";
			// 
			// txtPort
			// 
			txtPort.ForeColor = Color.Black;
			txtPort.Location = new Point(333, 92);
			txtPort.Margin = new Padding(4, 5, 4, 5);
			txtPort.Mask = "00000";
			txtPort.Name = "txtPort";
			txtPort.Size = new Size(143, 31);
			txtPort.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = Color.Black;
			label3.Location = new Point(56, 92);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(56, 25);
			label3.TabIndex = 4;
			label3.Text = "User: ";
			// 
			// txtUser
			// 
			txtUser.ForeColor = Color.Black;
			txtUser.Location = new Point(104, 87);
			txtUser.Margin = new Padding(4, 5, 4, 5);
			txtUser.Name = "txtUser";
			txtUser.Size = new Size(141, 31);
			txtUser.TabIndex = 2;
			// 
			// txtPassword
			// 
			txtPassword.ForeColor = Color.Black;
			txtPassword.Location = new Point(104, 135);
			txtPassword.Margin = new Padding(4, 5, 4, 5);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(141, 31);
			txtPassword.TabIndex = 4;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = Color.Black;
			label4.Location = new Point(17, 142);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(96, 25);
			label4.TabIndex = 6;
			label4.Text = "Password: ";
			// 
			// txtName
			// 
			txtName.ForeColor = Color.Black;
			txtName.Location = new Point(333, 135);
			txtName.Margin = new Padding(4, 5, 4, 5);
			txtName.Name = "txtName";
			txtName.Size = new Size(143, 31);
			txtName.TabIndex = 5;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.ForeColor = Color.Black;
			label5.Location = new Point(247, 142);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(96, 25);
			label5.TabIndex = 8;
			label5.Text = "DB Name: ";
			// 
			// btnConnectDisconnect
			// 
			btnConnectDisconnect.ForeColor = Color.Black;
			btnConnectDisconnect.Location = new Point(9, 183);
			btnConnectDisconnect.Margin = new Padding(4, 5, 4, 5);
			btnConnectDisconnect.Name = "btnConnectDisconnect";
			btnConnectDisconnect.Size = new Size(469, 45);
			btnConnectDisconnect.TabIndex = 6;
			btnConnectDisconnect.Text = "Connect Database";
			btnConnectDisconnect.UseVisualStyleBackColor = true;
			btnConnectDisconnect.Click += BtnConnectDisconnect_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(txtPort);
			groupBox1.Controls.Add(txtIp);
			groupBox1.Controls.Add(cmbDatabase);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(btnConnectDisconnect);
			groupBox1.Controls.Add(txtName);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtPassword);
			groupBox1.Controls.Add(txtUser);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label4);
			groupBox1.ForeColor = Color.Navy;
			groupBox1.Location = new Point(17, 20);
			groupBox1.Margin = new Padding(4, 5, 4, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 5, 4, 5);
			groupBox1.Size = new Size(486, 243);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Connection";
			// 
			// txtIp
			// 
			txtIp.ForeColor = Color.Black;
			txtIp.Location = new Point(333, 43);
			txtIp.Margin = new Padding(4, 5, 4, 5);
			txtIp.Name = "txtIp";
			txtIp.Size = new Size(143, 31);
			txtIp.TabIndex = 1;
			// 
			// cmbDatabase
			// 
			cmbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbDatabase.FormattingEnabled = true;
			cmbDatabase.Location = new Point(104, 38);
			cmbDatabase.Margin = new Padding(4, 5, 4, 5);
			cmbDatabase.Name = "cmbDatabase";
			cmbDatabase.Size = new Size(141, 33);
			cmbDatabase.TabIndex = 0;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.ForeColor = Color.Black;
			label6.Location = new Point(20, 43);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(95, 25);
			label6.TabIndex = 11;
			label6.Text = "Database: ";
			// 
			// dgvTables
			// 
			dgvTables.AllowUserToAddRows = false;
			dgvTables.AllowUserToDeleteRows = false;
			dgvTables.AllowUserToResizeRows = false;
			dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTables.Columns.AddRange(new DataGridViewColumn[] { ColChecked, ColTable, ColClassName, ColSelect });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = Color.Navy;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			dgvTables.DefaultCellStyle = dataGridViewCellStyle3;
			dgvTables.Dock = DockStyle.Fill;
			dgvTables.Location = new Point(4, 29);
			dgvTables.Margin = new Padding(4, 5, 4, 5);
			dgvTables.Name = "dgvTables";
			dgvTables.RowHeadersVisible = false;
			dgvTables.RowHeadersWidth = 62;
			dgvTables.RowTemplate.Height = 25;
			dgvTables.Size = new Size(478, 746);
			dgvTables.TabIndex = 12;
			dgvTables.CellEndEdit += DgvTables_CellEndEdit;
			dgvTables.CellMouseClick += DgvTables_CellMouseClick;
			// 
			// ColChecked
			// 
			ColChecked.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColChecked.HeaderText = "Generate?";
			ColChecked.MinimumWidth = 8;
			ColChecked.Name = "ColChecked";
			ColChecked.Width = 96;
			// 
			// ColTable
			// 
			ColTable.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.BackColor = Color.LightGray;
			dataGridViewCellStyle1.ForeColor = Color.Black;
			ColTable.DefaultCellStyle = dataGridViewCellStyle1;
			ColTable.HeaderText = "Table";
			ColTable.MinimumWidth = 8;
			ColTable.Name = "ColTable";
			ColTable.ReadOnly = true;
			// 
			// ColClassName
			// 
			ColClassName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.ForeColor = Color.Black;
			ColClassName.DefaultCellStyle = dataGridViewCellStyle2;
			ColClassName.HeaderText = "Class Name";
			ColClassName.MinimumWidth = 8;
			ColClassName.Name = "ColClassName";
			// 
			// ColSelect
			// 
			ColSelect.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColSelect.HeaderText = "";
			ColSelect.MinimumWidth = 8;
			ColSelect.Name = "ColSelect";
			ColSelect.Text = "Open";
			ColSelect.ToolTipText = "Open";
			ColSelect.UseColumnTextForButtonValue = true;
			ColSelect.Width = 8;
			// 
			// dgvTable
			// 
			dgvTable.AllowUserToAddRows = false;
			dgvTable.AllowUserToDeleteRows = false;
			dgvTable.AllowUserToResizeRows = false;
			dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTable.Columns.AddRange(new DataGridViewColumn[] { ColConstructor, ColName, ColType, ColPropertyName });
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = SystemColors.Window;
			dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle7.ForeColor = Color.Navy;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
			dgvTable.DefaultCellStyle = dataGridViewCellStyle7;
			dgvTable.Dock = DockStyle.Fill;
			dgvTable.Location = new Point(4, 29);
			dgvTable.Margin = new Padding(4, 5, 4, 5);
			dgvTable.Name = "dgvTable";
			dgvTable.RowHeadersVisible = false;
			dgvTable.RowHeadersWidth = 62;
			dgvTable.RowTemplate.Height = 25;
			dgvTable.Size = new Size(606, 828);
			dgvTable.TabIndex = 13;
			dgvTable.CellEndEdit += DgvTable_CellEndEdit;
			// 
			// ColConstructor
			// 
			ColConstructor.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColConstructor.HeaderText = ".Constructor?";
			ColConstructor.MinimumWidth = 8;
			ColConstructor.Name = "ColConstructor";
			ColConstructor.Width = 123;
			// 
			// ColName
			// 
			ColName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.BackColor = Color.LightGray;
			dataGridViewCellStyle4.ForeColor = Color.Black;
			ColName.DefaultCellStyle = dataGridViewCellStyle4;
			ColName.HeaderText = "Column Name";
			ColName.MinimumWidth = 8;
			ColName.Name = "ColName";
			ColName.ReadOnly = true;
			// 
			// ColType
			// 
			ColType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle5.BackColor = Color.LightGray;
			dataGridViewCellStyle5.ForeColor = Color.Black;
			ColType.DefaultCellStyle = dataGridViewCellStyle5;
			ColType.HeaderText = "Type";
			ColType.MinimumWidth = 8;
			ColType.Name = "ColType";
			ColType.ReadOnly = true;
			ColType.Width = 85;
			// 
			// ColPropertyName
			// 
			ColPropertyName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle6.ForeColor = Color.Black;
			ColPropertyName.DefaultCellStyle = dataGridViewCellStyle6;
			ColPropertyName.HeaderText = "Property Name";
			ColPropertyName.MinimumWidth = 8;
			ColPropertyName.Name = "ColPropertyName";
			// 
			// btnGenerate
			// 
			btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnGenerate.Location = new Point(516, 980);
			btnGenerate.Margin = new Padding(4, 5, 4, 5);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(610, 73);
			btnGenerate.TabIndex = 3;
			btnGenerate.Text = "Generate Code";
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += BtnGenerate_Click;
			// 
			// grpTables
			// 
			grpTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			grpTables.Controls.Add(dgvTables);
			grpTables.ForeColor = Color.Navy;
			grpTables.Location = new Point(17, 273);
			grpTables.Margin = new Padding(4, 5, 4, 5);
			grpTables.Name = "grpTables";
			grpTables.Padding = new Padding(4, 5, 4, 5);
			grpTables.Size = new Size(486, 780);
			grpTables.TabIndex = 1;
			grpTables.TabStop = false;
			grpTables.Text = "Tables";
			// 
			// grpTable
			// 
			grpTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpTable.Controls.Add(dgvTable);
			grpTable.ForeColor = Color.Navy;
			grpTable.Location = new Point(511, 20);
			grpTable.Margin = new Padding(4, 5, 4, 5);
			grpTable.Name = "grpTable";
			grpTable.Padding = new Padding(4, 5, 4, 5);
			grpTable.Size = new Size(614, 862);
			grpTable.TabIndex = 2;
			grpTable.TabStop = false;
			grpTable.Text = "Table";
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(chkInterfaces);
			groupBox2.Controls.Add(chkPersistence);
			groupBox2.Controls.Add(chkService);
			groupBox2.Controls.Add(chkConstructor);
			groupBox2.Controls.Add(chkModel);
			groupBox2.ForeColor = Color.Navy;
			groupBox2.Location = new Point(516, 892);
			groupBox2.Margin = new Padding(4, 5, 4, 5);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 5, 4, 5);
			groupBox2.Size = new Size(610, 78);
			groupBox2.TabIndex = 4;
			groupBox2.TabStop = false;
			groupBox2.Text = "Files";
			// 
			// chkInterfaces
			// 
			chkInterfaces.AutoSize = true;
			chkInterfaces.ForeColor = Color.Black;
			chkInterfaces.Location = new Point(480, 37);
			chkInterfaces.Margin = new Padding(4, 5, 4, 5);
			chkInterfaces.Name = "chkInterfaces";
			chkInterfaces.Size = new Size(114, 29);
			chkInterfaces.TabIndex = 4;
			chkInterfaces.Text = "Interfaces";
			chkInterfaces.UseVisualStyleBackColor = true;
			// 
			// chkPersistence
			// 
			chkPersistence.AutoSize = true;
			chkPersistence.Checked = true;
			chkPersistence.CheckState = CheckState.Checked;
			chkPersistence.ForeColor = Color.Black;
			chkPersistence.Location = new Point(350, 37);
			chkPersistence.Margin = new Padding(4, 5, 4, 5);
			chkPersistence.Name = "chkPersistence";
			chkPersistence.Size = new Size(124, 29);
			chkPersistence.TabIndex = 3;
			chkPersistence.Text = "Persistence";
			chkPersistence.UseVisualStyleBackColor = true;
			// 
			// chkService
			// 
			chkService.AutoSize = true;
			chkService.Checked = true;
			chkService.CheckState = CheckState.Checked;
			chkService.ForeColor = Color.Black;
			chkService.Location = new Point(251, 37);
			chkService.Margin = new Padding(4, 5, 4, 5);
			chkService.Name = "chkService";
			chkService.Size = new Size(93, 29);
			chkService.TabIndex = 2;
			chkService.Text = "Service";
			chkService.UseVisualStyleBackColor = true;
			// 
			// chkConstructor
			// 
			chkConstructor.AutoSize = true;
			chkConstructor.Checked = true;
			chkConstructor.CheckState = CheckState.Checked;
			chkConstructor.ForeColor = Color.Black;
			chkConstructor.Location = new Point(116, 37);
			chkConstructor.Margin = new Padding(4, 5, 4, 5);
			chkConstructor.Name = "chkConstructor";
			chkConstructor.Size = new Size(131, 29);
			chkConstructor.TabIndex = 1;
			chkConstructor.Text = "Constructor";
			chkConstructor.UseVisualStyleBackColor = true;
			// 
			// chkModel
			// 
			chkModel.AutoSize = true;
			chkModel.Checked = true;
			chkModel.CheckState = CheckState.Checked;
			chkModel.ForeColor = Color.Black;
			chkModel.Location = new Point(21, 37);
			chkModel.Margin = new Padding(4, 5, 4, 5);
			chkModel.Name = "chkModel";
			chkModel.Size = new Size(89, 29);
			chkModel.TabIndex = 0;
			chkModel.Text = "Model";
			chkModel.UseVisualStyleBackColor = true;
			// 
			// FormGenerator
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1143, 1073);
			Controls.Add(groupBox2);
			Controls.Add(grpTable);
			Controls.Add(grpTables);
			Controls.Add(btnGenerate);
			Controls.Add(groupBox1);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FormGenerator";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Code Generator";
			Load += FormGenerator_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
			grpTables.ResumeLayout(false);
			grpTable.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
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
	}
}