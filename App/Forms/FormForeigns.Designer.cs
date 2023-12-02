namespace CodeGenerator.Forms {
	partial class FormForeigns {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			btnAccept = new Button();
			dgvForeigns = new DataGridView();
			ColTable = new DataGridViewTextBoxColumn();
			ColColumn = new DataGridViewTextBoxColumn();
			ColClassName = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvForeigns).BeginInit();
			SuspendLayout();
			// 
			// btnAccept
			// 
			btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnAccept.Location = new Point(361, 364);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(108, 45);
			btnAccept.TabIndex = 0;
			btnAccept.Text = "Accept";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += BtnAccept_Click;
			// 
			// dgvForeigns
			// 
			dgvForeigns.AllowUserToAddRows = false;
			dgvForeigns.AllowUserToDeleteRows = false;
			dgvForeigns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvForeigns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvForeigns.Columns.AddRange(new DataGridViewColumn[] { ColTable, ColColumn, ColClassName });
			dgvForeigns.Location = new Point(12, 12);
			dgvForeigns.Name = "dgvForeigns";
			dgvForeigns.RowHeadersVisible = false;
			dgvForeigns.RowTemplate.Height = 25;
			dgvForeigns.Size = new Size(457, 346);
			dgvForeigns.TabIndex = 1;
			// 
			// ColTable
			// 
			ColTable.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColTable.HeaderText = "Table";
			ColTable.Name = "ColTable";
			ColTable.ReadOnly = true;
			ColTable.Width = 59;
			// 
			// ColColumn
			// 
			ColColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ColColumn.HeaderText = "Column";
			ColColumn.Name = "ColColumn";
			ColColumn.ReadOnly = true;
			ColColumn.Width = 75;
			// 
			// ColClassName
			// 
			ColClassName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColClassName.HeaderText = "ClassName";
			ColClassName.Name = "ColClassName";
			// 
			// FormForeigns
			// 
			AcceptButton = btnAccept;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnAccept;
			ClientSize = new Size(481, 421);
			Controls.Add(dgvForeigns);
			Controls.Add(btnAccept);
			Name = "FormForeigns";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Set Foreigns Data";
			Load += FormForeigns_Load;
			((System.ComponentModel.ISupportInitialize)dgvForeigns).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnAccept;
		private DataGridView dgvForeigns;
		private DataGridViewTextBoxColumn ColTable;
		private DataGridViewTextBoxColumn ColColumn;
		private DataGridViewTextBoxColumn ColClassName;
	}
}