using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators.Generate.Generic {
	public abstract class GenerateCode {

		public string GenerateModel(Table table) {

			var noPk = table.Columns.Where(x => !x.Iskey).ToList();

			var text = "";

			text += "public partial class {{className}} : {{className}}Id {" + Environment.NewLine;

			foreach (var column in noPk) {
				text += $"\tpublic {ConvertTypeBdToCSharp(column.DataType)} {column.PropertyName} {{ get; set; }}" + Environment.NewLine + Environment.NewLine;
			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateModelPk(Table table) {

			var pk = table.Columns.Where(x => x.Iskey).ToList();

			var text = "";

			text += "public class {{className}}Id {" + Environment.NewLine;

			foreach (var column in pk) {
				text += $"\tpublic {ConvertTypeBdToCSharp(column.DataType)} {column.PropertyName} {{ get; set; }}" + Environment.NewLine + Environment.NewLine;
			}

			text += "}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public string GenerateConstructor(Table table) {
			var text = "";

			text += "public partial class {{className}} {" + Environment.NewLine;

			#region Empty Constructure

			text += "\tpublic {{className}}(){" + Environment.NewLine;

			foreach (var column in table.Columns) {
				text += $"\t\t{column.PropertyName} = default;" + Environment.NewLine;
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

		public string GenerateService(Table table) {
			var text = @"public class {{className}}Service : IBaseService<{{className}}, {{className}}Id> {
	private readonly IBaseRepository<{{className}}, {{className}}Id> _{{className}}Repository = null!;
	public {{className}}Service(IBaseRepository<{{className}}, {{className}}Id> {{className}}Repository) {
		_{{className}}Repository = {{className}}Repository;
	}

	public async Task<bool> Add({{className}} entity) {
		if (_{{className}}Repository.ValidateData(entity)) {
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
		if (id == 0) {
			throw new Exception(""{{className}} id is empty"");
		}
		return await _{{className}}Repository.Exists(id);
	}

	public List<{{className}}> GetAll() {
		return _{{className}}Repository.GetAll();
	}

	public async Task<{{className}}> GetById({{className}}Id id) {
		if (!await Exists(id)) {
			throw new Exception(""{{className}} id dosen't exists"");
		}
		return await _{{className}}Repository.GetById(id);
	}

	public async Task<bool> Modify({{className}} entity) {
		if (!await Exists(entity.{{className}}Id)) {
			throw new Exception(""{{className}} id is empty"");
		} else if (_{{className}}Repository.ValidateData(entity)) {
			return await _{{className}}Repository.Modify(entity);
		}
		return false;
	}
}";

			text = text.Replace("{{className}}", table.ClassName);

			return text;
		}

		public GeneratedInterfaces GenerateInterfaces() {
			string interfaceAdd = @"public interface IAdd<T> {
	Task<bool> Add (T entity);
}";
			string interfaceModify = @"public interface IModify<T> {
	Task<bool> Modify (T entity);
}";
			string interfaceDelete = @"public interface IDelete<I> {
	Task<bool> Delete (I id);
}";
			string interfaceList = @"public interface IList<T, I> {
	List<T> GetAll ();
	Task<T> GetById (I id);
}";
			string interfaceExists = @"public interface IExists<I> {
	Task<bool> Exists (I id);
}";
			string interfaceValidateData = @"public interface IValidateData<T> {
	bool ValidateData (T entity);
}";
			string interfaceService = @"public interface IBaseService<T, I> : IAdd<T>, IModify<T>, IDelete<I>, IList<T, I>, IExists<I> {
}";
			string interfaceRepository = @"public interface IBaseRepository<T, I> : IAdd<T>, IModify<T>, IDelete<I>, IList<T, I>, IExists<I>, IValidateData<T> {
}";

			return new GeneratedInterfaces(interfaceAdd, interfaceModify, interfaceDelete, interfaceList, interfaceExists, interfaceValidateData, interfaceService, interfaceRepository);
		}

		public abstract string ConvertTypeBdToCSharp(string typeBd);
	}
}
