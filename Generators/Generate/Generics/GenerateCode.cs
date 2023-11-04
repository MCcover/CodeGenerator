using Domain.Model.Table;

namespace CodeGenerator.Generators.Generate.Generic {
	public abstract class GenerateCode {

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

		public string GenerateInterfaceRepository(string nameSpace, Table table) {
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

		public string GenerateModelFrontend(Table table) {
			var text = "class {{className}} {" + Environment.NewLine;

			foreach (var column in table.Columns) {
				text += $"\t{column.PropertyName} : {ConvertTypeBdToTypeScript(column.DataType)}; " + Environment.NewLine + Environment.NewLine;
			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public abstract string ConvertTypeBdToCSharp(string typeBd);
		public abstract string ConvertTypeBdToTypeScript(string typeBd);
	}
}
