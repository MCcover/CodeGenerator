﻿using CodeGenerator.Model.Enums;

namespace CodeGenerator.Model.DatabaseConnectors.Connectors {
	public class DatabaseConnector {

		private static volatile object _lock = new object();
		private static DatabaseConnector? _instance;
		public static DatabaseConnector Instance {
			get {
				if (_instance == null) {
					lock (_lock) {
						if (_instance == null) {
							_instance = new DatabaseConnector();
						}
					}
				}
				return _instance;
			}
		}

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

		public void CreateConnector(ConnectionInfo info, Database database) {
			if (_connector == null) {
				lock (_lock) {
					if (_connector == null) {
						_connector = new GenericDatabaseConnector(info, database);
					} else {
						throw new Exception("The connector is alredy stablished, please Dispose the current connector and generete another.");
					}
				}
			} else {
				throw new Exception("The connector is alredy stablished, please Dispose the current connector and generete another.");
			}
		}


		public void DisposeConnector() {
			_connector = null;
		}

	}
}