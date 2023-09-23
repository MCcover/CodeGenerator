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

			var columnsSql = string.Join(", ", columns);


			#region Insert
			var columnsParametersInsert = string.Join(", ", columnsSimple.Select(x => "@" + x).ToList());

			var insert = $@"""INSERT INTO {{{{tableName}}}} ({{{{columns}}}}) VALUES ({{{{columnsValues}}}})""";

			insert = insert.Replace("{{columnsValues}}", columnsParametersInsert);

			#endregion

			var fullParameters = "";
			foreach (var column in table.Columns) {
				fullParameters += $"cmd.AddParameter(\"@{column.Name}\", entity.{column.PropertyName}); " + Environment.NewLine + "\t\t";
			}

			var columnsWithPk = table.Columns.Where(x => x.Iskey).ToList();
			var columnsNoPk = table.Columns.Where(x => !x.Iskey).ToList();

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

			var loads = table.Columns.Select(x => "obj." + x.PropertyName + " = " + GenerateGetValue(ConvertTypeBdToCSharp(x.DataType), x.Name) + ";").ToList();
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
		cmd.CommandText = ""DELETE FROM {{{{tableName}}}} "" +
						  ""WHERE {{{{conditions}}}}; "";
							  
		{{{{parametersPk}}}}
			
		var affectedRows = await cmd.ExecuteNonQuertyAsync();
	
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
		var list = new List<{{{{className}}}}>();
			
		_connection.Open();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "";
			
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
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "" +
						  ""WHERE {{{{conditions}}}}; "";
			
		{{{{parametersPk}}}}

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
		{{{{loadData}}}}
	}}
}}";

			text = text.Replace("{{insertSql}}", insert);
			text = text.Replace("{{parametersInsert}}", fullParameters);

			text = text.Replace("{{modifySql}}", modify);
			text = text.Replace("{{parametersModify}}", fullParameters);

			text = text.Replace("{{parametersPk}}", parametersPk);

			text = text.Replace("{{tableName}}", table.Name);

			text = text.Replace("{{conditions}}", conditions);

			text = text.Replace("{{columns}}", columnsSql);

			text = text.Replace("{{loadData}}", loadData);

			text = text.Replace("{{className}}", table.ClassName);
			text = text.Replace("{{primaryKey}}", ConvertTypeBdToCSharp(table.Columns[0].DataType));

			return text;
		}

		public string GenerateGetValue(string type, string parameterName) {

			string get = $"dr.Get{{{{type}}}}(dr.GetOrdinal(\"{parameterName}\"))";

			string t;

			switch (type) {

				#region INT

				case "sbyte":
				case "int":
				case "uint":
				case "short":
				case "ushort":
					t = "Int";
					break;

				#endregion INT

				#region LONG

				case "long":
				case "ulong":
					t = "Long";
					break;

				#endregion LONG

				#region DOUBLE

				case "float":
				case "double":
					t = "Double";
					break;

				#endregion DOUBLE

				#region BYTE

				case "byte":
					t = "Byte";
					break;

				#endregion BYTE

				#region CHAR

				case "char":
					t = "Char";
					break;

				#endregion CHAR

				#region BOOL

				case "bool":
					t = "Boolean";
					break;

				#endregion BOOL

				#region OBJECT

				case "object":
					t = "null";
					break;

				#endregion OBJECT

				#region STRING

				case "string":
					t = "String";
					break;

				#endregion STRING

				#region DECIMAL

				case "decimal":
					t = "Decimal";
					break;

				#endregion DECIMAL

				#region DATETIME?

				case "DateTime?":
					t = "DateTimeNullable";
					break;

				#endregion DATETIME?

				#region DATETIME

				case "DateTime":
					t = "DateTime";
					break;

				#endregion DATETIME

				default:
					t = "null";
					break;
			}

			get = get.Replace("{{type}}", t);

			return get;

		}

	}

}
