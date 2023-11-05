using DatabaseConnectors.Connectors;
using Domain.Model;
using Domain.Model.Table;
using Generators.GeneratorsOfCode;
using Generators.Model.Backend;
using Generators.Model.Frontend;
using Generators.Model.Generator;
using System.Reflection;
using Utils;
using Utils.Enums.Lenguages;
using Utils.Model.Enums;

namespace CodeGenerator.Forms {

	public partial class FormGenerator : Form {

		#region Attributes

		private List<Table> _Tables = new();
		private int _SelectedTable = -1;

		private ConnectionState ConnectionState { get; set; } = ConnectionState.Disconnected;

		#endregion

		#region Constructors

		public FormGenerator() => InitializeComponent();

		#endregion

		#region Events

		private void FormGenerator_Load(object sender, EventArgs e) {
			cmbDatabase.DataSource = Enum.GetValues(typeof(Database));

			var valuesBackend = EnumHelper.GetValuesAttributes<LenguagesBackend>();
			cmbLenguageBackend.DataSource = valuesBackend;
			cmbLenguageBackend.ValueMember = "Value";
			cmbLenguageBackend.DisplayMember = "Value";

			var valuesFrontend = EnumHelper.GetValuesAttributes<LenguagesFrontend>();
			cmbLenguageFrontend.DataSource = valuesFrontend;
			cmbLenguageFrontend.ValueMember = "Value";
			cmbLenguageFrontend.DisplayMember = "Value";

			var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			version = version[..version.LastIndexOf(".")];

			Text = "Code Generator V" + version;

		}

		private async void BtnConnectDisconnect_Click(object sender, EventArgs e) {
			try {
				CleanTables();

				if (ConnectionState == ConnectionState.Connected) {
					DatabaseConnector.Instance.DisposeConnector();
					ConnectionState = ConnectionState.Disconnected;
				} else {
					(ConnectionInfo connectionInfo, Database database) = CreateConnectionInfo();

					DatabaseConnector.Instance.CreateConnector(connectionInfo, database).Connect();

					ConnectionState = ConnectionState.Connected;

					await ShowTables();
				}

				EnableDisableControls(ConnectionState);

				btnConnectDisconnect.Text = ConnectionState == ConnectionState.Connected ? "Disconnect Database" : "Connect Database";
			} catch (Exception ex) {

				try {
					DatabaseConnector.Instance.DisposeConnector();
				} catch {
				}

				MessageBox.Show(this, ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void BtnGenerate_Click(object sender, EventArgs e) {

			if (!chkModelBack.Checked &&
				!chkConstructorBack.Checked &&
				!chkServiceBack.Checked &&
				!chkPersistenceBack.Checked &&
				!chkInterfacesBack.Checked &&
				!chkModelFront.Checked) {
				MessageBox.Show(this, "Select at least one file to generate.", "WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((!chkModelBack.Checked ||
				!chkConstructorBack.Checked ||
				!chkServiceBack.Checked ||
				!chkPersistenceBack.Checked ||
				!chkInterfacesBack.Checked) &&
				txtProjectName.Text.Trim() == string.Empty) {
				MessageBox.Show(this, "If you select generate backend you must indicate project name.", "WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try {
				var projectName = txtProjectName.Text;
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				List<Table> tables = GetTablesToGenerate();

				BackendInfo backendInfo = new(GetSelectedDatabase(),
											  GetSelectedLenguageBackend(),
											  projectName,
											  chkModelBack.Checked,
											  chkConstructorBack.Checked,
											  chkServiceBack.Checked,
											  chkPersistenceBack.Checked,
											  chkInterfacesBack.Checked);

				FrontendInfo frontendInfo = new(GetSelectedLenguageFrontend(), chkModelFront.Checked);


				GeneratorInfo info = new(tables, path, frontendInfo, backendInfo);

				Generator.Instance.Generate(info);

				MessageBox.Show(this, "Code Generated.", "SUCCESS!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

				_Tables[e.RowIndex].Columns = columns;

				_SelectedTable = e.RowIndex;
			}
		}

		private void DgvTables_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex != ColClassName.Index) {
				return;
			}

			var row = dgvTables.Rows[e.RowIndex];

			var newClassName = row.Cells[ColClassName.Index].Value?.ToString();

			_Tables[e.RowIndex].ClassName = newClassName;
		}

		private void DgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == ColPropertyName.Index) {
				var propertyName = dgvTable.Rows[e.RowIndex].Cells[ColPropertyName.Index].Value?.ToString();

				_Tables[_SelectedTable].Columns[e.RowIndex].Name = propertyName;
			}

			if (e.ColumnIndex == ColConstructor.Index) {
				var inConstructor = (bool?)dgvTable.Rows[e.RowIndex].Cells[ColConstructor.Index].Value;

				_Tables[_SelectedTable].Columns[e.RowIndex].InConstructor = inConstructor ?? false;

			}

		}

		private void TxtFilterTables_TextChanged(object sender, EventArgs e) {
			string filter = txtFilterTables.Text.ToLower();

			foreach (DataGridViewRow row in dgvTables.Rows) {
				if (row.Index == dgvTables.NewRowIndex ||
					row.Cells[ColTable.Index].Value == null) {
					continue;
				}

				string name = row.Cells[ColTable.Index].Value.ToString().ToLower();

				row.Visible = name.Contains(filter);

			}
		}

		#endregion

		#region Privates

		private (ConnectionInfo connectionInfo, Database database) CreateConnectionInfo() {
			var ip = txtIp.Text;
			int.TryParse(txtPort.Text, out int port);
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

		private LenguagesBackend GetSelectedLenguageBackend() {
			Enum.TryParse(cmbLenguageBackend.SelectedValue?.ToString(), out LenguagesBackend lenguage);
			return lenguage;
		}

		private LenguagesFrontend GetSelectedLenguageFrontend() {
			Enum.TryParse(cmbLenguageFrontend.SelectedValue?.ToString(), out LenguagesFrontend lenguage);
			return lenguage;
		}

		private void CleanTables() {
			dgvTables.Rows.Clear();
			dgvTable.Rows.Clear();
		}

		private async Task ShowTables() {

			Cursor = Cursors.WaitCursor;

			_Tables = await DatabaseConnector.Instance.Connector.Persistance.GetTables();

			var rows = new List<DataGridViewRow>();

			foreach (var table in _Tables) {
				var row = new DataGridViewRow();
				row.CreateCells(dgvTables);

				row.Cells[ColChecked.Index].Value = false;
				row.Cells[ColTable.Index].Value = table.Name;

				row.Cells[ColClassName.Index].Value = table.ClassName;

				rows.Add(row);
			}

			dgvTables.Rows.AddRange(rows.ToArray());

			Cursor = Cursors.Default;
		}

		private async Task<List<Column>> ShowColumns(string table) {
			dgvTable.Rows.Clear();

			var columns = await DatabaseConnector.Instance.Connector.Persistance.GetColumns(table);

			var rows = new List<DataGridViewRow>();

			foreach (var column in columns) {
				var row = new DataGridViewRow();
				row.CreateCells(dgvTable);

				row.Cells[ColConstructor.Index].Value = !column.IsNullable;
				row.Cells[ColName.Index].Value = column.Name;
				row.Cells[ColType.Index].Value = column.DataType;
				row.Cells[ColPropertyName.Index].Value = column.PropertyName;

				if (column.IsNullable) {
					row.Cells[ColConstructor.Index].Style.BackColor = Color.LightGray;
					row.Cells[ColConstructor.Index].ReadOnly = true;
				}

				if (column.Iskey) {
					row.Cells[ColConstructor.Index].Value = false;
				}

				rows.Add(row);
			}

			dgvTable.Rows.AddRange(rows.ToArray());

			return columns;
		}

		private List<Table> GetTablesToGenerate() {
			var indexes = dgvTables.Rows.OfType<DataGridViewRow>()
											.Where(x => x.Cells[ColChecked.Index].Value != null &&
														(bool)x.Cells[ColChecked.Index].Value)
											.Select(x => x.Index)
											.ToList();

			var tables = indexes.Select(index => _Tables.ElementAtOrDefault(index)).ToList();

			return tables;
		}

		private void EnableDisableControls(ConnectionState state) {
			txtIp.Enabled =
			txtPort.Enabled =
			txtName.Enabled =
			txtPassword.Enabled =
			txtUser.Enabled = state != ConnectionState.Connected; ;
		}

		#endregion

	}
}