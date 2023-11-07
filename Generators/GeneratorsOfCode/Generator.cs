using Domain.Model.Table;
using Generators.FoldersGenerators.Backend;
using Generators.FoldersGenerators.Frontend;
using Generators.Interfaces;
using Generators.Model.Backend;
using Generators.Model.Frontend;
using Generators.Model.Generator;
using System.Reflection;
using Utils;
using Utils.Attributes.Class;
using Utils.Attributes.Fields;
using Utils.Enums.Lenguages;

namespace Generators.GeneratorsOfCode {
	public class Generator : SingletonWrapper<Generator>, IGenericGenerator {

		private Generator() {

		}

		public void Generate(GeneratorInfo info) {
			var generators = SelectGenerators(info);

			foreach (var table in info.Tables) {
				var pathsBackend = FolderBackendGenerator.GenerateFolderStructure(info.Path, info.BackendInfo, table);
				var pathsFrontend = FolderFrontendGenerator.GenerateFolderStructure(info.Path, info.BackendInfo, table);

				info.BackendInfo.Paths = pathsBackend;
				info.FrontendInfo.Paths = pathsFrontend;

				GeneratedBackend backend = generators.backendGenerator?.Generate(info.BackendInfo, table);
				GeneratedFrontend frontend = generators.frontendGenerator?.Generate(info.FrontendInfo, table);

				GenerateFilesBackend(info, table, backend, pathsBackend);
				GenerateFilesFrontend(info, table, frontend, pathsFrontend);

			}

		}

		private (IBackendGenerator? backendGenerator, IFrontendGenerator? frontendGenerator) SelectGenerators(GeneratorInfo info) {
			IBackendGenerator? backendGenerator = null;
			IFrontendGenerator? frontendGenerator = null;

			if (info.BackendInfo != null) {

				Type? tipoClase = Assembly.GetExecutingAssembly()
										 .GetTypes()
										 .DefaultIfEmpty(null)
										 .FirstOrDefault(t => {
											 var lenguage = t?.GetCustomAttribute<LenguageBackendAttribute>()?.Value == info.BackendInfo.Lenguaje;
											 var database = t?.GetCustomAttribute<DatabaseAttribute>()?.Value == info.BackendInfo.Database;

											 return lenguage && database;
										 });


				if (tipoClase == null) {
					throw new Exception("no generator is defined for this backend language and database.");
				}

				backendGenerator = (IBackendGenerator?)Activator.CreateInstance(tipoClase) ?? throw new Exception("");
			}

			if (info.FrontendInfo != null) {
				Type? tipoClase = Assembly.GetExecutingAssembly()
										 .GetTypes()
										 .DefaultIfEmpty(null)
										 .FirstOrDefault(t => {
											 var lenguage = t?.GetCustomAttribute<LenguageFrontendAttribute>()?.Value == info.FrontendInfo.Lenguaje;

											 return lenguage;
										 });


				if (tipoClase == null) {
					throw new Exception("no generator is defined for this frontend language.");
				}

				frontendGenerator = (IFrontendGenerator?)Activator.CreateInstance(tipoClase) ?? throw new Exception("");

			}

			return (backendGenerator, frontendGenerator);
		}

		private static void GenerateFilesBackend(GeneratorInfo info, Table table, GeneratedBackend backend, PathsBackend pathsBackend) {
			var fileExtension = EnumHelper.GetAttributeValue<ExtensionFileAttribute, LenguagesBackend>(info.BackendInfo.Lenguaje).Value;

			var pathFileDomain = Path.Combine(pathsBackend.PathDomainFolder, table.ClassName + fileExtension);
			var pathFileDomainPk = Path.Combine(pathsBackend.PathDomainFolder, table.ClassName + "Id" + fileExtension);
			var pathFileDomainConstructor = Path.Combine(pathsBackend.PathDomainFolder, table.ClassName + "Constructors" + fileExtension);

			var pathFileService = Path.Combine(pathsBackend.PathServicesFolder, table.ClassName + "Service" + fileExtension);
			var pathFileInterfaceService = Path.Combine(pathsBackend.PathServicesFolder, "I" + table.ClassName + "Service" + fileExtension);

			var pathFileRepository = Path.Combine(pathsBackend.PathPersistenceFolder, table.ClassName + "Repository" + fileExtension);
			var pathFileInterfaceRepository = Path.Combine(pathsBackend.PathPersistenceFolder, "I" + table.ClassName + "Repository" + fileExtension);

			FileHelper.GenerateFile(pathFileDomain, backend.Model);
			FileHelper.GenerateFile(pathFileDomainPk, backend.ModelPk);
			FileHelper.GenerateFile(pathFileDomainConstructor, backend.Constructor);

			FileHelper.GenerateFile(pathFileService, backend.Service);
			FileHelper.GenerateFile(pathFileInterfaceService, backend.InterfaceService);

			FileHelper.GenerateFile(pathFileRepository, backend.Persistence);
			FileHelper.GenerateFile(pathFileInterfaceRepository, backend.InterfaceRepository);

			if (info.BackendInfo.GenerateInterfaces) {
				var pathFileInterfaceAdd = Path.Combine(pathsBackend.PathInterfaces, "IAdd" + fileExtension);
				var pathFileInterfaceModify = Path.Combine(pathsBackend.PathInterfaces, "IModify" + fileExtension);
				var pathFileInterfaceDelete = Path.Combine(pathsBackend.PathInterfaces, "IDelete" + fileExtension);
				var pathFileInterfaceList = Path.Combine(pathsBackend.PathInterfaces, "IList" + fileExtension);
				var pathFileInterfaceExists = Path.Combine(pathsBackend.PathInterfaces, "IExists" + fileExtension);
				var pathFileInterfaceRepositoryBase = Path.Combine(pathsBackend.PathInterfaces, "IBaseRepository" + fileExtension);
				var pathFileInterfaceServiceBase = Path.Combine(pathsBackend.PathInterfaces, "IBaseService" + fileExtension);
				var pathFileInterfaceValidateData = Path.Combine(pathsBackend.PathInterfaces, "IValidateData" + fileExtension);
				var pathFileInterfaceConnection = Path.Combine(pathsBackend.PathInterfaces, "IConnection" + fileExtension);

				FileHelper.GenerateFile(pathFileInterfaceAdd, backend.Interfaces.Add);
				FileHelper.GenerateFile(pathFileInterfaceModify, backend.Interfaces.Modify);
				FileHelper.GenerateFile(pathFileInterfaceDelete, backend.Interfaces.Delete);
				FileHelper.GenerateFile(pathFileInterfaceList, backend.Interfaces.List);
				FileHelper.GenerateFile(pathFileInterfaceExists, backend.Interfaces.Exists);
				FileHelper.GenerateFile(pathFileInterfaceRepositoryBase, backend.Interfaces.Repository);
				FileHelper.GenerateFile(pathFileInterfaceServiceBase, backend.Interfaces.Service);
				FileHelper.GenerateFile(pathFileInterfaceValidateData, backend.Interfaces.ValidateData);
				FileHelper.GenerateFile(pathFileInterfaceConnection, backend.Interfaces.Connection);
			}
		}

		private static void GenerateFilesFrontend(GeneratorInfo info, Table table, GeneratedFrontend frontend, PathsFrontend pathsFrontend) {
			var fileExtension = EnumHelper.GetAttributeValue<ExtensionFileAttribute, LenguagesFrontend>(info.FrontendInfo.Lenguaje).Value;

			var pathFileModelFrontend = Path.Combine(pathsFrontend.PathDomainFolder, table.ClassName + fileExtension);
			FileHelper.GenerateFile(pathFileModelFrontend, frontend.Model);
		}

	}
}
