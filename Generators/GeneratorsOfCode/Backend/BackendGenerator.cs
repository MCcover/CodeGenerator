using Generators.Interfaces;
using Generators.Model.Backend;
using Utils;

namespace Generators.GeneratorsOfCode.Backend {
	public class BackendGenerator : SingletonWrapper<BackendGenerator>, IGenerator<GeneratedBackend, BackendInfo> {

		private BackendGenerator() {

		}

		public GeneratedBackend Generate(BackendInfo info) {
			throw new NotImplementedException();
		}
	}
}
