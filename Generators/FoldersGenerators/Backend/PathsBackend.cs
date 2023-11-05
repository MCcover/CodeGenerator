namespace Generators.FoldersGenerators.Backend {
	public class PathsBackend {
		public string PathDomainFolder { get; set; }
		public string PathPersistenceFolder { get; set; }
		public string PathServicesFolder { get; set; }
		public string PathInterfaces { get; set; }

		public PathsBackend() {
			PathDomainFolder =
			PathPersistenceFolder =
			PathServicesFolder =
			PathInterfaces = string.Empty;
		}

		public PathsBackend(string pathDomainFolder, string pathPersistenceFolder, string pathServicesFolder, string pathInterfaces) {
			PathDomainFolder = pathDomainFolder;
			PathPersistenceFolder = pathPersistenceFolder;
			PathServicesFolder = pathServicesFolder;
			PathInterfaces = pathInterfaces;
		}
	}
}
