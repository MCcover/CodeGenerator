using Domain.Model;
using Utils;
using Utils.Model.Enums;

namespace DatabaseConnectors.Connectors {

	public class DatabaseConnector : SingletonWrapper<DatabaseConnector> {
		private static volatile object _Lock = new();

		private DatabaseConnector() {
		}

		private static GenericDatabaseConnector? _connector;

		public GenericDatabaseConnector Connector {
			get {
				if (_connector == null) {
					throw new Exception("Connector not defined.");
				}
				return _connector;
			}
		}

		public GenericDatabaseConnector CreateConnector(ConnectionInfo info, Database database) {
			if (_connector == null) {
				lock (_Lock) {
					if (_connector == null) {
						_connector = new GenericDatabaseConnector(info, database);
					} else {
						throw new Exception("The connector is alredy stablished, please Dispose the current connector and generete another.");
					}
				}
			} else {
				throw new Exception("The connector is alredy stablished, please Dispose the current connector and generete another.");
			}
			return _connector;
		}

		public bool ConnectorStablished() {
			return _connector != null;
		}

		public void DisposeConnector() {
			_connector.Disconnect();
			_connector = null;
		}
	}
}