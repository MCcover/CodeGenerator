namespace Generators.FoldersGenerators.Frontend {
	public class PathsFrontend {
		public string PathDomainFolder { get; set; }

		public PathsFrontend() {
			PathDomainFolder = string.Empty;
		}

		public PathsFrontend(string pathDomainFolder) {
			PathDomainFolder = pathDomainFolder;
		}
	}
}
