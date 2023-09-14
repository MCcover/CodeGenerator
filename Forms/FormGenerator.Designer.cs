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
			dgvTable = new DataGridView();
			btnGenerate = new Button();
			grpTables = new GroupBox();
			grpTable = new GroupBox();
			ColChecked = new DataGridViewTextBoxColumn();
			ColTable = new DataGridViewTextBoxColumn();
			ColClassName = new DataGridViewTextBoxColumn();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
			grpTables.SuspendLayout();
			grpTable.SuspendLayout();
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
			groupBox1.Controls.Add(txtIp);
			groupBox1.Controls.Add(cmbDatabase);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(btnConnectDisconnect);
			groupBox1.Controls.Add(txtName);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtPort);
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
			dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTables.Columns.AddRange(new DataGridViewColumn[] { ColChecked, ColTable, ColClassName });
			dgvTables.Dock = DockStyle.Fill;
			dgvTables.Location = new Point(3, 19);
			dgvTables.Name = "dgvTables";
			dgvTables.RowHeadersVisible = false;
			dgvTables.RowTemplate.Height = 25;
			dgvTables.Size = new Size(334, 446);
			dgvTables.TabIndex = 12;
			// 
			// dgvTable
			// 
			dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTable.Dock = DockStyle.Fill;
			dgvTable.Location = new Point(3, 19);
			dgvTable.Name = "dgvTable";
			dgvTable.RowTemplate.Height = 25;
			dgvTable.Size = new Size(424, 548);
			dgvTable.TabIndex = 13;
			// 
			// btnGenerate
			// 
			btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnGenerate.Location = new Point(361, 588);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(427, 44);
			btnGenerate.TabIndex = 3;
			btnGenerate.Text = "Generate Code";
			btnGenerate.UseVisualStyleBackColor = true;
			// 
			// grpTables
			// 
			grpTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			grpTables.Controls.Add(dgvTables);
			grpTables.ForeColor = Color.Navy;
			grpTables.Location = new Point(12, 164);
			grpTables.Name = "grpTables";
			grpTables.Size = new Size(340, 468);
			grpTables.TabIndex = 1;
			grpTables.TabStop = false;
			grpTables.Text = "Tables";
			// 
			// grpTable
			// 
			grpTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpTable.Controls.Add(dgvTable);
			grpTable.ForeColor = Color.Navy;
			grpTable.Location = new Point(358, 12);
			grpTable.Name = "grpTable";
			grpTable.Size = new Size(430, 570);
			grpTable.TabIndex = 2;
			grpTable.TabStop = false;
			grpTable.Text = "Table";
			// 
			// ColChecked
			// 
			ColChecked.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColChecked.HeaderText = "Genera";
			ColChecked.Name = "ColChecked";
			ColChecked.Width = 69;
			// 
			// ColTable
			// 
			ColTable.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColTable.HeaderText = "Table";
			ColTable.Name = "ColTable";
			ColTable.ReadOnly = true;
			// 
			// ColClassName
			// 
			ColClassName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColClassName.HeaderText = "Class Name";
			ColClassName.Name = "ColClassName";
			ColClassName.Width = 94;
			// 
			// FormGenerator
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 644);
			Controls.Add(grpTable);
			Controls.Add(grpTables);
			Controls.Add(btnGenerate);
			Controls.Add(groupBox1);
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
		private DataGridViewTextBoxColumn ColChecked;
		private DataGridViewTextBoxColumn ColTable;
		private DataGridViewTextBoxColumn ColClassName;
	}
}