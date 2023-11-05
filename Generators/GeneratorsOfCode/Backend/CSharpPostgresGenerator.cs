using Domain.Model.Table;
using Generators.Interfaces;
using Generators.Model.Backend;
using Utils.Attributes.Class;
using Utils.Enums.Lenguages;
using Utils.Model.Enums;

namespace Generators.GeneratorsOfCode.Backend {
	[LenguageBackend(LenguagesBackend.CSharp)]
	[Database(Database.Postgres)]
	public class CSharpPostgresGenerator : IBackendGenerator {

		public GeneratedBackend Generate(BackendInfo info, Table table) {

			var model = string.Empty;
			var modelPk = string.Empty;
			var constructor = string.Empty;

			var service = string.Empty;
			var persistence = string.Empty;

			var interfaceRepository = string.Empty;
			var interfaceService = string.Empty;

			var interfaces = new GeneratedInterfaces();

			if (info.GenerateModel) {
				model = GenerateModel(info.ProjectName, table);
				modelPk = GenerateModelPk(info.ProjectName, table);
			}

			if (info.GenerateConstructor) {
				constructor = GenerateConstructor(info.ProjectName, table);
			}

			if (info.GenerateService) {
				interfaceService = GenerateInterfaceService(info.ProjectName, table);
				service = GenerateService(info.ProjectName, table);
			}

			if (info.GeneratePersistence) {
				interfaceService = GenerateInterfacePersistence(info.ProjectName, table);
				persistence = GeneratePersistence(info.ProjectName, table);
			}

			if (info.GenerateInterfaces) {
				interfaces = GenerateInterfaces(info.ProjectName);
			}

			return new GeneratedBackend(model, modelPk, constructor, service, persistence, interfaceRepository, interfaceService, interfaces);
		}

		public string GenerateModel(string nameSpace, Table table) {

			var noPk = table.Columns.Where(x => !x.Iskey).ToList();

			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine;

			text += "public partial class {{className}} : {{className}}Id, IValidateData<{{className}}Id> {" + Environment.NewLine;

			foreach (var column in noPk) {
				text += $"\tpublic {ConvertTypeBdToCSharp(column.DataType)} {column.PropertyName} {{ get; set; }}" + Environment.NewLine + Environment.NewLine;
			}

			text += "\tpublic bool ValidateData ({{className}}Id entity) {" + Environment.NewLine;
			text += "\t\tthrow new NotImplementedException();" + Environment.NewLine;
			text += "\t}" + Environment.NewLine;
			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateModelPk(string nameSpace, Table table) {

			var pk = table.Columns.Where(x => x.Iskey).ToList();

			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine;

			text += "public class {{className}}Id {" + Environment.NewLine;

			foreach (var column in pk) {
				text += $"\tpublic {ConvertTypeBdToCSharp(column.DataType)} {column.PropertyName}Key {{ get; set; }}" + Environment.NewLine + Environment.NewLine;
			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateConstructor(string nameSpace, Table table) {
			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine;

			text += "public partial class {{className}} {" + Environment.NewLine;

			#region Empty Constructure

			text += "\tpublic {{className}}(){" + Environment.NewLine;

			foreach (var column in table.Columns) {
				text += $"\t\t{column.PropertyName}{(column.Iskey ? "Key" : "")} = default;" + Environment.NewLine;
			}

			text += "\t}" + Environment.NewLine + Environment.NewLine;

			#endregion

			var propsInConstructure = table.Columns.Where(x => x.InConstructor).ToList();

			if (propsInConstructure.Count > 0) {
				string[] parametersNames = new string[propsInConstructure.Count];
				string[] parameters = new string[propsInConstructure.Count];
				for (int i = 0; i < propsInConstructure.Count; i++) {
					var type = ConvertTypeBdToCSharp(propsInConstructure[i].DataType);
					var parameterName = propsInConstructure[i].PropertyName[..1].ToLower() + propsInConstructure[i].PropertyName[1..];

					var parameter = type + " " + parameterName;

					parametersNames[i] = parameterName;
					parameters[i] = parameter;
				}
				string parametersConstuctor = string.Join(", ", parameters);

				text += $"\tpublic {{{{className}}}}({parametersConstuctor}) : this() {{" + Environment.NewLine;

				for (int i = 0; i < propsInConstructure.Count; i++) {
					text += $"\t\t{propsInConstructure[i].PropertyName} = {parametersNames[i]};" + Environment.NewLine;
				}

				text += "\t}" + Environment.NewLine;

			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateService(string nameSpace, Table table) {
			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public class {{className}}Service : I{{className}}Service {
	private readonly I{{className}}Repository _{{className}}Repository = null!;
	public {{className}}Service(I{{className}}Repository {{className}}Repository) {
		_{{className}}Repository = {{className}}Repository;
	}

	public async Task<bool> Add({{className}} entity) {
		if (entity.ValidateData(entity)) {
			return await _{{className}}Repository.Add(entity);
		}
		return false;
	}

	public async Task<bool> Delete({{className}}Id id) {
		if (!await Exists(id)) {
			throw new Exception(""{{className}} id is empty"");
		}
		return await _{{className}}Repository.Delete(id);
	}

	public async Task<bool> Exists({{className}}Id id) {
		return await _{{className}}Repository.Exists(id);
	}

	public async Task<List<{{className}}>> GetAll() {
		return await _{{className}}Repository.GetAll();
	}

	public async Task<{{className}}> GetById({{className}}Id id) {
		return await _{{className}}Repository.GetById(id);
	}

	public async Task<bool> Modify({{className}} entity) {
		if (!await Exists(entity)) {
			throw new Exception(""{{className}} id is empty"");
		} else if (entity.ValidateData(entity)) {
			return await _{{className}}Repository.Modify(entity);
		}
		return false;
	}
}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateInterfaceService(string nameSpace, Table table) {
			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface I{{className}}Service : IBaseService<{{className}}, {{className}}Id> { 

}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateInterfacePersistence(string nameSpace, Table table) {
			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface I{{className}}Repository : IBaseRepository<{{className}}, {{className}}Id> { 

}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public GeneratedInterfaces GenerateInterfaces(string nameSpace) {

			string interfaceAdd = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IAdd<T> {
	Task<bool> Add (T entity);
}";
			string interfaceModify = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IModify<T> {
	Task<bool> Modify (T entity);
}";
			string interfaceDelete = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IDelete<I> {
	Task<bool> Delete (I id);
}";
			string interfaceList = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IList<T, I> {
	Task<List<T>> GetAll ();
	Task<T> GetById (I id);
}";
			string interfaceExists = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IExists<I> {
	Task<bool> Exists (I id);
}";
			string interfaceValidateData = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IValidateData<T> {
	bool ValidateData (T entity);
}";
			string interfaceService = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IBaseService<T, I> : IAdd<T>, IModify<T>, IDelete<I>, IList<T, I>, IExists<I> {
}";
			string interfaceRepository = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IBaseRepository<T, I> : IAdd<T>, IModify<T>, IDelete<I>, IList<T, I>, IExists<I> {
}";

			string interfaceConnection = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
@"public interface IConnection {

	public DbCommand CreateCommand();

	public Task Connect();

	public Task Disconnect();

	public Task BeginTransaction();

	public Task CommitTransaction();

	public Task CancelTransaction();

}";
			return new GeneratedInterfaces(interfaceAdd, interfaceModify, interfaceDelete, interfaceList, interfaceExists, interfaceValidateData, interfaceService, interfaceRepository, interfaceConnection);
		}

		public string ConvertTypeBdToCSharp(string typeBd) {
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

		public string GeneratePersistence(string nameSpace, Table table) {
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
				parametersPk += $"cmd.AddParameter(\"@{column.Name}\", entity.{column.PropertyName}{(column.Iskey ? "Key" : "")}); " + Environment.NewLine + "\t\t";
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

			var loads = table.Columns.Select(x => "obj." + x.PropertyName + (x.Iskey ? "Key" : "") + $" = dr.GetValue<{ConvertTypeBdToCSharp(x.DataType) + (x.IsNullable ? "?" : "")}>(\"{x.Name}\");").ToList();
			var loadData = string.Join("" + Environment.NewLine + "\t\t", loads);

			#endregion

			var text = "namespace " + nameSpace + "; " + Environment.NewLine + Environment.NewLine +
$@"public class {{{{className}}}}Repository : I{{{{className}}}}Repository {{

	private IConnection _connection;
	
	public {{{{className}}}}Repository(IConnection connection) {{
		_connection = connection;
	}}
	
	public async Task<bool> Add({{{{className}}}} entity) {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = {{{{insertSql}}}};
			
		AllParameters(cmd, entity);
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		await _connection.Disconnect();
			
		return affectedRows > 0;
	}}
		
	public async Task<bool> Modify({{{{className}}}} entity) {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = {{{{modifySql}}}};
							  
		AllParameters(cmd, entity);
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		await _connection.Disconnect();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Delete({{{{className}}}}Id id) {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""DELETE FROM {{{{tableName}}}} "" +
						  ""WHERE {{{{conditions}}}}; "";
							  
		ConditionsParameters(cmd, id);
			
		var affectedRows = await cmd.ExecuteNonQueryAsync();
	
		await _connection.Disconnect();
			
		return affectedRows > 0;
	}}
	
	public async Task<bool> Exists({{{{className}}}}Id id) {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT 1 AS exists FROM {{{{tableName}}}} "" +
						  ""WHERE {{{{conditions}}}}; "";
							  
		ConditionsParameters(cmd, id);
			
		var existsValue = (int?)await cmd.ExecuteScalarAsync();
	
		await _connection.Disconnect();
			
		return existsValue != null;
	}}
	
	public async Task<List<{{{{className}}}}>> GetAll() {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "";
			
		var list = await cmd.ExecuteSelectList<{{{{className}}}}>(LoadData);
			
		await _connection.Disconnect();
			
		return list;
	}}
	
	public async Task<{{{{className}}}}> GetById({{{{className}}}}Id id) {{
		await _connection.Connect();
			
		var cmd = _connection.CreateCommand();
		cmd.CommandText = ""SELECT {{{{columns}}}} "" +
						  ""FROM {{{{tableName}}}}; "" +
						  ""WHERE {{{{conditions}}}}; "";
			
		ConditionsParameters(cmd, id);

		var result = await cmd.ExecuteSelect<{{{{className}}}}>(LoadData);

		await _connection.Disconnect();

		return result;
	}}

	public void LoadData({{{{className}}}} obj, DbDataReader dr) {{
		{{{{loadData}}}}
	}}

	public void AllParameters(DbCommand cmd, {{{{className}}}} entity) {{
		ConditionsParameters(cmd, entity);
		ParametersLessConditions(cmd, entity);
	}}

	public void ConditionsParameters(DbCommand cmd, {{{{className}}}}Id entity) {{
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
