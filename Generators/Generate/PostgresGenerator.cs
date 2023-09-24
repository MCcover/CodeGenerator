﻿using CodeGenerator.Generators.Abstracts;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators {

	public class PostgresGenerator : AbstractGenerator {

		public override string ConvertTypeBdToCSharp(string typeBd) {
			var type = "";
			switch (typeBd) {
				case "bit":
				case "bool":
					type = "bool";
					break;

				case "bytea":
					type = "byte[]";
					break;

				case "date":
				case "timestamp":
				case "timetz":
				case "timestamptz":
					type = "DateTime";
					break;

				case "numeric":
				case "money":
					type = "decimal";
					break;

				case "float8":
					type = "double";
					break;

				case "float4":
					type = "float";
					break;

				case "uuid":
					type = "Guid";
					break;

				case "int4":
					type = "int";
					break;

				case "int8":
					type = "long";
					break;

				case "int2":
					type = "short";
					break;

				case "bpchar":
				case "json":
				case "text":
				case "varchar":
					type = "string";
					break;

				case "interval":
				case "time":
					type = "TimeSpan";
					break;
			}
			return type;
		}

		public override string GeneratePersistence(Table table) {
			var columnsSimple = table.Columns.Select(x => x.Name).ToList();
			var columns = columnsSimple.Select(x => table.Name + "." + x).ToList();

			var columnsSql = string.Join(", ", columns);


			#region Insert
			var columnsParametersInsert = string.Join(", ", columnsSimple.Select(x => "@" + x).ToList());

			var insert = $@"""INSERT INTO {{{{tableName}}}} ({{{{columns}}}}) VALUES ({{{{columnsValues}}}})""";

			insert = insert.Replace("{{columnsValues}}", columnsParametersInsert);

			#endregion


			var columnsWithPk = table.Columns.Where(x => x.Iskey).ToList();
			var columnsNoPk = table.Columns.Where(x => !x.Iskey).ToList();

			var fullParameters = "";
			foreach (var column in columnsNoPk) {
				fullParameters += $"cmd.AddParameter(\"@{column.Name}\", entity.{column.PropertyName}); " + Environment.NewLine + "\t\t";
			}

			var parametersPk = "";
			foreach (var column in columnsWithPk) {
				parametersPk += $"cmd.AddParameter(\"@{column.Name}\", entity.{column.PropertyName}); " + Environment.NewLine + "\t\t";
			}

			#region Condition

			var conditions = string.Join(" AND ", columnsWithPk.Select(x => table.Name + "." + x.Name + " = @" + x.Name));

			#endregion

			#region Modify


			var updateValues = columnsNoPk.Select(x => table.Name + "." + x.Name + " = @" + x.Name);

			var modifySet = string.Join(", ", updateValues);

			var modify = $@"""UPDATE {{{{tableName}}}} SET {{{{modifySet}}}} WHERE {{{{conditions}}}}""";

			modify = modify.Replace("{{tableName}}", table.Name);
			modify = modify.Replace("{{modifySet}}", modifySet);

			#endregion

			#region LoadData

			var loads = table.Columns.Select(x => "obj." + x.PropertyName + $" = dr.GetValue<{ConvertTypeBdToCSharp(x.DataType) + (x.IsNullable ? "?" : "")}>(\"{x.Name}\");").ToList();
			var loadData = string.Join("" + Environment.NewLine + "\t\t", loads);

			#endregion

			var text = $@"public class {{{{className}}}}Repository : IBaseRepository<{{{{className}}}}, {{{{primaryKey}}}}> {{

	private IConnecion _connection;
	
	public {{{{className}}}}Repository(IConnecion connection) {{
		_connection = connection;
	}}
	
	public async Task<bool> Add({{{{className}}}} entity) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = {{{{insertSql}}}};
			
		AllParameters(cmd, entity);
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
		
	public async Task<bool> Modify({{{{className}}}} entity) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = {{{{modifySql}}}};
							  
		AllParameters(cmd, entity);
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Delete({{{{primaryKey}}}} id) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""DELETE FROM {{{{tableName}}}} "" +
						  ""WHERE {{{{conditions}}}}; "";
							  
		{{{{parametersPk}}}}
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Exists({{{{primaryKey}}}} id) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT 1 AS exists FROM {{{{tableName}}}} "" +
						  ""WHERE {{{{conditions}}}}; "";
							  
		{{{{parametersPk}}}}
			
		var existsValue = (int?)await cmd.ExecuteScalarAsync();
	
		_connection.Close();
			
		return existsValue != null;
	}}
	
	public async Task<List<{{{{className}}}}>> GetAll() {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "";
			
		var list = cmd.ExecuteSelectList<{{{{className}}}}>(LoadData);
			
		_connection.Close();
			
		return list;
	}}
	
	public async Task<{{{{className}}}}> GetById({{{{primaryKey}}}} id) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "" +
						  ""WHERE {{{{conditions}}}}; "";
			
		{{{{parametersPk}}}}

		var result = cmd.ExecuteSelect<{{{{className}}}}>(LoadData);

		_connection.Close();

		return result;
	}}
	
	public bool ValidateData({{{{className}}}} entity) {{
		throw new NotImplementedException();
	}}

	public void LoadData({{{{className}}}} obj, DbDataReader dr) {{
		{{{{loadData}}}}
	}}

	public void AllParameters(DbCommand cmd, {{{{className}}}} entity) {{
		ConditionsParameters(cmd, entity);
		ParametersLessConditions(cmd, entity);
	}}

	public void ConditionsParameters(DbCommand cmd, {{{{className}}}} entity) {{
		{{{{parametersPk}}}}
	}}

	public void ParametersLessConditions(DbCommand cmd, {{{{className}}}} entity) {{
		{{{{parameters}}}}
	}}

}}";

			text = text.Replace("{{insertSql}}", insert);
			text = text.Replace("{{parameters}}", fullParameters);

			text = text.Replace("{{modifySql}}", modify);
			text = text.Replace("{{parametersPk}}", parametersPk);


			text = text.Replace("{{tableName}}", table.Name);

			text = text.Replace("{{conditions}}", conditions);

			text = text.Replace("{{columns}}", columnsSql);

			text = text.Replace("{{loadData}}", loadData);

			text = text.Replace("{{className}}", table.ClassName);
			text = text.Replace("{{primaryKey}}", ConvertTypeBdToCSharp(table.Columns[0].DataType));

			return text;
		}

	}

}
