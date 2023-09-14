using CodeGenerator.Model.DatabaseConnectors.Interfaces;
using CodeGenerator.Model.Enums;
using CodeGenerator.Persistances;
using CodeGenerator.Persistances.Interfaces;
using System.Data.Common;

namespace CodeGenerator.Model.DatabaseConnectors.Connectors {

	public class GenericDatabaseConnector : IConnectorBase {
		private IConnector _connector { get; set; }
		private IPersistance _persistance { get; set; }
		public IPersistance Persistance { get => _persistance; }

		public ConnectionInfo ConnectionInfo { get; private set; }

		public GenericDatabaseConnector(ConnectionInfo info, Database database) {
			ConnectionInfo = info;
			SelectConnector(database);
		}

		private void SelectConnector(Database database) {
			switch (database) {
				case Database.Postgres:
					_connector = PostgresConnector.Instance;
					_persistance = PostgresPersistance.Instance;
					break;

				default:
					throw new Exception("Database not sopported");
			}
		}

		public void Connect() => _connector.Connect(ConnectionInfo);

		public void Disconnect() {
			_connector.Disconnect();
			_persistance.Dispose();
		}

		public DbCommand GetCommand() => _connector.GetCommand();

		public DbConnection GetConnection() => _connector.GetConnection();
	}
}