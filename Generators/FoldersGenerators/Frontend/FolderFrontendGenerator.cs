using Domain.Model.Table;
using Generators.Model.Backend;
using Utils;
using Utils.MethodsOfExtensions;

namespace Generators.FoldersGenerators.Frontend {
	public static class FolderFrontendGenerator {

		public static PathsFrontend GenerateFolderStructure(string destinationPath, BackendInfo backendInfo, Table table) {
			if (destinationPath == null || destinationPath.Trim().Length <= 0) {
				throw new Exception("The Destination Path is Required.");
			}

			if (table == null) {
				throw new Exception("The information for the table to generate is not loaded.");
			}

			if (!backendInfo.GenerateData) {
				return new PathsFrontend();
			}

			var path = destinationPath;

			FolderHelper.GenerateDirectory(path, Constants.FOLDER_GENERATED_CODE);
			var pathGeneratedCodeFolder = Path.Combine(destinationPath, Constants.FOLDER_GENERATED_CODE);

			FolderHelper.GenerateDirectory(pathGeneratedCodeFolder, Constants.FOLDER_FRONTEND);
			var pathFrontend = Path.Combine(pathGeneratedCodeFolder, Constants.FOLDER_FRONTEND);

			string pathTableFolder = string.Empty;
			string pathDomainFolder = string.Empty;

			if (table != null) {
				FolderHelper.GenerateDirectory(pathFrontend, table.Name.RemoveSpecialCharactersAndFormatText('_'));

				pathTableFolder = Path.Combine(pathFrontend, table.Name.RemoveSpecialCharactersAndFormatText('_'));

				FolderHelper.GenerateDirectory(pathTableFolder, Constants.FOLDER_DOMAIN);

				pathDomainFolder = Path.Combine(pathTableFolder, Constants.FOLDER_DOMAIN);
			}

			return new PathsFrontend(pathDomainFolder);

		}

	}
}
