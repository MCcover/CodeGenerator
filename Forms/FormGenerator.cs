using CodeGenerator.Model;
using CodeGenerator.Model.DatabaseConnectors.Connectors;
using CodeGenerator.Model.Enums;

namespace CodeGenerator.Forms {

	public enum State {
		Connected,
		Disconnected
	}

	public partial class FormGenerator : Form {
		private State ConnectionState { get; set; } = State.Disconnected;

		public FormGenerator() => InitializeComponent();

		private void FormGenerator_Load(object sender, EventArgs e) {
			cmbDatabase.DataSource = Enum.GetValues(typeof(Database));
		}

		private void BtnConnectDisconnect_Click(object sender, EventArgs e) {
			try {
				if (ConnectionState == State.Connected) {
					DatabaseConnector.Instance.DisposeConnector();
					ConnectionState = State.Disconnected;
				} else {
					(ConnectionInfo connectionInfo, Database database) = CreateConnectionInfo();

					DatabaseConnector.Instance.CreateConnector(connectionInfo, database).Connect();

					ConnectionState = State.Connected;
				}

				btnConnectDisconnect.Text = ConnectionState == State.Connected ? "Disconnect Database" : "Connect Database";
			} catch (Exception ex) {
				MessageBox.Show(this, ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnGenerate_Click(object sender, EventArgs e) {
		}

		private (ConnectionInfo connectionInfo, Database database) CreateConnectionInfo() {
			var ip = txtIp.Text;
			var port = Convert.ToInt32(txtPort.Text);
			var databaseName = txtName.Text;
			var databaseUser = txtUser.Text;
			var databasePassword = txtPassword.Text;
			Enum.TryParse(cmbDatabase.SelectedValue?.ToString(), out Database database);

			var connectionInfo = new ConnectionInfo(ip, port, databaseName, databaseUser, databasePassword);

			return (connectionInfo, database);
		}
	}
}