using CodeGenerator.Model.DatabaseConnectors.Interfaces;
using CodeGenerator.Model.Enums;
using System.Data.Common;

namespace CodeGenerator.Model.DatabaseConnectors.Connectors {
	public class GenericDatabaseConnector : IConnectorBase {

		private IConnector _connector { get; set; }

		public ConnectionInfo ConnectionInfo { get; private set; }

		public GenericDatabaseConnector(ConnectionInfo info, Database database) {
			ConnectionInfo = info;
			SelectConnector(database);
		}

		private void SelectConnector(Database database) {
			switch (database) {
				case Database.Postgres:
					_connector = PostgresConnector.Instance;
					break;
				default:
					throw new Exception("Database not sopported");
			}
		}

		public void Connect() => _connector.Connect(ConnectionInfo);

		public void Disconnect() => _connector.Disconnect();

		public DbCommand GetCommand() => _connector.GetCommand();

		public DbConnection GetConnection() => _connector.GetConnection();
	}
}
