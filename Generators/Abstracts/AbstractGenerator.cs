using CodeGenerator.MethodsOfExtensions;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators.Abstracts {
	public abstract class AbstractGenerator : GenerateCode {

		private const string FOLDER_GENERATED_CODE = "GeneratedCode";
		private const string FOLDER_DOMAIN = "Domain";
		private const string FOLDER_INFRASTRUCTURE = "Infrastructure";
		private const string FOLDER_PERSISTENCE = "Persistence";
		private const string FOLDER_SERVICES = "Services";

		public abstract void Generate(List<Table> tables);

		public abstract string GeneratePersistence(Table table);

		public void GenerateFolderStructure(string destinationPath, GeneratedFileInfo generatedInfo) {

			if (destinationPath == null || destinationPath.Trim().Length <= 0) {
				throw new Exception("The Destination Path is Required.");
			}

			if (generatedInfo == null) {
				throw new Exception("The information for the table to generate is not loaded.");
			}

			if (generatedInfo.HasInfo()) {
				throw new Exception("The model, persistence, or service layer has not been generated.");
			}

			var path = destinationPath;
			GenerateDirectory(destinationPath, FOLDER_GENERATED_CODE);

			var pathGeneratedCodeFolder = Path.Combine(destinationPath, FOLDER_GENERATED_CODE);

			GenerateDirectory(pathGeneratedCodeFolder, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

			var pathTableFolder = Path.Combine(pathGeneratedCodeFolder, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

			GenerateDirectory(pathTableFolder, FOLDER_DOMAIN);
			GenerateDirectory(pathTableFolder, FOLDER_INFRASTRUCTURE);

			var pathDomainFolder = Path.Combine(pathTableFolder, FOLDER_DOMAIN);
			var pathInfrastructureFolder = Path.Combine(pathTableFolder, FOLDER_INFRASTRUCTURE);

			GenerateDirectory(pathInfrastructureFolder, FOLDER_PERSISTENCE);
			GenerateDirectory(pathInfrastructureFolder, FOLDER_SERVICES);

			var pathPersistenceFolder = Path.Combine(pathInfrastructureFolder, FOLDER_PERSISTENCE);
			var pathServicesFolder = Path.Combine(pathInfrastructureFolder, FOLDER_SERVICES);

			var paths = new Paths(pathDomainFolder, pathPersistenceFolder, pathServicesFolder);

			GenerateFiles(paths, generatedInfo);
		}

		private void GenerateFiles(Paths paths, GeneratedFileInfo generatedInfo) {
			var pathFileDomain = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + ".cs");
			var pathFileDomainConstructor = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + "Constructors.cs");
			var pathFileService = Path.Combine(paths.PathServicesFolder, generatedInfo.Table.ClassName + "Service.cs");
			var pathFileRepository = Path.Combine(paths.PathPersistenceFolder, generatedInfo.Table.ClassName + "Repository.cs");

			GenerateFile(pathFileDomain, generatedInfo.Model);
			GenerateFile(pathFileDomainConstructor, generatedInfo.Constructor);
			GenerateFile(pathFileService, generatedInfo.Service);
			GenerateFile(pathFileRepository, generatedInfo.Persistence);
		}

		private void GenerateFile(string path, string text) {
			using (var fs = File.CreateText(path)) {
				fs.Write(text);
			}
		}

		private void GenerateDirectory(string destinationPath, string directoryName) {
			var path = Path.Combine(destinationPath, directoryName);
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}

	}

}

public abstract class GenerateCode {
	public string GenerateModel(Table table) {
		var text = "";

		text += "public partial class {{className}} {" + Environment.NewLine;

		foreach (var column in table.Columns) {
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
		text += "}";

		text = text.Replace("{{className}}", table.ClassName);

		return text;
	}

	public string GenerateService(Table table) {
		return "Empty Service";
	}

	public abstract string ConvertTypeBdToCSharp(string typeBd);
}


public class GeneratedFileInfo {
	public Table Table { get; set; }
	public string Model { get; set; }
	public string Constructor { get; set; }
	public string Service { get; set; }
	public string Persistence { get; set; }

	public GeneratedFileInfo(Table table, string model, string constructor, string service, string persistence) {
		Model = model;
		Constructor = constructor;
		Service = service;
		Persistence = persistence;
		Table = table;
	}

	public bool HasInfo() {
		return (Model != null && Model.Trim().Length <= 0) ||
			   (Constructor != null && Constructor.Trim().Length <= 0) ||
			   (Service != null && Service.Trim().Length <= 0) ||
			   (Persistence != null && Persistence.Trim().Length <= 0);
	}

}


public class Paths {
	public string PathDomainFolder { get; set; }
	public string PathPersistenceFolder { get; set; }
	public string PathServicesFolder { get; set; }

	public Paths(string pathDomainFolder, string pathPersistenceFolder, string pathServicesFolder) {
		PathDomainFolder = pathDomainFolder;
		PathPersistenceFolder = pathPersistenceFolder;
		PathServicesFolder = pathServicesFolder;
	}
}

