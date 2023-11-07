using DatabaseConnectors.Interfaces;
using Domain.Model;
using Npgsql;
using System.Data;
using System.Data.Common;
using Utils;

namespace DatabaseConnectors.Connectors {
	public class PostgresConnector : SingletonWrapper<PostgresConnector>, IConnector {

		private NpgsqlConnection _connection;

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
			_connection.Close();
			_connection = null;
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
