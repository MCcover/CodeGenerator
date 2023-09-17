using CodeGenerator.Generators.Generate.Generic;
using CodeGenerator.MethodsOfExtensions;
using CodeGenerator.Model.Table;

namespace CodeGenerator.Generators.Abstracts {
	public abstract class AbstractGenerator : GenerateCode {

		private const string FOLDER_GENERATED_CODE = "GeneratedCode";
		private const string FOLDER_DOMAIN = "Domain";
		private const string FOLDER_INFRASTRUCTURE = "Infrastructure";
		private const string FOLDER_PERSISTENCE = "Persistence";
		private const string FOLDER_SERVICES = "Services";
		private const string FOLDER_INTERFACES = "Interfaces";

		public void Generate(List<Table> tables, FilesToGenerate filesToGenerate, string path) {
			string model = "",
				   constructor = "",
				   service = "",
				   persistence = "";

			if (filesToGenerate.GenerateInterfaces) {
				var interfaces = GenerateInterfaces();
				GenerateFolderStructure(path, new GeneratedFileInfo(null, "", "", "", "", interfaces));
			}

			foreach (var table in tables) {
				model = "";
				constructor = "";
				service = "";
				persistence = "";

				if (filesToGenerate.GenerateModel) {
					model = GenerateModel(table);
				}

				if (filesToGenerate.GenerateConstructor) {
					constructor = GenerateConstructor(table);
				}

				if (filesToGenerate.GenerateService) {
					service = GenerateService(table);
				}

				if (filesToGenerate.GeneratePersistence) {
					persistence = GeneratePersistence(table);
				}

				GenerateFolderStructure(path, new GeneratedFileInfo(table, model, constructor, service, persistence, null));
			}


		}

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

			var pathInterfaces = "";
			if (generatedInfo.Interfaces != null) {
				GenerateDirectory(pathGeneratedCodeFolder, FOLDER_INTERFACES);
				pathInterfaces = Path.Combine(pathGeneratedCodeFolder, FOLDER_INTERFACES);
			}

			string pathTableFolder = string.Empty;
			string pathDomainFolder = string.Empty;
			string pathPersistenceFolder = string.Empty;
			string pathServicesFolder = string.Empty;

			if (generatedInfo.Table != null) {
				GenerateDirectory(pathGeneratedCodeFolder, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

				pathTableFolder = Path.Combine(pathGeneratedCodeFolder, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

				GenerateDirectory(pathTableFolder, FOLDER_DOMAIN);
				GenerateDirectory(pathTableFolder, FOLDER_INFRASTRUCTURE);

				pathDomainFolder = Path.Combine(pathTableFolder, FOLDER_DOMAIN);
				var pathInfrastructureFolder = Path.Combine(pathTableFolder, FOLDER_INFRASTRUCTURE);

				GenerateDirectory(pathInfrastructureFolder, FOLDER_PERSISTENCE);
				GenerateDirectory(pathInfrastructureFolder, FOLDER_SERVICES);

				pathPersistenceFolder = Path.Combine(pathInfrastructureFolder, FOLDER_PERSISTENCE);
				pathServicesFolder = Path.Combine(pathInfrastructureFolder, FOLDER_SERVICES);
			}

			var paths = new Paths(pathDomainFolder, pathPersistenceFolder, pathServicesFolder, pathInterfaces);

			GenerateFiles(paths, generatedInfo);
		}

		private void GenerateFiles(Paths paths, GeneratedFileInfo generatedInfo) {

			if (generatedInfo.Table != null) {
				var pathFileDomain = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + ".cs");
				var pathFileDomainConstructor = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + "Constructors.cs");
				var pathFileService = Path.Combine(paths.PathServicesFolder, generatedInfo.Table.ClassName + "Service.cs");
				var pathFileRepository = Path.Combine(paths.PathPersistenceFolder, generatedInfo.Table.ClassName + "Repository.cs");

				if (generatedInfo.Model != null && generatedInfo.Model.Trim() != string.Empty) {
					GenerateFile(pathFileDomain, generatedInfo.Model);
				}

				if (generatedInfo.Constructor != null && generatedInfo.Constructor.Trim() != string.Empty) {
					GenerateFile(pathFileDomainConstructor, generatedInfo.Constructor);
				}

				if (generatedInfo.Service != null && generatedInfo.Service.Trim() != string.Empty) {
					GenerateFile(pathFileService, generatedInfo.Service);
				}

				if (generatedInfo.Persistence != null && generatedInfo.Persistence.Trim() != string.Empty) {
					GenerateFile(pathFileRepository, generatedInfo.Persistence);
				}
			}

			if (generatedInfo.Interfaces != null) {
				var pathFileInterfaceAdd = Path.Combine(paths.PathInterfaces, "IAdd.cs");
				var pathFileInterfaceModify = Path.Combine(paths.PathInterfaces, "IModify.cs");
				var pathFileInterfaceDelete = Path.Combine(paths.PathInterfaces, "IDelete.cs");
				var pathFileInterfaceList = Path.Combine(paths.PathInterfaces, "IList.cs");
				var pathFileInterfaceExists = Path.Combine(paths.PathInterfaces, "IExists.cs");
				var pathFileInterfaceRepository = Path.Combine(paths.PathInterfaces, "IBaseRepository.cs");
				var pathFileInterfaceService = Path.Combine(paths.PathInterfaces, "IBaseService.cs");
				var pathFileInterfaceValidateData = Path.Combine(paths.PathInterfaces, "IValidateData.cs");

				GenerateFile(pathFileInterfaceAdd, generatedInfo.Interfaces.Add);
				GenerateFile(pathFileInterfaceModify, generatedInfo.Interfaces.Modify);
				GenerateFile(pathFileInterfaceDelete, generatedInfo.Interfaces.Delete);
				GenerateFile(pathFileInterfaceList, generatedInfo.Interfaces.List);
				GenerateFile(pathFileInterfaceExists, generatedInfo.Interfaces.Exists);
				GenerateFile(pathFileInterfaceRepository, generatedInfo.Interfaces.Repository);
				GenerateFile(pathFileInterfaceService, generatedInfo.Interfaces.Service);
				GenerateFile(pathFileInterfaceValidateData, generatedInfo.Interfaces.ValidateData);
			}

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

public class FilesToGenerate {
	public bool GenerateModel { get; set; }
	public bool GenerateConstructor { get; set; }
	public bool GenerateService { get; set; }
	public bool GeneratePersistence { get; set; }
	public bool GenerateInterfaces { get; set; }


	public FilesToGenerate(bool generateModel, bool generateConstructor, bool generateService, bool generatePersistence, bool generateInterfaces) {
		GenerateModel = generateModel;
		GenerateConstructor = generateConstructor;
		GenerateService = generateService;
		GeneratePersistence = generatePersistence;
		GenerateInterfaces = generateInterfaces;
	}
}

public class GeneratedFileInfo {
	public Table Table { get; set; }
	public string Model { get; set; }
	public string Constructor { get; set; }
	public string Service { get; set; }
	public string Persistence { get; set; }
	public GeneratedInterfaces Interfaces { get; set; }

	public GeneratedFileInfo(Table table, string model, string constructor, string service, string persistence, GeneratedInterfaces interfaces) {
		Model = model;
		Constructor = constructor;
		Service = service;
		Persistence = persistence;
		Table = table;
		Interfaces = interfaces;
	}

	public bool HasInfo() {
		bool hasModel = (Model != null && Model.Trim() != string.Empty);
		bool hasConstructor = (Constructor != null && Constructor.Trim() != string.Empty);
		bool hasService = (Service != null && Service.Trim() != string.Empty);
		bool hasPersistence = (Persistence != null && Persistence.Trim() != string.Empty);
		bool hasInterface = Interfaces != null;

		return !(hasModel ||
				 hasConstructor ||
				 hasService ||
				 hasPersistence ||
				 hasInterface);
	}

}

public class GeneratedInterfaces {
	public string Add { get; set; }
	public string Modify { get; set; }
	public string Delete { get; set; }
	public string List { get; set; }
	public string Exists { get; set; }
	public string ValidateData { get; set; }
	public string Service { get; set; }
	public string Repository { get; set; }

	public GeneratedInterfaces(string add,
							   string modify,
							   string delete,
							   string list,
							   string exists,
							   string validateData,
							   string service,
							   string repository) {
		Add = add;
		Modify = modify;
		Delete = delete;
		List = list;
		Exists = exists;
		ValidateData = validateData;
		Service = service;
		Repository = repository;
	}
}

public class Paths {
	public string PathDomainFolder { get; set; }
	public string PathPersistenceFolder { get; set; }
	public string PathServicesFolder { get; set; }
	public string PathInterfaces { get; set; }


	public Paths(string pathDomainFolder, string pathPersistenceFolder, string pathServicesFolder, string pathInterfaces) {
		PathDomainFolder = pathDomainFolder;
		PathPersistenceFolder = pathPersistenceFolder;
		PathServicesFolder = pathServicesFolder;
		PathInterfaces = pathInterfaces;
	}
}

