using CodeGenerator.Generators.Generate.Generic;
using Domain.Model.Table;
using Utils.MethodsOfExtensions;

namespace CodeGenerator.Generators.Abstracts {
	public abstract class AbstractGenerator : GenerateCode {

		private const string FOLDER_GENERATED_CODE = "GeneratedCode";
		private const string FOLDER_DOMAIN = "Domain";
		private const string FOLDER_INFRASTRUCTURE = "Infrastructure";
		private const string FOLDER_PERSISTENCE = "Persistence";
		private const string FOLDER_SERVICES = "Services";
		private const string FOLDER_FRONTEND = "Frontend";
		private const string FOLDER_BACKEND = "Backend";
		private const string FOLDER_INTERFACES = "Interfaces";

		public void Generate(string projectName, List<Table> tables, FilesToGenerate filesToGenerate, string path) {
			string model = "",
				   modelPk = "",
				   constructor = "",
				   service = "",
				   persistence = "",
				   interfaceService = "",
				   interfaceRepository = "",
				   modelFrontend = "";

			if (filesToGenerate.Backend.GenerateInterfaces) {
				var nameSpace = projectName + ".Interfaces";
				var interfaces = GenerateInterfaces(nameSpace);

				var generatedInfo = new GeneratedFileInfo(null, interfaces);

				var paths = GenerateFolderStructure(path, generatedInfo);

				GenerateFiles(paths, generatedInfo);

			}

			foreach (var table in tables) {
				model = "";
				modelPk = "";
				constructor = "";
				service = "";
				persistence = "";
				interfaceService = "";
				interfaceRepository = "";
				modelFrontend = "";

				var generatedInfo = new GeneratedFileInfo(table, null);

				var paths = GenerateFolderStructure(path, generatedInfo);

				if (filesToGenerate.Backend.GenerateModel) {
					var nameSpace = projectName + "." + string.Join(".", paths.PathDomainFolder.Split("GeneratedCode")[1].Split('\\', StringSplitOptions.RemoveEmptyEntries));

					model = GenerateModel(nameSpace, table);
					modelPk = GenerateModelPk(nameSpace, table);
				}

				if (filesToGenerate.Backend.GenerateConstructor) {
					var nameSpace = projectName + "." + string.Join(".", paths.PathDomainFolder.Split("GeneratedCode")[1].Split('\\', StringSplitOptions.RemoveEmptyEntries));
					constructor = GenerateConstructor(nameSpace, table);
				}

				if (filesToGenerate.Backend.GenerateService) {
					var nameSpace = projectName + "." + string.Join(".", paths.PathServicesFolder.Split("GeneratedCode")[1].Split('\\', StringSplitOptions.RemoveEmptyEntries));
					service = GenerateService(nameSpace, table);

					interfaceService = GenerateInterfaceService(nameSpace, table);
					interfaceRepository = GenerateInterfaceRepository(nameSpace, table);
				}

				if (filesToGenerate.Backend.GeneratePersistence) {
					var nameSpace = projectName + "." + string.Join(".", paths.PathServicesFolder.Split("GeneratedCode")[1].Split('\\', StringSplitOptions.RemoveEmptyEntries));

					persistence = GeneratePersistence(nameSpace, table);
				}

				if (filesToGenerate.Frontend.GenerateModel) {
					modelFrontend = GenerateModelFrontend(table);
				}

				generatedInfo.SetData(model, modelPk, constructor, service, persistence, interfaceRepository, interfaceService, modelFrontend);

				GenerateFiles(paths, generatedInfo);
			}

		}

		public abstract string GeneratePersistence(string nameSpace, Table table);

		public Paths GenerateFolderStructure(string destinationPath, GeneratedFileInfo generatedInfo) {

			if (destinationPath == null || destinationPath.Trim().Length <= 0) {
				throw new Exception("The Destination Path is Required.");
			}

			if (generatedInfo == null) {
				throw new Exception("The information for the table to generate is not loaded.");
			}

			var path = destinationPath;
			GenerateDirectory(destinationPath, FOLDER_GENERATED_CODE);

			var pathGeneratedCodeFolder = Path.Combine(destinationPath, FOLDER_GENERATED_CODE);


			GenerateDirectory(pathGeneratedCodeFolder, FOLDER_BACKEND);
			var pathBackend = Path.Combine(pathGeneratedCodeFolder, FOLDER_BACKEND);

			var pathInterfaces = "";
			if (generatedInfo.Interfaces != null) {
				GenerateDirectory(pathBackend, FOLDER_INTERFACES);
				pathInterfaces = Path.Combine(pathBackend, FOLDER_INTERFACES);
			}

			string pathTableFolder = string.Empty;
			string pathDomainFolder = string.Empty;
			string pathPersistenceFolder = string.Empty;
			string pathServicesFolder = string.Empty;
			string pathFrontendFolder = string.Empty;

			if (generatedInfo.Table != null) {
				GenerateDirectory(pathBackend, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

				pathTableFolder = Path.Combine(pathBackend, generatedInfo.Table.Name.RemoveSpecialCharactersAndFormatText('_'));

				GenerateDirectory(pathTableFolder, FOLDER_DOMAIN);
				GenerateDirectory(pathTableFolder, FOLDER_INFRASTRUCTURE);

				pathDomainFolder = Path.Combine(pathTableFolder, FOLDER_DOMAIN);
				var pathInfrastructureFolder = Path.Combine(pathTableFolder, FOLDER_INFRASTRUCTURE);

				GenerateDirectory(pathInfrastructureFolder, FOLDER_PERSISTENCE);
				GenerateDirectory(pathInfrastructureFolder, FOLDER_SERVICES);

				pathPersistenceFolder = Path.Combine(pathInfrastructureFolder, FOLDER_PERSISTENCE);
				pathServicesFolder = Path.Combine(pathInfrastructureFolder, FOLDER_SERVICES);

				GenerateDirectory(pathGeneratedCodeFolder, FOLDER_FRONTEND);
				pathFrontendFolder = Path.Combine(pathGeneratedCodeFolder, FOLDER_FRONTEND);

			}

			var paths = new Paths(pathDomainFolder, pathPersistenceFolder, pathServicesFolder, pathInterfaces, pathFrontendFolder);

			return paths;
		}

		private void GenerateFiles(Paths paths, GeneratedFileInfo generatedInfo) {

			if (generatedInfo.Table != null) {
				if (generatedInfo.HasInfo()) {
					throw new Exception("The model, persistence, or service layer has not been generated.");
				}

				var pathFileDomain = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + ".cs");
				var pathFileDomainPk = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + "Id.cs");
				var pathFileDomainConstructor = Path.Combine(paths.PathDomainFolder, generatedInfo.Table.ClassName + "Constructors.cs");
				var pathFileService = Path.Combine(paths.PathServicesFolder, generatedInfo.Table.ClassName + "Service.cs");
				var pathFileRepository = Path.Combine(paths.PathPersistenceFolder, generatedInfo.Table.ClassName + "Repository.cs");

				var pathFileInterfaceService = Path.Combine(paths.PathServicesFolder, "I" + generatedInfo.Table.ClassName + "Service.cs");
				var pathFileInterfaceRepository = Path.Combine(paths.PathPersistenceFolder, "I" + generatedInfo.Table.ClassName + "Repository.cs");

				var pathFileModelFrontend = Path.Combine(paths.PathModelFrontend, generatedInfo.Table.ClassName + ".ts");

				if (generatedInfo.Model != null && generatedInfo.Model.Trim() != string.Empty) {
					GenerateFile(pathFileDomain, generatedInfo.Model);
				}

				if (generatedInfo.ModelPk != null && generatedInfo.ModelPk.Trim() != string.Empty) {
					GenerateFile(pathFileDomainPk, generatedInfo.ModelPk);
				}

				if (generatedInfo.Constructor != null && generatedInfo.Constructor.Trim() != string.Empty) {
					GenerateFile(pathFileDomainConstructor, generatedInfo.Constructor);
				}

				if (generatedInfo.Service != null && generatedInfo.Service.Trim() != string.Empty) {
					GenerateFile(pathFileService, generatedInfo.Service);
					GenerateFile(pathFileInterfaceService, generatedInfo.InterfaceService);
				}

				if (generatedInfo.Persistence != null && generatedInfo.Persistence.Trim() != string.Empty) {
					GenerateFile(pathFileRepository, generatedInfo.Persistence);
					GenerateFile(pathFileInterfaceRepository, generatedInfo.InterfaceRepository);
				}

				if (generatedInfo.ModelFrontend != null && generatedInfo.ModelFrontend.Trim() != string.Empty) {
					GenerateFile(pathFileModelFrontend, generatedInfo.ModelFrontend);
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
				var pathFileInterfaceConnection = Path.Combine(paths.PathInterfaces, "IConnection.cs");

				GenerateFile(pathFileInterfaceAdd, generatedInfo.Interfaces.Add);
				GenerateFile(pathFileInterfaceModify, generatedInfo.Interfaces.Modify);
				GenerateFile(pathFileInterfaceDelete, generatedInfo.Interfaces.Delete);
				GenerateFile(pathFileInterfaceList, generatedInfo.Interfaces.List);
				GenerateFile(pathFileInterfaceExists, generatedInfo.Interfaces.Exists);
				GenerateFile(pathFileInterfaceRepository, generatedInfo.Interfaces.Repository);
				GenerateFile(pathFileInterfaceService, generatedInfo.Interfaces.Service);
				GenerateFile(pathFileInterfaceValidateData, generatedInfo.Interfaces.ValidateData);
				GenerateFile(pathFileInterfaceConnection, generatedInfo.Interfaces.Connection);
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
	public FilesToGenerateBackend Backend { get; set; }
	public FilesToGenerateFrontend Frontend { get; set; }

	public FilesToGenerate(FilesToGenerateBackend backend, FilesToGenerateFrontend frontend) {
		Backend = backend;
		Frontend = frontend;
	}
}

public class FilesToGenerateBackend {
	public bool GenerateModel { get; set; }
	public bool GenerateConstructor { get; set; }
	public bool GenerateService { get; set; }
	public bool GeneratePersistence { get; set; }
	public bool GenerateInterfaces { get; set; }


	public FilesToGenerateBackend(bool generateModel, bool generateConstructor, bool generateService, bool generatePersistence, bool generateInterfaces) {
		GenerateModel = generateModel;
		GenerateConstructor = generateConstructor;
		GenerateService = generateService;
		GeneratePersistence = generatePersistence;
		GenerateInterfaces = generateInterfaces;
	}
}

public class FilesToGenerateFrontend {
	public bool GenerateModel { get; set; }

	public FilesToGenerateFrontend(bool generateModel) {
		GenerateModel = generateModel;
	}
}


public class GeneratedFileInfo {
	public Table Table { get; set; }
	public string Model { get; set; }
	public string ModelPk { get; set; }
	public string Constructor { get; set; }
	public string Service { get; set; }
	public string Persistence { get; set; }

	public string InterfaceRepository { get; set; }
	public string InterfaceService { get; set; }

	public string ModelFrontend { get; set; }


	public GeneratedInterfaces Interfaces { get; set; }

	public GeneratedFileInfo(Table table, GeneratedInterfaces interfaces) {
		Table = table;
		Interfaces = interfaces;
	}

	public void SetData(string model, string modelPk, string constructor, string service, string persistence, string interfaceRepository, string interfaceService, string modelFrontend) {
		Model = model;
		ModelPk = modelPk;
		Constructor = constructor;
		Service = service;
		Persistence = persistence;
		InterfaceRepository = interfaceRepository;
		InterfaceService = interfaceService;
		ModelFrontend = modelFrontend;
	}

	public bool HasInfo() {
		bool hasModel = (Model != null && Model.Trim() != string.Empty);
		bool hasModelPk = (ModelPk != null && ModelPk.Trim() != string.Empty);
		bool hasConstructor = (Constructor != null && Constructor.Trim() != string.Empty);
		bool hasService = (Service != null && Service.Trim() != string.Empty);
		bool hasPersistence = (Persistence != null && Persistence.Trim() != string.Empty);
		bool hasInterface = Interfaces != null;
		bool hasModelFrontend = (ModelFrontend != null && ModelFrontend.Trim() != string.Empty);

		return !(hasModel ||
				 hasModelPk ||
				 hasConstructor ||
				 hasService ||
				 hasPersistence ||
				 hasInterface ||
				 hasModelFrontend);
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
	public string Connection { get; set; }
	public GeneratedInterfaces(string add,
							   string modify,
							   string delete,
							   string list,
							   string exists,
							   string validateData,
							   string service,
							   string repository,
							   string connection) {
		Add = add;
		Modify = modify;
		Delete = delete;
		List = list;
		Exists = exists;
		ValidateData = validateData;
		Service = service;
		Repository = repository;
		Connection = connection;
	}
}

public class Paths {
	public string PathDomainFolder { get; set; }
	public string PathPersistenceFolder { get; set; }
	public string PathServicesFolder { get; set; }
	public string PathInterfaces { get; set; }
	public string PathModelFrontend { get; set; }



	public Paths(string pathDomainFolder, string pathPersistenceFolder, string pathServicesFolder, string pathInterfaces, string pathModelFrontend) {
		PathDomainFolder = pathDomainFolder;
		PathPersistenceFolder = pathPersistenceFolder;
		PathServicesFolder = pathServicesFolder;
		PathInterfaces = pathInterfaces;
		PathModelFrontend = pathModelFrontend;
	}
}

