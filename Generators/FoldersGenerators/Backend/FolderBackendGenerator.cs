using Domain.Model.Table;
using Generators.Model.Backend;
using Utils;
using Utils.MethodsOfExtensions;

namespace Generators.FoldersGenerators.Backend {
	public static class FolderBackendGenerator {

		public static PathsBackend GenerateFolderStructure(string destinationPath, BackendInfo backendInfo, Table table) {
			if (destinationPath == null || destinationPath.Trim().Length <= 0) {
				throw new Exception("The Destination Path is Required.");
			}

			if (table == null) {
				throw new Exception("The information for the table to generate is not loaded.");
			}

			if (!backendInfo.GenerateData) {
				return new PathsBackend();
			}

			var path = destinationPath;

			FolderHelper.GenerateDirectory(path, Constants.FOLDER_GENERATED_CODE);
			var pathGeneratedCodeFolder = Path.Combine(destinationPath, Constants.FOLDER_GENERATED_CODE);

			FolderHelper.GenerateDirectory(pathGeneratedCodeFolder, Constants.FOLDER_BACKEND);
			var pathBackend = Path.Combine(pathGeneratedCodeFolder, Constants.FOLDER_BACKEND);

			var pathInterfaces = "";
			if (backendInfo.GenerateInterfaces) {
				FolderHelper.GenerateDirectory(pathBackend, Constants.FOLDER_INTERFACES);
				pathInterfaces = Path.Combine(pathBackend, Constants.FOLDER_INTERFACES);
			}

			string pathTableFolder = string.Empty;
			string pathDomainFolder = string.Empty;
			string pathPersistenceFolder = string.Empty;
			string pathServicesFolder = string.Empty;

			if (table != null) {
				FolderHelper.GenerateDirectory(pathBackend, table.Name.RemoveSpecialCharactersAndFormatText('_'));

				pathTableFolder = Path.Combine(pathBackend, table.Name.RemoveSpecialCharactersAndFormatText('_'));

				FolderHelper.GenerateDirectory(pathTableFolder, Constants.FOLDER_DOMAIN);
				FolderHelper.GenerateDirectory(pathTableFolder, Constants.FOLDER_INFRASTRUCTURE);

				pathDomainFolder = Path.Combine(pathTableFolder, Constants.FOLDER_DOMAIN);
				var pathInfrastructureFolder = Path.Combine(pathTableFolder, Constants.FOLDER_INFRASTRUCTURE);

				FolderHelper.GenerateDirectory(pathInfrastructureFolder, Constants.FOLDER_PERSISTENCE);
				FolderHelper.GenerateDirectory(pathInfrastructureFolder, Constants.FOLDER_SERVICES);

				pathPersistenceFolder = Path.Combine(pathInfrastructureFolder, Constants.FOLDER_PERSISTENCE);
				pathServicesFolder = Path.Combine(pathInfrastructureFolder, Constants.FOLDER_SERVICES);

			}

			var paths = new PathsBackend(pathDomainFolder, pathPersistenceFolder, pathServicesFolder, pathInterfaces);

			return paths;
		}

	}
}
