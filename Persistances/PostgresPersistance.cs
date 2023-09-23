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
			cmd.CommandText = "SELECT j.id,\n" +
							  "		  j.name,\n" +
							  "		  j.type,\n" +
							  "		  j.column_name,\n" +
							  "		  j.is_pk\n" +
							  "FROM (\n" +
							  "	SELECT t.id,\n" +
							  "		   t.name,\n" +
							  "		   t.type,\n" +
							  "		   t.column_name,\n" +
							  "		   bool_or(t.is_pk) AS is_pk\n" +
							  "	FROM (\n" +
							  "		SELECT ROW_NUMBER() OVER (ORDER BY(SELECT NULL)) AS id,\n" +
							  "			   c.column_name AS name, \n" +
							  "			   c.udt_name AS type, \n" +
							  "			   c.column_name, \n" +
							  "			   tc.constraint_type = 'PRIMARY KEY' AS is_pk\n" +
							  "		FROM information_schema.table_constraints tc \n" +
							  "		JOIN information_schema.constraint_column_usage AS ccu USING (constraint_schema, constraint_name) \n" +
							  "		JOIN information_schema.columns AS c ON (c.table_schema = tc.constraint_schema AND \n" +
							  "																						 tc.table_name = c.table_name AND \n" +
							  "																						 ccu.column_name = c.column_name)\n" +
							  "		WHERE c.table_schema = 'public' AND\n" +
							  "			  c.table_name = @tableName AND\n" +
							  "			  c.table_catalog = @catalog\n" +
							  "		UNION (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),\n" +
							  "					  c.column_name AS name, \n" +
							  "					  c.udt_name AS type, \n" +
							  "					  c.column_name, \n" +
							  "					  false\n" +
							  "				 FROM information_schema.columns c\n" +
							  "				 WHERE c.table_schema = 'public' AND\n" +
							  "				c.table_name = @tableName AND\n" +
							  "				c.table_catalog = @catalog)\n" +
							  "	) T\n" +
							  "	GROUP BY 1, 2, 3, 4\n" +
							  ") J\n" +
							  "ORDER BY j.is_pk DESC, j.id";

			cmd.AddParameter("@tableName", tableName, DbType.String);
			cmd.AddParameter("@catalog", DatabaseConnector.Instance.Connector.ConnectionInfo.DatabaseName, DbType.String);

			var rs = await cmd.ExecuteReaderAsync();

			while (rs.Read()) {
				var name = rs.GetString(rs.GetOrdinal("name"));
				var type = rs.GetString(rs.GetOrdinal("type"));
				var propertyName = name.RemoveSpecialCharactersAndFormatText('_');
				var isPk = rs.GetBoolean(rs.GetOrdinal("is_pk"));

				var column = new Column(name, type, false, propertyName, isPk);

				columns.Add(column);
			}

			rs.Close();


			return columns;
		}
	}
}