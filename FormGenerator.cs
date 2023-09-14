using CodeGenerator.Model;
using CodeGenerator.Model.DatabaseConnectors.Connectors;
using CodeGenerator.Model.Enums;

namespace CodeGenerator {
	public partial class FormGenerator : Form {

		public FormGenerator() => InitializeComponent();

		private void FormGenerator_Load(object sender, EventArgs e) {

			cmbDatabase.DataSource = Enum.GetValues(typeof(Database));
		}

		private void BtnConnect_Click(object sender, EventArgs e) {
			var ip = txtIp.Text;
			var port = Convert.ToInt32(txtPort.Text);
			var databaseName = txtName.Text;
			var databaseUser = txtUser.Text;
			var databasePassword = txtPassword.Text;
			Enum.TryParse(cmbDatabase.SelectedValue?.ToString(), out Database database);

			var connectionInfo = new ConnectionInfo(ip, port, databaseName, databaseUser, databasePassword);

			DatabaseConnector.Instance.CreateConnector(connectionInfo, database);

			//DatabaseConnector.Instance.Connector.Connect();

			//var cmd = DatabaseConnector.Instance.Connector.GetCommand();

			//cmd.CommandText = "SELECT table_name AS name\n" +
			//				  "FROM information_schema.tables \n" +
			//				  "WHERE table_schema = 'public' AND\n" +
			//				  "			table_catalog = 'don_obdulio';";

			//var rs = cmd.ExecuteReader();

			//while (rs.Read()) {

			//	var a = rs.GetFieldValue<string>(0);

			//	rs.NextResult();
			//}
			//rs.Close();

		}


	}
}