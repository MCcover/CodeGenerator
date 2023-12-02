using DatabaseConnectors.Connectors;
using DatabaseConnectors.Persistances.Interfaces;
using DatabaseConnectors.Persistances.Utils;
using Domain.Model.Table;
using System.Data;
using Utils;
using Utils.MethodsOfExtensions;

namespace DatabaseConnectors.Persistances {

	public class PostgresPersistance : SingletonWrapper<PostgresPersistance>, IPersistance {

		private PostgresPersistance() {
		}

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
			cmd.CommandText = "WITH foreings AS (\n" +
							  "	SELECT tc.table_name,\n" +
							  "				 kcu.column_name,\n" +
							  "				 ccu.table_name AS references_table,\n" +
							  "				 ccu.column_name AS references_field\n" +
							  "	FROM information_schema.table_constraints tc\n" +
							  "	LEFT JOIN information_schema.key_column_usage kcu ON (tc.constraint_catalog = kcu.constraint_catalog AND \n" +
							  "																											  tc.constraint_schema = kcu.constraint_schema AND \n" +
							  "																											  tc.constraint_name = kcu.constraint_name)\n" +
							  "	LEFT JOIN information_schema.referential_constraints rc ON (tc.constraint_catalog = rc.constraint_catalog AND \n" +
							  "																														  tc.constraint_schema = rc.constraint_schema AND \n" +
							  "																														  tc.constraint_name = rc.constraint_name)\n" +
							  "	LEFT JOIN information_schema.constraint_column_usage ccu ON (rc.unique_constraint_catalog = ccu.constraint_catalog AND \n" +
							  "																															 rc.unique_constraint_schema = ccu.constraint_schema AND \n" +
							  "																															 rc.unique_constraint_name = ccu.constraint_name)\n" +
							  "	WHERE LOWER(tc.constraint_type) = 'foreign key' AND\n" +
							  "				tc.table_name = @tableName\n" +
							  ")\n" +
							  "SELECT K.id,\n" +
							  "			 K.name,\n" +
							  "			 K.type,\n" +
							  "			 K.column_name,\n" +
							  "			 K.is_nullable = 'YES' AS is_nullable,\n" +
							  "			 K.is_pk,\n" +
							  "			 K.fk_column_name,\n" +
							  "			 K.fk_referenced_table,\n" +
							  "			 K.fk_referenced_field\n" +
							  "FROM (\n" +
							  "	SELECT J.id,\n" +
							  "				 J.name,\n" +
							  "				 J.type,\n" +
							  "				 J.column_name,\n" +
							  "				 J.is_nullable = 'YES' AS is_nullable,\n" +
							  "				 J.is_pk,\n" +
							  "				 foreings.column_name AS fk_column_name,\n" +
							  "				 foreings.references_table AS fk_referenced_table,\n" +
							  "				 foreings.references_field AS fk_referenced_field\n" +
							  "	FROM (\n" +
							  "		SELECT T.id,\n" +
							  "					 T.name,\n" +
							  "					 T.type,\n" +
							  "					 T.column_name,\n" +
							  "					 T.is_nullable,\n" +
							  "					 bool_or(T.is_pk) AS is_pk\n" +
							  "		FROM (\n" +
							  "			SELECT ROW_NUMBER() OVER (ORDER BY(SELECT NULL)) AS id,\n" +
							  "						 c.column_name AS name, \n" +
							  "						 c.udt_name AS type, \n" +
							  "						 c.column_name, \n" +
							  "						 c.is_nullable, \n" +
							  "						 tc.constraint_type = 'PRIMARY KEY' AS is_pk\n" +
							  "			FROM information_schema.table_constraints tc \n" +
							  "			JOIN information_schema.constraint_column_usage AS ccu USING (constraint_schema, constraint_name) \n" +
							  "			JOIN information_schema.columns AS c ON (c.table_schema = tc.constraint_schema AND \n" +
							  "																							 tc.table_name = c.table_name AND \n" +
							  "																							 ccu.column_name = c.column_name)\n" +
							  "			WHERE c.table_schema = 'public' AND\n" +
							  "						c.table_name = @tableName AND\n" +
							  "						c.table_catalog = @catalog AND\n" +
							  "						tc.constraint_type = 'PRIMARY KEY'\n" +
							  "			UNION (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),\n" +
							  "							c.column_name AS name, \n" +
							  "							c.udt_name AS type, \n" +
							  "							c.column_name, \n" +
							  "							c.is_nullable, \n" +
							  "							false\n" +
							  "					 FROM information_schema.columns c\n" +
							  "					 WHERE c.table_schema = 'public' AND\n" +
							  "								 c.table_name = @tableName AND\n" +
							  "								 c.table_catalog = @catalog)\n" +
							  "		) T\n" +
							  "		GROUP BY 1, 2, 3, 4, 5\n" +
							  "	) J\n" +
							  "	LEFT JOIN foreings ON (foreings.column_name = j.column_name )\n" +
							  ") K\n" +
							  "ORDER BY K.is_pk DESC, K.id;";

			cmd.AddParameter("@tableName", tableName, DbType.String);
			cmd.AddParameter("@catalog", DatabaseConnector.Instance.Connector.ConnectionInfo.DatabaseName, DbType.String);

			var rs = await cmd.ExecuteReaderAsync();

			while (rs.Read()) {
				var name = rs.GetString(rs.GetOrdinal("name"));
				var type = rs.GetString(rs.GetOrdinal("type"));
				var propertyName = name.RemoveSpecialCharactersAndFormatText('_');
				var isPk = rs.GetBoolean(rs.GetOrdinal("is_pk"));
				var isNullable = rs.GetBoolean(rs.GetOrdinal("is_nullable"));

				var foreignTable = string.Empty;
				if (!rs.IsDBNull("fk_referenced_table")) {
					foreignTable = rs.GetString(rs.GetOrdinal("fk_referenced_table"));
				}

				var foreignColumn = string.Empty;

				if (!rs.IsDBNull("fk_referenced_field")) {
					foreignColumn = rs.GetString(rs.GetOrdinal("fk_referenced_field"));
				}

				Foreign foreign = null;
				if (foreignTable != string.Empty && foreignColumn != string.Empty) {
					foreign = new Foreign(foreignTable, foreignColumn);
				}

				var column = new Column(name, type, false, propertyName, isPk, isNullable, foreign);

				columns.Add(column);
			}

			rs.Close();


			return columns;
		}
	}
}