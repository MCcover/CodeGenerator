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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerator));
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
			txtFilterTables = new TextBox();
			grpTable = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox5 = new GroupBox();
			cmbLenguageFrontend = new ComboBox();
			label8 = new Label();
			chkModelFront = new CheckBox();
			groupBox4 = new GroupBox();
			cmbLenguageBackend = new ComboBox();
			label7 = new Label();
			chkModelBack = new CheckBox();
			chkInterfacesBack = new CheckBox();
			chkConstructorBack = new CheckBox();
			chkPersistenceBack = new CheckBox();
			chkServiceBack = new CheckBox();
			groupBox3 = new GroupBox();
			txtProjectName = new TextBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
			grpTables.SuspendLayout();
			grpTable.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Black;
			label1.Location = new Point(213, 29);
			label1.Name = "label1";
			label1.Size = new Size(23, 15);
			label1.TabIndex = 1;
			label1.Text = "IP: ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.Black;
			label2.Location = new Point(201, 58);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.TabIndex = 2;
			label2.Text = "Port: ";
			// 
			// txtPort
			// 
			txtPort.ForeColor = Color.Black;
			txtPort.Location = new Point(233, 55);
			txtPort.Mask = "00000";
			txtPort.Name = "txtPort";
			txtPort.Size = new Size(101, 23);
			txtPort.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = Color.Black;
			label3.Location = new Point(39, 55);
			label3.Name = "label3";
			label3.Size = new Size(36, 15);
			label3.TabIndex = 4;
			label3.Text = "User: ";
			// 
			// txtUser
			// 
			txtUser.ForeColor = Color.Black;
			txtUser.Location = new Point(73, 52);
			txtUser.Name = "txtUser";
			txtUser.Size = new Size(100, 23);
			txtUser.TabIndex = 2;
			// 
			// txtPassword
			// 
			txtPassword.ForeColor = Color.Black;
			txtPassword.Location = new Point(73, 81);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(100, 23);
			txtPassword.TabIndex = 4;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = Color.Black;
			label4.Location = new Point(12, 85);
			label4.Name = "label4";
			label4.Size = new Size(63, 15);
			label4.TabIndex = 6;
			label4.Text = "Password: ";
			// 
			// txtName
			// 
			txtName.ForeColor = Color.Black;
			txtName.Location = new Point(233, 81);
			txtName.Name = "txtName";
			txtName.Size = new Size(101, 23);
			txtName.TabIndex = 5;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.ForeColor = Color.Black;
			label5.Location = new Point(173, 85);
			label5.Name = "label5";
			label5.Size = new Size(63, 15);
			label5.TabIndex = 8;
			label5.Text = "DB Name: ";
			// 
			// btnConnectDisconnect
			// 
			btnConnectDisconnect.ForeColor = Color.Black;
			btnConnectDisconnect.Location = new Point(6, 110);
			btnConnectDisconnect.Name = "btnConnectDisconnect";
			btnConnectDisconnect.Size = new Size(328, 27);
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
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(340, 146);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Connection";
			// 
			// txtIp
			// 
			txtIp.ForeColor = Color.Black;
			txtIp.Location = new Point(233, 26);
			txtIp.Name = "txtIp";
			txtIp.Size = new Size(101, 23);
			txtIp.TabIndex = 1;
			// 
			// cmbDatabase
			// 
			cmbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbDatabase.FormattingEnabled = true;
			cmbDatabase.Location = new Point(73, 23);
			cmbDatabase.Name = "cmbDatabase";
			cmbDatabase.Size = new Size(100, 23);
			cmbDatabase.TabIndex = 0;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.ForeColor = Color.Black;
			label6.Location = new Point(14, 26);
			label6.Name = "label6";
			label6.Size = new Size(61, 15);
			label6.TabIndex = 11;
			label6.Text = "Database: ";
			// 
			// dgvTables
			// 
			dgvTables.AllowUserToAddRows = false;
			dgvTables.AllowUserToDeleteRows = false;
			dgvTables.AllowUserToResizeRows = false;
			dgvTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
			dgvTables.Location = new Point(6, 51);
			dgvTables.Name = "dgvTables";
			dgvTables.RowHeadersVisible = false;
			dgvTables.RowHeadersWidth = 62;
			dgvTables.RowTemplate.Height = 25;
			dgvTables.Size = new Size(328, 551);
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
			ColChecked.Width = 65;
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
			dgvTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
			dgvTable.Location = new Point(6, 22);
			dgvTable.Name = "dgvTable";
			dgvTable.RowHeadersVisible = false;
			dgvTable.RowHeadersWidth = 62;
			dgvTable.RowTemplate.Height = 25;
			dgvTable.Size = new Size(430, 464);
			dgvTable.TabIndex = 13;
			dgvTable.CellEndEdit += DgvTable_CellEndEdit;
			// 
			// ColConstructor
			// 
			ColConstructor.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColConstructor.HeaderText = ".Constructor?";
			ColConstructor.MinimumWidth = 8;
			ColConstructor.Name = "ColConstructor";
			ColConstructor.Width = 84;
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
			ColType.Width = 56;
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
			btnGenerate.Location = new Point(361, 728);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(439, 44);
			btnGenerate.TabIndex = 3;
			btnGenerate.Text = "Generate Code";
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += BtnGenerate_Click;
			// 
			// grpTables
			// 
			grpTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			grpTables.Controls.Add(txtFilterTables);
			grpTables.Controls.Add(dgvTables);
			grpTables.ForeColor = Color.Navy;
			grpTables.Location = new Point(12, 164);
			grpTables.Name = "grpTables";
			grpTables.Size = new Size(340, 608);
			grpTables.TabIndex = 1;
			grpTables.TabStop = false;
			grpTables.Text = "Tables";
			// 
			// txtFilterTables
			// 
			txtFilterTables.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtFilterTables.Location = new Point(6, 22);
			txtFilterTables.Name = "txtFilterTables";
			txtFilterTables.Size = new Size(328, 23);
			txtFilterTables.TabIndex = 13;
			txtFilterTables.TextChanged += TxtFilterTables_TextChanged;
			// 
			// grpTable
			// 
			grpTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpTable.Controls.Add(dgvTable);
			grpTable.ForeColor = Color.Navy;
			grpTable.Location = new Point(358, 12);
			grpTable.Name = "grpTable";
			grpTable.Size = new Size(442, 492);
			grpTable.TabIndex = 2;
			grpTable.TabStop = false;
			grpTable.Text = "Table";
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(groupBox5);
			groupBox2.Controls.Add(groupBox4);
			groupBox2.ForeColor = Color.Navy;
			groupBox2.Location = new Point(361, 567);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(439, 155);
			groupBox2.TabIndex = 4;
			groupBox2.TabStop = false;
			groupBox2.Text = "Files";
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(cmbLenguageFrontend);
			groupBox5.Controls.Add(label8);
			groupBox5.Controls.Add(chkModelFront);
			groupBox5.Location = new Point(221, 22);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(212, 127);
			groupBox5.TabIndex = 6;
			groupBox5.TabStop = false;
			groupBox5.Text = "Frontend";
			// 
			// cmbLenguageFrontend
			// 
			cmbLenguageFrontend.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbLenguageFrontend.FormattingEnabled = true;
			cmbLenguageFrontend.Location = new Point(70, 16);
			cmbLenguageFrontend.Name = "cmbLenguageFrontend";
			cmbLenguageFrontend.Size = new Size(136, 23);
			cmbLenguageFrontend.TabIndex = 8;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.ForeColor = Color.Black;
			label8.Location = new Point(9, 19);
			label8.Name = "label8";
			label8.Size = new Size(65, 15);
			label8.TabIndex = 7;
			label8.Text = "Lenguage: ";
			// 
			// chkModelFront
			// 
			chkModelFront.AutoSize = true;
			chkModelFront.Checked = true;
			chkModelFront.CheckState = CheckState.Checked;
			chkModelFront.ForeColor = Color.Black;
			chkModelFront.Location = new Point(70, 65);
			chkModelFront.Name = "chkModelFront";
			chkModelFront.Size = new Size(60, 19);
			chkModelFront.TabIndex = 1;
			chkModelFront.Text = "Model";
			chkModelFront.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(cmbLenguageBackend);
			groupBox4.Controls.Add(label7);
			groupBox4.Controls.Add(chkModelBack);
			groupBox4.Controls.Add(chkInterfacesBack);
			groupBox4.Controls.Add(chkConstructorBack);
			groupBox4.Controls.Add(chkPersistenceBack);
			groupBox4.Controls.Add(chkServiceBack);
			groupBox4.ForeColor = Color.Navy;
			groupBox4.Location = new Point(6, 22);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(209, 125);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Backend";
			// 
			// cmbLenguageBackend
			// 
			cmbLenguageBackend.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbLenguageBackend.FormattingEnabled = true;
			cmbLenguageBackend.Location = new Point(67, 21);
			cmbLenguageBackend.Name = "cmbLenguageBackend";
			cmbLenguageBackend.Size = new Size(136, 23);
			cmbLenguageBackend.TabIndex = 6;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.ForeColor = Color.Black;
			label7.Location = new Point(6, 24);
			label7.Name = "label7";
			label7.Size = new Size(65, 15);
			label7.TabIndex = 5;
			label7.Text = "Lenguage: ";
			// 
			// chkModelBack
			// 
			chkModelBack.AutoSize = true;
			chkModelBack.Checked = true;
			chkModelBack.CheckState = CheckState.Checked;
			chkModelBack.ForeColor = Color.Black;
			chkModelBack.Location = new Point(25, 50);
			chkModelBack.Name = "chkModelBack";
			chkModelBack.Size = new Size(60, 19);
			chkModelBack.TabIndex = 0;
			chkModelBack.Text = "Model";
			chkModelBack.UseVisualStyleBackColor = true;
			// 
			// chkInterfacesBack
			// 
			chkInterfacesBack.AutoSize = true;
			chkInterfacesBack.ForeColor = Color.Black;
			chkInterfacesBack.Location = new Point(56, 100);
			chkInterfacesBack.Name = "chkInterfacesBack";
			chkInterfacesBack.Size = new Size(77, 19);
			chkInterfacesBack.TabIndex = 4;
			chkInterfacesBack.Text = "Interfaces";
			chkInterfacesBack.UseVisualStyleBackColor = true;
			// 
			// chkConstructorBack
			// 
			chkConstructorBack.AutoSize = true;
			chkConstructorBack.Checked = true;
			chkConstructorBack.CheckState = CheckState.Checked;
			chkConstructorBack.ForeColor = Color.Black;
			chkConstructorBack.Location = new Point(98, 50);
			chkConstructorBack.Name = "chkConstructorBack";
			chkConstructorBack.Size = new Size(89, 19);
			chkConstructorBack.TabIndex = 1;
			chkConstructorBack.Text = "Constructor";
			chkConstructorBack.UseVisualStyleBackColor = true;
			// 
			// chkPersistenceBack
			// 
			chkPersistenceBack.AutoSize = true;
			chkPersistenceBack.Checked = true;
			chkPersistenceBack.CheckState = CheckState.Checked;
			chkPersistenceBack.ForeColor = Color.Black;
			chkPersistenceBack.Location = new Point(98, 75);
			chkPersistenceBack.Name = "chkPersistenceBack";
			chkPersistenceBack.Size = new Size(85, 19);
			chkPersistenceBack.TabIndex = 3;
			chkPersistenceBack.Text = "Persistence";
			chkPersistenceBack.UseVisualStyleBackColor = true;
			// 
			// chkServiceBack
			// 
			chkServiceBack.AutoSize = true;
			chkServiceBack.Checked = true;
			chkServiceBack.CheckState = CheckState.Checked;
			chkServiceBack.ForeColor = Color.Black;
			chkServiceBack.Location = new Point(25, 75);
			chkServiceBack.Name = "chkServiceBack";
			chkServiceBack.Size = new Size(63, 19);
			chkServiceBack.TabIndex = 2;
			chkServiceBack.Text = "Service";
			chkServiceBack.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox3.Controls.Add(txtProjectName);
			groupBox3.ForeColor = Color.Navy;
			groupBox3.Location = new Point(358, 510);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(442, 51);
			groupBox3.TabIndex = 5;
			groupBox3.TabStop = false;
			groupBox3.Text = "Project Name";
			// 
			// txtProjectName
			// 
			txtProjectName.Location = new Point(6, 22);
			txtProjectName.Name = "txtProjectName";
			txtProjectName.Size = new Size(430, 23);
			txtProjectName.TabIndex = 0;
			// 
			// FormGenerator
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(812, 784);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(grpTable);
			Controls.Add(grpTables);
			Controls.Add(btnGenerate);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(828, 767);
			Name = "FormGenerator";
			StartPosition = FormStartPosition.CenterScreen;
			Load += FormGenerator_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
			grpTables.ResumeLayout(false);
			grpTables.PerformLayout();
			grpTable.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
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
		private CheckBox chkModelBack;
		private CheckBox chkConstructorBack;
		private CheckBox chkServiceBack;
		private CheckBox chkPersistenceBack;
		private CheckBox chkInterfacesBack;
		private TextBox txtFilterTables;
		private GroupBox groupBox3;
		private TextBox txtProjectName;
		private GroupBox groupBox5;
		private CheckBox chkModelFront;
		private GroupBox groupBox4;
		private ComboBox cmbLenguageFrontend;
		private Label label8;
		private ComboBox cmbLenguageBackend;
		private Label label7;
	}
}