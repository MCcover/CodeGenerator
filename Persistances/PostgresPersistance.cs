using CodeGenerator.DatabaseConnectors.Connectors;
using CodeGenerator.MethodsOfExtensions;
using CodeGenerator.Model.Table;
using CodeGenerator.Persistances.Interfaces;
using System.Data;

namespace CodeGenerator.Persistances {

	public class PostgresPersistance : IPersistance {
		private static volatile object _lock = new object();

		private static PostgresPersistance? _instance;

		public static PostgresPersistance Instance {
			get {
				if (_instance == null) {
					lock (_lock) {
						if (_instance == null) {
							_instance = new PostgresPersistance();
						}
					}
				}
				return _instance;
			}
		}

		private PostgresPersistance() {
		}

		public void Dispose() => _instance = null;

		public async Task<List<Table>> GetTables() {
			List<Table> tables = new();

			var cmd = DatabaseConnector.Instance.Connector.GetCommand();
			cmd.CommandText = "SELECT table_name AS name\n" +
							  "FROM information_schema.tables \n" +
							  "WHERE table_schema = 'public' AND\n" +
							 $"		 table_catalog = @catalog;";

			cmd.AddParameter("@catalog", DatabaseConnector.Instance.Connector.ConnectionInfo.DatabaseName, DbType.String);

			var rs = await cmd.ExecuteReaderAsync();

			while (rs.Read()) {
				var name = rs.GetString(rs.GetOrdinal("name"));
				var table = new Table(name, name.RemoveSpecialCharactersAndFormatText('_'));

				tables.Add(table);
			}

			rs.Close();

			return tables;
		}

		public async Task<List<Column>> GetColumns(string tableName) {
			List<Column> columns = new();

			var cmd = DatabaseConnector.Instance.Connector.GetCommand();
			cmd.CommandText = "SELECT column_name AS name, \n" +
								  "		  udt_name AS type\n" +
								  "FROM information_schema.columns\n" +
								  "WHERE table_schema = 'public' AND\n" +
								 $"		 table_name = @tableName AND\n" +
								 $"		 table_catalog = @catalog;";

			cmd.AddParameter("@tableName", tableName, DbType.String);
			cmd.AddParameter("@catalog", DatabaseConnector.Instance.Connector.ConnectionInfo.DatabaseName, DbType.String);

			var rs = await cmd.ExecuteReaderAsync();

			while (rs.Read()) {
				var name = rs.GetString(rs.GetOrdinal("name"));
				var type = rs.GetString(rs.GetOrdinal("type"));
				var propertyName = name.RemoveSpecialCharactersAndFormatText('_');

				var column = new Column(name, type, false, propertyName);

				columns.Add(column);
			}

			rs.Close();

			return columns;
		}
	}
}