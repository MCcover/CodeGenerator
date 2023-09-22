using CodeGenerator.Generators.Abstracts;
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

			#region Insert
			var columnsInsert = string.Join(", ", columns);
			var columnsParametersInsert = string.Join(", " , columnsSimple.Select(x => "@" + x).ToList());

			var insert = $@"INSERT INTO {{{{tableName}}}} ({{{{columns}}}}) VALUES ({{{{columnsValues}}}})";

			insert = insert.Replace("{{tableName}}", table.Name);
			insert = insert.Replace("{{columns}}", columnsInsert);
			insert = insert.Replace("{{columnsValues}}", columnsParametersInsert);

			#endregion

			var fullParameters = "";
			foreach (var column in table.Columns) {
				fullParameters += $"cmd.AddParameter(\"@{column.Name}\", entity.{column.PropertyName}); " + Environment.NewLine + "\t\t";
			}


			var columnsWithPk = table.Columns.Where(x => x.Iskey).ToList();
			var columnsNoPk = table.Columns.Where(x => !x.Iskey).ToList();

			#region Condition
			
			var conditions = string.Join(" AND ", columnsWithPk.Select(x => table.Name + "." + x.Name + " = @" + x.Name));

			#endregion

			#region Modify


			var updateValues = columnsNoPk.Select(x => table.Name + "." + x.Name + " = @" + x.Name);

			var modifySet = string.Join(", ", updateValues);

			var modify = $@"UPDATE {{{{tableName}}}} SET {{{{modifySet}}}} WHERE {{{{conditions}}}}";

			modify = modify.Replace("{{tableName}}", table.Name);
			modify = modify.Replace("{{modifySet}}", modifySet);
			modify = modify.Replace("{{conditions}}", conditions);

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
			
		{{{{parametersInsert}}}}
			
		var affectedRows = await cmd.ExecuteNonQuertyAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
		
	public async Task<bool> Modify({{{{className}}}} entity) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = {{{{modifySql}}}};
							  
		{{{{parametersModify}}}}
			
		var affectedRows = await cmd.ExecuteNonQuertyAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Delete({{{{primaryKey}}}} id) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""DELETE FROM countries "" +
							""WHERE countries.country_id = @countriesId; "";
							  
		cmd.AddParammeter(""@countriesId"", id, DbType.Int32);
			
		var affectedRows = await cmd.ExecuteNonQuertyAsync();
	
		_connection.Close();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Exists({{{{primaryKey}}}} id) {{
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT 1 AS exists FROM countries "" +
							""WHERE countries.country_id = @countriesId; "";
							  
		cmd.AddParammeter(""@countriesId"", id, DbType.Int32);
			
		var existsValue = (int?)await cmd.ExecuteScalarAsync();
	
		_connection.Close();
			
		return existsValue != null;
	}}
	
	public async Task<List<{{{{className}}}}>> GetAll() {{
		var list = new List<{{{{className}}}}>();
			
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT countries.country_id, "" +
							""       countries.name, "" +
							""       countries.phone, "" +
							""       countries.currency, "" +
							""       ccountries.abreviation "" +
							""FROM countries; "";
			
		var dr = await cmd.ExecuteReaderAsync();
			
		while(dr.Read()) {{
			
			var obj = new {{{{className}}}}();
			LoadData(obj, dr);
				
			list.Add(obj);
		}}
			
		dr.Close();
			
		_connection.Close();
			
		return list;
	}}
	
	public async Task<{{{{className}}}}> GetById({{{{primaryKey}}}} id) {{
		{{{{className}}}} obj = null;
			
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT countries.country_id, "" +
							""       countries.name, "" +
							""       countries.phone, "" +
							""       countries.currency, "" +
							""       ccountries.abreviation "" +
							""FROM countries; "" +
							""WHERE countries.country_id=@countriesId"";
			
		cmd.AddParammeter(""@countriesId"", id, DbType.Int32);
			
		var dr = await cmd.ExecuteReaderAsync();
	
		if(dr.Read()) {{
			obj = new();
			LoadData(obj, dr);
		}}
			
		dr.Close();
			
		return obj;
	}}
	
	public bool ValidateData({{{{className}}}} entity) {{
		throw new NotImplementedException();
	}}
		
	public void LoadData({{{{className}}}} obj, DbDataReader dr) {{
		obj.CountryId = dr.GetString(dr.GetOrdinal(""country_id""));
	}}
}}";

			text = text.Replace("{{insertSql}}", insert);
			text = text.Replace("{{parametersInsert}}", fullParameters);

			text = text.Replace("{{modifySql}}", modify);
			text = text.Replace("{{parametersModify}}", fullParameters);

			text = text.Replace("{{className}}", table.ClassName);
			text = text.Replace("{{primaryKey}}", ConvertTypeBdToCSharp(table.Columns[0].DataType));

			return text;
		}
	}
}
