using Domain.Model.Table;
using Generators.Model.Backend;
using Generators.Model.Frontend;

namespace Generators.Model.Generator {
	public class GeneratorInfo {
		public string Path { get; set; }
		public List<Table> Tables { get; set; }
		public FrontendInfo FrontendInfo { get; set; }
		public BackendInfo BackendInfo { get; set; }

		public GeneratorInfo(List<Table> tables, string path, FrontendInfo frontendInfo, BackendInfo backendInfo) {
			Tables = tables;
			Path = path;
			FrontendInfo = frontendInfo;
			BackendInfo = backendInfo;
		}
	}
}
