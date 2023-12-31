﻿using DatabaseConnectors.Connectors;
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
			cmd.CommandText = "SELECT j.id,\n" +
							  "		  j.name,\n" +
							  "		  j.type,\n" +
							  "		  j.column_name,\n" +
							  "		  j.is_nullable = 'YES' AS is_nullable,\n" +
							  "		  j.is_pk\n" +
							  "FROM (\n" +
							  "	SELECT t.id,\n" +
							  "		   t.name,\n" +
							  "		   t.type,\n" +
							  "		   t.column_name,\n" +
							  "		   t.is_nullable,\n" +
							  "		   bool_or(t.is_pk) AS is_pk\n" +
							  "	FROM (\n" +
							  "		SELECT ROW_NUMBER() OVER (ORDER BY(SELECT NULL)) AS id,\n" +
							  "			   c.column_name AS name, \n" +
							  "			   c.udt_name AS type, \n" +
							  "			   c.column_name, \n" +
							  "			   c.is_nullable, \n" +
							  "			   tc.constraint_type = 'PRIMARY KEY' AS is_pk\n" +
							  "		FROM information_schema.table_constraints tc \n" +
							  "		JOIN information_schema.constraint_column_usage AS ccu USING (constraint_schema, constraint_name) \n" +
							  "		JOIN information_schema.columns AS c ON (c.table_schema = tc.constraint_schema AND \n" +
							  "																						 tc.table_name = c.table_name AND \n" +
							  "																						 ccu.column_name = c.column_name)\n" +
							  "		WHERE c.table_schema = 'public' AND\n" +
							  "			  c.table_name = @tableName AND\n" +
							  "			  c.table_catalog = @catalog AND\n" +
							  "			  tc.constraint_type = 'PRIMARY KEY'\n" +
							  "		UNION (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),\n" +
							  "					  c.column_name AS name, \n" +
							  "					  c.udt_name AS type, \n" +
							  "					  c.column_name, \n" +
							  "					  c.is_nullable, \n" +
							  "					  false\n" +
							  "				 FROM information_schema.columns c\n" +
							  "				 WHERE c.table_schema = 'public' AND\n" +
							  "				c.table_name = @tableName AND\n" +
							  "				c.table_catalog = @catalog)\n" +
							  "	) T\n" +
							  "	GROUP BY 1, 2, 3, 4, 5\n" +
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
				var isNullable = rs.GetBoolean(rs.GetOrdinal("is_nullable"));

				var column = new Column(name, type, false, propertyName, isPk, isNullable);

				columns.Add(column);
			}

			rs.Close();


			return columns;
		}
	}
}