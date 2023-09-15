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
			this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.grpTables = new System.Windows.Forms.GroupBox();
			this.grpTable = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
			this.grpTables.SuspendLayout();
			this.grpTable.SuspendLayout();
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
			this.groupBox1.Controls.Add(this.txtIp);
			this.groupBox1.Controls.Add(this.cmbDatabase);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btnConnectDisconnect);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPort);
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
			this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTables.Location = new System.Drawing.Point(3, 19);
			this.dgvTables.Name = "dgvTables";
			this.dgvTables.RowHeadersVisible = false;
			this.dgvTables.RowTemplate.Height = 25;
			this.dgvTables.Size = new System.Drawing.Size(334, 446);
			this.dgvTables.TabIndex = 12;
			this.dgvTables.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTables_CellEndEdit);
			this.dgvTables.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTables_CellMouseClick);
			// 
			// ColChecked
			// 
			this.ColChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColChecked.HeaderText = "Generate?";
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
			this.ColTable.Name = "ColTable";
			this.ColTable.ReadOnly = true;
			// 
			// ColClassName
			// 
			this.ColClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			this.ColClassName.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColClassName.HeaderText = "Class Name";
			this.ColClassName.Name = "ColClassName";
			// 
			// ColSelect
			// 
			this.ColSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColSelect.HeaderText = "";
			this.ColSelect.Name = "ColSelect";
			this.ColSelect.Text = "Open";
			this.ColSelect.ToolTipText = "Open";
			this.ColSelect.UseColumnTextForButtonValue = true;
			this.ColSelect.Width = 5;
			// 
			// dgvTable
			// 
			this.dgvTable.AllowUserToAddRows = false;
			this.dgvTable.AllowUserToDeleteRows = false;
			this.dgvTable.AllowUserToResizeRows = false;
			this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
			this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTable.Location = new System.Drawing.Point(3, 19);
			this.dgvTable.Name = "dgvTable";
			this.dgvTable.RowHeadersVisible = false;
			this.dgvTable.RowTemplate.Height = 25;
			this.dgvTable.Size = new System.Drawing.Size(424, 548);
			this.dgvTable.TabIndex = 13;
			this.dgvTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTable_CellEndEdit);
			// 
			// ColName
			// 
			this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			this.ColName.DefaultCellStyle = dataGridViewCellStyle4;
			this.ColName.HeaderText = "Column Name";
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
			this.ColPropertyName.Name = "ColPropertyName";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerate.Location = new System.Drawing.Point(361, 588);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(427, 44);
			this.btnGenerate.TabIndex = 3;
			this.btnGenerate.Text = "Generate Code";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
			// 
			// grpTables
			// 
			this.grpTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpTables.Controls.Add(this.dgvTables);
			this.grpTables.ForeColor = System.Drawing.Color.Navy;
			this.grpTables.Location = new System.Drawing.Point(12, 164);
			this.grpTables.Name = "grpTables";
			this.grpTables.Size = new System.Drawing.Size(340, 468);
			this.grpTables.TabIndex = 1;
			this.grpTables.TabStop = false;
			this.grpTables.Text = "Tables";
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
			this.grpTable.Size = new System.Drawing.Size(430, 570);
			this.grpTable.TabIndex = 2;
			this.grpTable.TabStop = false;
			this.grpTable.Text = "Table";
			// 
			// FormGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 644);
			this.Controls.Add(this.grpTable);
			this.Controls.Add(this.grpTables);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormGenerator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Code Generator";
			this.Load += new System.EventHandler(this.FormGenerator_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
			this.grpTables.ResumeLayout(false);
			this.grpTable.ResumeLayout(false);
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
		private DataGridViewTextBoxColumn ColName;
		private DataGridViewTextBoxColumn ColType;
		private DataGridViewTextBoxColumn ColPropertyName;
	}
}