using DatabaseConnectors.Interfaces;
using DatabaseConnectors.Persistances;
using DatabaseConnectors.Persistances.Interfaces;
using Domain.Model;
using System.Data.Common;
using Utils.Model.Enums;

namespace DatabaseConnectors.Connectors {

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

			_connector = null;
			_persistance = null;
		}

		public DbCommand GetCommand() => _connector.GetCommand();

		public DbConnection GetConnection() => _connector.GetConnection();
	}
}