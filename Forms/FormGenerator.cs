using CodeGenerator.DatabaseConnectors.Connectors;
using CodeGenerator.Generators;
using CodeGenerator.Generators.Interfaces;
using CodeGenerator.Model;
using CodeGenerator.Model.Enums;
using CodeGenerator.Model.Table;
using System.Text.RegularExpressions;
using System;
using CodeGenerator.MethodsOfExtensions;

namespace CodeGenerator.Forms {

	public partial class FormGenerator : Form {
		private ConnectionState ConnectionState { get; set; } = ConnectionState.Disconnected;

		public FormGenerator() => InitializeComponent();

		private void FormGenerator_Load(object sender, EventArgs e) {
			cmbDatabase.DataSource = Enum.GetValues(typeof(Database));
		}

		private async void BtnConnectDisconnect_Click(object sender, EventArgs e) {
			try {
				if (ConnectionState == ConnectionState.Connected) {
					DatabaseConnector.Instance.DisposeConnector();
					ConnectionState = ConnectionState.Disconnected;
				} else {
					(ConnectionInfo connectionInfo, Database database) = CreateConnectionInfo();

					DatabaseConnector.Instance.CreateConnector(connectionInfo, database).Connect();

					ConnectionState = ConnectionState.Connected;
				}

				btnConnectDisconnect.Text = ConnectionState == ConnectionState.Connected ? "Disconnect Database" : "Connect Database";

				await ShowTables();
			} catch (Exception ex) {
				DatabaseConnector.Instance.DisposeConnector();

				MessageBox.Show(this, ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnGenerate_Click(object sender, EventArgs e) {
			try {
				IGenerator? generator = Generator.SelectGenerator(GetSelectedDatabase());

				List<Table> tables = GetTablesToGenerate();

				generator?.Generate(tables);
			} catch (Exception ex) {
				MessageBox.Show(this, ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void DgvTables_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.RowIndex < 0 || e.ColumnIndex == ColTable.Index) {
				return;
			}

			if (e.ColumnIndex == ColChecked.Index || e.ColumnIndex == ColSelect.Index) {
				var row = dgvTables.Rows[e.RowIndex];
				row.Cells[ColChecked.Index].Value = true;

				var table = row.Cells[ColTable.Index].Value?.ToString();

				var columns = await ShowColumns(table);

				row.Tag = columns;
			}
		}

		private void DgvTables_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex != ColClassName.Index) {
				return;
			}

			var row = dgvTable.Rows[e.RowIndex];

			if (row.Tag != null) {
				var newClassName = row.Cells[ColClassName.Index].Value?.ToString();

				((Table)row.Tag).ClassName = newClassName;
			}
		}

		private void DgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex != ColPropertyName.Index) {
				return;
			}
		}

		private (ConnectionInfo connectionInfo, Database database) CreateConnectionInfo() {
			var ip = txtIp.Text;
			var port = Convert.ToInt32(txtPort.Text);
			var databaseName = txtName.Text;
			var databaseUser = txtUser.Text;
			var databasePassword = txtPassword.Text;

			Database database = GetSelectedDatabase();

			var connectionInfo = new ConnectionInfo(ip, port, databaseName, databaseUser, databasePassword);

			return (connectionInfo, database);
		}

		private Database GetSelectedDatabase() {
			Enum.TryParse(cmbDatabase.SelectedValue?.ToString(), out Database database);
			return database;
		}

		private async Task ShowTables() {
			Cursor = Cursors.WaitCursor;

			var tables = await DatabaseConnector.Instance.Connector.Persistance.GetTables();

			var rows = new List<DataGridViewRow>();

			foreach (var table in tables) {
				var row = new DataGridViewRow();
				row.CreateCells(dgvTables);

				row.Cells[ColChecked.Index].Value = false;
				row.Cells[ColTable.Index].Value = table.Name;

				row.Cells[ColClassName.Index].Value = table.Name.RemoveSpecialCharactersAndFormatText('_');

				row.Tag = table;

				rows.Add(row);
			}

			dgvTables.Rows.AddRange(rows.ToArray());

			Cursor = Cursors.Default;
		}

		private async Task<List<Column>> ShowColumns(string table) {
			var columns = await DatabaseConnector.Instance.Connector.Persistance.GetColumns(table);

			var rows = new List<DataGridViewRow>();

			foreach (var column in columns) {
				var row = new DataGridViewRow();
				row.CreateCells(dgvTable);

				row.Cells[ColName.Index].Value = column.Name;
				row.Cells[ColType.Index].Value = column.DataType;

				row.Cells[ColPropertyName.Index].Value = column.Name.RemoveSpecialCharactersAndFormatText('_');

				rows.Add(row);
			}

			dgvTable.Rows.AddRange(rows.ToArray());

			return columns;
		}

		private List<Table> GetTablesToGenerate() {
			throw new NotImplementedException();
		}
	}
}