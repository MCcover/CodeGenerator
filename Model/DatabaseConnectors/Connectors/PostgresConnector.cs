using CodeGenerator.Model.DatabaseConnectors.Interfaces;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace CodeGenerator.Model.DatabaseConnectors.Connectors {
	public class PostgresConnector : IConnector {

		private NpgsqlConnection _connection;

		private static volatile object _lock = new object();
		private static PostgresConnector? _instance;
		public static PostgresConnector Instance {
			get {
				if (_instance == null) {
					lock (_lock) {
						if (_instance == null) {
							_instance = new PostgresConnector();
						}
					}
				}
				return _instance;
			}
		}

		private PostgresConnector() {

		}

		public void Connect(ConnectionInfo info) {
			if (_connection == null) {
				_connection = new NpgsqlConnection($"Server={info.Ip};Port={info.Port};Database={info.DatabaseName};User Id={info.DatabaseUser};Password={info.DatabasePassword}");
			}
			if (_connection.State != ConnectionState.Open) {
				_connection.Open();
			}
		}

		public void Disconnect() {
			if (_connection != null && _connection.State != ConnectionState.Closed) {
				_connection.Close();
			}
		}

		public DbConnection GetConnection() {
			if (_connection == null) {
				throw new Exception("Connection not defined.");
			}

			if (_connection.State != ConnectionState.Open) {
				throw new Exception("The connection is Closed.");
			}

			return _connection;
		}

		public DbCommand GetCommand() {
			return new NpgsqlCommand {
				Connection = (NpgsqlConnection)GetConnection(),
			};
		}
	}
}
